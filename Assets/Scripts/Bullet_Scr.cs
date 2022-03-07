using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Scr : MonoBehaviour
{
    //[SerializeField]
    //private float damage;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            //HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();
            //healthSystem?.TakeDamage(damage);
            Destroy(gameObject, .0001f);
        }
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 3f);
    }
}
