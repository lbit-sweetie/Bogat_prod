using UnityEngine;

[CreateAssetMenu(fileName = "ArrowData", menuName = "Data/Arrows")]
public class Arrows_SO : ScriptableObject
{
    public string name;
    public float damage;
    public float attackSpeed;
    public bool canAcross;
    public bool canRicochet;
    public bool canSplash;
}
 