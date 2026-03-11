using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WindowManager : MonoBehaviour
{
    public GameObject HighlighterObject;
    private static GameObject FoldedObject;
    private static GameObject OpenObject;
    private static short HighlighterNamber = 0;
    public int CountWindow {  get; private set; }
    public GameObject[] Windows;
    private static bool WindowIsSelected = false;
    public const float NormalScale = 0.838f;
    public const float NormalWidht = 18f;
    public float SmallScale { get; private set; }
    public float SmallWidht { get; private set; }
    public const float Space = 1.2f;
    //private const float TimeForFolded = 1;
    private void Awake()
    {
        CountWindow = Windows.Length;
        SmallScale = NormalScale / (CountWindow * Space);
        SmallWidht = NormalWidht / (CountWindow * Space);
    }
    void Start()
    {
        
        HighlighterObject.GetComponent<UnityEngine.UI.Image>().enabled = false;
        HighlighterObject.GetComponent<Transform>().localScale = new Vector3(SmallScale, SmallScale, SmallScale);
        for (int i = 1; i < Windows.Length; i++)
        {
            Windows[i].GetComponent<Canvas>().enabled = false;
        }
        FoldedAll();
        WindowOpen(0);
    }


    void Update()
    {
        if (!WindowIsSelected && Input.GetKeyDown(KeyManager.GetTransition()))
        {
            WindowIsSelected = true;
            OpenSelectMenu();
        }
        if (WindowIsSelected && Input.GetKeyUp(KeyManager.GetTransition()))
        {
            WindowIsSelected = false;
            
            for (int i = 0; i < Windows.Length; i++)
            {
                Windows[i].GetComponent<Transform>().localScale = new Vector3(NormalScale, NormalScale , NormalScale );
                Windows[i].GetComponent<Transform>().localPosition = new Vector2(0,0);
            }
            HighlighterObject.GetComponent<UnityEngine.UI.Image>().enabled = false;
            FoldedAll();
            WindowOpen(HighlighterNamber);
        }
        if (WindowIsSelected)
        {
            if (Input.GetKeyDown(KeyManager.GetMoveRight())){
                if (HighlighterNamber < CountWindow - 1)
                {
                    HighlighterNamber++;
                }
                else
                {
                    HighlighterNamber = 0;
                }
                HighlighterObject.GetComponent<Transform>().position = Windows[HighlighterNamber].GetComponent<Transform>().position;
            }
            if (Input.GetKeyDown(KeyManager.GetMoveLeft()))
            {
                if (HighlighterNamber > 0)
                {
                    HighlighterNamber--;
                } else
                {
                    HighlighterNamber = (short)(CountWindow - 1);
                }
                HighlighterObject.GetComponent<Transform>().position = Windows[HighlighterNamber].GetComponent<Transform>().position;
            }

        }
    }

    private void OpenSelectMenu()
    {
        float XForFirstPosition = -SmallWidht * CountWindow / 2 + SmallWidht / 2 - (SmallWidht * (Space - 1) * (CountWindow - 1)) / 2;
        for (int i = 0; i < Windows.Length; i++)
        {
            Windows[i].GetComponent<Transform>().localScale = new Vector3(SmallScale, SmallScale, SmallScale);
            Windows[i].GetComponent<Transform>().localPosition = new Vector2(XForFirstPosition + i * SmallWidht * Space, 0);
        }
        HighlighterObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
        HighlighterObject.GetComponent<Transform>().position = Windows[HighlighterNamber].GetComponent<Transform>().position;
        OpenAll();
        StopAllWindows();
    }

    private void FinishWindowSelection()
    {

    }

    private void StopAllWindows()
    {
        foreach (var window in Windows)
            window.GetComponent<FoldedObjectScript>().StopThisWindow();
    }

    private void RunAllWindows()
    {
        foreach (var window in Windows)
            window.GetComponent<FoldedObjectScript>().StartThisWindow();
    }

    private void FoldedAll()
    {
        foreach (var window in Windows)
            window.GetComponent<FoldedObjectScript>().FoldedYourSelf();
    }

    private void OpenAll()
    {
        foreach(var window  in Windows)
            window.GetComponent<FoldedObjectScript>().OpenYourSelf();
    }

    private void WindowFolded(short Index)
    {
        Windows[Index].GetComponent<FoldedObjectScript>().FoldedYourSelf();
    }
    private void WindowOpen(short Index)
    {
        Windows[Index].GetComponent<FoldedObjectScript>().OpenYourSelf();
    }
    public static short GetHighlighterNamber() { return HighlighterNamber; }
    public static GameObject GetFoldedObject() { return FoldedObject; }
    public static GameObject GetOpenObject() { return OpenObject; }
    public static bool GetWindowIsSelected() { return WindowIsSelected; }
}
