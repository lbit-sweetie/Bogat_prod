using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKillSystem : MonoBehaviour
{
    private PProperties player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PProperties>();
    }
    public void KillPlayer()
    {
        if (player.secondChance)
        {
            player.secondChance = false;
        }
    }
}
