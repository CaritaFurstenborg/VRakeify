using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Balettinakit
{
    public class Apple : MonoBehaviour
    {
        public Action EatApple;
        private GameHandler handler;

        void Awake()
        {
            handler = FindObjectOfType<GameHandler>();
            if(handler == null)
            {
                Debug.Log("No handler found");
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.tag.Equals("Player"))
            {
                handler.DestroyApple();
                var player = collider.GetComponent<Player>();
                player.AddBodyPice();
            }
        }
    }
}
