using UnityEngine;

namespace AllanReford._flappyclone.Code
{
    public class BirdController : MonoBehaviour
    {
        public float jumpForce;
        public Transform deathPoint;
        
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        // private void Update()
        // {
        //     if (Manager.Instance.GameManager.IsPaused())
        //     {
        //         _rb.simulated = false;
        //         Time.timeScale = 0;
        //     }
        //     else
        //     {
        //         _rb.simulated = true;
        //         Time.timeScale = 1;
        //     }
        // }

        private void OnEnable()
        {
            if (Manager.Instance.InputManager != null)
            {
                Manager.Instance.InputManager.OnJumpEvent += Jump;
            }
        }

        private void OnDisable()
        {
            Manager.Instance.InputManager.OnJumpEvent -= Jump;
        }

        private void Jump()
        {
            _rb.linearVelocity = Vector2.zero; // Reset the current velocity for consistent jumps
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                transform.position = deathPoint.position;
            }
            
            if (other.gameObject.CompareTag("Goal"))
            {
                //TODO: Implement increase score events
            }
        }
    }
}
