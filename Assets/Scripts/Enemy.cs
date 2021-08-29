using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody player;

    public Rigidbody self;

    public PlayerStats enemyStats;

    public float speed = 3;

    public float radius = 5;

    //public int health = 2;

    private void Start()
    {
        
    }

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
            enemyStats.TakeDamage(player.GetComponent<Player>().myStats.damage);
            Debug.Log("Enemy Health: " + enemyStats.health);
        }
        if (enemyStats.isDead)
        {
            Destroy(gameObject);
        }
    }
}
