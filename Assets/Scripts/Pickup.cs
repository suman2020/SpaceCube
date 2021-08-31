using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    MeshRenderer[] mra;
    private ScoreManager coin_Score;

    void Start()
    {
        mra = this.GetComponentsInChildren<MeshRenderer>();
        coin_Score = GameObject.Find("Canvas").GetComponent<ScoreManager>();

    }

    void OnTriggerEnter(Collider item)
    {
        if (item.gameObject.tag == "PlayerCube")
        {
            FindObjectOfType<AudioManager>().PlayMusic("CoinCollect");
            coin_Score.scoreAmount += 50;
            foreach (MeshRenderer m in mra)
                m.enabled = false;
            if (coin_Score.spell_boost == false)
            {
                coin_Score.coins_collected += 1;
                
                coin_Score.coin_value = 1;
                coin_Score.CoinHandler();
            }
            else
            {
                coin_Score.coins_collected += 2;
                coin_Score.coin_value = 2;
                coin_Score.CoinHandler();
            }
            
          //  coin_score.coins_value = 1;
           // coin_score.coins = coin_score.coins_collected * coin_score.coins_value;
        }

        
    }


    // Update is called once per frame
    void OnEnable()
    {
        if (mra != null)
        {
            foreach (MeshRenderer m in mra)
                m.enabled = true;
        }
    }
}