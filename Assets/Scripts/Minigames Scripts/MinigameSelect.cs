using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinigameSelect : MonoBehaviour{


    public event EventHandler OnMorseCodeSelect;
    public event EventHandler OnWiresSelect;

    private bool FirstTab = true;
    public static MinigameSelect Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }

    private void Start() {
        gameObject.SetActive(false);
        
        InputManager.Instance.OnChangeToSpider += Inputanager_OnChangeToSpider;
    }

    private void Inputanager_OnChangeToSpider(object sender, EventArgs e) {
        if (!FirstTab) {
            FirstTab = true;
            gameObject.SetActive(false);
        }
        else {
            FirstTab = false;
            
            gameObject.SetActive(true);

            int Minigame = UnityEngine.Random.Range(1, 2);

            Minigame = 2;

            if (Minigame == 1) {
                OnMorseCodeSelect?.Invoke(this, EventArgs.Empty);
            }
            else if (Minigame == 2) {
                OnWiresSelect?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
