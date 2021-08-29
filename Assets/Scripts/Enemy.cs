using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody player;

    public Rigidbody self;

    public float speed = 3;

    public float radius = 5;

    public int health = 2;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerLock = player.position - gameObject.transform.position;
        playerLock.y = 0;

        if (playerLock.magnitude < radius)
        {
            //Face the player
            Quaternion direction;
            direction = Quaternion.LookRotation(playerLock);
            gameObject.transform.rotation = direction;

            //Move Forward
            Vector3 vel = gameObject.transform.forward * speed;
            self.velocity = vel;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("PlayerWeapon"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
