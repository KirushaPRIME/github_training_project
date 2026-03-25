using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GeneratorBehaviour;

public class GeneratorBehaviour : InteractiveObjectBehaviour
{
    public delegate void DoneGEnerator(object Ob, EventArgs args);
    public static event DoneGEnerator doneGEnerator;


    private float SkillCheakTime;
    public static float MaxSkillCheakPause = 10;
    public static float PauseBeforCheaking = 2;

    public static int CountDoneGane {  get; private set; }

    public SkillCheakBehaviour _SkillCheakBehaviour;



    protected override void Awake()
    {
        doneGEnerator = null;
        CountDoneGane = 0;
        HaveProgressBar = true;
        _SkillCheakBehaviour = GameObject.Find("SkillCheak").GetComponent<SkillCheakBehaviour>();
        base.Awake();
    }
    protected override void DoWithInteraction()
    {
        if (SkillCheakTime < Time.time)
        {
            Debug.Log("Skill cheak");
            SkillCheakTime = Time.time + UnityEngine.Random.Range(5, MaxSkillCheakPause);
            _SkillCheakBehaviour.StartSkillCheak(PauseBeforCheaking, 1);
        }
    }
    protected override void DoWithStartInteraction()
    {
        SkillCheakTime = Time.time + UnityEngine.Random.Range(0, MaxSkillCheakPause);
    }
    protected override void DoWithStopInteraction()
    {
        _SkillCheakBehaviour.DoDangerBreak();
    }
    protected override void DoWhenDone()
    {
        _SkillCheakBehaviour.DoSafeBreak();
        CountDoneGane++;
        if (doneGEnerator != null)
            doneGEnerator(this, new EventArgs());
        base.DoWhenDone();
    }

}
