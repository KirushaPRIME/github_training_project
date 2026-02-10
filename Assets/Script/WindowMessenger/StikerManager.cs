using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StikerManager : MonoBehaviour
{
    public Sprite[] sprites;
    public Transform Transform;
    public GameObject StikerPrefab;
    public GameObject PrefabMessage;
    public GameObject Content;
    private const float Space = 0.5f;
    private void Awake()
    {
        float SizeTableX = GetComponent<Transform>().transform.parent.GetComponentInParent<RectTransform>().sizeDelta.x;
        float SizeStiker = SizeTableX / 2;
        int Count = 0;
        GameObject NewButtonStiker;
        foreach (Sprite sprite in sprites)
        {
            NewButtonStiker = Instantiate(StikerPrefab, GetComponent<Transform>());
            NewButtonStiker.transform.GetChild(0).gameObject.GetComponentsInChildren<UnityEngine.UI.Image>()[0].sprite = sprite;
            NewButtonStiker.GetComponent<RectTransform>().sizeDelta = new Vector2(SizeStiker, SizeStiker);
            NewButtonStiker.GetComponent<Transform>().localPosition = new Vector2(Count % 2 != 0 ? -SizeStiker / 2 : SizeStiker / 2, -Count / 2 * SizeStiker - SizeStiker/2);
            NewButtonStiker.GetComponent<StikerScript>().Content = Content;
            NewButtonStiker.GetComponent<StikerScript>().PrefabMessage = PrefabMessage;
            NewButtonStiker.GetComponent<StikerScript>().StikerManager = GetComponent<StikerManager>();
            Count++;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
