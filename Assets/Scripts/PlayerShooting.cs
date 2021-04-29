using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireDelay = 0.1f;
    float cooldownTimer = 0;
    int bulletLayer;
    void Start()
    {
        bulletLayer = gameObject.layer;
    }
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            //shoot
            Debug.Log("fiya!!");
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);
            GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGo.layer = bulletLayer;
        }
    }
}
