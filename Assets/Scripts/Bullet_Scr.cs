using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Scr : MonoBehaviour
{
    private GameObject player;
    private PlayerStatistics playerStatistics;
    private HealthEnemySustem healthEnemy;
    private float damage;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatistics = player.GetComponent<PlayerStatistics>();
        damage = playerStatistics.damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            //HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();
            //healthSystem?.TakeDamage(damage);
            if (collision.gameObject.tag == "Enemy")
            {
                healthEnemy = collision.gameObject.GetComponent<HealthEnemySustem>();
                healthEnemy?.TakeDamage(damage);
                Destroy(gameObject, .0001f);
            }
            else
            {
                Destroy(gameObject, 0.001f);
            }
            Destroy(gameObject, .0001f);
        }
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 2f);
    }
}
