using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : Entity
{
    //Components
    private Player Instance;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRend;
    private CircleCollider2D collider;

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator deathAnimator;

    //Events
    public UnityEvent PlayerLevelUp;
    public UnityEvent PlayerDeath;


    //Inputs
    [SerializeField] private Inputs Controls;
    [SerializeField] private Vector2 inputVector;

    //Storage
    [SerializeField] private float Power;
    [SerializeField] private int CurrentLevel;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int BombCount;
    [SerializeField] private ShotType currentShottype;
    [SerializeField] private ShotType[] shottypes;
    [SerializeField] public Transform EmitterWorkspace;

    //Bool conditions
    [SerializeField] public bool isShooting { get; private set; }
    [SerializeField]public bool isSlow { get; private set; }
    [SerializeField]private bool bombCooldown = false;
    private bool isDead = false;
    
    private void Awake()
    {
        Instance = this;
        Controls = InputSys.Instance.Controls;
        Controls.InGame.Bomb.performed += Bomb_performed;
        //Controls.InGame.Shoot.performed += Shoot_performed;
        Controls.InGame.Shoot.started += Shoot_performed;
        Controls.InGame.Shoot.canceled += Shoot_cancelled;
        Health = 3;
        BombCount = 3;
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        collider = GetComponent<CircleCollider2D>();
        deathAnimator.StopPlayback();
        currentShottype?.Init(this, 1);
    }

    void Start()
    {
        
    }

    //Please just handle inputs through update I BEG OF YOU
    void Update()
    {
        ProcessInputs();

        playerAnimator.SetBool("isLeft", inputVector.x < 0);
        playerAnimator.SetBool("isRight", inputVector.x > 0);
        playerAnimator.SetBool("isSlow", isSlow);

        currentShottype?.CardUpdate();

        moveSpeed = isSlow ? 4.75f : 9f;

        rb.linearVelocity = inputVector * moveSpeed;
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.75f, 7.75f), Mathf.Clamp(transform.position.y, -8.5f, 8.5f));
    }

    public void ProcessInputs() 
    {
        isShooting = Controls.InGame.Shoot.IsPressed();
        isSlow = Controls.InGame.Slow.IsPressed();
        /*inputVector = new Vector2(Controls.InGame.Left.ReadValue<float>() + Controls.InGame.Right.ReadValue<float>(), Controls.InGame.Up.ReadValue<float>() + Controls.InGame.Down.ReadValue<float>()).normalized;
        if(Controls.InGame.Left.ReadValue<float>() == -1 && Controls.InGame.Right.ReadValue<float>() == 1) { inputVector = new Vector2(-1 ,inputVector.y).normalized; }
        if(Controls.InGame.Up.ReadValue<float>() == 1 && Controls.InGame.Down.ReadValue<float>() == -1) { inputVector = new Vector2(inputVector.x, -1).normalized; }
        */
        float horizontal = Controls.InGame.Left.ReadValue<float>() == -1 ? -1 :
                   Controls.InGame.Right.ReadValue<float>() == 1 ? 1 : 0;

        float vertical = Controls.InGame.Down.ReadValue<float>() == -1 ? -1 :
                   Controls.InGame.Up.ReadValue<float>() == 1 ? 1 : 0;

        inputVector = new Vector2 (horizontal, vertical).normalized;
    }

    public override void Damage(int _damage)
    {
        if(isDead) return;
        isDead = true;
        base.Damage(_damage);
        Power = Mathf.FloorToInt(Power) - 1;
        CheckPowerLevel();
        collider.enabled = false;
        spriteRend.enabled = false;
        Controls.InGame.Disable();
        deathAnimator.gameObject.transform.parent = null;
        deathAnimator.StopPlayback();
        deathAnimator.Play("Init");
        StartCoroutine(RespawnCoro());
    }

    private async void Bomb_performed(InputAction.CallbackContext obj)
    {
        if (bombCooldown) { return; }
        bombCooldown = true;
        BombCount--;
        Debug.Log("Log BOMB");
        await Task.Delay(2000);
        bombCooldown = false;
    }


    // Fix a bug here where if you spam shoot, it just freezes up
    // This may be an issue with the shot type logic itself
    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        currentShottype?.Fire();
    }
    private void Shoot_cancelled(InputAction.CallbackContext context)
    {
        currentShottype?.StopFire();
    }

    public void GivePower(float p)
    {
        Power = Mathf.Clamp(Power + p, 1, 4);
        CheckPowerLevel();
    }

    //Only check power level on gaining new power items
    private void CheckPowerLevel()
    {
        int newLevel = Mathf.FloorToInt(Power);

        if (newLevel > CurrentLevel)
        {
            for (int i = CurrentLevel + 1; i <= newLevel; i++)
            {
                LevelUp(i);
            }
            CurrentLevel = newLevel;
        }
        else if (newLevel < CurrentLevel)
        {
            CurrentLevel = newLevel;
        }
    }

    private void LevelUp(int level)
    {
        Debug.Log("Leveled up to: " + level);
        PlayerLevelUp?.Invoke();
        currentShottype.Init(this, level);
    }

    private IEnumerator RespawnCoro()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRend.enabled = true;
        transform.position = new Vector3(0,-9.5f,0);
        while(transform.position.y <= -7.5)
        {
            rb.linearVelocity = new Vector2(0,3f);
            yield return null;
        }
        Controls.InGame.Enable();
        yield return new WaitForSeconds(0.2f);
        deathAnimator.transform.parent = transform;
        deathAnimator.transform.localPosition = Vector3.zero;
        yield return new WaitForSeconds(2f);
        collider.enabled = true;
        isDead = false;
        yield return null;
    }

    //Couldn't get tasks to work, maybe I'm dumb /shrug
    private async void RespawnTask()
    {
        await Task.Delay(150);
        spriteRend.enabled = true;
        transform.position = new Vector3(0, -9.5f, 0);
        while (transform.position.y <= -7.5)
        {
            rb.linearVelocity = new Vector2(0, 1f);
        }
        Controls.InGame.Enable();
        await Task.Delay(2000);
        collider.enabled = true;
        await Task.CompletedTask;
    }
}
