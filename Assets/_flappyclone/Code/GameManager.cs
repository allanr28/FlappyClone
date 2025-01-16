using UnityEngine;

namespace AllanReford._flappyclone.Code
{
    public class GameManager : MonoBehaviour
    {
        private int _score;
        
        public Transform spawnPoint;
        public Transform deathPoint;
        public BirdController birdController;
        public ObstacleSpawner obstacleSpawner;

        private Rigidbody2D _birdRb2D;
        
        private float _timer;
        private float _countDownTimer = 5;

        private bool _beginRound;
        private bool _roundStarted;
        private bool _isGamePaused;

        private void Start()
        {
            _birdRb2D = birdController.GetComponent<Rigidbody2D>();
            
            _beginRound = true;
            _isGamePaused = false;

            _birdRb2D.simulated = false;
            
            Manager.Instance.InputManager.OnRestartEvent += Restart;
            Manager.Instance.InputManager.OnPauseEvent += () => _isGamePaused = !_isGamePaused;
        }

        private void Update()
        {
            if (_beginRound)
            {
                Manager.Instance.UiManager.ShowCountDownText();
                Manager.Instance.UiManager.HideGameOverText();
                
                if (_timer >= 1)
                {
                    _countDownTimer--;
                    Manager.Instance.UiManager.UpdateCountDownText(_countDownTimer);
                    _timer = 0;
                    if (_countDownTimer < 0)
                    {
                        _beginRound = false;
                        StartRound();
                    }
                }
            }
            
            _timer += Time.deltaTime;
        }

        private void StartRound()
        {
            _score = 0;
            Manager.Instance.UiManager.UpdateScoreText(_score);
            Manager.Instance.UiManager.HideCountDownText();
            birdController.gameObject.transform.position = spawnPoint.position;
            obstacleSpawner.SpawnObstacles();
            _birdRb2D.linearVelocity = Vector2.zero;
            _birdRb2D.simulated = true;
            _roundStarted = true;
        }

        public void Restart()
        {
            _beginRound = true;
            _countDownTimer = 5;
        }

        public void IncreaseScore()
        {
            _score++;
            Manager.Instance.UiManager.UpdateScoreText(_score);
        }

        public void Die()
        {
            _birdRb2D.simulated = false;
            obstacleSpawner.StopSpawningObstacles();
            Manager.Instance.UiManager.ShowGameOverText();
            birdController.gameObject.transform.position = deathPoint.position;
        }
        
        public bool IsGamePaused()
        {
            return _isGamePaused;
        }
        
        public bool IsRoundStarted()
        {
            return _roundStarted;
        }
    }
}
