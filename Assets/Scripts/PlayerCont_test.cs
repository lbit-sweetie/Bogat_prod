//using UnityEngine;

//public class PlayerCont_test : MonoBehaviour
//{
//    public GameObject[] Models;

//    public float Speed = 2f;

//    public Camera Camera;

//    private bool ButtonDown = false;

//    Vector3 Velocity = Vector3.zero;
//    Vector3 Direction = Vector3.zero;

//    Vector3 Up = new Vector3(1, 0, 1);
//    Vector3 Left = new Vector3(-1, 0, 1);

//    Rigidbody Rigidbody;

//    public GameObject[] PlayerIcons;

//    void Start()
//    {
//        Rigidbody = GetComponent<Rigidbody>();
//    }

//    private float rt = 0;
//    private float angle = 0;

//    float prevangle = 0;
//    internal bool inWater = false;
//    private void FixedUpdate()
//    {
//        prevangle = angle;
//        angle = Mathf.Atan2(Vector3.Normalize(Direction).z, -Vector3.Normalize(Direction).x) * Mathf.Rad2Deg + 90;

//        Velocity = Vector3.Lerp(Velocity, ButtonDown ? Vector3.Normalize(Direction) * Time.deltaTime * (CanWalk ? Speed : 0) : Vector3.zero, InterpFactor);
//        Rigidbody.velocity = Velocity;

//        Camera.transform.parent.position = Vector3.Lerp(Camera.transform.parent.position, transform.position, InterpFactor);

//    }
    
//    bool changing = false;
//    float changeTime = 0;
//    bool ability = false;
//    Vector3 tempPosition;
//    void Update()
//    {
//        RaycastHit hit;
        
//        Direction = Vector3.Normalize(Direction);
//        if (Input.GetKey(KeyCode.W))
//            Direction += Up;
//        if (Input.GetKey(KeyCode.A))
//            Direction += Left;
//        if (Input.GetKey(KeyCode.D))
//            Direction += -Left;
//        if (Input.GetKey(KeyCode.S))
//            Direction += -Up;
       
//    }
//}