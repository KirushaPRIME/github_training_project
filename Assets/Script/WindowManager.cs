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
    private static short LastHighlighterNamber = 0;
    public const short COUNT_WINDOW = 2;
    public GameObject[] Windows = new GameObject[COUNT_WINDOW];
    private static bool WindowIsSelected = false;
    public const float NormalScale = 0.838f;
    public const float NormalWidht = 18f;
    public const float SmallScale = NormalScale / (COUNT_WINDOW * Space);
    public const float SmallWidht = NormalWidht / (COUNT_WINDOW * Space);
    public const float Space = 1.2f;
    //private const float TimeForFolded = 1;
    void Start()
    {
        HighlighterObject.GetComponent<UnityEngine.UI.Image>().enabled = false;
        HighlighterObject.GetComponent<Transform>().localScale = new Vector3(SmallScale, SmallScale, SmallScale);
        for (int i = 1; i < Windows.Length; i++)
        {
            Windows[i].GetComponent<Canvas>().enabled = false;
        }
        WindowOpen(0);
    }


    void Update()
    {
        if (!WindowIsSelected && Input.GetKeyDown(KeyManager.GetTransition()))
        {
            WindowIsSelected = true;
            LastHighlighterNamber = HighlighterNamber;
            float XForFirstPosition = -SmallWidht * COUNT_WINDOW / 2 + SmallWidht / 2 -(SmallWidht * (Space - 1) * (COUNT_WINDOW - 1)) / 2;
            for (int i = 0; i < Windows.Length; i++)
            {
                Windows[i].GetComponent<Transform>().localScale = new Vector3 (SmallScale, SmallScale, SmallScale);
                Windows[i].GetComponent<Transform>().localPosition = new Vector2(XForFirstPosition + i * SmallWidht * Space, 0);
            }
            HighlighterObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
            HighlighterObject.GetComponent<Transform>().position = Windows[HighlighterNamber].GetComponent<Transform>().position;
        }
        if (WindowIsSelected && Input.GetKeyUp(KeyManager.GetTransition()))
        {
            WindowIsSelected = false;
            WindowFolded(LastHighlighterNamber);
            WindowOpen(HighlighterNamber);
            for (int i = 0; i < Windows.Length; i++)
            {
                Windows[i].GetComponent<Transform>().localScale = new Vector3(NormalScale, NormalScale , NormalScale );
                Windows[i].GetComponent<Transform>().localPosition = new Vector2(0,0);
            }
            HighlighterObject.GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
        if (WindowIsSelected)
        {
            if (Input.GetKeyDown(KeyManager.GetMoveLeft())){
                if (HighlighterNamber < COUNT_WINDOW - 1)
                {
                    HighlighterNamber++;
                }
                else
                {
                    HighlighterNamber = 0;
                }
                HighlighterObject.GetComponent<Transform>().position = Windows[HighlighterNamber].GetComponent<Transform>().position;
            }
            if (Input.GetKeyDown(KeyManager.GetMoveRight()))
            {
                if (HighlighterNamber > 0)
                {
                    HighlighterNamber--;
                } else
                {
                    HighlighterNamber = COUNT_WINDOW - 1;
                }
                HighlighterObject.GetComponent<Transform>().position = Windows[HighlighterNamber].GetComponent<Transform>().position;
            }

        }
    }
    private void WindowFolded(short Index)
    {
        FoldedObject = Windows[Index];
    }
    private void WindowOpen(short Index)
    {
        OpenObject = Windows[Index];
    }
    public static short GetHighlighterNamber() { return HighlighterNamber; }
    public static GameObject GetFoldedObject() { return FoldedObject; }
    public static GameObject GetOpenObject() { return OpenObject; }
    public static bool GetWindowIsSelected() { return WindowIsSelected; }
}
