using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // The Player
    public Rigidbody player;

    // The speed of the player
    public float speed = 5;

    // The jump height of the player
    public float jumpHeight = 10;

    // Sword Ability
    public GameObject sword; 

    public enum Power
    {
        Jump,
        Sword,
        Run
    }

    [HideInInspector]
    private bool powerJump = false;
    [HideInInspector]
    private bool powerSword = false;
    [HideInInspector]
    private bool powerRun = false;

    //
    private Quaternion direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Make the player move
        player.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, player.velocity.y, Input.GetAxis("Vertical") * speed);

        // Rotate Zalde
        Vector3 vel = new Vector3(player.velocity.x, 0, player.velocity.z);

        if (vel != new Vector3(0, 0, 0))
        {
            direction = Quaternion.LookRotation(vel);
            gameObject.transform.rotation = direction;
        }

        if (Input.GetKey(KeyCode.Space) && powerJump)
        {
            if (GroundCheck())
            {
                player.velocity = new Vector3(player.velocity.x, jumpHeight, player.velocity.z);
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && powerSword)
        {
            sword.GetComponent<MeshRenderer>().enabled = true;
            sword.GetComponent<BoxCollider>().enabled = true;
        } else
        {
            sword.GetComponent<MeshRenderer>().enabled = false;
            sword.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void activePower(Power power)
    {
        if (power == Power.Jump)
        {
            powerJump = true;
        }
        if (power == Power.Run)
        {
            powerRun = true;
        }
        if (power == Power.Sword)
        {
            powerSword = true;
        }
    }

    private bool GroundCheck()
    {
        float distance = 1.0f;

        Vector3 dir = new Vector3(0, -1, 0);

        return Physics.Raycast(player.position, dir, distance);
    }
}
