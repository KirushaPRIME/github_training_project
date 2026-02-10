using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MemeManager : ClassMessge
{
    public List<Sprite> spriteList;
    public List<Sprite> spriteListForWork;
    public GameObject PrefabMeme;

    void Start()
    {
        AddMeme(0);
        AddMeme(1);
        AddMeme(2);
    }

    void Update()
    {
        
    }
    public bool AddMeme(uint Index)
    {
        if (Index > spriteList.Count)
        {
            return false;
        }
        GameObject NewMeme;
        NewMeme = Instantiate(PrefabMeme,GetComponent<Transform>());
        NewMeme.GetComponent<SpriteRenderer>().sprite = spriteList[(int)Index];
        //NewMeme.GetComponent<PositionButtonControl>().ResetPosition(spriteList[(int)Index].bounds.size.y);
        AddMessage(NewMeme, spriteList[(int)Index].bounds.size.x, spriteList[(int)Index].bounds.size.y, GetComponent<Transform>().gameObject);
        return true;
    }
}
