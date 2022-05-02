using UnityEngine;

public class EProperties : MonoBehaviour
{
    [Header("Stats")]
    public int level;
    public float health;
    public float walkSpeed;
    public float damage;

    public GameObject buletPrefab;

    [Header("Place for assets enemys")]
    [SerializeField] private Enemy_SO[] enemys;
    public int indexEmemy;

    public void LevelUp()
    {
        level++;
    }
}
