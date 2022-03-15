using UnityEngine;

public class EStatistics : MonoBehaviour
{
    [SerializeField]
    public float damage = 1;
    [SerializeField]
    public float health = 100;
    [SerializeField]
    public float protection = 1;
    [SerializeField]
    public float attackSpeed = 1;
    [SerializeField]
    public float walkSpeed = 1;
    [SerializeField]
    private float timeOfDestroy;
    private ItemDroping itemDroping;

    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        itemDroping = player.GetComponent<ItemDroping>();
    }

    public void TakeDamage(float amount)
    {
        amount = Mathf.Abs(amount);
        health = Mathf.Clamp(health - amount, 0, 100);
        if (health <= 0)
        {
            Destroy(gameObject, timeOfDestroy);
            itemDroping.ItemDrop(transform);
        }
    }
}