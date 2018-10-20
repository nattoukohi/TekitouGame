using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
    public class BallExplode : MonoBehaviour
    {
        public GameObject explosion;
        public Transform ball;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(gameObject.transform.position.y > 700 || gameObject.transform.position.y<0)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject obj = Instantiate(explosion, ball.position, ball.rotation) as GameObject;
            Destroy(this.gameObject);
        }
    }
}

