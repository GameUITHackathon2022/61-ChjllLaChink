using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // public float maxHealth;
    // public float currentHealth;
    // float currentTime  = 0;

    // private void Start() {
    //     maxHealth = 100;
    //     currentHealth = maxHealth;
    // }

    // private void Update() {
    //     if(currentHealth <= 0)
    //     {
    //         GetComponent<PlayerController>().UpdateAnimation();
    //     }

    //     // currentTime += Time.deltaTime;
    //     // if(currentTime >= 1f)
    //     // {
    //     //     currentHealth -= 10;
    //     //     currentTime = 0f;
    //     // }
    // }

    // public float GetPercent(){
    //     return currentHealth/maxHealth;
    // }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Obstacle")
        {
            Debug.Log("DIE");
           // Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag =="Enemy")
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else if(other.gameObject.tag =="ChainSaw")
        {
            Debug.Log("DIE");
        }
    }
}
