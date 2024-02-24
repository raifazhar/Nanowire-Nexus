using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour {
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector3 rotation;
    [SerializeField] private float senstivity;

    private void Start() {
        controller = GetComponent<CharacterController>();

        senstivity = 5f;

        rotation = transform.eulerAngles;
    }
    void Update() {
        
        rotation.y += InputManager.Instance.GetHumanLook().x * senstivity * Time.deltaTime;
        rotation.x -= InputManager.Instance.GetHumanLook().y * senstivity * Time.deltaTime;

        rotation.x = Mathf.Clamp(rotation.x,-80f,80f);

        transform.eulerAngles = rotation;
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(InputManager.Instance.GetHumanMovement().x, 0, InputManager.Instance.GetHumanMovement().y);
        move = transform.forward * move.z + transform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}