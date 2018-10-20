using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
    public class EnemyGenerator : MonoBehaviour
    {
        public GameObject FlyingObject;
        public Transform Object;
        public float timeOut;
        private float timeElapsed;
        private float speed = 2f;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            timeElapsed += Time.deltaTime;

            if (timeElapsed >= timeOut)
            {
                // Do anything
                GameObject obj = Instantiate(FlyingObject, Object.position, Object.rotation) as GameObject;
                obj.gameObject.transform.Translate(Random.Range(-50f, 50f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
                obj.gameObject.transform.Rotate(90, 0, 0);
                obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward * 400000f);
                obj.gameObject.transform.Rotate(-90, 0, 0);
                //obj.transform.position += transform.forward * Time.deltaTime * speed;
                timeElapsed = 0.0f;
            }

            
        }
    }

}
