using System;
using UnityEngine;

namespace AllanReford._flappyclone.Input
{
    public class InputManager : MonoBehaviour
    {
        public event Action OnJumpEvent;
        public event Action OnPauseEvent;
        public event Action OnRestartEvent;

        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
    
        }
        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Interaction.Jump.performed += ctx => OnJumpEvent?.Invoke();
            _playerInput.Interaction.Pause.performed += ctx => OnPauseEvent?.Invoke();
            _playerInput.Interaction.Restart.performed += ctx => OnRestartEvent?.Invoke();
        }
    }
}
