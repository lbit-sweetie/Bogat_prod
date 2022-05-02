using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject BuletPref;
    [SerializeField]
    private float delayForShoot;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float speedBulet;

    private GameObject[] massEnemys;

    private WaitForSeconds waitForSeconds;

    void Start()
    {
        waitForSeconds = new WaitForSeconds(delayForShoot);
        massEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        StartCoroutine(Attack_IEnum());
    }

    private IEnumerator Attack_IEnum()
    {
        while (true)
        {
            var check = LookAtEnemy();
            if (!Input.anyKey && check != null)
            {
                CreateAndShoot(check);

                yield return waitForSeconds;
            }
            else
            {
                yield return null;
            }
        }
    }

    /// <summary>
    /// Create and push bulet
    /// </summary>
    private void CreateAndShoot(Transform check)
    {
        var enemyT = check;
        transform.LookAt(enemyT.position);
        GameObject bulet = GameObject.Instantiate(BuletPref, firePoint.position, Quaternion.identity);
        bulet.GetComponent<Rigidbody>().AddForce(firePoint.forward * speedBulet, ForceMode.Impulse);
    }

    /// <summary>
    /// Find near enemy
    /// </summary>
    /// <returns>Transform near enemy</returns>
    private Transform LookAtEnemy()
    {
        var min = 100f;
        float a;
        GameObject enemy = null;
        for (int i = 0; i < massEnemys.Length; i++)
        {
            if(massEnemys[i] != null)
            {
                a = Vector3.Distance(massEnemys[i].transform.position, firePoint.transform.position);
                if (a < min)
                {
                    min = a;
                    enemy = massEnemys[i];
                }
            }
        }

        return enemy == null ? null : enemy.transform;
    }
}
