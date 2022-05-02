using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScr : MonoBehaviour
{
    float a = 0;
    public float amplitude = 1000;
    public float speed = 1000;

    void FixedUpdate()
    {

        transform.position = new Vector3(Mathf.Sin(a / speed) * amplitude, transform.position.y, transform.position.z);
        a++;
        if(a >= 1000000)
            a = 0;
    }
}
