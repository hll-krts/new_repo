using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public GameObject tutQuestion, tutorial;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("LoggedInBefore"))
        {
            tutQuestion.SetActive(true);
        }
        else tutQuestion.SetActive(false);
    }

    public void Open_Close_Tutorial()
    {
        if (tutorial.activeSelf)
        {
            tutorial.SetActive(false);
        }
        else tutorial.SetActive(true);
    }

    public void GoToStoryStage()
    {
        PlayerPrefs.SetInt("LoggedInBefore", 1);
        SceneManager.LoadScene(3);
    }
    public void NoToTutorial()
    {
        PlayerPrefs.SetInt("LoggedInBefore", 1);
        tutQuestion.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
