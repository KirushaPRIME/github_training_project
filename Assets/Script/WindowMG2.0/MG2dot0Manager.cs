using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG2dot0Manager : MonoBehaviour
{
    public GameObject PrefabGenerator;
    public GameObject PrefabLocker;
    public GameObject PrefabGate;

    private List<List<GameObject>> interactiveObjects;

    public List<GameObject> generators;
    public List<GameObject> lockers;

    private int GeneratorNamber = 5;
    private int LockerNamber = 5;
    private float SizeMap = 180;
    private float Space = 20;
    private float SizeUsingMap => SizeMap - Space;
    private float SizeInteractiveObject = 6;
    private float groundLevel = -3.5f;

    private enum InOb { gs , ls , Length}

    private void Awake()
    {
        InitializeMap();
    }

    void InitializeMap()
    {
        if (generators != null)
            foreach (var generator in generators)
                Destroy(generator);
        if (interactiveObjects != null)
            foreach (var listObj in interactiveObjects)
                foreach (var obj in listObj)
                    Destroy(obj);

        interactiveObjects = new List<List<GameObject>>();

        generators = InstalizateObjectOnMap(PrefabGenerator, SizeInteractiveObject, GeneratorNamber,"Generator");
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

        Debug.Log("End InitializeMap");
    }

    List<GameObject> InstalizateObjectOnMap(GameObject obj, float size, int Namber, string Name)
    {
        var list = new List<GameObject>();
        float countObj = 0;
        foreach (var l in interactiveObjects)
            countObj += l.Count;
        if (SizeUsingMap / size / 2 < Namber + countObj)
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
            for (int j = 0; j < interactiveObjects[i].Count - 1; j++)
            {
                if (Mathf.Abs(NewPositionX - interactiveObjects[i][j].GetComponent<Transform>().localPosition.x) < SizeInteractiveObject)
                {
                    if (NewPositionX < SizeUsingMap)
                        NewPositionX += SizeInteractiveObject;
                    else
                        NewPositionX = 0;
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
