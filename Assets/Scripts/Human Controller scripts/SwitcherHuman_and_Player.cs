using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SwitcherHuman_and_Player : MonoBehaviour{

    [SerializeField] private  GameObject HumanGameObject;
    [SerializeField] private CinemachineVirtualCamera FPScamera;
    [SerializeField] private Transform CameraTarget;

    private HumanController human;

    private void Start() {
        InputManager.Instance.OnHumanInteract += InputManager_OnHumanInteract;
        InputManager.Instance.OnSpiderInteract += InputManager_OnSpiderInteract;
    }

    private void InputManager_OnSpiderInteract(object sender, EventArgs e) {
        FPScamera.Priority = 20;

        // Disable EnemyAI script 
        if (HumanGameObject.TryGetComponent(out EnemyAI EnemyComponent)) {
            Destroy(EnemyComponent);
        }
        else {
            Debug.LogError("No EnemyAI on this object!");
        }

        //Add the chracter controler scripts
        if(HumanGameObject.TryGetComponent(out HumanController HumanComponent)) {
            Debug.LogError("Already Exists");
        }
        else {
            human = HumanGameObject.AddComponent<HumanController>();
        }
        if (HumanGameObject.TryGetComponent(out CharacterController characterController)) {
            Debug.LogError("Character Controller already exists");
        }
        else {
            HumanGameObject.AddComponent<CharacterController>();
        }
    }

    private void InputManager_OnHumanInteract(object sender, EventArgs e) {
        FPScamera.Priority = 5;
    }
}
