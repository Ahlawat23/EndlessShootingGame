using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessShootingGameManager : MonoBehaviour
{
    public GameObject Enemy;
    float xPos;
    float zPos;
    public GameObject player;
    public GameObject button;

   

    public void spawnEnemy()
    {
        //genrates random postion for the spawn of enemy

        xPos = Random.Range(-17, 13);
        zPos = Random.Range(-30, 30);

        Instantiate(Enemy, new Vector3(xPos, 0.10f, zPos), Quaternion.identity);
        Invoke("spawnEnemy", 3f);
    }

    public void playGame()
    {
        //this is when you press play button, 
        //activate the palyer, deactivate the button and start spawing enemy
        player.SetActive(true);
        spawnEnemy();
        button.SetActive(false);
    }
}
