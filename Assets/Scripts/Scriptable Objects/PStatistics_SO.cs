using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Data/Characters")]
public class PStatistics_SO : ScriptableObject
{
    #region Prop

    [Header("Prop Haracters")]
    public int level = 1;
    public float health = 100;
    public float protection = 1;
    public float walkSpeed = 1;
    public float chanceCritDamage = 1;
    public float critDamage = 1;
    public bool secondChance;

    [Header("Prop Arrows")]
    public float attackSpeed = 1;
    public float damage;
    public bool canAcross;
    public bool canRicochet;

    #endregion


    #region Upgrade prop
    public void LevelUp()
    {
        level++;
        damage += 3;
        health += 10;
        protection += 2;
        critDamage += 1;
    }
    #endregion
}
