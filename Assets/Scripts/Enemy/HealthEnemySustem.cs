using UnityEngine;

public class HealthEnemySustem : MonoBehaviour
{
    [SerializeField]
    private float enemyHealth = 100f;
    [SerializeField]
    private float timeOfDestroy;

    private GameMechanic gameMechanic;

    private void Start()
    {
        //gameMechanic = GameObject.FindGameObjectWithTag("Finish").GetComponent<GameMechanic>();
        //enemyHealth = ((gameMechanic.currentChapter == 0 ? 1 : gameMechanic.currentChapter) * 
            //(gameMechanic.curentLocation == 0 ? 1 : gameMechanic.curentLocation)) + 100;
    }

    public void TakeDamage(float amount)
    {
        enemyHealth = Mathf.Clamp(enemyHealth - amount, 0, enemyHealth);
        if (enemyHealth <= 0)
        {
            Destroy(gameObject, timeOfDestroy);
        }
    }
}
