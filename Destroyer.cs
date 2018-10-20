using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
    public class Destroyer : MonoBehaviour
    {
        public AudioClip audioClip1;
        private AudioSource audioSource;

        // Use this for initialization
        void Start()
        {
            
            //ShootingSound();
        }

        public void DestroyedSound()
        {
            //Debug.Log("eee");
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
