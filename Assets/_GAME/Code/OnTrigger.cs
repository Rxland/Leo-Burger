using System;
using UnityEngine;

namespace _GAME.Code
{
    public class OnTrigger : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("OnCollisionEnter");
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");
        }
    }
}