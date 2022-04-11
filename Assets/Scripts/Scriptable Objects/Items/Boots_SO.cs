using UnityEngine;

[CreateAssetMenu(fileName = "Boots", menuName = "Data/Boots")]
public class Boots_SO : ScriptableObject
{
    public string name = "Boots";
    public float protection = 1;
    public float healthUp = 1;
    public float speedUp = 1;
}