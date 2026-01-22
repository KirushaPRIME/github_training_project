using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Script : MonoBehaviour
{
    public Transform SSSGhoul;
    private float Speed;
    private float Distance = 2;
    void Start()
    {
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2((SSSGhoul.position.x - GetComponent<Transform>().position.x) * Mathf.Abs((SSSGhoul.position.x - GetComponent<Transform>().position.x)) , 0);
    }
}
