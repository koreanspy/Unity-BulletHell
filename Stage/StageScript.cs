using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "StageScript", menuName = "Stage/StageScript")]
public class StageScript : ScriptableObject
{
    public UnityEvent BossAppear;
    public UnityEvent StageFinish;

    public virtual void InitializeStage()
    {

    }

    //Write tasks to call waves or whatever /shrug
}
