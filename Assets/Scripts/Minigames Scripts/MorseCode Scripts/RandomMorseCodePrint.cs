using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomMorseCodePrint : MonoBehaviour{


    [SerializeField] private TextMeshProUGUI MorseCodeReference;

    [SerializeField] private MorsecodeAlphabetScriptableObject morsecodeScriptableObject;

    private string RandomWord;

    private string RandomWordCode;

    [SerializeField] TMP_InputField inputField;

    char RandomCharacter;
    private void Start() {
        //this is just for testing. Event will be added for it to do random
        for (int i = 0; i < 5; i++) {
            int RandWordIndex = UnityEngine.Random.Range(1,26);

            RandomCharacter = (char)('A' + RandWordIndex - 1);

            RandomWord += RandomCharacter;
            
            RandomWordCode += morsecodeScriptableObject.AlphabetCodes[RandWordIndex-1];
            RandomWordCode += "\n";
        }
        MorseCodeReference.text = RandomWordCode;


        InputManager.Instance.OnSubmit += InputManager_OnSubmit;
    }

    private void InputManager_OnSubmit(object sender, EventArgs e) {

        if (CheckInputString()) {
            Debug.Log("Correct");
        }
        else {
            Debug.Log("Incorrect");
        }
    }

    bool CheckInputString() {
        return inputField.text == RandomWord || inputField.text == RandomWord.ToLower();
    }
}