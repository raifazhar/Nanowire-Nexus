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
    public event EventHandler OnInteract;
    public event EventHandler OnChangeToPlayer;

    //Singleton Pattern
    public static InputManager Instance { get; private set; }

    private PlayerInputActions inputActions;

    private void Awake() {
        Instance = this;
        inputActions = new PlayerInputActions();
    }

    private void Start() {
        
        inputActions.Spider.Disable();
        inputActions.PlayerMinigames.Enable();

        if (inputActions.PlayerMinigames.enabled) {
            inputActions.PlayerMinigames.Submit.performed += Submit_performed;
            inputActions.PlayerMinigames.SwitchToSpider.performed += SwitchToSpider_performed;
            inputActions.PlayerMinigames.Help.started += Help_Started;
            inputActions.PlayerMinigames.Help.canceled += Help_canceled;
        }
        
        if (inputActions.Spider.enabled) {
            inputActions.Spider.SwitchToHuman.performed += SwitchToHuman_performed;
            inputActions.Spider.Interact.performed += Interact_performed;
        }
    }

    private void Help_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnHelpFinished?.Invoke(this, EventArgs.Empty);
    }

    private void Help_Started(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnHelpStarted.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteract?.Invoke(this, EventArgs.Empty);
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
    Vector2 GetSpiderMovement() {
        if(inputActions.Spider.enabled)
            return inputActions.Spider.Movement.ReadValue<Vector2>();
        return Vector2.zero;
    }
}
