using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoireScript : MonoBehaviour
{
    public static GameObject SSSGhoul;
    public bool PushButon = false;
    public bool HidHere = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (Mathf.Abs(SSSGhoul.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x) < StreetManager.GetInteractiveDistance() && !HidHere)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SSSGhoul.GetComponent<SSS_Ghoul_Script>().ghoulHide();
                HidHere = true;
                PushButon = true;
            }
        }
        if (HidHere && !PushButon)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SSSGhoul.GetComponent<SSS_Ghoul_Script>().ghoulUnhide();
                HidHere = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            PushButon = false;
        }
    }

}
