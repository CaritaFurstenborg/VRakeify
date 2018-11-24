using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balettinakit
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform player;

        void Start()
        {
            player = FindObjectOfType<Player>().transform;
            if(player == null)
            {
                Debug.Log("Cam can not find player");
            }
        }

        void LateUpdate()
        {
            if(player == null)
            {
                player = FindObjectOfType<Player>().transform;
            }
            transform.position = new Vector3(player.position.x, player.position.y, player.position.z - 0.8f);
        }
    }
}
