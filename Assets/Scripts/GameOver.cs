using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balettinakit
{
    public class GameOver : MonoBehaviour
    {
        public Action GameOverCall;
        private Flow flow;

        void Awake()
        {
            flow = FindObjectOfType<Flow>();
            if(flow == null)
            {
                Debug.Log("No flow obj found");
            }
        }

        public void OnTriggerEnter(Collider c)
        {
            flow.GameOverEvent();
        }
    }
}
