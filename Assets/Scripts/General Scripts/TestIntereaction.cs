using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIntereaction : MonoBehaviour,IIntereactable
{
    public bool interact(InteractCollider interactCollider)
    {
        Debug.Log("Machuda");
        return true;
    }

 
}
