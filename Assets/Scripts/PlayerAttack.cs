using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject BuletPref;
    [SerializeField]
    private float delayForShoot;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float impulse;
    [SerializeField]
    private GameObject[] massEnemys;

    public bool delayPerAttack = false;

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
            if (!Input.anyKey && LookAtEnemy() != null)
            {
                StartCoroutine(ChangeRotation());
                //StopCoroutine(ChangeRotation());

                //WaitForSeconds waitForSeconds = new WaitForSeconds(delayForShoot * 1.5f);
                GameObject bulet = GameObject.Instantiate(BuletPref, firePoint.position, Quaternion.identity);
                bulet.GetComponent<Rigidbody>().AddForce(firePoint.forward * impulse, ForceMode.Impulse);

                yield return waitForSeconds;
            }
            else
            {
                yield return null;
            }
        }
    }

    private IEnumerator ChangeRotation()
    {
        var enemyT = LookAtEnemy();
        var look_dir = (enemyT.position - firePoint.transform.position).normalized;
        look_dir.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(look_dir), 30);
        yield return new WaitForSeconds(delayForShoot);

    }

    //private GameObject[] GetEnemy()
    //{
    //    return GameObject.FindGameObjectsWithTag("Enemy");
    //}

    private Transform LookAtEnemy() // בכטחזאירודמ גנאדא
    {
        //massEnemys = GetEnemy();
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
        return enemy.transform;
    }
}
