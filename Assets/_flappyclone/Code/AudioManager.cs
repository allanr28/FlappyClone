using System;
using UnityEngine;

namespace AllanReford._flappyclone.Code
{
    public class AudioManager : MonoBehaviour
    {
        public SoundEffect[] soundEffects;
        
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void PlaySoundEffect(string effectName)
        {
            SoundEffect soundEffect = Array.Find(soundEffects, sound => sound.name == effectName);
            _audioSource.Stop();
            _audioSource.volume = soundEffect.volume;
            _audioSource.PlayOneShot(soundEffect.clip);
        }
    }

    [Serializable]
    public class SoundEffect
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume;
    }
}
