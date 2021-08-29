using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public GameObject door;

    public Vector3 positionChange = new Vector3(0, 5, 0);

    private bool activated = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() && !activated)
        {
            door.transform.position += positionChange;
            activated = true;
        }
    }
}
