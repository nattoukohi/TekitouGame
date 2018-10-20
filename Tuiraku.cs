using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
   

    public class Tuiraku : MonoBehaviour
    {
        [SerializeField] Destroyer destroyed;
        public Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            rb = this.GetComponent<Rigidbody>();
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
            }
        }
    }

}
