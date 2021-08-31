using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkyBox : MonoBehaviour
{
    public float RotateSpeed = 1.2f;
    public Vector3 rotation = new Vector3(0, 1, 0);
    // Update is called once per frame
    void Update()
    {
         RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSpeed);

    }
}
