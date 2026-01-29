using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeView : MonoBehaviour
{
    public List<Sprite> spriteList;
    public List<Sprite> spriteListForWork;
    public GameObject PrefabMeme;
    private float HeightContent = 10;
    private float Space = 1f;
    void Start()
    {
        AddMeme(0);
        AddMeme(1);
        AddMeme(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool AddMeme(uint Index)
    {
        if (Index > spriteList.Count)
        {
            return false;
        }
        float Height = spriteList[(int)Index].bounds.size.y;
        GameObject NewMeme;
        NewMeme = Instantiate(PrefabMeme,GetComponent<Transform>());
        NewMeme.GetComponent<SpriteRenderer>().sprite = spriteList[(int)Index];
        HeightContent = HeightContent + Height + Space;
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, HeightContent);
        NewMeme.GetComponent<RectTransform>().localPosition = new Vector2(0, -HeightContent / 2 + Height / 2);
        //GetComponent<Transform>().localPosition = Vector2.zero;
        return true;
    }
}
