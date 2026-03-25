using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class InteractiveObjectBehaviour : MonoBehaviour
{
    public delegate void Iteration(object Ob, EventArgs args);
    public static event Iteration StartInteraction;

    public float InteractionTime {get;set; }
    protected float InteractionProgress { get; private set; }
    protected bool IsSurvInTrigger { get; set; }
    protected GameObject Surv { get; private set; }
    public bool IsSurvInteracting {  get; private set; }
    public bool IsDone { get; private set; }

    protected bool HaveProgressBar;
    private UnityEngine.UI.Image ProgressBar;
    private HintsBehaviour Hints;
    


    protected virtual void DoWithInteraction() { }
    protected virtual void DoWithStartInteraction() { }
    protected virtual void DoWithStopInteraction() { }
    protected virtual void DoWhenDone() { }

    protected virtual void Awake()
    {
        gameObject.tag = "InteractiveObject";

        if (HaveProgressBar)
            try
            {
                ProgressBar = GetComponent<Transform>().
                GetChild(0).
                GetChild(0).
                GetComponent<UnityEngine.UI.Image>();
            }
            catch
            {
                Console.Error.WriteLine("Не удалось найти объект ProgressBar");
                Debug.Log("Не удалось найти объект ProgressBar");
            }

        if (InteractionTime < 0)
        {
            Debug.Log("Время взаимодействия не может быть отрицательным!");
            InteractionTime = 0;

        }


        Hints = GameObject.Find("Hints").GetComponent<HintsBehaviour>();
        if (Hints == null)
        {
            Debug.Log("Объект Hints не найден!");
            this.gameObject.SetActive(false);
        }

        Surv = GameObject.Find("Surv");
        if (Surv == null)
        {
            Debug.Log("Объект Surv не найден!");
            this.gameObject.SetActive(false);
        }
        InteractionProgress = 0;
        IsSurvInTrigger = false;
        IsSurvInteracting = false;
        IsDone = false;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Surv")
        {
            IsSurvInTrigger = true;
            Hints.UpdateHint(true, HintsBehaviour.TypeMessage.BaseIteraction);
        }
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Surv")
        {
            IsSurvInTrigger = false;
            Hints.UpdateHint(false, HintsBehaviour.TypeMessage.BaseIteraction);
        }
    }
    void Update()
    {
        if (!IsSurvInTrigger || IsDone)
            goto EndUpdate;

        if (!IsSurvInteracting && Input.GetKey(KeyManager.Interaction))
        {
            IsSurvInteracting = true;
            Surv.GetComponent<Transform>().position = 
                new Vector2(this.transform.position.x, Surv.GetComponent<Transform>().position.y);
            if(StartInteraction != null) StartInteraction(this, new EventArgs());
            DoWithStartInteraction();
        }

        if (InteractionProgress > InteractionTime)
        {
            IsSurvInteracting = false;
            IsDone = true;
            if (HaveProgressBar) ProgressBar.fillAmount = 1;
            DoWhenDone();
        }

        if (IsSurvInteracting)
        {
            InteractionProgress += Time.deltaTime;

            if (HaveProgressBar) ProgressBar.fillAmount = InteractionProgress / InteractionTime;

            DoWithInteraction();

            if (Surv.GetComponent<SurvBehaviour>().MoveVector.x != 0)
            {
                IsSurvInteracting = false;
                Debug.Log(IsSurvInteracting);
                DoWithStopInteraction();
            }
        }

    EndUpdate:;
    }
}
