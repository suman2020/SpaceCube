using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBooster : MonoBehaviour
{
    MeshRenderer[] mrs;
    private ScoreManager coin_score;

    void Start()
    {
        mrs = this.GetComponents<MeshRenderer>();
        coin_score = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }
    void OnTriggerEnter(Collider item)
    {
        if (item.gameObject.tag == "PlayerCube")
        {
            coin_score.spell_boost = true;
            FindObjectOfType<AudioManager>().PlayMusic("CoinBooster");
            coin_score.scoreAmount += 50;
            foreach (MeshRenderer m in mrs)
                m.enabled = false;
            //   coin_score.coins_collected += 1;   
            Invoke("CoinManage", 10.0f);
        }
    }


    // Update is called once per frame
    void OnEnable()
    {
        if (mrs != null)
        {
            foreach (MeshRenderer m in mrs)
                m.enabled = true;
        }
    }
    void CoinManage()
    {
        coin_score.spell_boost = false;
    }
}
