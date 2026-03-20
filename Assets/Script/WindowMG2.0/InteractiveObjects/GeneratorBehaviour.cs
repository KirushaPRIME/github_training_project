using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBehaviour : InteractiveObjectBehaviour
{
    private float SkillCheakTime;
    private float MaxSkillCheakPause = 10;
    public SkillCheakBehaviour _SkillCheakBehaviour;

    protected override void Awake()
    {
        HaveProgressBar = true;
        InteractionTime = 20;
        _SkillCheakBehaviour = GameObject.Find("SkillCheak").GetComponent<SkillCheakBehaviour>();
        base.Awake();
    }
    protected override void DoWithInteraction()
    {
        if (SkillCheakTime < Time.time)
        {
            Debug.Log("Skill cheak");
            SkillCheakTime = Time.time + Random.Range(5, MaxSkillCheakPause);
            _SkillCheakBehaviour.StartSkillCheak(3, 1);
        }
    }
    protected override void DoWithStartInteraction()
    {
        SkillCheakTime = Time.time + Random.Range(0, MaxSkillCheakPause);
    }
    protected override void DoWithStopInteraction()
    {
        Debug.Log("DoWithStopInteraction");
        _SkillCheakBehaviour.DoDangerBreak();
    }
}
