using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesScript : MonoBehaviour
{
    static private int NeedDuneGenerator;
    static private bool NeedDuneGeneratorIsSet = false;
    public static GameObject Street;
    private static Transform TouchingObject;
    void Start()
    {
        
    }

    void Update()
    {
        if (NeedDuneGenerator <= Street.GetComponent<StreetManager>().GetGeneratorIsReady())
        {
            if (NeedDuneGeneratorIsSet)
            {
                GatesOpen();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TouchingObject = GetComponent<Transform>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TouchingObject = null;
    }
    void GatesOpen()
    {
        GetComponent<Animator>().SetBool("IsOpen", true);
        GetComponent<BoxCollider2D>().enabled = false;
    }
    static public void SetNeedDuneGenerator(int Namber)
    {
        NeedDuneGenerator = Namber;
        NeedDuneGeneratorIsSet = true;
    }
    public static Transform GetTouchingObject() { return TouchingObject; }
}
