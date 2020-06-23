using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    [SerializeField] private GameObject pauseScreenObject;
    [SerializeField] private GameObject mainMenuScreenObject;
    [SerializeField] private GameObject gameoverScreenObject;
    [SerializeField] private GameObject tutorScreen;

    [SerializeField] private GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseGame() {
        Time.timeScale = 0;
        this.pauseScreenObject.SetActive(true);
    }

    public void resumeGame() {
        Time.timeScale = 1;
        this.pauseScreenObject.SetActive(false);
    }

    public void gameoverScreen(){
        Time.timeScale = 0;
        this.gameoverScreenObject.SetActive(true);
    }

    public void reloadGameScene(){
        SceneManager.LoadScene(1);
    }
    public void backToMainmenu(){
        SceneManager.LoadScene(0);
    }
    public void playGame(){
        SceneManager.LoadScene(1);
    }

    public void continueAndCloseTutor(){
        this.tutorScreen.SetActive(false);
        Time.timeScale = 1;
        this.gameHandler.setGameStarted(true);
    }
    public void openTutorScreen(){
        this.tutorScreen.SetActive(true);
    }
}
