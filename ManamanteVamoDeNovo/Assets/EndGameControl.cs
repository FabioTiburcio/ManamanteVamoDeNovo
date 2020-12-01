using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameControl : MonoBehaviour
{

    private int questsCompleted;
    public GameObject endGameScreen;

    // Update is called once per frame
    void Update()
    {

    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("QuestsCompleted", 0);
        PlayerPrefs.SetInt("FeedbacksReceived", 0);
        PlayerPrefs.SetInt("Feedback", 0);
        PlayerPrefs.SetInt("QuestAccepted", 0);
    }
    public void CloseGame()
    {
        Application.Quit();
        endGameScreen.SetActive(false);
        PlayerPrefs.SetInt("QuestsCompleted", 0);
    }
}
