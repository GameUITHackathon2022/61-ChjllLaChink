using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelController : MonoBehaviour
{
    private static LevelController instance;

    public static LevelController Instance{
        get{
            if (instance == null) 
            {
                instance = FindObjectOfType<LevelController>(true);
            }
             return instance;
        }
    }

    private void Awake() {
        Debug.Log("awake");
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

    [Header("Button")]
    public Button PauseButton;
    public Button GameOverButton;
    public Button LevelCompleteButton;
    public Button SoundButton;
    public Button MusicButton;

    [Header("Popup")]
    public GameObject GameOverPopup;
    public GameObject LevelCompletePopup;
    public GameObject PausePopup;
    public GameObject InventoryPopup;

    [Header("Point")]
    public TextMeshProUGUI PointText;

    [Header("Slider")]
    public Slider sliderSound;
    public Slider sliderMusic;

    PlayerHealth playerHealth;

    private void Start() {
        PauseButton.onClick.AddListener(OnClickPauseButton);
        GameOverButton.onClick.AddListener(OnClickGameOverButton);
        LevelCompleteButton.onClick.AddListener(OnClickLevelCompleteButton);

        playerHealth= FindObjectOfType<PlayerHealth>();
    }

    private void OnClickPauseButton(){
        PausePopup.SetActive(true);
    }

    private void OnClickGameOverButton(){
        GameOverPopup.SetActive(true);
    }

    private void OnClickLevelCompleteButton(){
        LevelCompletePopup.SetActive(true);
    }

    public void OnClickRestartButton(){
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == Scenes.Level1Scene.ToString())
        {
            SceneManager.LoadScene(Scenes.Level1Scene.ToString());
        }
        else if(scene.name == Scenes.Level2Scene.ToString()){
            SceneManager.LoadScene(Scenes.Level2Scene.ToString());
        }
        else if(scene.name == Scenes.Level3Scene.ToString()){
            SceneManager.LoadScene(Scenes.Level3Scene.ToString());
        }
    }

    public void OnClickMenuButton(){
        SceneManager.LoadScene(Scenes.MenuScene.ToString());
    }

    public void OnClickNextButton(){
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == Scenes.Level1Scene.ToString())
        {
            SceneManager.LoadScene(Scenes.Level2Scene.ToString());
        }
        else if(scene.name == Scenes.Level2Scene.ToString()){
            SceneManager.LoadScene(Scenes.Level3Scene.ToString());
        }
        else if(scene.name == Scenes.Level3Scene.ToString()){
            Debug.Log("HELLO");
        }
    }

    public void OnClickCancelPopupButton(){
        PausePopup.SetActive(false);
        LevelCompletePopup.SetActive(false);
        GameOverPopup.SetActive(false);
    }

    public void OnClickSoundButton(){

    }

    public void OnClickMusicButton(){
        
    }

    public void OpenPopupInventory(){
        InventoryPopup.SetActive(true);
        ItemController.Instance.FillItemToInventory();
    }

}
