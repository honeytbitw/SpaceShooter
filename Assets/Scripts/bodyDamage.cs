using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyDamage : MonoBehaviour
{
    public int health = 1;
    public float invulnPeriod = 0;
    float invulTimer = 0;
    int correctLayer;
    //float invulAnimTimer = 0;
    SpriteRenderer spriteRender;
    void Start(){
        correctLayer = gameObject.layer;
        spriteRender = GetComponent<SpriteRenderer>();
        
        //it only works for parent object
        if (spriteRender == null)
        {
            spriteRender = transform.GetComponentInChildren<SpriteRenderer>();
            if(spriteRender == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer");
            }
        }
    }
    private void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");
        
            health--;
            invulTimer = invulnPeriod;
            gameObject.layer = 8;
         
    }
    void Update(){
        invulTimer -= Time.deltaTime;
        if (invulTimer <= 0)
        {
            gameObject.layer = correctLayer;
            if (spriteRender != null)
            {
                spriteRender.enabled = true;
            }
        }
        else
        {
            if (spriteRender == null)
            {
                spriteRender.enabled = !spriteRender.enabled;
            }
        }
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
