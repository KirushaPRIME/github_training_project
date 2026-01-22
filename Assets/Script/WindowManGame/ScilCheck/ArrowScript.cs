using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour
{
    private int CountSkillCheck;
    private int NamberSkillCheck;
    private bool Click = false;
    private short DTargetZone = 10;
    //private bool SkillCheackReady = false;
    //private bool SkillCheackResult = false;
    public float z = 0;
    public int CornerTargetZone;
    public Transform Arrow;
    public Transform Circle;
    public static int Speed = 360;
    public static SkillCheakManager Interface;
    public static AudioSource NiceReactionAudio;
    public static AudioSource FailReactionAudio;
    public GameObject SoulArrowPrefab;
    GameObject a;
    void Start()
    {
        if (Arrow != null)
        {
            //SoulArrow.GetComponent<Image>().enabled = false;
        }
        else
        {
            GetComponent<ArrowScript>().enabled = false;
            Debug.Log("Error in DBD_Arrow script: not faund object arrrow\n");
        }
    }
   void Update()
    {
        if (!Interface.SkillCheackReady)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !Click)
            {
                a = Instantiate(SoulArrowPrefab, GetComponent<Transform>());
                a.GetComponent<SoulArrow>().PlayerTry(z);
                if (z > CornerTargetZone - DTargetZone && z < CornerTargetZone + DTargetZone)
                {
                    Click = true;
                    //SkillCheackResult = true;
                    Interface.SkillCheackResult = true;
                    FailReactionAudio.Stop();
                    NiceReactionAudio.Play();
                    NamberSkillCheck++;
                }
                else
                {
                    Click = true;
                    Interface.SkillCheackResult = false;
                    //SkillCheackResult = false;
                    FailReactionAudio.Play();
                    NiceReactionAudio.Stop();
                }
            }
            if (Click && !Interface.SkillCheackResult && !Interface.SkillCheackReady)
            {
                Interface.SkillCheackReady = true;
            }
            if (z > 360)
            {
                z = 0;
                if (!Click && !Interface.SkillCheackReady)
                {
                    Interface.SkillCheackResult = false;
                    NiceReactionAudio.Stop();
                    FailReactionAudio.Play();
                    Interface.SkillCheackReady = true;
                }
            }
            if (z == 0)
            {
                CornerTargetZone = UnityEngine.Random.Range(60, 350);
                Circle.rotation = Quaternion.Euler(0, 0, CornerTargetZone);
            }
            if (NamberSkillCheck == CountSkillCheck && !Interface.SkillCheackReady)
            {
                Interface.SkillCheackReady = true;
            }
            z += Time.deltaTime * Speed;
            Arrow.rotation = Quaternion.Euler(0, 0, z);
        }
    }

    public static void BreakSkillCheak()
    {
        if (Interface.SkillCheackResult == false)
        {
            FailReactionAudio.Play();
            NiceReactionAudio.Stop();
        }
        Interface.SkillCheackReady = true;
    }
    public static void SecurityBreakSkillCheak()
    {
        Interface.SkillCheackResult = true;
        Interface.SkillCheackReady = true;
    }
    public void SkillCheckStart(int CountSkillCheck)
    {
        this.CountSkillCheck = CountSkillCheck;
        NamberSkillCheck = 0;
    }
    //public bool GetSkillCheackResult(){return SkillCheackResult;}
    //public bool GetSkillCheackReady(){return SkillCheackReady;}
}
