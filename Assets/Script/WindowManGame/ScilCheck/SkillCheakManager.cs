using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheakManager : MonoBehaviour
{
    public AudioSource NiceReactionAudio;
    public AudioSource FailReactionAudio;
    public AudioSource StartSkillCheckAudio;
    public GameObject SkillCheckPrefab;
    private GameObject SkillCheckObject;
    //По хорошему эти поля должны быть приватными и доступ к их изменению должениметься только у ArrowScript
    public bool SkillCheackReady = false;
    public bool SkillCheackResult = false;

    private float PositiomGenerator;
    private float DTime1 = 1f;
    private float DTime0 = 2f;
    private bool StartSkillCheak = false;
    private int SkillCheakCount;
    private void Awake()
    {
        ArrowScript.NiceReactionAudio = NiceReactionAudio;
        ArrowScript.FailReactionAudio = FailReactionAudio;
        ArrowScript.Interface = GetComponent<SkillCheakManager>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (SkillCheackReady)
        {
            if (SkillCheckObject != null) {
                Destroy(SkillCheckObject);
            }
        }
        if (DTime0 > DTime1 && StartSkillCheak)
        {
            SkillCheckObject = Instantiate(SkillCheckPrefab, GetComponent<Transform>());
            SkillCheckObject.GetComponent<ArrowScript>().SkillCheckStart(SkillCheakCount);
            StartSkillCheak = false;
        }else if (StartSkillCheak)
        {
            DTime0 += Time.deltaTime;
        }
    }
    public void BreakSkillCheak()
    {
        ArrowScript.BreakSkillCheak();
    }
    public void SecurityBreakSkillCheak()
    {
        ArrowScript.SecurityBreakSkillCheak();
    }
    public void SkillCheckFunction(int SkillCheakCount)
    {
        Debug.Log("SkillCheckFunction");
        StartSkillCheckAudio.Play();
        this.SkillCheakCount = SkillCheakCount;
        DTime0 = 0;
        StartSkillCheak = true;
        SkillCheackResult = false;
        SkillCheackReady = false;
    }
    public bool GetSkillCheackResult() { return SkillCheackResult; }
    public bool GetSkillCheackReady() { return SkillCheackReady; }
    public void SetSpeed(int Speed) { ArrowScript.Speed = Speed; }
    //public bool GetSkillCheakStart() { return SkillCheakStart; }
    public void SetPositiomGenerator(float positiomGenerator) { PositiomGenerator = positiomGenerator; }
    public float GetPositiomGenerator() { return PositiomGenerator; }
}
