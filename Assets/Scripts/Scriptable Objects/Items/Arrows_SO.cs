using UnityEngine;

[CreateAssetMenu(fileName = "ArrowData", menuName = "Data/Arrows")]
public class Arrows_SO : ScriptableObject
{
    public string Name;
    public float Damage;
    public float AttackSpeed;
    public bool canAcross;
    public bool canRicochet;
    public bool canSplash;
}
 