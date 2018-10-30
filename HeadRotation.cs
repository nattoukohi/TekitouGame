using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HeadRotation : MonoBehaviour {
    public GameObject Camera;
    public TurnSword TurnSword;
    public GameObject Sword;

    float PrevPos;
    float NewPos;
    public float ObjVelocity;
    private float timeElapsed;

    // Use this for initialization
    void Start () {
        PrevPos = 0;
        NewPos = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;

        Vector3 cameraPos = Camera.transform.position;
        Vector3 cameraDir = Camera.transform.forward;

        Vector3 vrPos = InputTracking.GetLocalPosition(XRNode.CenterEye);
        Quaternion vrRot = InputTracking.GetLocalRotation(XRNode.CenterEye);

        Vector3 pos = cameraPos + vrPos; // 視点
        Vector3 dir = vrRot * Sword.transform.position;  // 方向

        Vector3 sworder = dir - pos;

        var diff = Sword.transform.position - this.transform.position;

        var axis = Vector3.Cross(this.transform.forward, diff);

        var angle = Vector3.Angle(this.transform.forward, diff)

                         * (axis.y < 0 ? -1 : 1);

        NewPos = angle;  // each frame track the new position
        ObjVelocity = NewPos - PrevPos;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation

        

       // Debug.Log("YO" + ObjVelocity);
    }
}
