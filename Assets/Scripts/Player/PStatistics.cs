using UnityEngine;

public class PStatistics : MonoBehaviour // Тут будет храниться статистика игрока, будем её менять в течении игры
{
    public int level = 1;
    public float damage = 1;
    public float health = 100;
    public float protection = 1;
    public float attackSpeed = 1;
    public float walkSpeed = 1;
    public float chanceCritDamage = 1;
    public float critDamage = 1;

    [Space]

    [SerializeField]
    private float curentCountExp;
    [SerializeField]
    private float curentCountMoney;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CollectExp(float count)
    {
        curentCountExp += count;
    }
    public void CollectMoney(float count)
    {
        curentCountMoney += count;
    }


    public void LevelUp()
    {
        level++;
    }
}
