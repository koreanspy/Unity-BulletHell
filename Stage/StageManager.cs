using UnityEngine;

public class StageManager : MonoBehaviour
{
    // omg is that a singleton,.......
    public static StageManager Instance;

    [SerializeField] private StageScript StageScript;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        //These are only here for testing purposes, will be removed laters
        StageScript.BossAppear.AddListener(BossAppear);
        StageScript.StageFinish.AddListener(StageEnd);

        StageScript.InitializeStage();
    }

    void BossAppear()
    {
        Debug.Log("The boss has appeared!!!!!!!!!!!!");
    }

    void StageEnd()
    {
        Debug.Log("The stage has been finished!!!!!!!!!!!");
    }
}
