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
        PositionX = transform.position.x;
    }

    void FixedUpdate()
    {
        VectorX =  Tr_Surv.position.x - this.transform.position.x;
        if (Mathf.Abs(VectorX) > 1)
        {
            if (Mathf.Abs(VectorX) > 3)
                IsLongDistance = true;
            if (IsLongDistance)
                if (Mathf.Abs(survBehaviour.MoveVector.x) > 0)
                    PositionX += Mathf.Abs(survBehaviour.MoveVector.x) * ((VectorX > 0) ? 1 : -1) * Time.fixedDeltaTime;
                else
                    PositionX += ((VectorX > 0) ? 1 : -1) * 2 * Time.fixedDeltaTime;
            GetComponent<Transform>().position =
                                new Vector3(PositionX, this.transform.position.y, this.transform.position.z);
        } else
            IsLongDistance = false;
    }
}
