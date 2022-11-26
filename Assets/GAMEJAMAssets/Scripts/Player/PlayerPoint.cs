using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Diamond"){
            ItemController.Instance.AddItem(other.GetComponent<Item>().id);
            Destroy(other.gameObject);
        }
    }
}
