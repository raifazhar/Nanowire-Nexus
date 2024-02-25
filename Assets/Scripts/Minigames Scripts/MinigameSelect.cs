using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Cinemachine.DocumentationSortingAttribute;

public class MinigameSelect : MonoBehaviour{

    public class Morseeventtrigger: EventArgs
    {
        public GameObject puzzlesend;
    }
    public class Wireeventtrigger : EventArgs
    {
        public GameObject puzzlesend;
    }

    public event EventHandler OnMorseCodeSelect;
    public event EventHandler OnWiresSelect;
    public event EventHandler onIntereact;
    public event EventHandler<Morseeventtrigger> OnMorseEventTrigger;
    public event EventHandler<Wireeventtrigger> OnWireEventTrigger;
    public GameObject puzzle;
    public static MinigameSelect Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }

    private void Start() {
        gameObject.SetActive(false);
        RandomMorseCodePrint.instance.OnCorrectMorseCodeSubmit += Instance_OnCorrectMorseCodeSubmit;
        wireTask.instance.wiretaskcompleted += Instance_wiretaskcompleted;
    }

    private void Instance_wiretaskcompleted(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
        OnWireEventTrigger?.Invoke(this, new Wireeventtrigger { puzzlesend = puzzle });
        onIntereact?.Invoke(this, EventArgs.Empty);
    }

    private void Instance_OnCorrectMorseCodeSubmit(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
        OnMorseEventTrigger?.Invoke(this, new Morseeventtrigger { puzzlesend=puzzle});
        onIntereact?.Invoke(this, EventArgs.Empty);
    }

    public void setinteract(int selected,GameObject obj)
    {
        puzzle=obj;
        gameObject.SetActive(true);
        onIntereact?.Invoke(this,EventArgs.Empty);

        int Minigame = selected;
        if (Minigame == 1)
        {
            OnMorseCodeSelect?.Invoke(this, EventArgs.Empty);
        }
        else if (Minigame == 2)
        {
            OnWiresSelect?.Invoke(this, EventArgs.Empty);
        }
    }

}

