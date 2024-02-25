using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntereactWiretask : MonoBehaviour,IIntereactable
{

    [SerializeField] private GameObject puzzle;
    [SerializeField] private TriggerList Triggermanager;
    public bool interact(InteractCollider interactCollider)
    {

        MinigameSelect.Instance.setinteract(2, puzzle);

        return true;
    }

    private void Start()
    {
        MinigameSelect.Instance.OnWireEventTrigger += Instance_OnWireEventTrigger;
    }

    private void Instance_OnWireEventTrigger(object sender, MinigameSelect.Wireeventtrigger e)
    {
        if (puzzle == e.puzzlesend)
            Triggermanager.triggercall(puzzle);
    }
}
