using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectSceneController : MonoBehaviour
{
    [Header("Button")]
    public Button ReturnButton;
    public Button IntroButton;
    public Button TutorialButton;
    public Button Level1Button;
    public Button Level2Button;
    public Button Level3Button;

    private void Start() {

        GameController.Instance.isPlayFirstTime = true;
        ReturnButton.onClick.AddListener(OnClickReturnButton);
        IntroButton.onClick.AddListener(OnClickIntroButton);
        TutorialButton.onClick.AddListener(OnClickTutorialButton);
        Level1Button.onClick.AddListener(OnClickLevel1Button);
        Level2Button.onClick.AddListener(OnClickLevel2Button);
        Level3Button.onClick.AddListener(OnClickLevel3Button);
    }

    private void OnClickReturnButton(){
        SceneManager.LoadScene(Scenes.MenuScene.ToString());
    }

    private void OnClickIntroButton(){
        SceneManager.LoadScene(Scenes.IntroVideoScene.ToString());
    }

    private void OnClickTutorialButton(){
        SceneManager.LoadScene(Scenes.TutorialScene.ToString());
    }

    private void OnClickLevel1Button(){
        SceneManager.LoadScene(Scenes.Level1Scene.ToString());
    }

    private void OnClickLevel2Button(){
        SceneManager.LoadScene(Scenes.Level2Scene.ToString());
    }

    private void OnClickLevel3Button(){
        SceneManager.LoadScene(Scenes.Level3Scene.ToString());
    }
}
