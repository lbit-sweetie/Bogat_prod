using UnityEngine;

[CreateAssetMenu(fileName = "ArrowData", menuName = "Data/Arrows")]
public class Arrows_SO : ScriptableObject
{
    public string Name;
    public float Damage;
    public bool canRicochet;
    public bool canAcross;
    public float AttackSpeed;
}
 