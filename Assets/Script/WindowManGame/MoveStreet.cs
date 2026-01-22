using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveStreet : MonoBehaviour
{
    private bool ObstacleOnTheLeft = false;
    private bool ObstacleOnTheRight = false;
    public Transform SSSGhoul;
    public Transform MainCamera;
    private static Transform TransformPosition;
    private int Speed = SSS_Ghoul_Script.CONST_SPEED;
    private int FastSpeed = SSS_Ghoul_Script.CONST_FAST_SPEED;
    public int X;
    void Start()
    {
        TransformPosition = GetComponent<Transform>();
    }

    void Update()
    {
        //GetComponent<Transform>().position = new Vector2(-MainCamera.GetComponent<Transform>().position.x, -MainCamera.GetComponent<Transform>().position.y);

    }
    private void FixedUpdate()
    {
        if (GatesScript.GetTouchingObject() != null)
        {
            if (GatesScript.GetTouchingObject().position.x < SSSGhoul.position.x)
            {
                ObstacleOnTheLeft = true;
            }
            else
            {
                ObstacleOnTheRight = true;
            }
        }
        else
        {
            ObstacleOnTheLeft = false;
            ObstacleOnTheRight = false;
        }
        if (Input.GetKey(KeyManager.GetMoveLeft()) && !ObstacleOnTheLeft && SSS_Ghoul_Script.GetHeCanMove())
        {
            if (Input.GetKey(KeyManager.GetRun()))
            {
                //Debug.Log("Click A + Shift");
                X = -FastSpeed;
            }
            else
            {
                //Debug.Log("Click A");
                X = -Speed;
            }
            SSS_Ghoul_Script.SetMove(true);
        }
        else if (Input.GetKey(KeyManager.GetMoveRight()) && !ObstacleOnTheRight && SSS_Ghoul_Script.GetHeCanMove())
        {
            if (Input.GetKey(KeyManager.GetRun()))
            {
                //Debug.Log("Click D + Shift");
                X = FastSpeed;
            }
            else
            {
                //Debug.Log("Click D + Shift");
                X = Speed;
            }
            SSS_Ghoul_Script.SetMove(true);
        }
        else
        {
            X = 0;
            SSS_Ghoul_Script.SetMove(false);
        }
        if (!KeyManager.GetControlInManGame())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //Debug.Log("-");
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-X, 0);
            //Debug.Log("+");
        }
        //Debug.Log(KeyManager.GetControlInManGame());
    }
    public static Transform GetTransformPosition() { return TransformPosition; }
}
