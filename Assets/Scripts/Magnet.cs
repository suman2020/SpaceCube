﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Magnet : MonoBehaviour
{

    public GameObject coinDetectorObj;

    // Start is called before the first frame update
    void Start()
    {
        coinDetectorObj = GameObject.FindGameObjectWithTag("Coin Detector");
        coinDetectorObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerCube")
        {
            FindObjectOfType<AudioManager>().PlayMusic("Magnet");
            StartCoroutine(ActivateCoin());
            Destroy(transform.GetChild(0).gameObject);

        }
    }

    IEnumerator ActivateCoin()
    {
        coinDetectorObj.SetActive(true);
        yield return new WaitForSeconds(14f);
        coinDetectorObj.SetActive(false);
    }
}
