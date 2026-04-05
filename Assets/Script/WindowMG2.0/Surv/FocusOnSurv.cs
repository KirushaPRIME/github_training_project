using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FocusOnSurv : MonoBehaviour
{
    public Transform Tr_Surv;
    public SurvBehaviour survBehaviour;
    public float MultiplierSpeed;
    public float DegreeAcceleration;
    public float NamberSpeed;
    private bool IsLongDistance;

    private float PositionX;
    public float VectorX;

    void Start()
    {

    }

    void FixedUpdate()
    {
        //VectorX = Tr_Surv.localPosition.x - this.transform.localPosition.x;
        GetComponent<Transform>().localPosition =
                                new Vector3(Tr_Surv.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
        /*
        if (Mathf.Abs(VectorX) > 1)
        {
            
            if (Mathf.Abs(VectorX) > 2)
                IsLongDistance = true;
            if (IsLongDistance)
                if (Mathf.Abs(survBehaviour.MoveVector.x) > 0)
                    PositionX += Mathf.Abs(survBehaviour.MoveVector.x) * ((VectorX > 0) ? 1 : -1) * Time.fixedDeltaTime;
                else
                    PositionX += ((VectorX > 0) ? 1 : -1) * 2 * Time.fixedDeltaTime;
            //PositionX 

            GetComponent<Transform>().localPosition =
                                new Vector3(PositionX * ScaleManager.ScaleWindow, this.transform.localPosition.y, this.transform.localPosition.z);
        } else
            IsLongDistance = false;
        */
    }
}
