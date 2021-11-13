using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ZombieScript : MonoBehaviour
{
    public Transform player;
    Vector3 directionToPlayer;
    float moveSpeed = 2f;

    public float health = 50f;

    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        rushToPlayer();
    }

    void rushToPlayer()
    {
        //gets the direction of player and then look towards it and move
        directionToPlayer = player.position - transform.position;
        directionToPlayer = directionToPlayer.normalized;

        transform.Translate(directionToPlayer * Time.deltaTime * moveSpeed);
        transform.LookAt(player);

    }

    public void TakeDamage(float damage)
    {
        //handles the damage 
        health -= damage;
        if(health < 0f)
        {
            Die();
        }

    }

    void Die()
    {
        //destroy the gameobject when die
        Destroy(gameObject);
        
    }
    
}
