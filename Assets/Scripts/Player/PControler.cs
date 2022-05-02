using UnityEngine;

public class PControler : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        speed = GetComponent<PProperties>().walkSpeed;
    }

    public void UpdateSpeed()
    {
        speed = GetComponent<PProperties>().walkSpeed;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.forward, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.back, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.left, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right, speed * Time.deltaTime);
        }
    }
}
