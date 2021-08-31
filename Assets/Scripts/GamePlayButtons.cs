using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayButtons : MonoBehaviour
{
    public GameObject PanalPause;
    public GameObject PauseButton;
    
    public GameObject ScoreCard;
    public GameObject DeathWindow;
  //  public GameObject NextLevelWindow;
    public GameObject Player;
    public GameObject HighScore;
    public GameObject JoyStick;
    public GameObject JumpButton;
    public bool playerdisplay=true;
    public void Start()
    {
        ResumeGamePlay();

    }
    public void PauseGamePlay()
    {
        PanalPause.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGamePlay()
    {
        PanalPause.SetActive(false);
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        

    }
    public void NavigateToHomePage()
    {
        SceneManager.LoadScene(1);
    }
    public void RemoveGamePlayButtons()
    {
        if (playerdisplay == false)
        {
            
            Player.SetActive(false);
            ScoreCard.SetActive(false);
            HighScore.SetActive(false);
        }
        PanalPause.SetActive(false);
        PauseButton.SetActive(false);
        
        DeathWindow.SetActive(false);
        JoyStick.SetActive(false);
        JumpButton.SetActive(false);

       //s NextLevelWindow.SetActive(false);
        
       
        
    }
    public void ActivateGamePlayButtons()
    {
        JumpButton.SetActive(true);
        JoyStick.SetActive(true);
        PauseButton.SetActive(true);
        
    }

}

