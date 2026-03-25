using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManBehaviour : MonoBehaviour
{
    public Transform Tr_Surv;
    delegate void Behaviour();
    Behaviour behaviour;

    public ManMove MM;

    GameObject[] InteractiveObject;

    float triggerDistance;

    RaycastHit2D hit;
    LayerMask mask;

    Vector2 DirectionView = new Vector2(-1,0);


    private void Awake()
    {
        mask = LayerMask.GetMask("MG2.0");
        triggerDistance = 6;
    }
    void Start()
    {
        SkillCheakBehaviour.Fail += WhinFailSkillCheak;

        behaviour = new Behaviour(MapCrowling);

        InteractiveObject = GameObject.FindGameObjectsWithTag("InteractiveObject");
    }

    void FixedUpdate()
    {
        hit = Physics2D.Raycast(transform.position, (MM.MoveVector), triggerDistance * ScaleManager.ScaleWindow, mask);
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
                    //Debug.Log("LookRigth");
                }
                else
                {
                    //Debug.Log("LookLeft");
                }
                TimeNextTurn = Time.time + LookingBackTime;
            }
        }
    }

    void Pursuit()
    {
        Debug.Log("Pursuit");
        MM.FastMove(Tr_Surv.localPosition.x - transform.localPosition.x);
    }

    bool CheakWhereThis = false;
    float NoisePlace;
    void CheakPlace()
    {
        if (!CheakWhereThis)
        {
            NoisePlace = Tr_Surv.localPosition.x;
            CheakWhereThis = true;
        }
        else
        {
            MM.FastMove(NoisePlace - transform.localPosition.x);
        }
        if (Mathf.Abs(NoisePlace - transform.localPosition.x) < 1)
        {
            behaviour = new Behaviour(MapCrowling);
        }
    }


    private void ResetValues()
    {
        
    }

    public void WhinFailSkillCheak(object Ob, EventArgs args)
    {
        Debug.Log("I see that!");
        CheakWhereThis = false;
        behaviour = new Behaviour(CheakPlace);
    }
}
