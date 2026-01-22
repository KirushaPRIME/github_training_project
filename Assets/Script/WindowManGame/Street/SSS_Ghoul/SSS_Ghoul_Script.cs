using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSS_Ghoul_Script : MonoBehaviour
{
    //public Transform MainCamera;
    //public const int BACKLACH_SIZE = 2;
    public const int CONST_SPEED = 5;
    public const int CONST_FAST_SPEED = 10;
    private static bool HeCanMove = true;
    private static bool GotOutOfTheBacklash = false;
    private int Speed = CONST_SPEED;
    private int FastSpeed = CONST_FAST_SPEED;
    private bool IHid = false;
    private static bool Move = false;
    void Start()
    {

    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        // Двигаем гуля
        /*
        if (Mathf.Abs(GetComponent<Transform>().position.x - MainCamera.position.x) > BACKLACH_SIZE)
        {
            GotOutOfTheBacklash = true;
        }
        if (!GotOutOfTheBacklash) {
            if (Input.GetKey(KeyManager.GetMoveLeft()))
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
            }
            else if (Input.GetKey(KeyManager.GetMoveRight()))
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
            }
            else
            {
                X = 0;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(X, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }*/

    }

    public void ghoulStartFixing()
    {
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 10);
    }
    public void ghoulBreakFixing()
    {
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
    }
    public void ghoulHide()
    {
        GetComponent<Image>().enabled = false;
        HeCanMove = false;
        IHid = true;
    }
    public void ghoulUnhide()
    {
        GetComponent<Image>().enabled = true;
        HeCanMove = true;
        IHid = false; 
    }


    public bool GetIHid() {  return IHid; }
    //public static bool GetGotOutOfTheBacklash() { return GotOutOfTheBacklash; }
    public static void SetMove(bool IsMove) { Move = IsMove; }
    public static bool GetMove() {  return Move; }
    public static void SetHeCanMove(bool HeCanMove_) { HeCanMove = HeCanMove_; }
    public static bool GetHeCanMove() { return HeCanMove; }

}
