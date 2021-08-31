using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerview;
    public Vector3 offset;
    // Update is called once per frame
    private void Start()
    {
        offset = transform.position - playerview.position;
    }
    void FixedUpdate()
    {
        if (playerview != null)
        {
            Vector3 targetPosition = playerview.position + offset;
            //targetPosition.x = 0;
            transform.position = targetPosition;

        }
    }
}
