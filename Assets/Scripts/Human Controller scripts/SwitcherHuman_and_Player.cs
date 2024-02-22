using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SwitcherHuman_and_Player : MonoBehaviour{

    [SerializeField] private new GameObject gameObject;
    [SerializeField] private new CinemachineVirtualCamera camera;

    private const string HumanController = "HumanControler";
    private const string EnemyAI = "EnemyAI";

    private void Start() {
        InputManager.Instance.OnHumanInteract += InputManager_OnHumanInteract;
        InputManager.Instance.OnSpiderInteract += InputManager_OnSpiderInteract;
    }

    private void InputManager_OnSpiderInteract(object sender, EventArgs e) {
        Debug.Log("SpiderInteract");
        camera.Priority = 20;
    }

    private void InputManager_OnHumanInteract(object sender, EventArgs e) {
        Debug.Log("HumanInteract");
        camera.Priority = 5;
    }
}
