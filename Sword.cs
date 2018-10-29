using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
    public class Sword : MonoBehaviour
    {
        public TurnSword TurnSword;
        

        void Awake()
        {
           
        }

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            var trackedObject = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackedObject.index);

            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                
                TurnSword.RotateSword();
            }
            

        }



        private void OnTriggerEnter(Collider collision)
        {
            
            if (collision.gameObject.tag == "sample")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

