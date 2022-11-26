using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private static ItemController instance;

    public static ItemController Instance => instance;

    private void Awake() {
        
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

    public ItemScriptableObject itemConfig;

    public  Item[] listItemInScene ;
    int totalItem => listItemInScene.Length;
    public GameObject[] ItemUI;

    public Dictionary<string,bool> listItem = new Dictionary<string, bool>();

    public int currentItemGet =  0;
    
    private void OnValidate() {
        listItemInScene = FindObjectsOfType<Item>();
    }

    private void Start() {
        for(int i = 0;i< itemConfig.ids.Length;i++)
        {
            listItem.Add(itemConfig.ids[i],false);
        }
    }

    public void FillItemToInventory(){
        int index = 0;
        foreach(var child in listItem)
        {
            if(child.Value == true)
            {
                int sprite=  itemConfig.GetIndex(child.Key);
                ItemUI[index].gameObject.GetComponent<Image>().sprite =  itemConfig.sprites[sprite];
                ItemUI[index].gameObject.transform.parent.transform.GetComponent<ItemUI>().id = child.Key;
                index ++;
            }
        }
    }

    public void AddItem(string id){
        listItem[id] = true;
    }
}
