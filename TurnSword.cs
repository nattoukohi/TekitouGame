using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSword : MonoBehaviour {
    public Animator Animator;
    Vector3 PrevPos;
    Vector3 NewPos;
    Vector3 ObjDisplacement;
    Vector3 Calculation;
    public Vector3 ObjVelocity;
    private float timeElapsed;
    [SerializeField] HeadRotation HeadRotation;
    [SerializeField] Sword Sword;

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
        ObjDisplacement = (NewPos - PrevPos);
        ObjVelocity = ObjDisplacement / Time.fixedDeltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation
        //Debug.Log(ObjVelocity);
        //Debug.Log(transform.forward + "..." + ObjDisplacement.ToString("F4"));

        Calculation = ObjDisplacement + transform.forward;

        if (ObjVelocity.magnitude > 3&&timeElapsed > 0.2)
        {
            if(Sword.rotat > -0.5 && Sword.rotat < 0.5)
            {
                /*if (Sword.rotat > -0.05 && Sword.rotat < 0)
                {
                    if (HeadRotation.ObjVelocity2 > 0.2)
                    {
                        Debug.Log(HeadRotation.ObjVelocity);
                        Animator.SetTrigger("Attack");
                        timeElapsed = 0;
                        Debug.Log("Left");
                    }
                }else if (Sword.rotat < 0.05 && Sword.rotat > 0)
                {
                    if (HeadRotation.ObjVelocity2 > 0.2)
                    {
                        Animator.SetTrigger("AttackReverse");
                        timeElapsed = 0;
                        Debug.Log("Right");
                    }
                }else */ if (HeadRotation.ObjVelocity < -1.5)
                {
                    Debug.Log(HeadRotation.ObjVelocity);
                    Animator.SetTrigger("Attack");
                    timeElapsed = 0;
                    Debug.Log("Left");
                }

                else if (HeadRotation.ObjVelocity > 1.5)
                {
                    Animator.SetTrigger("AttackReverse");
                    timeElapsed = 0;
                    Debug.Log("Right");
                }
            }else if(Sword.rotat < -0.5 || Sword.rotat > 0.5)
            {
                if (HeadRotation.ObjVelocity < -1.5)
                {
                    Animator.SetTrigger("AttackReverse");
                    timeElapsed = 0;
                    Debug.Log("RevRight");
                }

                else if (HeadRotation.ObjVelocity > 1.5)
                {
                    
                    Debug.Log(HeadRotation.ObjVelocity);
                    Animator.SetTrigger("Attack");
                    timeElapsed = 0;
                    Debug.Log("REvLeft");
                }
            }
            else if(HeadRotation)
            {
                
            }
            


        }
    }

    public void RotateSword()
    {
        Debug.Log("トリガーを深く引いた");
        Animator.SetTrigger("Attack");
        //Animator.SetBool("Why", true);
    }
}
