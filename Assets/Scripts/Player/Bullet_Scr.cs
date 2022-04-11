using UnityEngine;

public class Bullet_Scr : MonoBehaviour
{
    #region Свойства
    private GameObject player;
    private PProperties playerStatistics;
    private HealthEnemySustem healthEnemy;

    private float damage;
    public bool canRicochet;
    public bool canAcross;

    private Rigidbody rb;
    #endregion 

    private void Awake()
    {
        TakeProp();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            DamageEnemyColision(collision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            DamageEnemyColider(other);
        }
    }

    /// <summary>
    /// Метод для проверки, нанесения урона обьекту
    /// </summary>
    /// <param name="colider"></param>
    private void DamageEnemyColider(Collider colider)
    {
        if (colider.gameObject.tag == "Enemy") // Проверка если пуля попала в врага - отнимать хп
        {
            healthEnemy = colider.gameObject.GetComponent<HealthEnemySustem>();
            healthEnemy?.TakeDamage(damage);
            if (!canAcross/* && colider.gameObject.tag != "Coin"*/)
            {
                Delete();
            }
        }

        //if (colider.gameObject.tag == "Wall")
        //{
        //    if (canRicochet)
        //    {
        //        //rb.velocity = Vector3.Reflect(-collision.relativeVelocity.normalized, collision.contacts[0].normal) * 10;
        //    }
        //    else
        //    {
        //        Delete();
        //    }
        //}
        //else
        //{
        //    if (colider.gameObject.tag == "Bulet")
        //        Delete();
        //    else
        //    {
        //        if (colider.gameObject.tag != "Coin")
        //        {
        //            Delete();
        //        }
        //    }
        //}
    }
    private void DamageEnemyColision(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") // Проверка если пуля попала в врага - отнимать хп
        {
            healthEnemy = collision.gameObject.GetComponent<HealthEnemySustem>();
            healthEnemy?.TakeDamage(damage);
            if (!canAcross/* && colider.gameObject.tag != "Coin"*/)
            {
                Delete();
            }
            return;
        }

        if (collision.gameObject.tag == "Wall")
        {
            if (canRicochet)
            {
                rb.velocity = Vector3.Reflect(-collision.relativeVelocity.normalized, collision.contacts[0].normal) * 10;
            }
            else
            {
                Delete();
            }
        }
        else
        {
            if (collision.gameObject.tag == "Bulet")
                Delete();
            else
            {
                if (collision.gameObject.tag != "Coin")
                {
                    Delete();
                }
            }
        }
    }

    private void TakeProp()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatistics = player.GetComponent<PProperties>();

        canRicochet = playerStatistics.canRicochet;
        canAcross = playerStatistics.canAcross;
        rb = GetComponent<Rigidbody>();

        damage = playerStatistics.damage;

        //if (canAcross)
        //{
        //    gameObject.GetComponent<SphereCollider>().isTrigger = true;
        //}
        //else
        //{
        //    gameObject.GetComponent<SphereCollider>().isTrigger = false;
        //}

        //if (canRicochet)
        //{
        //    gameObject.GetComponent<SphereCollider>().isTrigger = true;
        //}
        //else
        //{
        //    gameObject.GetComponent<SphereCollider>().isTrigger = false;
        //}
    }

    private void Delete()
    {
        Destroy(gameObject, 0.001f);
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 2f);
    }
}