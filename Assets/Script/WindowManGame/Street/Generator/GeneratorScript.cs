using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{

    private float Progress = 0;
    private float Distance = 2;
    public float RealDistance;
    public static GameObject Street;
    public static GameObject SSSGhoul;
    public static SkillCheakManager SkillCheakManager;
    public bool SkillCheakBool;
    private bool Fixing = false;
    void Start()
    {
        
    }

    void Update()
    {
        RealDistance = SSSGhoul.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x;
        //Если ген не чиниться можем сесть его чинить
        if (!Fixing)
        {
            if (StreetManager.GetInteractiveDistance() > Mathf.Abs(RealDistance))
            {
                //will add Fnction
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SSSGhoul.GetComponent<SSS_Ghoul_Script>().ghoulStartFixing();
                    Fixing = true;
                }
            }
        }
        // Если прогресс достаточный прекращаем починку
        if (Progress > God.NEED_PROGRESS_FOR_GENERATOR)
        {
            StopFixing();
            GeneratorReady();
        }
        // Если у нас идёт проверка реакции и провекра реакции завершина тогда выполняем тело условия
        if (SkillCheakBool && SkillCheakManager.GetSkillCheackReady())
        {
            if (!SkillCheakManager.GetSkillCheackResult())
            {
                SkillCheakBool = false;
                StopFixing();
            }
        }

        if (SkillCheakBool && SSS_Ghoul_Script.GetMove())
        {
            StopFixingWithSkillCheck();
        }
        // Если мы чиним ген то у нас копиться прогресс
        if (Fixing)
        {
            Progress += Time.deltaTime;
            if (SSS_Ghoul_Script.GetMove())
            {
                StopFixing();
            }
        }
    }
    public void StopFixing()
    {
        Fixing = false;
        SSSGhoul.GetComponent<SSS_Ghoul_Script>().ghoulBreakFixing();
    }
    public void StopFixingWithSkillCheck()
    {
        Fixing = false;
        SkillCheakManager.BreakSkillCheak();
        SSSGhoul.GetComponent<SSS_Ghoul_Script>().ghoulBreakFixing();
    }
    public void GeneratorReady()
    {
        Street.GetComponent<StreetManager>().OneGeneratorIsReady();
        SkillCheakManager.SecurityBreakSkillCheak();
        GetComponent<GeneratorScript>().enabled = false;
    }
    public float GetProgress() {  return Progress; }
    public bool GetFixing() {  return Fixing; }
}
