using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheakBehaviour : MonoBehaviour
{
    public float ArrowSpeed = 200;
    public float GreatReactionCorner = 60;// Размер отличной проверки реакции в виде угла


    private float StartTime = 0;
    private float CornerCircle; // Указывает на конец отличной проверки реакции
    private float CurrentAngel; 
    private int NamberSkillCheak;
    private int CountSkillCheak;
    private bool HaveResult = false;
    private bool WasClick = false;
    private bool HasSkillCheakEnded = true;
    private bool HasSkillCheakStarted = false;
    private bool Result = true;

    public GameObject Arrow;
    public GameObject ArrowSoul;
    public GameObject CircleInside;
    public GameObject CircleOutside;


    public CheakSC_Interface[] Overseers;

    public void StartSkillCheak(float Delay, int NamberSkillCheak)
    {
        if (HasSkillCheakEnded)
        {
            Debug.Log("Start");
            StartTime = Time.time + Delay;
            HasSkillCheakEnded = false;
            HasSkillCheakStarted = false;
            Result = true;
            this.NamberSkillCheak = (NamberSkillCheak > 0) ? NamberSkillCheak : 1;
        }
    }

    public void DoSafeBreak()
    {
        HaveResult = true;
        Result = true;
    }

    public void DoDangerBreak()
    {
        if (HasSkillCheakStarted && !HasSkillCheakEnded)
        {
            HaveResult = true;
            Result = false;
            CurrentAngel += 360;
        }
    }


    void Start()
    {
        SetActiveObjects(false);
    }

    void Update()
    {
        if (StartTime > Time.time || HasSkillCheakEnded)
            goto EndUpdate;

        if (!HasSkillCheakStarted)
        {
            Preparation();
        }

        if (!HaveResult)
        {
            if (Input.GetKeyDown(KeyManager.Action))
            {
                Debug.Log("Cheak");
                CheakResult();
            }
        }
        if (!HaveResult || CurrentAngel < 360)
        {
            if (CurrentAngel > 360)
            {
                if (WasClick)
                {
                    UpdateSkillCheak();
                    CurrentAngel = 0;
                } else
                {
                    HaveResult = true;
                    Result = false;
                }
            } else
                CurrentAngel = CurrentAngel + ArrowSpeed * Time.deltaTime;
            Arrow.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, CurrentAngel);
        }
        else
        {
            HasSkillCheakEnded = true;
            if (Result)
            {
                Debug.Log("Great");
            }
            else
            {
                Debug.Log("Fail");
                DoWhenFailSkillCheak();
            }
            CompleteSkillCheak();
            Debug.Log("End");
        }
        EndUpdate:;
    }

    void Preparation()
    {
        HaveResult = false;
        HasSkillCheakStarted = true;
        CountSkillCheak = 0;
        SetActiveObjects(true, true);
        Arrow.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        UpdateSkillCheak();
    }

    void UpdateSkillCheak()
    {
        CurrentAngel = 0;
        CircleInside.GetComponent<UnityEngine.UI.Image>().fillAmount = GreatReactionCorner / 360;
        CornerCircle = Random.Range(90, 330);
        CircleInside.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180 + CornerCircle);
    }

    void CompleteSkillCheak()
    {
        SetActiveObjects(false);
    }

    void SetActiveObjects(bool Status, bool IgnoreArrowSoul = false)
    {
        if (!IgnoreArrowSoul)
            ArrowSoul.SetActive(Status);
        Arrow.SetActive(Status);
        CircleInside.SetActive(Status);
        CircleOutside.SetActive(Status);
    }

    void CheakResult()
    {
        ArrowSoul.SetActive(true);
        ArrowSoul.GetComponent<Transform>().rotation = Arrow.GetComponent<Transform>().rotation;
        if (CurrentAngel <= CornerCircle &&
            CurrentAngel >= CornerCircle - GreatReactionCorner)
        {
            CountSkillCheak++;
            if (CountSkillCheak >= NamberSkillCheak)
            {
                HaveResult = true;
            } else
                WasClick = true;
        } else
        {
            HaveResult = true;
            Result = false;
        }
    }

    void DoWhenFailSkillCheak()
    {
        if (Overseers != null)
            foreach (var CSC in Overseers)
                CSC.DoWhenFailSkillCheak();
    }
}
