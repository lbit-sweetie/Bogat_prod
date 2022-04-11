using UnityEngine;

public class EProperties : MonoBehaviour
{
    [Header("Статы")]
    public int level;
    public float health;
    public float walkSpeed;
    public float damage;

    public GameObject buletPrefab;

    [Header("Сюда кидать ассеты врагов")]
    [SerializeField] private Enemy_SO[] enemys;
    public int indexEmemy;

    public void LevelUp()
    {
        level++;
    }
}
