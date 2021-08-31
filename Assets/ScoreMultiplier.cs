using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
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
            FindObjectOfType<AudioManager>().PlayMusic("ScoreMultiplier");
            coin_score.scoreAmount += coin_score.scoreAmount;
            foreach (MeshRenderer m in mrs)
                m.enabled = false;
       
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
}
