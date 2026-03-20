using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMove : MonoBehaviour
{
    public float NormalSpeed = 8.0f;
    public float FastSpeed = 16.0f;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void NormalMove(float X)
    {
        rb.MovePosition(
            (Vector2)this.transform.position + 
            new Vector2(
            ((X > 0) ? 1 : -1)
            * NormalSpeed * Time.fixedDeltaTime * ScaleManager.ScaleWindow,
            0
            ));
    }
    public void FastMove(float X)
    {
        rb.MovePosition(
            (Vector2)this.transform.position +
            new Vector2(
            ((X > 0) ? 1 : -1 )
            * FastSpeed * Time.fixedDeltaTime * ScaleManager.ScaleWindow,
            0
            ));
    }
}
