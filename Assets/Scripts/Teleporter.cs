using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject destination;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 offset = this.transform.position - other.transform.position;
        other.transform.position = destination.transform.position - offset;
    }
}
