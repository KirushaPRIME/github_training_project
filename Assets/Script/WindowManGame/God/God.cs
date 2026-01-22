using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public StreetManager StreetManager;
    public ManScript ManScript;
    public SkillCheakManager SkillCheakManager;
    public const float NEED_PROGRESS_FOR_GENERATOR = 20;
    private int LegthPauseX10 = 50;

    private int CountGenerator = 4;
    private int CountArmoire = 4;
    private int NamberFindGen = -1;

    private float RandomPause = 0;
    private void Awake()
    {
        ManScript.enabled = false;
        StreetManager.enabled = false;
    }
    void Start()
    {
        ManScript.setFastSpeed(11);
        ManScript.setNeedDistance(10);
        ManScript.setNormalSpeed(6);
        GatesScript.SetNeedDuneGenerator(CountGenerator > 2?CountGenerator - 2: CountGenerator);
        ManScript.enabled = true;
        StreetManager.enabled = true;
    }
    void Update()
    {
        if (StreetManager.GetInstalized())
        {
            if (NamberFindGen == -1)
            {
                for (int i = 0; i < CountGenerator; i++)
                {
                    if (StreetManager.GetGenerator(i).GetComponent<GeneratorScript>().GetFixing())
                    {
                        NamberFindGen = i;
                        RandomPause = Time.time + Random.Range(0, LegthPauseX10) / 10;
                        break;
                    }
                    else
                    {
                        NamberFindGen = -1;
                    }
                }
            }
            if (NamberFindGen != -1 && !StreetManager.GetGenerator(NamberFindGen).GetComponent<GeneratorScript>().GetFixing())
            {
                NamberFindGen = -1;
            }
            if (NamberFindGen != -1 && RandomPause < Time.time)
            {
                SkillCheakManager.SkillCheckFunction(1);
                SkillCheakManager.SetPositiomGenerator(StreetManager.GetGenerator(NamberFindGen).GetComponent<Transform>().localPosition.x);
                StreetManager.GetGenerator(NamberFindGen).GetComponent<GeneratorScript>().SkillCheakBool = true;
                RandomPause = Time.time + Random.Range(50, LegthPauseX10) / 10;
            }
        }
    }
    public int GetCountGenerator() { return CountGenerator; }
    public int GetCountArmoire() { return CountArmoire; }
}
