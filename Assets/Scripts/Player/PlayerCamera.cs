using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float speed;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
        //offset = transform.position - player.transform.position;
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, speed);
    }
}
