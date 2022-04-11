using UnityEngine;

public class PControler : MonoBehaviour
{
    public float speed;


    //private PProperties stats;

    //private Vector3 dir;

    //private Vector3 lerpMovement;
    //private Vector3 movement;

    //[SerializeField]
    //private float smooth;

    //private CharacterController characterController;
    //private void Awake()
    //{
    //    characterController = GetComponent<CharacterController>();
    //}

    private void Start()
    {
        speed = GetComponent<PProperties>().walkSpeed;
    }
    void Update()
    {
        //float vertical = Input.GetAxis("Vertical");
        //float horizontal = Input.GetAxis("Horizontal");

        //Vector3 forward = -Vector3.forward * vertical;
        //Vector3 direction = -Vector3.right * horizontal;
        //movement = (forward + direction) * speed;

        //lerpMovement = Vector3.Lerp(lerpMovement, movement, speed * Time.deltaTime);

        //if (Input.anyKey)
        //    transform.LookAt(lerpMovement);

        //characterController.Move(lerpMovement * Time.deltaTime);


        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.back, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.forward, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.left, speed * Time.deltaTime);
        }

        //transform.position = Vector3.Lerp(transform.position, dir, speed * Time.deltaTime);
        //transform.LookAt(dir);


        //lerpMovement = Vector3.Lerp(lerpMovement, dir, speed);

        //characterController.Move(lerpMovement * Time.deltaTime);
        //dir = Vector3.zero;
    }
}
