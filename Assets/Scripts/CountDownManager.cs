using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class CountDownManager : MonoBehaviour
{
    public bool countDownCompleted = false;
    // countdown image is created where the animation is displayed
    private GamePlayButtons displayButtons;
    public GameObject CountDownImage;

    void Start()
    {
        displayButtons = GameObject.Find("Canvas").GetComponent<GamePlayButtons>();
        displayButtons.playerdisplay = true;
        displayButtons.RemoveGamePlayButtons();
    }

    // countdown continues until it is completed
    void update()
    {
        if (countDownCompleted== true)
        {
            // after the completion of countdown, the image is made inactive
          //  CountDownImage.SetActive(false);
           



        }
    }
    
}
