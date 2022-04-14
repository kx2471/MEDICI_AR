using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }


    public GameObject mainMenuUI;
    public GameObject infomationText;
    


    public void OnClickGameStart()
    {
        SceneManager.LoadScene("SampleScene");
        PlayerUnityEngine.clearCount = 50;

        Time.timeScale = 1;
    }

    public void OnClickMaineSceneReturn()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void OnClickMainMenu()
    {
        mainMenuUI.SetActive(true);
        Time.timeScale = 0;
        
        
    }

    public void OnClickReturn()
    {
        infomationText.SetActive(false);
    }

    public void OnClickInfomation()
    {
        infomationText.SetActive(true);
    }

    public void OnclickNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void OnClickContinue()
    {
        mainMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickNextStage()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerUnityEngine.clearCount += 25;
        
       
    }
}
