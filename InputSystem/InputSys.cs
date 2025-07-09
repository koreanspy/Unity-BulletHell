using UnityEngine;

public class InputSys : MonoBehaviour
{
    //So that we can use this inbetween games, and unify an "Engine" between them
    //Only bind Inputs to actions WITHIN the game, not in the inputsystem.
    public static InputSys Instance;
    public Inputs Controls;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        Controls = new Inputs();
        Controls.Enable();
        Controls.InGame.Enable();
        Controls.Menus.Enable();
    }
}
