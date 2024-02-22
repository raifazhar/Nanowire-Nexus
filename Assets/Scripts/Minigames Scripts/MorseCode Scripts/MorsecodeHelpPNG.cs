using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorsecodeHelpPNG : MonoBehaviour{
    private void Start() {
        gameObject.SetActive(false);

        InputManager.Instance.OnHelpStarted += inputManager_OnHelpStarted;
        InputManager.Instance.OnHelpFinished += InputManager_OnHelpFinished;
    }

    private void InputManager_OnHelpFinished(object sender, System.EventArgs e) {
        gameObject.SetActive(false);
    }

    private void inputManager_OnHelpStarted(object sender, System.EventArgs e) {
        gameObject.SetActive(true);
    }


}
