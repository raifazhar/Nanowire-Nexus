using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public static class ChangeTextPrompt
{
    public static string ReadandReplace(string texttoDisplay,InputBinding actionNeeded,TMP_SpriteAsset spriteAsset)
    {
        
        string stringButtonNames = actionNeeded.ToString();
        stringButtonNames = RenameInput(stringButtonNames);
        Debug.Log(stringButtonNames);
        texttoDisplay = texttoDisplay.Replace("BUTTONPROMOT",$"<sprite=\"{spriteAsset.name}\" name=\"{(stringButtonNames.ToUpper())}\">" );
        Debug.Log(texttoDisplay);
        return texttoDisplay;
    }

    private static string RenameInput(string stringButtonname)
    {
        stringButtonname = stringButtonname.Replace(
            "Interact:", string.Empty);
        stringButtonname = stringButtonname.Replace(
            "<Keyboard>/", string.Empty);
        return stringButtonname;

    }
}
