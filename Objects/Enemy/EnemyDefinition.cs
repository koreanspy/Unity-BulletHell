using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDefinition", menuName = "Enemy/EnemyDefinition")]
public class EnemyDefinition : ScriptableObject
{
    public string Name = "DEFAULT";
    public int Health = 0;
    public int Armor = 0;

    //public AnimatorController Animator;
}
