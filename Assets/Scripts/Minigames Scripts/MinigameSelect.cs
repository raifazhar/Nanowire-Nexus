using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinigameSelect : MonoBehaviour{


    public event EventHandler OnMorseCodeSelect;
    public event EventHandler OnWiresSelect;
    public event EventHandler onIntereact;
    
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
        onIntereact?.Invoke(this, EventArgs.Empty);
    }

    private void Instance_OnCorrectMorseCodeSubmit(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
        onIntereact?.Invoke(this, EventArgs.Empty);
    }

    public void setinteract(int selected)
    {
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
