using UnityEngine;

public class ItemDroping : MonoBehaviour
{
    public GameObject moneyPrefab;
    public GameObject itemPrefab;

    [SerializeField]
    [Header("Chance for money")]
    private float chanceMoney = .90f;

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
