using UnityEngine;

namespace AllanReford._flappyclone.Code
{
    public class Obstacle : MonoBehaviour
    {
        
        public float speed = 5f;

        private void Update()
        {
            if (Manager.Instance.GameManager.IsGamePaused())
                return;
            
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
            
            if(transform.position.x < -5)
                Destroy(gameObject);
        }
    }
}
