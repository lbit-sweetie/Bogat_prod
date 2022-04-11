using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Data/Characters")]
public class PStatistics_SO : ScriptableObject // Тут будет храниться статистика игрока, будем её менять в течении игры
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
    }
    public void DamageUp()
    {
        damage += (level * 2);
    }
    public void HealthUp()
    {
        health += (level * 5);
    }
    public void SpeedUp()
    {
        walkSpeed += 0.5f;
    }
    public void ProtectionUp()
    {
        protection += 5;
    }
    public void ChanceCritDamageUp()
    {
        chanceCritDamage += 1;
    }

    public void CritDamageUp()
    {
        critDamage += 1;
    }
    #endregion
}