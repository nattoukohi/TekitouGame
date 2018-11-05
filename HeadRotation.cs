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

    float PrevPos2;
    float NewPos2;
    public float ObjVelocity;
    public float ObjVelocity2;
    Vector3 ObjVel;
    private float timeElapsed;

    // Use this for initialization
    void Start () {
        PrevPos = 0;
        NewPos = 0;
        PrevPos2 = 0;
        NewPos2 = 0;
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
        ObjVelocity = NewPos - PrevPos;  // velocity = dist/time / Time.deltaTime
        PrevPos = NewPos;  // update position for next frame calculation

        NewPos2 = Sword.transform.position.y;
        ObjVelocity2 = NewPos2 - PrevPos2;
        PrevPos2 = NewPos2;

        //Debug.Log("YO" + ObjVelocity2);
    }
}
