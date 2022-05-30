using System.Collections;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject BuletPref;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float speedBulet;

    public float delayForShoot;
    private GameObject[] massEnemys;
    private WaitForSeconds waitForSeconds;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        waitForSeconds = new WaitForSeconds(3 - player.GetComponent<PProperties>().attackSpeed);
        massEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        StartCoroutine(Attack_IEnum());
    }

    private IEnumerator Attack_IEnum()
    {
        //waitForSeconds = new WaitForSeconds(delayForShoot);
        waitForSeconds = new WaitForSeconds(1 - player.GetComponent<PProperties>().attackSpeed * 0.1f);
        delayForShoot = 1 - player.GetComponent<PProperties>().attackSpeed * 0.3f;
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

    private void CreateAndShoot(Transform check)
    {
        var enemyT = check;
        transform.LookAt(enemyT.position);
        GameObject bulet = GameObject.Instantiate(BuletPref, firePoint.position, Quaternion.identity);
        bulet.GetComponent<Rigidbody>().AddForce(firePoint.forward * speedBulet, ForceMode.Impulse);
    }

    private Transform LookAtEnemy()
    {
        var min = 100f;
        float a;
        GameObject enemy = null;
        for (int i = 0; i < massEnemys.Length; i++)
        {
            if (massEnemys[i] != null)
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
