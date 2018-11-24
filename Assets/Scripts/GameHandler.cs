using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balettinakit
{
    public class GameHandler : MonoBehaviour
    {
        public GameObject ApplePrefab;
        private GameObject currentApple;
        private Vector3 spawnPoint;

        void Start()
        {
            SpawnApple();
        }

        public void SpawnApple()
        {
            spawnPoint = new Vector3(Random.Range(-30f, 30f), Random.Range(-25f, 25f), Random.Range(-30f, 30f));
            if (currentApple == null)
            {
                currentApple = Instantiate(ApplePrefab, spawnPoint, Quaternion.identity);
            }
        }

        public void DestroyApple()
        {
            Destroy(currentApple);
            currentApple = null;
            SpawnApple();
        }
    }
}
