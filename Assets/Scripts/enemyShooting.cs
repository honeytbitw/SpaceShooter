using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireDelay = 0.5f;
    float cooldownTimer = 0;
    int bulletLayer;
    Transform player;
    void Start()
    {
        bulletLayer = gameObject.layer;
    }
    void Update()
    {
        if (player == null)
        {
            //finding playership
            GameObject go = GameObject.FindGameObjectWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
            //at this point we've either found the ship
            //or player does'nt exist
        }
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4)
        {

            //shoot
            Debug.Log("enemy fiya!!");
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}
