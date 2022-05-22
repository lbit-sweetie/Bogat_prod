using System.Collections.Generic;
using UnityEngine;

public class Bullet_Scr : MonoBehaviour
{
    #region Prop
    private GameObject player;
    private PProperties playerStatistics;
    private HealthEnemySustem healthEnemy;

    private float damage;
    public bool canRicochet;
    public bool canAcross;
    public bool canSplash;
    public float distanceForSplash;

    private GameObject[] massEnemys;
    private Rigidbody rb;
    #endregion 

    private void Awake()
    {
        TakeProp();
    }
    void Start()
    {
        massEnemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            DamageEnemyColision(collision);
        }
    }
    private void OnTriggerEnter(Collider triger)
    {
        if (triger != null)
        {
            DamageEnemyColider(triger);
        }
    }
    private void DamageEnemyColider(Collider colider)
    {
        switch (colider.gameObject.tag)
        {
            case "Player":
                Del();
                break;
            case "Enemy":
                AttackEnemy(colider);
                break;
            case "Wall":
                Del();
                break;
            case "Other":
                Del();
                break;
            case "Bulet":
                Del();
                break;
        }
    }
    private void DamageEnemyColision(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                Del();
                break;
            case "Enemy":
                AttackEnemy(collision);
                break;
            case "Wall":
                Ricochet(collision);
                break;
            case "Other":
                Del();
                break;
            case "Bulet":
                Del();
                break;
        }
    }

    private void AcrossAttack()
    {
        if (canAcross)
        {
            if (damage >= 0)
                damage -= damage * 0.4f;
            damage = Mathf.Round(damage);
        }
        else
        {
            Del();
        }
    }
    private void Ricochet(Collision collision)
    {
        if (canRicochet)
        {
            rb.velocity = Vector3.Reflect(-collision.relativeVelocity.normalized, collision.contacts[0].normal) * 30;
        }
        else
        {
            Del();
        }
    }
    private void AttackEnemy(Collider colider)
    {
        healthEnemy = colider.gameObject.GetComponent<HealthEnemySustem>();
        healthEnemy?.TakeDamage(damage);
        SplashAttack(colider);
        AcrossAttack();
    }
    private void AttackEnemy(Collision collision)
    {
        healthEnemy = collision.gameObject.GetComponent<HealthEnemySustem>();
        healthEnemy?.TakeDamage(damage);
        SplashAttack(collision);
        AcrossAttack();
    }
    private void SplashAttack(Collider colider)
    {
        if (canSplash)
        {
            var masNearEnemy = NearEnemy(colider.gameObject, distanceForSplash);
            if (masNearEnemy.Length == 1)
                return;
            foreach (var e in masNearEnemy)
            {
                if (e == colider.gameObject)
                    return;
                healthEnemy = e.GetComponent<HealthEnemySustem>();
                healthEnemy?.TakeDamage(damage - (damage * 0.5f));
            }
            masNearEnemy = null;
        }
    }
    private void SplashAttack(Collision collision)
    {
        if (canSplash)
        {
            var masNearEnemy = NearEnemy(collision.gameObject, distanceForSplash);
            if (masNearEnemy.Length == 1)
                return;
            foreach (var e in masNearEnemy)
            {
                if (e == collision.gameObject)
                    return;
                healthEnemy = e.GetComponent<HealthEnemySustem>();
                healthEnemy?.TakeDamage(damage - (damage * 0.5f));
            }
            masNearEnemy = null;
        }
    }
    private void TakeProp()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatistics = player.GetComponent<PProperties>();
        rb = GetComponent<Rigidbody>();

        canRicochet = playerStatistics.canRicochet;
        canAcross = playerStatistics.canAcross;
        damage = playerStatistics.damage;
        canSplash = playerStatistics.canSplash;
    }
    private void Del()
    {
        Destroy(gameObject);
    }
    private GameObject[] NearEnemy(GameObject hitObj, float distance)
    {
        List<GameObject> outputMas = new List<GameObject>();
        var min = 100f;
        float a;
        for (int i = 0; i < massEnemys.Length; i++)
        {
            if (massEnemys[i] != null)
            {
                a = Vector3.Distance(massEnemys[i].transform.position, hitObj.transform.position);
                if (a <= distance)
                    outputMas.Add(massEnemys[i]);
            }
        }

        if (outputMas != null)
            return outputMas.ToArray();
        else
            return null;
    }
    private void FixedUpdate()
    {
        Destroy(gameObject, 2.5f);
    }
}
