using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StikerScript : ClassMessge
{
    private UInt32 Namber;
    public GameObject PrefabMessage;
    public StikerManager StikerManager;
    public GameObject Content;
    
    //public List<Sprite> sprites;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SendStiker()
    {
        GameObject NewMeme;
        NewMeme = Instantiate(PrefabMessage, StikerManager.Transform);
        NewMeme.GetComponent<SpriteRenderer>().sprite = StikerManager.sprites[0];
        AddMessage(NewMeme, StikerManager.sprites[0].bounds.size.x, StikerManager.sprites[0].bounds.size.y, Content);
    }
    public UInt32 GetNamber() { return Namber; }
}