using UnityEngine;
using AllanReford._flappyclone.Input;

namespace AllanReford._flappyclone.Code
{
    public class Manager : MonoBehaviour
    {
        public static Manager Instance;
        
        public InputManager InputManager { get; private set; }
        public GameManager GameManager { get; private set; }
        public UiManager UiManager { get; private set; }
        
        public AudioManager AudioManager { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            
            Instance = this;

            InputManager = GetComponent<InputManager>();
            GameManager = GetComponent<GameManager>();
            UiManager = GetComponent<UiManager>();
            AudioManager = GetComponent<AudioManager>();
        }
    }
}