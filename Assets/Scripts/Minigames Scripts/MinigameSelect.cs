using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinigameSelect : MonoBehaviour{


    public event EventHandler OnMorseCodeSelect;
    public event EventHandler OnWiresSelect;

    
    public static MinigameSelect Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }

    private void Start() {
        gameObject.SetActive(false);
        RandomMorseCodePrint.instance.OnCorrectMorseCodeSubmit += Instance_OnCorrectMorseCodeSubmit; ;
    }

    private void Instance_OnCorrectMorseCodeSubmit(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
    }

    public void setinteract()
    {
        gameObject.SetActive(true);

        int Minigame = UnityEngine.Random.Range(1, 2);

        

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
