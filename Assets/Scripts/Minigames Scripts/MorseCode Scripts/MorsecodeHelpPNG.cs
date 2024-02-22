using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorsecodeHelpPNG : MonoBehaviour{

    [SerializeField] MorsecodeGameContainer morseCodeGameContainer;

    private void Start() {
        gameObject.SetActive(false);

        InputManager.Instance.OnHelpFinished += InputManager_OnHelpFinished;
        InputManager.Instance.OnHelpStarted += inputManager_OnHelpStarted;
    }

    private void InputManager_OnHelpFinished(object sender, System.EventArgs e) {
        gameObject.SetActive(false);
    }

    private void inputManager_OnHelpStarted(object sender, System.EventArgs e) {
        gameObject.SetActive(true);
    }


}
