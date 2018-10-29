using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSword : MonoBehaviour {
    public Animator Animator;
    Vector3 PrevPos;
    Vector3 NewPos;
    Vector3 ObjVelocity;
    private float timeElapsed;

    //private Rigidbody _rigidbody;
    // Use this for initialization
    void Start () {
        PrevPos = transform.position;
        NewPos = transform.position;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;


        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation
        Debug.Log(ObjVelocity);
        Debug.Log(transform.rotation);

        if (ObjVelocity.magnitude > 3&&timeElapsed > 1)
        {
            Animator.SetTrigger("Attack");
            timeElapsed = 0;
        }
    }

    public void RotateSword()
    {
        Debug.Log("トリガーを深く引いた");
        Animator.SetTrigger("Attack");
        //Animator.SetBool("Why", true);
    }
}
