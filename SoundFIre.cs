using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
    public class SoundFIre : MonoBehaviour
    {
        public AudioClip audioClip1;
        private AudioSource audioSource;

        // Use this for initialization
        void Start()
        {
            
            ShootingSound();
        }

        public void ShootingSound()
        {
            Debug.Log("eee");
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip1;
            audioSource.Play();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    
}
