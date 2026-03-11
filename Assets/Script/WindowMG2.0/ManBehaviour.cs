using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManBehaviour : MonoBehaviour
{
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
        
    }

    void Update()
    {
        hit = Physics2D.Raycast(transform.position, new Vector2(-1,0), triggerDistance * ScaleManager.ScaleWindow, mask);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
    }
}
