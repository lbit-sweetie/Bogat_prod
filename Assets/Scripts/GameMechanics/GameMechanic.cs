using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMechanic : MonoBehaviour
{
    private GameObject[] placeForEnemys;
    private PProperties pProperties;
    [SerializeField] private DataForMainGame dataForMainGame;

    public GameObject[] enemes;
    public int currentChapter;
    public int curentLocation;

    private void Start()
    {
        pProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<PProperties>();
        placeForEnemys = GameObject.FindGameObjectsWithTag("PlaceForEnemys");
        SpawnEnemy();

        currentChapter = dataForMainGame.currentChapter;
        curentLocation = dataForMainGame.curentLocation;
    }

    public void DoneLocation()
    {
        curentLocation += 1;

        if (new int[3] { 5, 10, 15 }.ToList().Contains(curentLocation))
        {
            pProperties.ChooseSkill();
        }

        if (curentLocation == 20)
        {
            if (currentChapter != 2)
            {
                currentChapter += 1;
                curentLocation = 0;
            }
            else
            {
                EndGame();
            }
        }
        SaveLocations();

        SceneManager.LoadScene("TestGeneration");
    }

    public void PlayerDeath()
    {
        curentLocation = 0;
        pProperties.TakedFalse();
        SaveLocations();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerDeath();
            SceneManager.LoadScene("TestGeneration");
        }
    }

    private void SaveLocations()
    {
        dataForMainGame.curentLocation = curentLocation;
        dataForMainGame.currentChapter = currentChapter;
    }

    public void SpawnEnemy()
    {
        foreach (var e in placeForEnemys)
        {
            var a = Random.Range(0, 2);
            if (a == 0)
            {
                Instantiate(enemes[Random.Range(0, enemes.Length)],
                    e.transform.position,
                    Quaternion.identity);
            }
        }
    }

    public void EndGame()
    {

    }
}
