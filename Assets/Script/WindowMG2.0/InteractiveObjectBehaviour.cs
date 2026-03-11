using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class InteractiveObjectBehaviour : MonoBehaviour
{
    protected float InteractionTime {get;set; }
    protected float InteractionProgress { get; private set; }
    protected bool IsSurvInTrigger { get; private set; }
    public bool IsSurvInteracting {  get; private set; }
    public bool IsDone { get; private set; }

    private UnityEngine.UI.Image ProgressBar;
    private HintsBehaviour Hints;
    private GameObject Surv;


    protected virtual void DoWithInteraction() { }
    protected virtual void DoWithStartInteraction() { }
    protected virtual void DoWithStopInteraction() { }
    protected virtual void DoWhenDone() { }

    protected virtual void Awake()
    {
        //Если объект имеет время взаимодействия пытаемся найти ProgressBar
        if (InteractionTime > 0)
        {
            ProgressBar = GetComponent<Transform>().
            GetChild(0).
            GetChild(0).
            GetComponent<UnityEngine.UI.Image>();
            if (ProgressBar == null)
            {
                Debug.Log("ProgressBar не найден, не смотря не то, что InteractionTime > 0!");
                this.gameObject.SetActive(false);
            }
        }
        else
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
        IsSurvInTrigger = true;
        Hints.UpdateHint("Click " + KeyManager.Interaction.ToString() + " to interact");
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        IsSurvInTrigger = false;
        Hints.UpdateHint("");
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (!IsSurvInTrigger)
            goto EndUpdate;

        if (!IsSurvInteracting && Input.GetKeyDown(KeyManager.Interaction))
        {
            IsSurvInteracting = true;
            Surv.GetComponent<Transform>().position = 
                new Vector2(this.transform.position.x, Surv.GetComponent<Transform>().position.y);
            DoWithStartInteraction();
        }

        if (InteractionProgress > InteractionTime)
        {
            IsSurvInteracting = false;
            IsDone = true;
            if (ProgressBar != null) ProgressBar.fillAmount = 1;
            DoWhenDone();
        }

        if (IsSurvInteracting)
        {
            InteractionProgress += Time.deltaTime;

            if (ProgressBar != null) ProgressBar.fillAmount = InteractionProgress / InteractionTime;

            DoWithInteraction();

            if (Surv.GetComponent<SurvBehaviour>().MoveVector.x != 0)
            {
                IsSurvInteracting = false;
                DoWithStopInteraction();
            }
        }

    EndUpdate:;
    }
}
