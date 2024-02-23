using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InputManager : MonoBehaviour{

    //Events for Player UI Minigames
    public event EventHandler OnSubmit;
    public event EventHandler OnChangeToSpider;
    public event EventHandler OnHelpStarted;
    public event EventHandler OnHelpFinished;

    //Events for Spider
    public event EventHandler OnSpiderInteract;
    public event EventHandler OnChangeToPlayer;

    //Events for Human
    public event EventHandler OnHumanInteract;

    //Singleton Pattern
    public static InputManager Instance { get; private set; }

    private PlayerInputActions inputActions;

    private void Awake() {
        Instance = this;
        inputActions = new PlayerInputActions();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start() {
        
        inputActions.Spider.Enable();
        inputActions.PlayerMinigames.Disable();
        inputActions.Human.Disable();

        inputActions.PlayerMinigames.Submit.performed += Submit_performed;
        inputActions.PlayerMinigames.SwitchToSpider.performed += SwitchToSpider_performed;
        inputActions.PlayerMinigames.Help.started += Help_Started;
        inputActions.PlayerMinigames.Help.canceled += Help_canceled;

        inputActions.Spider.SwitchToHuman.performed += SwitchToHuman_performed;
        inputActions.Spider.Interact.performed += SpiderInteract_performed;

        inputActions.Human.HumanInteract.performed += HumanInteract_performed;
    }

    private void HumanInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        
        inputActions.Spider.Enable();
        
        inputActions.Human.Disable();
        
        OnHumanInteract?.Invoke(this, EventArgs.Empty);
    }

    private void Help_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnHelpFinished?.Invoke(this, EventArgs.Empty);
    }

    private void Help_Started(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnHelpStarted.Invoke(this, EventArgs.Empty);
    }

    private void SpiderInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        inputActions.Spider.Disable();
        
        inputActions.Human.Enable();
        
        OnSpiderInteract?.Invoke(this, EventArgs.Empty);
        
    }

    private void SwitchToHuman_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnChangeToPlayer?.Invoke(this, EventArgs.Empty);
    }

    private void SwitchToSpider_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnChangeToSpider?.Invoke(this, EventArgs.Empty);
    }

    private void Submit_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnSubmit?.Invoke(this, EventArgs.Empty);
    }

    // function for spider to get movement
    public Vector2 GetSpiderMovement() {
        if(inputActions.Spider.enabled)
            return inputActions.Spider.Movement.ReadValue<Vector2>();
        return Vector2.zero;
    }

    public Vector2 GetSpiderLook() {
        if (inputActions.Spider.enabled)
            return inputActions.Spider.MouseLook.ReadValue<Vector2>();
        return Vector2.zero;
    }

    public Vector2 GetHumanMovement() {
        if (inputActions.Human.enabled) {
            return inputActions.Human.Movement.ReadValue<Vector2>();
        }
        return Vector2.zero;
    }

    public Vector2 GetHumanLook() {
        if (inputActions.Human.enabled) {
            return inputActions.Human.Look.ReadValue<Vector2>();
        }
        return Vector2.zero;
    }
}
