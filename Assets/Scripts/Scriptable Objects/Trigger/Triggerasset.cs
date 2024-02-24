using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct triggers
{
    public GameObject trigger;
    public bool completed;
}

public class Triggerasset:MonoBehaviour,IIntereactable
{
    public GameObject target;
    [SerializeField]public List<triggers> Triggers;

    public bool interact(InteractCollider interactCollider)
    {
        bool open = true;
        for (int i = 0; i < Triggers.Count; i++)
        {
            if (Triggers[i].completed == false)
            {
                open = false;
            }
        }
        if (open == true)
        {
            Debug.Log("Open the door");
        }
        return true;
    }
};

