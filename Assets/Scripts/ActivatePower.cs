using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePower : MonoBehaviour
{
    public GameObject player;

    public Player.Power power;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<Player>().activePower(power);
            Destroy(gameObject);
        }
    }
}
