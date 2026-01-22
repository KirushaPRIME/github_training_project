using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class StreetManager : MonoBehaviour
{
    public God God;

    private bool Instalized = false;

    //Дистанция для взаимодестви с объектами
    private static float InteractiveDistance = 1.2f;
    private float SpawnDistance = 5;

    //Префаб генератора
    public GameObject GeneratorPrefab;
    //Массив генераторов
    private GameObject[] generatorArray;

    private int GeneratorIsReady = 0;
    
    //Префаб для шкафчика
    public GameObject ArmoirePrefab;
    //Массив шкафчиков
    private GameObject[] armoireArray;


    //Префаб ворот
    public GameObject GatePrefab;
    //Массив ворот
    private GameObject[] gateArray;
    const short COUNT_GATES = 2;
    const short DISTANCE_FROM_THE_MAIN_STAGE = 5;

    public GameObject Man;

    //Размер карты
    private int SizeMap = 100;

    //Для удобства генерации
    private List<int> FreePosition;

    public GameObject Street;
    public GameObject SSSGhoul;
    public AudioSource NiceReactionAudio;
    public AudioSource FailReactionAudio;
    public SkillCheakManager SkillCheakManager;
    public GameObject WindowManGame;
    private void Awake()
    {
        GeneratorScript.Street = Street;
        GatesScript.Street = Street;
        GeneratorScript.SSSGhoul = SSSGhoul;
        GeneratorScript.SkillCheakManager = SkillCheakManager;
        ArmoireScript.SSSGhoul = SSSGhoul;
    }
    void Start()
    {
        int A = 0;
        gateArray = new GameObject[COUNT_GATES];
        generatorArray = new GameObject[God.GetCountGenerator()];
        for(int i = 0; i < COUNT_GATES; i++)
        {
            gateArray[i] = Instantiate(GatePrefab, GetComponent<Transform>());
        }
        for (int i = 0; i < God.GetCountGenerator(); i++)
        {
            generatorArray[i] = Instantiate(GeneratorPrefab, GetComponent<Transform>());
        }
        armoireArray = new GameObject[God.GetCountArmoire()];
        for (int i = 0; i < God.GetCountArmoire(); i++)
        {
            armoireArray[i] = Instantiate(ArmoirePrefab, GetComponent<Transform>());
        }




        gateArray[0].GetComponent<Transform>().localPosition = new Vector2(-DISTANCE_FROM_THE_MAIN_STAGE, 0);
        gateArray[1].GetComponent<Transform>().localPosition = new Vector2(SizeMap + DISTANCE_FROM_THE_MAIN_STAGE, 0);

        A = Convert.ToInt32(SizeMap / SpawnDistance);
        if (A < God.GetCountGenerator() + God.GetCountArmoire())
        {
            goto ERROR;
        }

        FreePosition = new List<int>();
        for (int i = 0; i < A; i++)
        {
            FreePosition.Add(i);
        }

        for (int  i = 0;  i < God.GetCountGenerator(); i++)
        {
            A = UnityEngine.Random.Range(i * (FreePosition.Count - 1) / God.GetCountGenerator(), (i + 1)* (FreePosition.Count - 1) / God.GetCountGenerator());
            generatorArray[i].GetComponent<Transform>().localPosition = new Vector2(FreePosition[A] * SpawnDistance, 0);
            FreePosition.RemoveAt(A);
        }
        for (int i = 0; i < God.GetCountArmoire(); i++)
        {
            A = UnityEngine.Random.Range(0, (FreePosition.Count - 1));
            armoireArray[i].GetComponent<Transform>().localPosition = new Vector2(FreePosition[A] * SpawnDistance, 0);
            FreePosition.RemoveAt(A);
        }

        /*
        for (int i = 0; i < God.GetCountGenerator(); i++)
        {
            generatorArray[i].GetComponent<Transform>().localPosition = new Vector2(Random.Range(SizeMap / 2 / God.GetCountGenerator() + SizeMap / God.GetCountGenerator() * i, SizeMap / God.GetCountGenerator() * (i + 1)), 0);
        }
        if (SizeMap / God.GetCountGenerator() > ArmoireScript.Distance * 2) {
            for (int i = 0; i < God.GetCountArmoire(); i++)
            {
                Good = false;
                B = 0;
                while (!Good && B < 3)
                {
                    A = Random.Range(0, God.GetCountGenerator());
                    armoireArray[i].GetComponent<Transform>().localPosition = new Vector2(Random.Range(ArmoireScript.Distance + SizeMap / God.GetCountGenerator() * A, SizeMap / God.GetCountGenerator() * (A + 1) - SizeMap / 2 / God.GetCountGenerator() - ArmoireScript.Distance), 0);
                    for(int j = 0; j < i; j++)
                    {
                        if (Mathf.Abs(armoireArray[j].GetComponent<Transform>().localPosition.x - armoireArray[i].GetComponent<Transform>().localPosition.x) < ArmoireScript.Distance * 2)
                        {
                            Good = false;
                            break;
                        } else { Good = true; }
                    }
                    B++;
                }
                if (!Good)
                {
                    Destroy(armoireArray[i]);
                }
            }
        }*/
        
        Instalized = true;
        KeyManager.SetControlInManGame(true);
    ERROR:
        if (!Instalized)
        {
            Debug.Log("Ошибка иницилизации");
        }
    }
    void Update()
    {
        if (Instalized)
        {
            Man.GetComponent<ManScript>().SetDynamicNeedDistance(Man.GetComponent<ManScript>().GetNeedDistance() * WindowManGame.GetComponent<Transform>().localScale.x);
        }
    }

    public GameObject GetGenerator(int generatorIndex) { return generatorArray[generatorIndex]; }
    public void OneGeneratorIsReady() { GeneratorIsReady++; }
    public int GetGeneratorIsReady() {  return GeneratorIsReady; }
    public bool GetInstalized() {  return Instalized; }
    public static float GetInteractiveDistance() { return InteractiveDistance; }
}
