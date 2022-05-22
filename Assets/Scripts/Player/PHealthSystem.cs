using UnityEngine;

public class PHealthSystem : MonoBehaviour
{
    private float health;

    private PProperties pProperties;

    private void Start()
    {
        pProperties = GetComponent<PProperties>();
        health = pProperties.health;
    }

    public void TakeDamage(float amout)
    {
        health -= amout;
        if(health <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        if (pProperties.secondChance)
        {
            pProperties.secondChance = false;
            health = pProperties.GetHealthInSO();
        }
        else
        {
            PlayAgain();
        }
    }

    private void PlayAgain()
    {
        // Here need change SetActive canvas for death

    }
}
