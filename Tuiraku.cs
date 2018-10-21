using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
   

    public class Tuiraku : MonoBehaviour
    {
        [SerializeField] Destroyer destroyed;
        //[SerializeField] GameObject count;
        private ScoreCounter script;
        public Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            rb = this.GetComponent<Rigidbody>();
            //script = count.GetComponent<ScoreCounter>();
            //tagを使うことでなんか解決した
            script = GameObject.FindWithTag("Score").GetComponent<ScoreCounter>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "ball" &&collision.gameObject.name != "Sphere")
            {
                rb.useGravity = true;
                destroyed.DestroyedSound();
                script.AddScore();
            }
        }
    }

}
