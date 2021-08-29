using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The target of the camera; the player
    public GameObject target;

    //Distance from target Y
    public float distanceY = 10;

    //Distance from target Z
    public float distanceZ = -10;

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(target.transform.position.x, 
            target.transform.position.y + distanceY, target.transform.position.z + distanceZ);
    }
}
