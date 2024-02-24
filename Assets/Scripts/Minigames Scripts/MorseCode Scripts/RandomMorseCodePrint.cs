using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomMorseCodePrint : MonoBehaviour{


    public event EventHandler OnCorrectMorseCodeSubmit;
  

    [SerializeField] private TextMeshProUGUI MorseCodeReference;
    [SerializeField] private MorsecodeAlphabetScriptableObject morsecodeScriptableObject;
    [SerializeField] TMP_InputField inputField;

    [SerializeField] MorsecodeGameContainer morseCodeGameContainer;

    public static RandomMorseCodePrint instance ;

    

    private string RandomWord;
    private string RandomWordCode;
    char RandomCharacter;

    private void Awake()
    {
        instance = this;
    }

    private void Start() {

        inputField.text = "";
        RandomWord = "";
        RandomWordCode = "";
        for (int i = 0; i < 5; i++) {
            int RandWordIndex = UnityEngine.Random.Range(0, 25);

            RandomCharacter = (char)('A' + RandWordIndex);

            RandomWord += RandomCharacter;

            RandomWordCode += morsecodeScriptableObject.AlphabetCodes[RandWordIndex];
            RandomWordCode += "\n";
        }
        MorseCodeReference.text = RandomWordCode;


        MinigameSelect.Instance.OnMorseCodeSelect += MinigameSelect_OnMorseCodeSelect;

        InputManager.Instance.OnSubmit += InputManager_OnSubmit;

    }

    private void MinigameSelect_OnMorseCodeSelect(object sender, EventArgs e) {
        RandomWord = "";
        RandomWordCode = "";
        for (int i = 0; i < 5; i++) {
            int RandWordIndex = UnityEngine.Random.Range(0, 25);

            RandomCharacter = (char)('A' + RandWordIndex);

            RandomWord += RandomCharacter;

            RandomWordCode += morsecodeScriptableObject.AlphabetCodes[RandWordIndex];
            RandomWordCode += "\n";
        }
        MorseCodeReference.text = RandomWordCode;
    }

    private void InputManager_OnSubmit(object sender, EventArgs e) {

        if (CheckInputString()) {
           
            OnCorrectMorseCodeSubmit?.Invoke(this, EventArgs.Empty);
            
        }
        else {
            Debug.Log("Incorrect");
        }

    }

    bool CheckInputString() {
        return inputField.text == RandomWord || inputField.text == RandomWord.ToLower();
    }
}