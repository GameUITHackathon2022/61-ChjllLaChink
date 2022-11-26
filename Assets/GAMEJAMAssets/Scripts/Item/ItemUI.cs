using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public string id;
    Button button;

    private void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
        id = "0";
    }

    private void OnClickButton(){
        GetComponent<Image>().color = new Color(251,255,177);
    }



}
