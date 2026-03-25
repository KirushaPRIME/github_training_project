using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MG2dot0Manager : MonoBehaviour
{
    public GameObject PrefabGenerator;
    public GameObject PrefabLocker;
    public GameObject PrefabGate;
    public GameObject PrefabExit;

    public GameObject Man;

    private List<List<GameObject>> interactiveObjects;

    public List<GameObject> generators;
    public List<GameObject> lockers;

    private int GeneratorNamber = 5;
    private int LockerNamber = 5;
    private float SizeMap = 160;
    private float Space = 20;
    private float SizeUsingMap => SizeMap - Space;
    private float SizeInteractiveObject = 5;
    private float groundLevel = -3.5f;

    private float InteractionTimeGenerator;

    private enum InOb { gs , ls , Length}

    private void Awake()
    {
        SettingDifficulty();
        InitializeMap();
    }

    void SettingDifficulty()
    {
        SizeMap = 120;
        LockerNamber = 5;
        GeneratorNamber = 4;

        GateBehaviour.NamberForOpen = 2;

        Man.GetComponent<ManMove>().NormalSpeed = 3.5f;
        Man.GetComponent<ManMove>().FastSpeed = 6.5f;

        SkillCheakBehaviour.ArrowSpeed = 200;
        SkillCheakBehaviour.GreatReactionCorner = 60;

        GeneratorBehaviour.MaxSkillCheakPause = 10;
        GeneratorBehaviour.PauseBeforCheaking = 1;
        InteractionTimeGenerator = 25;
        if (Scenes.Level > 0)
        {
            Debug.Log("Level: 1");
        }
        if (Scenes.Level > 1)
        {

            Debug.Log("Level: 2");
            SizeMap = 140;
            GeneratorNamber = 5;
            GateBehaviour.NamberForOpen = 3;
            Man.GetComponent<ManMove>().NormalSpeed = 4f;
            Man.GetComponent<ManMove>().FastSpeed = 7f;
            GeneratorBehaviour.MaxSkillCheakPause = 7;
        }
        if (Scenes.Level > 2)
        {
            Debug.Log("Level: 3");
            SkillCheakBehaviour.GreatReactionCorner = 45;
            Man.GetComponent<ManMove>().NormalSpeed = 6f;
            Man.GetComponent<ManMove>().FastSpeed = 12f;
            InteractionTimeGenerator = 35;
        }
        if (Scenes.Level > 3)
        {
            Debug.Log("Level: 4");
            SkillCheakBehaviour.ArrowSpeed = 300;
            SkillCheakBehaviour.GreatReactionCorner = 45;

            GeneratorBehaviour.MaxSkillCheakPause = 6;
            GeneratorBehaviour.PauseBeforCheaking = 0.8f;
        }
        if (Scenes.Level > 4)
        {
            Debug.Log("Level: 5");
            Man.GetComponent<ManMove>().NormalSpeed = 7f;
            LockerNamber = 4;
            SizeMap = 160;
        }
    }
     
    void InitializeMap()
    {
        if (interactiveObjects != null)
            foreach (var listObj in interactiveObjects)
                if (listObj != null)
                    foreach (var obj in listObj)
                        Destroy(obj);

        interactiveObjects = new List<List<GameObject>>();

        generators = InstalizateObjectOnMap(PrefabGenerator, SizeInteractiveObject, GeneratorNamber,"Generator");
        foreach (var obj in generators)
            obj.GetComponent<GeneratorBehaviour>().InteractionTime = InteractionTimeGenerator;
        lockers = InstalizateObjectOnMap(PrefabLocker, SizeInteractiveObject, LockerNamber, "Locker");

        GameObject gate = Instantiate(PrefabGate, this.transform);
        gate.GetComponent<Transform>().localPosition = new Vector2(
            -Space / 2,
            groundLevel +
            gate.GetComponent<RectTransform>().sizeDelta.y *
            gate.transform.localScale.y / 2);
        gate = Instantiate(PrefabGate, this.transform);
        gate.GetComponent<Transform>().localPosition = new Vector2(
            SizeMap - Space / 2,
            groundLevel +
            gate.GetComponent<RectTransform>().sizeDelta.y *
            gate.transform.localScale.y / 2);

        GameObject exit = Instantiate(PrefabExit, this.transform);
        exit.GetComponent<Transform>().localPosition = new Vector2(
            -Space / 2,
            groundLevel +
            exit.GetComponent<RectTransform>().sizeDelta.y *
            exit.transform.localScale.y / 2);
        exit = Instantiate(PrefabExit, this.transform);
        exit.GetComponent<Transform>().localPosition = new Vector2(
            SizeMap - Space / 2,
            groundLevel +
            exit.GetComponent<RectTransform>().sizeDelta.y *
            exit.transform.localScale.y / 2);

        Man.SetActive(true);
        Debug.Log("End InitializeMap");
    }

    List<GameObject> InstalizateObjectOnMap(GameObject obj, float size, int Namber, string Name)
    {
        var list = new List<GameObject>();
        int countObj = 0;
        foreach (var l in interactiveObjects)
            countObj += l.Count;
        if (SizeUsingMap / size / 1.5 < Namber + countObj)
        {
            Debug.Log("Недостаточно места на карте для размещения всех объектов!");
            return null;
        }
        interactiveObjects.Add(list);
        for (int i = 0; i < Namber; i++)
        {
            list.Add(Instantiate(obj, this.transform));
            list[i].name = Name + "#" + i;
            PlaceObject(list[i]);
        }
        return list;
    }

    void PlaceObject(GameObject go)
    {
        float NewPositionX;
        NewPositionX = Random.Range(0, SizeUsingMap / SizeInteractiveObject) * SizeInteractiveObject;
    Retry:;
        for (int i = 0; i < interactiveObjects.Count; i++)
        {
            if (interactiveObjects[i] == null)
                continue;
            for (int j = 0; j < interactiveObjects[i].Count; j++)
            {
                if (interactiveObjects[i][j] == go)
                    continue;
                if (Mathf.Abs(NewPositionX - interactiveObjects[i][j].GetComponent<Transform>().localPosition.x) < SizeInteractiveObject)
                {
                    if (NewPositionX < SizeUsingMap)
                    {
                        NewPositionX += SizeInteractiveObject;
                    }
                    else
                    {
                        NewPositionX = 0;
                    }
                    goto Retry;
                    
                }
            }
        }
        
        go.GetComponent<Transform>().localPosition = new Vector2(
            NewPositionX,
            groundLevel +
            go.GetComponent<RectTransform>().sizeDelta.y *
            go.transform.localScale.y / 2);
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
