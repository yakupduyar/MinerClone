using UnityEngine;

[CreateAssetMenu(fileName = "Level Data",menuName = "ScriptableObjects/LevelData",order = 2)]
public class LevelData : ScriptableObject
{
    public OreData[] oresInLevel;
    [Range(0,1)]
    public float valuableChance;
}
