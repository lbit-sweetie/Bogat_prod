using UnityEngine;
using UnityEngine.SceneManagement;

public class PControler : MonoBehaviour
{
    public float speed;
    private CharacterController characterController;
    private Vector3 lerpMovement;
    private float lerpHeight;
    private float height;
    private void Start()
    {
        speed = GetComponent<PProperties>().walkSpeed;
        characterController = GetComponent<CharacterController>();
    }

    public void UpdateSpeed()
    {
        speed = GetComponent<PProperties>().walkSpeed;
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(Vector3.right);
        }
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 forward = transform.forward * vertical;
        Vector3 direction = transform.right * horizontal;
        var movement = (forward + direction) * speed;

        lerpMovement = Vector3.Lerp(lerpMovement, movement, 5000);
        lerpHeight = Mathf.Lerp(lerpHeight, height, 5000);
        lerpMovement.y = lerpHeight;

        characterController.Move(lerpMovement * Time.deltaTime);
    }
}
