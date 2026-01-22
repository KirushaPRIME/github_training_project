using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Meme : MonoBehaviour
{
    private bool CheakSkiilCheak = false;
    private bool Play = false;
    private float A = 0;
    private float Speed = 1;
    private float AAAAAAAAAA = 0;
    private Color color = Color.white;

    public SkillCheakManager cheakManager;
    void Start()
    {
        color.a = 0f;
        GetComponent<UnityEngine.UI.Image>().color = color;
    }
    void Update()
    {
        if (Play)
        {
            if (Speed > 0)
            {
                A += Time.deltaTime * Speed;
                if (A < 1)
                {
                    color.a = A;
                    GetComponent<UnityEngine.UI.Image>().color = color;
                }
                else {
                    A = 1;
                    color.a = A;
                    GetComponent<UnityEngine.UI.Image>().color = color;
                    Speed = -Speed;
                    AAAAAAAAAA = Time.time;
                }
            }
            if (AAAAAAAAAA + 1.5 < Time.time)
            {
                if (Speed < 0)
                {
                    A += Time.deltaTime * Speed;
                    if (A > 0)
                    {
                        color.a = A;
                        GetComponent<UnityEngine.UI.Image>().color = color;
                    }
                    else
                    {
                        A = 0;
                        color.a = A;
                        GetComponent<UnityEngine.UI.Image>().color = color;
                        Speed = -Speed;
                        Play = false;
                    }
                }
            }
        }

        if (cheakManager.SkillCheackReady && !CheakSkiilCheak)
        {
            if (!cheakManager.SkillCheackResult)
            {
                Play = true;
                GetComponent<AudioSource>().Play();
            }
            CheakSkiilCheak = true;
        }
        if (!cheakManager.SkillCheackReady && CheakSkiilCheak)
        {
            CheakSkiilCheak = false;
        }
    }
}
