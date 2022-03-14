using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Scr : MonoBehaviour
{
    private GameObject player;
    private PStatistics playerStatistics;
    private EStatistics healthEnemy;
    private float damage;
    private bool ricochet;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatistics = player.GetComponent<PStatistics>();
        damage = playerStatistics.damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            DamageEnemy(collision);
            Destroy(gameObject, .0001f);
        }
    }

    /// <summary>
    /// Метод для проверки, нанесения урона обьекту
    /// </summary>
    /// <param name="collision"></param>
    private void DamageEnemy(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") // Проверка если пуля попала в врага - отнимать хп
        {
            healthEnemy = collision.gameObject.GetComponent<EStatistics>();
            healthEnemy?.TakeDamage(damage);
            Destroy(gameObject, .0001f);
        }
        else
        {
            Destroy(gameObject, 0.001f);
        }
    }



    private void FixedUpdate()
    {
        Destroy(gameObject, 2f);
    }
}