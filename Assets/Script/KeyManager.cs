using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    static public KeyCode Interaction { get; private set; }
    static public KeyCode MoveLeft { get; private set; }
    static public KeyCode MoveRight { get; private set; }
    static public KeyCode Action { get; private set; }
    static public KeyCode Run { get; private set; }
    static public KeyCode Transition { get; private set; }

    static private bool ControlInManGame = false;
    void Awake(){
        Interaction = KeyCode.E;
        MoveLeft = KeyCode.A;
        MoveRight = KeyCode.D;
        Action = KeyCode.Space;
        Run = KeyCode.LeftShift;
        Transition = KeyCode.Tab;
    }

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
