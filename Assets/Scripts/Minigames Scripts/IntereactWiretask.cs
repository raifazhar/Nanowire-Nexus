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

        MinigameSelect.Instance.setinteract(2);

        return true;
    }
    private void Start()
    {
        wireTask.instance.wiretaskcompleted += Instance_wiretaskcompleted;
    }

    private void Instance_wiretaskcompleted(object sender, EventArgs e)
    {
        Triggermanager.triggercall(puzzle);
    }

  
}
