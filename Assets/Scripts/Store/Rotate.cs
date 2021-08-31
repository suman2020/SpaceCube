using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShop
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private Vector3 rotSpeed;

        void Update()
        {
            transform.Rotate(rotSpeed * Time.deltaTime);
        }
    }
}

