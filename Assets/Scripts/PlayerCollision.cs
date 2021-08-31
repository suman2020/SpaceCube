using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public Transform player;

    public bool isDead = false;
    // helps to copy the score obtained into the end game screen
    private ScoreManager scoreTransfer;

    // AudioSource audioSource;
    private bool collided = true;
    private bool fell_down = true;
    private int count = 1;
    private PlayerMovement cube;
    MeshRenderer mrs;
   
    void Start()
    { 
        scoreTransfer = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        //   audioSource = GetComponent<AudioSource>();
        cube = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
  
    void FixedUpdate()
    {
        if (player != null)
        {
            if (player.position.y < 0.25f && fell_down && count == 1)
            {
                isDead = true;
                FindObjectOfType<AudioManager>().StopMusic("GameMusic");
                //  FindObjectOfType<AudioManager>().PlayMusic("Collision");
                FindObjectOfType<AudioManager>().PlayMusic("GameOver");
                Invoke("Death", 1.5f);
                count = 0;
            }

        }  
   }
    void OnCollisionEnter (Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Deadly":
                //   audioSource.Stop();
                if (collided)
                {
                    FindObjectOfType<AudioManager>().StopMusic("GameMusic");
                    FindObjectOfType<AudioManager>().PlayMusic("Collision");
                    FindObjectOfType<AudioManager>().PlayMusic("GameOver");
                    Invoke("Death", 1.5f);
                   
                    collided = false;
                    fell_down = false;
                }
                isDead = true;
                // audioSource.PlayOneShot(collision_sound,1);
               

                break;

            case "Finish":
                isDead = true;
                FindObjectOfType<AudioManager>().StopMusic("GameMusic");
                Invoke("NextLevel", 1.5f);
                FindObjectOfType<AudioManager>().PlayMusic("Win");
                
                break;

            default:
              
                break;
        }
    }
    private void Death()
    {
        isDead = true;
    //    Destroy(character,1.0f);
        scoreTransfer.OnDeath();


    }
    private void NextLevel()
    {
        isDead = true;
     //   scoreTransfer.OnNextLevel();
       // GameObject.Find("Canvas").GetComponent<ScoreManager>().OnNextLevel();

    }
   
}
