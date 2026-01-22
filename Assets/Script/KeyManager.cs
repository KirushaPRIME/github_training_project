using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    static private KeyCode Interaction = KeyCode.E;
    static private KeyCode MoveLeft = KeyCode.A;
    static private KeyCode MoveRight = KeyCode.D;
    static private KeyCode Action = KeyCode.Space;
    static private KeyCode Run = KeyCode.LeftShift;
    static private KeyCode Transition = KeyCode.Tab;

    static private bool ControlInManGame = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    static public KeyCode GetInteraction() { return Interaction; }
    static public KeyCode GetMoveLeft() { return MoveLeft; }
    static public KeyCode GetMoveRight() { return MoveRight; }
    static public KeyCode GetAction() { return Action; }
    static public KeyCode GetRun() { return Run; }
    static public KeyCode GetTransition() { return Transition; }

    public static void SetControlInManGame( bool ControlInManGame_) { ControlInManGame = ControlInManGame_; }
    public static bool GetControlInManGame() { return ControlInManGame; }
}
