using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Data/Characters")]
public class PStatistics_SO : ScriptableObject // Тут будет храниться статистика игрока,
                                               // будем её менять в течении игры
{
    #region Статы

    [Header("Статы персонажа")]
    public int level = 1;
    public float health = 100;
    public float protection = 1;
    public float walkSpeed = 1;
    public float chanceCritDamage = 1;
    public float critDamage = 1;
    public bool secondChance;

    [Header("Статы оружия")]
    public float attackSpeed = 1;
    public float damage;
    public bool canAcross;
    public bool canRicochet;

    #endregion


    //[Header("Монеты и опыт на текущ сцене")]
    //[SerializeField]
    //private float curentCountExp;
    //[SerializeField]
    //private float curentCountMoney;

    //public void CollectExp(float count)
    //{
    //    curentCountExp += count;
    //}
    //public void CollectMoney(float count)
    //{
    //    curentCountMoney += count;
    //}


    #region Повышение параметров
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