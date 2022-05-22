using UnityEngine;

[CreateAssetMenu(fileName = "CurentStats", menuName = "Data/CurentStats")]
public class CurentStats_SO : ScriptableObject
{
    #region Prop haracter
    [Header("Prop haracter")]
    public int level;
    public float health;
    public float protection;
    public float walkSpeed;
    public float chanceCritDamage;
    public float critDamage;
    public bool secondChance = false;
    #endregion

    #region Prop arrows
    [Header("Prop arrows")]
    public float attackSpeed;
    public float damage;
    public bool canAcross;
    public bool canRicochet;
    public bool canSplash;
    #endregion

    public bool taked;
}
