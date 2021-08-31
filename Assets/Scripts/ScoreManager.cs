using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScore;
    public Text CoinsCounter;
    public float scoreAmount= 0.0f;
    private float pointIncreasedPerSecond= 20.0f;
    public int coins_collected = 0;
    public int coin_value = 1;
    public int total_coins;
    public bool spell_boost = false;
    private CountDownManager stm; // inherit property from the script CountDownManager
    public PlayerCollision collide;
    // used to transfer the score into the endgamescreen
    public EndGameScreen menuDisplay;
    public Text TotalCoinsCollected;
   
 //   int num;
  //  int coins;

    // counting the points achieved by the player
    void Start()
    {
        // referencr to the countdownmanager and player collision script
        stm = GameObject.Find("Canvas").GetComponent<CountDownManager>();
       // collide = GameObject.Find("Player").GetComponent<PlayerCollision>();
      //  scriptq =menu.GetComponent<NextLevel>();
        //menuDisplay = GameObject.Find("DeathWindow").GetComponent<EndGameScreen>();

        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore",0).ToString();
      //  coins = PlayerPrefs.GetInt("Coins", 0);
        TotalCoinsCollected.text = "TotalCoins: " + PlayerPrefs.GetInt("TotalCoins").ToString();
       // total_coins = PlayerPrefs.GetInt("TotalCoins");


    }

    void Update()
    {
        // when the player is dead, the score count stops
        if (collide.isDead)
        {
            return;
            
        }
        if (stm.countDownCompleted == true)
        {
            
            // increase the score after each time frame
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
            scoreText.text = ((int)scoreAmount).ToString();
            if (scoreAmount > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", (int)scoreAmount);
                highScore.text = "HighScore: " + ((int)scoreAmount).ToString();

            }
            

            CoinsCounter.text =' ' + coins_collected.ToString();
          //  PlayerPrefs.SetInt("TotalCoins", coins_collected) = PlayerPrefs.SetInt("TotalCoins", coins_collected); 
            
            

            /*
            PlayerPrefs.Save();
            TotalCoinsCollected.text = "TotalCoins" + (coins + coins_collected).ToString();
            */


        }
    }

    public void OnDeath()
    {
       

        menuDisplay.ToggleEndMenu(scoreAmount);
       
    }
    public void CoinHandler()
    {
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + coin_value);
        total_coins = PlayerPrefs.GetInt("TotalCoins");
        TotalCoinsCollected.text = "TotalCoins: " + total_coins.ToString();

    }
 
}
