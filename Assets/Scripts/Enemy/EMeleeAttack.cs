using System.Collections;
using UnityEngine;

public class EMeleeAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject BuletPref;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float impulse;

    private GameObject target;
    private WaitForSeconds waitForSeconds;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        waitForSeconds = new WaitForSeconds(1f);
        StartCoroutine(MeleeAttack_IEnum());
    }

    private IEnumerator MeleeAttack_IEnum() // ???????? ??????? ????? ????
    {
        while (true)
        {
            if (Vector3.Distance(target.transform.position, transform.position) <= 3.5f)
            {
                CreateAndShoot();
                yield return waitForSeconds;
            }
            else
            {
                yield return null;
            }
        }
    }

    private void CreateAndShoot()
    {
        transform.LookAt(target.transform.position);
        GameObject bullet = GameObject.Instantiate(BuletPref, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * impulse, ForceMode.Impulse);
    }
}