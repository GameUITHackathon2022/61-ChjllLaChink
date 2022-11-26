using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialSceneController : MonoBehaviour
{
    [Header("Button")]
    public Button SkipButton;
    public Button BackButton;
    public TextMeshProUGUI TutorialText ;
    public List<string> Tutorial =  new List<string>();
    
    float horizontalMove;
    bool isPressRight;
    bool isPressLeft;
    bool isPressSpace;
    int index; 

    private void Start() {
        index = 0;
        SkipButton.onClick.AddListener(OnClickSkipButton);
        BackButton.onClick.AddListener(OnClickBackButton);
        TutorialText.text =  Tutorial[0];
    }
    
    private void Update() {
        horizontalMove =  Input.GetAxisRaw("Horizontal");

        if(horizontalMove >0)
        {
            isPressRight = true;
        }    
        else if(horizontalMove < 0)
        {
            isPressLeft = true;
        }

        if(isPressLeft && isPressRight && index == 0)
        {
            index = 1;
            TutorialText.text = Tutorial[index];
        }

        if(Input.GetKeyDown(KeyCode.Space) && index == 1)
        {
            isPressSpace =  true;
        }

        if(isPressSpace && index == 1)
        {
            index =  2;
            TutorialText.text = Tutorial[index];
        }

        if(Input.GetKeyDown(KeyCode.S) && index == 2)
        {
            index = 3;
        }

        if(index == 3)
        {
            TutorialText.text =  "DONE TUTORIAL";
            StartCoroutine(GotoSelectScene());
            return;
        }
    }

    IEnumerator GotoSelectScene(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(Scenes.SelectScene.ToString());
    }

    private void OnClickSkipButton(){
        SceneManager.LoadScene(Scenes.SelectScene.ToString());
    }

    private void OnClickBackButton(){
        SceneManager.LoadScene(Scenes.MenuScene.ToString());
    }
}
