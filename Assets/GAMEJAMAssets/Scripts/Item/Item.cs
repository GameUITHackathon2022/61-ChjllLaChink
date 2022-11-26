using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string id;
    public string nameItem;

    public Item(string id, string name){
        this.id = id;
        this.name =  name;
    }
}
