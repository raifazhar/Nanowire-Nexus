using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomMorseCodePrint : MonoBehaviour{


    [SerializeField] private TextMeshProUGUI MorseCodeReference;

    [SerializeField] private MorsecodeAlphabetScriptableObject morsecodeScriptableObject;

    [SerializeField] private InputField inputField;

    private string RandomWord;

    private string RandomWordCode;

    private void Start() {
        //this is just for testing. Event will be added for it to do random
        for (int i = 0; i < 5; i++) {
            int RandWordIndex = UnityEngine.Random.Range(1,26);

            RandomWord += 'A' + RandWordIndex - 1;

            RandomWordCode += morsecodeScriptableObject.AlphabetCodes[RandWordIndex-1];
            RandomWordCode += "\n";
        }
        MorseCodeReference.text = RandomWordCode;


        InputManager.Instance.OnSubmit += InputManager_OnSubmit;
    }

    private void InputManager_OnSubmit(object sender, EventArgs e) {
        if (CheckCorrectWord()) {
            Debug.Log();
        }
    }

    bool CheckCorrectWord() {
        return RandomWord == inputField.text;
    }
}