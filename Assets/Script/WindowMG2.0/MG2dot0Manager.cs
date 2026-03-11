using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG2dot0Manager : MonoBehaviour
{
    public GameObject PrefabGenerator;

    private List<GameObject>[] interactiveObjects;

    public List<GameObject> generators;
    public List<GameObject> lockers;

    private int GeneratorNamber = 5;
    private float SizeMap = 100;
    private float SizeUsingMap = 50;
    private float SizeInteractiveObject = 6;
    private float groundLevel = -3.5f;

    private enum InOb { gs , ls , Length}

    private void Awake()
    {
        interactiveObjects = new List<GameObject>[(int)InOb.Length];
        InitializeMap();
    }

    void InitializeMap()
    {
        if (generators != null)
            foreach (var generator in generators)
                Destroy(generator);
        if (SizeUsingMap / SizeInteractiveObject * 2 < GeneratorNamber)
        {
            Debug.Log("Недостаточно места на карте для размещения всех объектов!");
            return;
        }
        generators = new List<GameObject>();
        interactiveObjects[(int)InOb.gs] = generators;
        for (int i = 0; i < GeneratorNamber; i++)
        {
            generators.Add(Instantiate(PrefabGenerator, this.transform));
            generators[i].name = "Generator#" + i;
            PlaceObject(generators[i]);
        }



        Debug.Log("End InitializeMap");
    }

    void PlaceObject(GameObject go)
    {
        Debug.Log(go.name);
        float NewPositionX;
        NewPositionX = Random.Range(0, SizeUsingMap / SizeInteractiveObject) * SizeInteractiveObject;
    Retry:;
        for (int i = 0; i < interactiveObjects.Length; i++)
        {
            if (interactiveObjects[i] == null)
                continue;
            for (int j = 0; j < interactiveObjects[i].Count - 1; j++)
            {
                Debug.Log(interactiveObjects[i][j].name + " " + Mathf.Abs(NewPositionX - interactiveObjects[i][j].GetComponent<Transform>().localPosition.x));
                if (Mathf.Abs(NewPositionX - interactiveObjects[i][j].GetComponent<Transform>().localPosition.x) < SizeInteractiveObject)
                {
                    Debug.Log("Retry");
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
