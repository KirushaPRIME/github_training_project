using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspense : MonoBehaviour
{
    public AudioSource Susp;
    public Transform Tr_Surv;
    private float TriggerDistance = 30;
    private void Start()
    {
        Susp = GetComponent<AudioSource>();
        Susp.Play();
    }
    void Update()
    {
        if (Mathf.Abs(Tr_Surv.transform.localPosition.x - transform.localPosition.x) < TriggerDistance)
        {
            Susp.volume = (TriggerDistance - Mathf.Abs(Tr_Surv.transform.localPosition.x - transform.localPosition.x)) / TriggerDistance;
            
        }
        else
            Susp.volume = 0;
    }
}
