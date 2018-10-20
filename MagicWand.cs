using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magic {
public class MagicWand : MonoBehaviour
{

        [SerializeField] ParticleSystem particle;
        [SerializeField] SoundFIre sounder;
    public GameObject effect;
    public GameObject effect2;

    public GameObject ball;
    public Transform BrushTip;
    private string Recorder;

        private float timeOut = 0.1f;
        private float timeElapsed;

        public LayerMask mask;




    void Start()
    {

    }

    void BallMagic()
    {
        GameObject obj = Instantiate(ball, BrushTip.position, BrushTip.rotation) as GameObject;
        obj.gameObject.transform.Translate(0, 0, 2.0f);
        obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward * 30000f);
            sounder.ShootingSound();

    }

    void BallMagic2()
    {
        GameObject obj = Instantiate(ball, BrushTip.position, BrushTip.rotation) as GameObject;
        obj.gameObject.transform.Translate(0, 0, 2.0f);
        obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward * 100f);
   
        }

    void Update()
    {
            timeElapsed += Time.deltaTime;

            


            SteamVR_TrackedObject trackedObject = GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

            //ふくらむ
            if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
            {

            }


            //攻撃を放つ
            if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
            {
                Recorder = "";
                if (timeElapsed >= 0.05f)
                {
                Debug.Log(timeElapsed);
                BallMagic();
                   timeElapsed = 0.0f;
                }

                

                }

            


            //tPressDown(SteamVR_Controller.ButtonMask.Trigger)
            

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchPosition = device.GetAxis();
            if (touchPosition.y / touchPosition.x > 1 || touchPosition.y / touchPosition.x < -1)
            {
                if (touchPosition.y > 0)
                {
                    //タッチパッド上をクリックした場合の処理
                    Debug.Log("Press UP");
                    Recorder += "1";
                    particle.Play();
                    
                }
                else
                {
                    //タッチパッド下をクリックした場合の処理
                    Debug.Log("Press DOWN");
                    Recorder += "4";
                    particle.Play();
                }
            }
            else
            {
                if (touchPosition.x > 0)
                {
                    //タッチパッド右をクリックした場合の処理
                    Debug.Log("Press RIGHT");
                    Recorder += "3";
                    particle.Play();
                }
                else
                {
                    //タッチパッド左をクリックした場合の処理
                    Debug.Log("Press LEFT");
                    Recorder += "2";
                    particle.Play();
                }
            }

            if(int.Parse(Recorder) == 1234)
            {
                BallMagic();
                Recorder = "";

            }

            if(int.Parse(Recorder) == 1423)
            {
                BallMagic2();
                Recorder = "";
            }

            if (int.Parse(Recorder) == 11)
            {

                    GameObject obj = Instantiate(effect, BrushTip.position, BrushTip.rotation) as GameObject;
                obj.gameObject.transform.Translate(0, -1.5f, 2.0f);
                Recorder = "";
            }


            if (int.Parse(Recorder) == 44)
            {

                    GameObject obj = Instantiate(effect2, BrushTip.position, BrushTip.rotation) as GameObject;
                //obj.gameObject.transform.Translate(0, 0, 2.0f);
                    obj.gameObject.transform.Rotate(0, -90f, 0);
                Recorder = "";
            }



            if (Recorder.Length > 4)
            {
                Recorder = "";
            }
        }



    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sample")
        {
            Destroy(other.gameObject);
        }

    }

       
    }
}