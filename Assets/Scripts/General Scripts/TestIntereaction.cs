using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIntereaction : MonoBehaviour,IIntereactable
{
    public bool completed;
    [SerializeField] private GameObject puzzle;
    [SerializeField] private TriggerList Triggermanager;
    public bool interact(InteractCollider interactCollider)
    {
        Debug.Log("Machud");
        if(completed)
        {
            Triggermanager.triggercall(puzzle);
        }
        return true;
    }

 
}
