using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemys")]
public class Enemy_SO : ScriptableObject
{
    [Header("Prop Enemy")]
    public int level = 1;
    public float health = 100;
    public float walkSpeed = 1;
    public float damage = 1;

    public GameObject buletPrefab;

    #region Upgrape prop
    public void LevelUp(int count)
    {
        level += count;
    }
    public void DamageUp(float count)
    {
        damage += count;
    }
    public void HealthUp(float count)
    {
        health += count;
    }
    public void SpeedUp(float count)
    {
        health += count;
    }
    #endregion
}
