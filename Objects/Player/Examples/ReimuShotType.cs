using UnityEngine;

[CreateAssetMenu(fileName = "ReimuShotType", menuName = "Reimu/ReimuShotType1")]
public class ReimuShotType : ShotType
{
    public override void Init(Player _player, int level)
    {
        base.Init(_player, level);

        EmitterAnchor = new GameObject("EmitterAnchor");
        EmitterAnchor.transform.parent = _player.EmitterWorkspace;
        Emitters = null;
        shootingCoroutine = null;
        /*if(Emitters.Length > 0)
        {
            for(int i = 0; i < Emitters.Length; i++)
            {
                Emitters[i] = null;
            }
        }*/
        ShotDelay = 0.2f;

        switch (level)
        {
            case 0:
                Emitters = new GameObject[1];
                for (int i = 0; i < 2; i++)
                {
                    Emitters[i] = Instantiate(EmitterPrefab);
                    Emitters[i].transform.parent = _player.EmitterWorkspace;
                }
                Emitters[0].transform.localPosition = Vector2.zero;
                break;
        }
    }
}
