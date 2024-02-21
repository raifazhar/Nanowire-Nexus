using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InputManager : MonoBehaviour{

    //Events for Player UI Minigames

    public event EventHandler OnUpKeyPress;
    public event EventHandler OnDownKeyPress;
    public event EventHandler OnLeftKeyPress;
    public event EventHandler OnRightKeyPress;
    public event EventHandler OnSubmit;
    public event EventHandler OnChangeToSpider;


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
        inputActions.Player.Enable();

        inputActions.Player.Up.performed += Up_performed;
        inputActions.Player.Down.performed += Down_performed;
        inputActions.Player.Left.performed += Left_performed;
        inputActions.Player.Right.performed += Right_performed;
        inputActions.Player.Submit.performed += Submit_performed;
        inputActions.Player.SwitchToSpider.performed += SwitchToSpider_performed;

        if (inputActions.Spider.enabled) {
            inputActions.Spider.SwitchToHuman.performed += SwitchToHuman_performed;
            inputActions.Spider.Interact.performed += Interact_performed;
        }
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

    private void Right_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnRightKeyPress?.Invoke(this, EventArgs.Empty);
    }

    private void Left_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnLeftKeyPress?.Invoke(this, EventArgs.Empty);
    }

    private void Down_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnDownKeyPress?.Invoke(this, EventArgs.Empty);
    }

    private void Up_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnUpKeyPress?.Invoke(this, EventArgs.Empty);
    }

    // function for spider to get movement
    Vector2 GetSpiderMovement() {
        return inputActions.Spider.Movement.ReadValue<Vector2>();
    }
}
