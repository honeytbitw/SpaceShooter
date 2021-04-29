using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facesPlayer : MonoBehaviour
{
    public float rotSpeed = 90f;
    Transform player;
    // Update is called once per frame
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
        if (player == null)
            return; //try again next frame
        //here we know for sure that player exists. Turn to face the player!
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }
}
