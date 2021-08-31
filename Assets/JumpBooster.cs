using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBooster : MonoBehaviour
{
    MeshRenderer[] mrs;
    private PlayerMovement jump;

    void Start()
    {
        mrs = this.GetComponents<MeshRenderer>();
        jump = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    void OnTriggerEnter(Collider item)
    {
        if (item.gameObject.tag == "PlayerCube")
        {
            FindObjectOfType<AudioManager>().PlayMusic("JumpBooster");
            foreach (MeshRenderer m in mrs)
                m.enabled = false;
            jump.jump_taken = true;

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
