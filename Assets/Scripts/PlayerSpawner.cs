using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;
    float respawnTime;
    int numLives = 4;
    // Start is called before the first frame update
    void Start()
    {
       
        PlayerSpawn();
    }
    void PlayerSpawn()
    {
        numLives--;
        respawnTime = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (playerInstance == null&& numLives>1)
        {
            respawnTime -= Time.deltaTime;
            if (respawnTime <= 0)
            {
                PlayerSpawn();
            }
        }
    }
    void OnGUI()
    {
        if(numLives>1 || playerInstance!=null)
            GUI.Label(new Rect(0, 0, 100, 50), "Lives : " + numLives);    
        else
            GUI.Label(new Rect(Screen.width/2 -50, Screen.height/2 - 25, 100, 50), "Game Over!" );

    }
}
