using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class TextSetUp : MonoBehaviour
{

    [TextArea(2, 3)]
    [SerializeField] private string message = "Press BUTTONPROMOT to Intereact:";

    [Header("Setup For script")]
    [SerializeField] TMP_SpriteAsset spriteAsset;

    private TMP_Text textBox;
    private PlayerInputActions playerInput;

   
    

    private void Awake()
    {
        playerInput = new PlayerInputActions();
        textBox = GetComponent<TMP_Text>();
        InteractCollider.OnNearIntereactable += Settext;
        InteractCollider.OnFarIntereactable += removetext;
    }
    void Settext()
    {
        textBox.text = ChangeTextPrompt.ReadandReplace(message, playerInput.Spider.Interact.bindings[0], spriteAsset);
    }
    void removetext()
    {
        textBox.text = null;
    }
}
