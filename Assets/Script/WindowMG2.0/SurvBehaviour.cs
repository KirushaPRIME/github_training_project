using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvBehaviour : MonoBehaviour
{
    private float WalkSpeed;
    private float RunSpeed;

    public bool CanMove = true;

    float SpeedMultiplier => RunSpeed / WalkSpeed;

    Animator animator;
    Rigidbody2D body;

    public Vector2 MoveVector { get; private set; }


    private void Awake()
    {
        WalkSpeed = 3;
        RunSpeed = 6;
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyManager.MoveLeft) && Input.GetKey(KeyManager.MoveRight) || !CanMove)
        {
            MoveVector = Vector2.zero;
        }
        else if (Input.GetKey(KeyManager.MoveLeft))
        {
            MoveVector = new Vector2(-WalkSpeed, 0);
            
        } else if (Input.GetKey(KeyManager.MoveRight))
        {
            MoveVector = new Vector2(WalkSpeed, 0);
        }
        else
        {
            MoveVector = Vector2.zero;
        }

        //Debug.Log(MoveVector);

        if (Input.GetKey(KeyManager.Run)){
            MoveVector *= SpeedMultiplier;
        }



        body.MovePosition(
            (Vector2)this.transform.position + 
            MoveVector * Time.fixedDeltaTime * ScaleManager.ScaleWindow);
        animator.SetFloat("Speed", Mathf.Abs(MoveVector.x));
        GetComponent<SpriteRenderer>().flipX = (MoveVector.x < 0);
    }
}
