using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Sword : MonoBehaviour
    {
        public TurnSword TurnSword;
    public float rotat;

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
            var trackedController = gameObject.GetComponent<SteamVR_TrackedController>();
            if (trackedController == null)
            {
                // トラッキング制御を所得でいなかった場合は、SteamVR_TrackedControllerを追加する
                trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
            }

            var trackedObject = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackedObject.index);
        rotat = trackedController.transform.rotation.x;
            //Debug.Log(trackedController.transform.rotation.x);

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


