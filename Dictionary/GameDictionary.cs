using FMOD.Studio;
using FMODUnity;
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
    public static Dictionary<string, EventReference> SFXDictionary;
    public static Dictionary<string, EventReference> MusicDictionary;

    //Adding this just in case the awake method thing doesn't work
    //I'm probably going to call this manually anyway lol
    public static void SetupDictionary(
        Dictionary<string, EnemyBehaviour> _enemyBehaviour,
        Dictionary<string, EnemyDefinition> _enemyDefinition,
        Dictionary<string, BulletBehaviour> _bulletBehaviour,
        Dictionary<string, BulletDefinition> _bulletDefinition,
        Dictionary<string, EventReference> _sfxDictionary,
        Dictionary<string, EventReference> _musicDictionary)
    {
        EnemyBehaviourDictionary = _enemyBehaviour;
        EnemyDefinitionDictionary = _enemyDefinition;
        BulletBehaviourDictionary = _bulletBehaviour;
        BulletDefinitionDictionary = _bulletDefinition;
        MusicDictionary = _musicDictionary;
        SFXDictionary = _sfxDictionary;
    }

    public static void ClearDictionaries()
    {
        EnemyBehaviourDictionary = null;
        EnemyDefinitionDictionary = null;
        BulletBehaviourDictionary = null;
        BulletDefinitionDictionary = null;
        SFXDictionary = null;
        MusicDictionary = null;
    }
}

[CreateAssetMenu(fileName = "EnemyDefinitionDictionary", menuName = "Dictionaries/Enemy/EnemyDefinitionDictionary")]
public class EnemyDefinitionDictionary : ScriptableObject
{
    public Dictionary<string, EnemyDefinition> dictionary = new Dictionary<string, EnemyDefinition>();
    [SerializeField]private EnemyDefinition[] EnemyDefinitions;

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
    [SerializeField]private EnemyBehaviour[] EnemyBehaviours;

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
    [SerializeField]private BulletBehaviour[] BulletBehaviours;

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
    [SerializeField]private BulletDefinition[] BulletDefinitions;

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

[CreateAssetMenu(fileName = "SFXDictionary", menuName = "Dictionaries/SFXDictionary")]
public class SFXDictionary : ScriptableObject
{
    public Dictionary<string, EventReference> dictionary = new Dictionary<string, EventReference>();
    [field: SerializeField] private EventReference[] EventInstances;

    private void Awake()
    {
        for (int i = 0; i < EventInstances.Length; i++)
        {
            dictionary.Add(EventInstances[i].ToString(), EventInstances[i]);
        }
        GameDictionary.SFXDictionary = dictionary;
        Debug.Log("SFX Dictionary built.");
    }
}

[CreateAssetMenu(fileName = "MusicDictionary", menuName = "Dictionaries/MusicDictionary")]
public class MusicDictionary : ScriptableObject
{
    public Dictionary<string, EventReference> dictionary = new Dictionary<string, EventReference>();
    [field: SerializeField] private EventReference[] EventInstances;

    private void Awake()
    {
        for (int i = 0; i < EventInstances.Length; i++)
        {
            dictionary.Add(EventInstances[i].ToString(), EventInstances[i]);
        }
        GameDictionary.SFXDictionary = dictionary;
        Debug.Log("Music Dictionary built.");
    }
}

[CreateAssetMenu(fileName = "SFX", menuName = "Sound/SFX")]
public class SFX : ScriptableObject
{
    public string Name;
    public EventReference FMODReference;
}

[CreateAssetMenu(fileName = "Song", menuName = "Sound/Song")]
public class Song : ScriptableObject
{
    public string Title;
    public string Description;
    public EventReference FMODReference;
}