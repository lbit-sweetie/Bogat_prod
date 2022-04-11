using UnityEngine;

public class ItemDroping : MonoBehaviour
{
    //private PStatistics playerStatistics;
    public GameObject moneyPrefab;
    public GameObject itemPrefab;

    //[Header("Макс колво монет за текущ локацию")]
    //[SerializeField]
    //public float countOfExp = 1f;

    //[SerializeField]
    //[Header("Макс колво XP за текущ локацию")]
    //public float countOfMoney = 1f;

    [SerializeField]
    [Header("Шанс на выпадение денег")]
    private float chanceMoney = .90f;

    //[SerializeField]
    //[Header("Шанс на выпадение предмета")]
    //private float chanceItem = .02f;

    public void DropMoney(Transform tf)
    {
        Instantiate(moneyPrefab, tf.position, Quaternion.identity);
    }
    public void DropItem(Transform tf)
    {
        Instantiate(itemPrefab, tf.position, Quaternion.identity);
    }

    public void ItemDrop(Transform tf)
    {
        var a = Random.Range(1, 100);

        if (a <= (chanceMoney * 100))
        {
            DropMoney(tf);
            return;
        }
        //if(a <= (chanceItem * 100))
        //{
        //    DropItem(tf);
        //}
        //else
        //{
        //    DropMoney(tf);
        //    return;
        //}
    }
}
