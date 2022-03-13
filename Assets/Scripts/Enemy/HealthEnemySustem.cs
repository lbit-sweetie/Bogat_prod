using UnityEngine;

public class HealthEnemySustem : MonoBehaviour
{
    [SerializeField]
    private float enemyHealth = 100f;
    [SerializeField]
    private float timeOfDestroy;

    private ItemDroping itemDroping;

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        itemDroping = player.GetComponent<ItemDroping>();
    }

    /// <summary>
    /// Наносит урон по обьекту на котором весит скрипт
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        amount = Mathf.Abs(amount);
        enemyHealth = Mathf.Clamp(enemyHealth - amount, 0, 100);
        if (enemyHealth <= 0)
        {
            Destroy(gameObject, timeOfDestroy);
            itemDroping.ItemDrop(transform);
        }
    }
}
