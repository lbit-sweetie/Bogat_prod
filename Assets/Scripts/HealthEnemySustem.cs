using UnityEngine;

public class HealthEnemySustem : MonoBehaviour
{
    [SerializeField]
    private float enemyHealth = 100f;
    [SerializeField]
    private float timeOfDestroy;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        amount = Mathf.Abs(amount);
        enemyHealth = Mathf.Clamp(enemyHealth - amount, 0, 100);
        if (enemyHealth <= 0)
        {
            Destroy(gameObject, timeOfDestroy);
        }
    }
}
