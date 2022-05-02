using System.Collections;
using UnityEngine;

public class ERangedAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject BuletPref;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float impulse;
    private GameObject target;

    private Vector3 oldPosition;
    private WaitForSeconds waitForSeconds;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        oldPosition = transform.position;
        waitForSeconds = new WaitForSeconds(1f);
        StartCoroutine(Attack_IEnum());
    }

    private IEnumerator Attack_IEnum() 
    {
        while (true)
        {
            if (oldPosition == transform.position) 
            {
                CreateAndShoot();
                oldPosition = transform.position;
                yield return waitForSeconds;
            }
            else
            {
                oldPosition = transform.position;
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
