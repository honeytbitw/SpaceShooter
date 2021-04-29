using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeed = 180f;
    public float shipBoundary = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotation
        //grab the rotation quaternion
        Quaternion rot = transform.rotation;
        //grab z euler angle
        float z = rot.eulerAngles.z; //use euler angels
        //change z based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //recreate quternion
        rot = Quaternion.Euler(0, 0, z);
        //feed quaternion into rotation
        transform.rotation = rot;
        //movement
        Vector3 pos = transform.position;
        Vector3 posChange = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * posChange;
        // vertical boundary set (much easier btw)
        if (pos.y + shipBoundary > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundary;
        }
        if (-pos.y + shipBoundary > Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundary;
        }
        //calculate width cuz orthographicSize gives height 
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        //horizontally balanced
        if (pos.x + shipBoundary > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundary;
        }
        if (-pos.x + shipBoundary > widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundary;
        }
        transform.position = pos;

    }
}
