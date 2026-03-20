using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManBehaviour : MonoBehaviour
{
    delegate void Behaviour();
    Behaviour behaviour;

    public ManMove MM;

    GameObject[] InteractiveObject;

    float triggerDistance;

    RaycastHit2D hit;
    LayerMask mask;


    private void Awake()
    {
        mask = LayerMask.GetMask("MG2.0");
        triggerDistance = 5;
    }
    void Start()
    {
        SkillCheakBehaviour.Fail += WhinFailSkillCheak;

        behaviour = new Behaviour(MapCrowling);

        InteractiveObject = GameObject.FindGameObjectsWithTag("InteractiveObject");
    }

    void FixedUpdate()
    {
        hit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), triggerDistance * ScaleManager.ScaleWindow, mask);
        if (hit.collider != null)
        {
            if(hit.collider.name == "Surv")
            {
                behaviour = new Behaviour(Pursuit);
            }
        }

        behaviour();
    }


    bool DidGetThere = true;
    float NewPlaceX;
    void MapCrowling()
    {
        if (DidGetThere)
        {
            
            NewPlaceX = InteractiveObject
                [UnityEngine.Random.Range(0, InteractiveObject.Length)]
                .transform.localPosition.x;
            //Debug.Log("New Place: " + NewPlaceX);
            DidGetThere = false;
        }
        else
        {
            MM.NormalMove(NewPlaceX - transform.localPosition.x);
        }
        if (Math.Abs(NewPlaceX - transform.localPosition.x) < 1)
        {
            DidGetThere = true;
            behaviour = new Behaviour(LookAround);
        }
    }

    float LookingBackTime = 1;
    float StopLookAroundTime;
    float TimeNextTurn = 0;
    bool DoneLookAround = true;
    void LookAround()
    {
        if (DoneLookAround && StopLookAroundTime < Time.time)
        {
            DoneLookAround = false;
            StopLookAroundTime = Time.time + LookingBackTime * 3;
        }
        else if (!DoneLookAround && StopLookAroundTime < Time.time)
        {
            DoneLookAround = true;
            behaviour = new Behaviour(MapCrowling);
        }
        else
        {
            if (TimeNextTurn < Time.time) {
                if ((int)(Time.time - StopLookAroundTime) % 2 == 0)
                {
                    Debug.Log("LookRigth");
                }
                else
                {
                    Debug.Log("LookLeft");
                }
                TimeNextTurn = Time.time + LookingBackTime;
            }
        }
    }

    void Pursuit()
    {
        Debug.Log("Pursuit");
    }

    public void WhinFailSkillCheak(object Ob, EventArgs args)
    {
        Debug.Log("I see that!");
    }
}
