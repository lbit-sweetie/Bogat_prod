using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Trees;
    [SerializeField]
    private GameObject[] CTree;

    private GameObject[] TreesPlace;
    private GameObject[] CTreePlace;

    private void Awake()
    {
        TreesPlace = GameObject.FindGameObjectsWithTag("TreePlace");
        CTreePlace = GameObject.FindGameObjectsWithTag("CTreePlace");
        LevelGenerate();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    LevelGenerate();
        //}
    }

    public void LevelGenerate()
    {
        var a = GameObject.FindGameObjectsWithTag("Other");
        foreach (var e in a)
        {
            Destroy(e);
        }

        a = null;
        foreach (var e in TreesPlace)
        {
            Instantiate(Trees[Random.Range(0, Trees.Length)], e.transform.position, Quaternion.identity);
        }
        foreach (var e in CTreePlace)
        {
            Instantiate(CTree[Random.Range(0, CTree.Length)], e.transform.position, Quaternion.identity);
        }
    }
}
