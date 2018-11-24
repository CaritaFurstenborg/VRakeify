using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace Balettinakit
{
    public class Flow : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        public GameObject GameOverPref;
        private Player player;

        void Start()
        {
            Assert.IsNotNull(PlayerPrefab, "Player Prefab missing");
            Initialize();
        }

        void Initialize()
        {
            player = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Player>();
        }

        public void GameOverEvent()
        {
            var sphe = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphe.transform.position = player.transform.position;
            Destroy(player.gameObject);
            GameObject go = Instantiate(GameOverPref);
        }

    }
}
