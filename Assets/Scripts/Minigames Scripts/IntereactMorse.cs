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

        MinigameSelect.Instance.setinteract(1,puzzle);

        return true;
    }
    private void Start()
    {
        MinigameSelect.Instance.OnMorseEventTrigger += Instance_OnMorseEventTrigger;
    }

    private void Instance_OnMorseEventTrigger(object sender, MinigameSelect.Morseeventtrigger e)
    {
        if(puzzle==e.puzzlesend)
        Triggermanager.triggercall(puzzle);
    }

   
}
