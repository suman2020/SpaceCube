using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownCounter : MonoBehaviour
{
    private CountDownManager stm;
    private Image image;
    private GamePlayButtons displayButtons;
    public GameObject CountDown;
    
    void Start()
    {
        displayButtons = GameObject.Find("Canvas").GetComponent<GamePlayButtons>();
        image = GetComponent<Image>();
    }
    // this function is called after the countdown in completed
    public void SetCountDown()
    {
     
        stm = GameObject.Find("Canvas").GetComponent<CountDownManager>();
        stm.countDownCompleted = true;
        displayButtons.ActivateGamePlayButtons();
        CountDown.SetActive(false);

        Destroy(image);
        // the image is then destroyed
    }


}
