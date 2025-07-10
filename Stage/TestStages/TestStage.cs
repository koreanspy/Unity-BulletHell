using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "TestStage", menuName = "Stage/TestStages/TestStage")]
public class TestStage : StageScript
{
    public override void InitializeStage()
    {
        Task.Run(() => { StageTask(); });
    }

    private async void StageTask()
    {
        Debug.Log("The stage has started.....");
        await Task.Delay(2000);
        EnemyPool.Instance.SpawnEnemy(Vector2.zero, null, null);
        BossAppear.Invoke();
        await Task.Delay(5000);
        StageFinish.Invoke();
        await Task.CompletedTask;
    }
}
