using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorsecodeGameContainer : MonoBehaviour{

    [SerializeField] RandomMorseCodePrint morseCodeGame;

    private void Start() {
        gameObject.SetActive(false);

        MinigameSelect.Instance.OnMorseCodeSelect += MinigameSelect_OnMorseCodeSelect;
    }

    private void MinigameSelect_OnMorseCodeSelect(object sender, EventArgs e) {

        gameObject.SetActive(true);
    }
}
