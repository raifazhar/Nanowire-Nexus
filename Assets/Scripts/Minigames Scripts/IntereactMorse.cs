using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IntereactMorse : MonoBehaviour, IIntereactable
{
    [SerializeField] private GameObject puzzle;
    [SerializeField] private TriggerList Triggermanager;
    public bool interact(InteractCollider interactCollider)
    {

        MinigameSelect.Instance.setinteract();

        return true;
    }
    private void start()
    {
        RandomMorseCodePrint.instance.OnCorrectMorseCodeSubmit += Instance_OnCorrectMorseCodeSubmit;
    }

    private void Instance_OnCorrectMorseCodeSubmit(object sender, EventArgs e)
    {
        Triggermanager.triggercall(puzzle);
    }
}
