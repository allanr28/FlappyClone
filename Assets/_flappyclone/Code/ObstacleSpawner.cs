using UnityEngine;

namespace AllanReford._flappyclone.Code
{
    public class ObstacleSpawner : MonoBehaviour
    {
        public Transform spawnPoint;
        public GameObject prefab;
        
        public float rateOfSpawn = 1f;
        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= rateOfSpawn)
            {
                _timer = 0;
                CreateObstacle();
            }
        }

        private void CreateObstacle()
        {
            float yPos = Random.Range(-2.5f, 2.5f);
            Vector3 position = new Vector3(spawnPoint.position.x, yPos, spawnPoint.position.z);

            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
