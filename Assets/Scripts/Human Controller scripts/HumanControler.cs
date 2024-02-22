using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    private void Start() {
        controller = gameObject.GetComponent<CharacterController>();
    }
    void Update() {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(InputManager.Instance.GetHumanMovement().x, 0, InputManager.Instance.GetHumanMovement().y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero) {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}