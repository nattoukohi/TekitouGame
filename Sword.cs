using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
    public class Sword : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.gameObject.tag == "sample")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

