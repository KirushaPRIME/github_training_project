using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerBehaviour : MonoBehaviour
{
    private GameObject Surv;
    private HintsBehaviour Hints;
    public bool IsHide = false;
    public bool IsSurvInTrigger = false;

    private void Awake()
    {
        Surv = GameObject.Find("Surv");
        Hints = GameObject.Find("Hints").GetComponent<HintsBehaviour>();
        if (Hints == null)
        {
            Debug.Log("Объект Hints не найден!");
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (IsSurvInTrigger && Input.GetKeyDown(KeyManager.Interaction))
        {
            Surv.SetActive(IsHide);
            IsHide = true;
            return;
        }
        if (IsHide && Input.GetKeyDown(KeyManager.Interaction))
        {
            Surv.SetActive(IsHide);
            IsHide = false;
        }
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == Surv.name)
        {
            IsSurvInTrigger = true;
            Hints.UpdateHint(true, HintsBehaviour.TypeMessage.BaseIteraction);
        }
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == Surv.name)
        {
            IsSurvInTrigger = false;
            Hints.UpdateHint(false, HintsBehaviour.TypeMessage.BaseIteraction);
        }
    }
}
