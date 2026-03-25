using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMove : MonoBehaviour
{
    public float NormalSpeed = 8.0f;
    public float FastSpeed = 16.0f;
    Rigidbody2D rb;
    public Vector2 MoveVector {  get; private set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void NormalMove(float X)
    {
        MoveVector = new Vector2(
            ((X > 0) ? 1 : -1)
            * NormalSpeed * Time.fixedDeltaTime * ScaleManager.ScaleWindow,
            0
            );
        rb.MovePosition((Vector2)this.transform.position + MoveVector);


    }
    public void FastMove(float X)
    {
        MoveVector = new Vector2(
            ((X > 0) ? 1 : -1)
            * FastSpeed * Time.fixedDeltaTime * ScaleManager.ScaleWindow,
            0
            );
        rb.MovePosition((Vector2)this.transform.position + MoveVector);
    }
}
