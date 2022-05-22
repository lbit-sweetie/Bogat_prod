using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private GameMechanic gameMechanic;
    //private GameObject player;
    private void Start()
    {
        gameMechanic = GetComponent<GameMechanic>();
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.tag == "Player")
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                    gameMechanic.DoneLocation();
                }
            }
        }
    }
}
