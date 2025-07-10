using System.Collections.Generic;
using UnityEngine;


//I'm sure I'm making this way more convoluted than it needs to be.
//I'll figure it out though LOL

public static class GameDictionary
{
    public static Dictionary<string, EnemyBehaviour> EnemyBehaviourDictionary;
    public static Dictionary<string, EnemyDefinition> EnemyDefinitionDictionary;
    public static Dictionary<string, BulletBehaviour> BulletBehaviourDictionary;
    public static Dictionary<string, BulletDefinition> BulletDefinitionDictionary;

    public static void ClearDictionaries()
    {

    }
}

[CreateAssetMenu(fileName = "EnemyDefinitionDictionary", menuName = "Dictionaries/Enemy/EnemyDefinitionDictionary")]
public class EnemyDefinitionDictionary : ScriptableObject
{
    public Dictionary<string, EnemyDefinition> dictionary = new Dictionary<string, EnemyDefinition>();
    private EnemyDefinition[] EnemyDefinitions;

    private void Awake()
    {
        for (int i = 0; i < EnemyDefinitions.Length; i++)
        {
            dictionary.Add(EnemyDefinitions[i].name, EnemyDefinitions[i]);
        }
        GameDictionary.EnemyDefinitionDictionary = dictionary;
        Debug.Log("EnemyDefinition Dictionary built.");
    }
}

[CreateAssetMenu(fileName = "EnemyBehaviourDictionary", menuName = "Dictionaries/Enemy/EnemyBehaviourDictionary")]
public class EnemyBehaviourDictionary : ScriptableObject
{
    public Dictionary<string, EnemyBehaviour> dictionary = new Dictionary<string, EnemyBehaviour>();
    private EnemyBehaviour[] EnemyBehaviours;

    private void Awake()
    {
        for (int i = 0; i < EnemyBehaviours.Length; i++)
        {
            dictionary.Add(EnemyBehaviours[i].name, EnemyBehaviours[i]);
        }
        GameDictionary.EnemyBehaviourDictionary = dictionary;
        Debug.Log("EnemyBehaviour Dictionary built.");
    }
}

[CreateAssetMenu(fileName = "BulletBehaviourDictionary", menuName = "Dictionaries/Bullets/BulletBehaviourDictionary")]
public class BulletBehaviourDictionary : ScriptableObject
{
    public Dictionary<string, BulletBehaviour> dictionary = new Dictionary<string, BulletBehaviour>();
    private BulletBehaviour[] BulletBehaviours;

    private void Awake()
    {
        for (int i = 0; i < BulletBehaviours.Length; i++)
        {
            dictionary.Add(BulletBehaviours[i].name, BulletBehaviours[i]);
        }
        GameDictionary.BulletBehaviourDictionary = dictionary;
        Debug.Log("BulletBehaviour Dictionary built.");
    }
}

[CreateAssetMenu(fileName = "BulletDefinitionDictionary", menuName = "Dictionaries/Bullets/BulletDefinitionDictionary")]
public class BulletDefinitionDictionary : ScriptableObject
{
    public Dictionary<string, BulletDefinition> dictionary = new Dictionary<string, BulletDefinition>();
    private BulletDefinition[] BulletDefinitions;

    private void Awake()
    {
        for (int i = 0; i < BulletDefinitions.Length; i++)
        {
            dictionary.Add(BulletDefinitions[i].name, BulletDefinitions[i]);
        }
        GameDictionary.BulletDefinitionDictionary = dictionary;
        Debug.Log("BulletDefinition Dictionary built.");
    }
}
