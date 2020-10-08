using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameControl : MonoBehaviour
{

    private int questsCompleted;
    public GameObject endGameScreen;

    // Update is called once per frame
    void Update()
    {
        questsCompleted = PlayerPrefs.GetInt("QuestsCompleted");
        if (questsCompleted == 6)
        {
            endGameScreen.SetActive(true);
            Time.timeScale = 0;
        } 
    }

    public void CloseGame()
    {
        Application.Quit();
        endGameScreen.SetActive(false);
        PlayerPrefs.SetInt("QuestsCompleted", 0);
    }
}
