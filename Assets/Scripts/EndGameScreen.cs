using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour
{
    public Text scoreText;
    private GamePlayButtons displayButtons;
  
    void Start()
    {
        gameObject.SetActive(false);
        displayButtons = GameObject.Find("Canvas").GetComponent<GamePlayButtons>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleEndMenu(float score)
    {
        displayButtons.playerdisplay = false;
        displayButtons.RemoveGamePlayButtons();
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
}
