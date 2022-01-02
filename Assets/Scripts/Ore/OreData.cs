using UnityEngine;

[CreateAssetMenu(fileName = "Ore Data",menuName = "ScriptableObjects/OreData",order = 1)]
public class OreData : ScriptableObject
{
    public string oreName;
    public Color color;
    public int hitPoint;
    public float price;
}
