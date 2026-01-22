using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManScript : MonoBehaviour
{
    public God God;
    public GameObject SSSGhoul;
    public SkillCheakManager SkillCheakManager;
    public StreetManager StreetManager;
    private float NeedDistance = 10;
    private float DynamicNeedDistance = 10;
    private float RealDistance;
    private float NormalSpeed = 6;
    private float FastSpeed = 11;
    private float CurrentSpeed;
    private bool IFindYou = false;
    private bool ICheckedItOut = false;
    private float WalkPurepouse;


    void Start()
    {
        WalkPurepouse = GetComponent<Transform>().localPosition.x;
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (StreetManager.GetInstalized())
        {
            RealDistance = SSSGhoul.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x;
            
            if (DynamicNeedDistance > Mathf.Abs(RealDistance) && !SSSGhoul.GetComponent<SSS_Ghoul_Script>().GetIHid())
            {
                iAmComingForYou();
            }
            else if (IFindYou && SSSGhoul.GetComponent<SSS_Ghoul_Script>().GetIHid())
            {
                iAmComingForYou();
            }
            else if (!ICheckedItOut && SkillCheakManager.GetSkillCheackReady() && !SkillCheakManager.GetSkillCheackResult())
            {
                cheakThere();
            }
            else
            {
                walkingOnTheMap();
            }
            if (!SkillCheakManager.GetSkillCheackReady()) { ICheckedItOut = false; }
            GetComponent<Rigidbody2D>().velocity = new Vector2(CurrentSpeed, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SSS_Ghoul_Script>() != null)
        {
            if (!SSSGhoul.GetComponent<SSS_Ghoul_Script>().GetIHid())
            {
                IKilledHim();
            }
            else if (IFindYou)
            {
                getHim();
            }
        }
    }
    private void iAmComingForYou()
    {
        IFindYou = true;
        if (RealDistance > 0)
        {
            CurrentSpeed = FastSpeed;
        } else
        {
            CurrentSpeed = -FastSpeed;
        }
    }
    private void IKilledHim()
    {
        Debug.Log("AHAHAHAHAHA");
    }
    private void getHim()
    {
        Debug.Log("Hello)");
    }
    private void cheakThere()
    {
        float A = SkillCheakManager.GetPositiomGenerator() - GetComponent<Transform>().localPosition.x;
        if (Mathf.Abs(A) > 1)
        {
            if (A > 0)
            {
                CurrentSpeed = FastSpeed;
            } else { CurrentSpeed = -FastSpeed; }
        }
        else
        {
            CurrentSpeed = 0;
            ICheckedItOut = true;
        }
    }
    private void walkingOnTheMap()
    {
        float A = WalkPurepouse - GetComponent<Transform>().localPosition.x;
        if (Mathf.Abs(A) < 1)
        {
            WalkPurepouse = StreetManager.GetGenerator(Random.Range(0, God.GetCountGenerator())).GetComponent<Transform>().localPosition.x;
        }
        else
        {
            if (A > 0) { CurrentSpeed = NormalSpeed; }
            else { CurrentSpeed = -NormalSpeed; }
        }
    }
    public void setNeedDistance(float NeedDistance) { this.NeedDistance = NeedDistance; }
    public float GetNeedDistance() {  return this.NeedDistance; }
    public void SetDynamicNeedDistance(float DynamicNeedDistance) { this.DynamicNeedDistance = DynamicNeedDistance; }
    public void setNormalSpeed(float NormalSpeed) { this.NormalSpeed = NormalSpeed; }
    public void setFastSpeed(float FastSpeed) { this.FastSpeed = FastSpeed; }
    public float GetRealDistance() {  return RealDistance; }
}
