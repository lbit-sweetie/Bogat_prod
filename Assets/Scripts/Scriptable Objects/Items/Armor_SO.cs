using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Data/Armors")]
public class Armor_SO : ScriptableObject
{
    public string name = "Armor";
    public float protection = 1;
    public float speedUp = 0;
}