using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Text scoreText;
    
    public GamePlayButtons script;
    void Start()
    {
    //    gameObject.SetActive(false);
      //  script = GameObject.Find("Canvas").GetComponent<GamePlayButtons>();
    }

    public void ToggleEndMenu(float score)
    {
       // if (script != null)
       // {
        script.playerdisplay = false;
        gameObject.SetActive(true);
        script.RemoveGamePlayButtons();
        //}

        FindObjectOfType<AudioManager>().PlayMusic("MenuMusic");
        gameObject.SetActive(true);
        scoreText.text = "Score : " + ((int)score).ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NavigateToMainMenu()
    {
        SceneManager.LoadScene("MainPage");
    }
    public void PlayNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
