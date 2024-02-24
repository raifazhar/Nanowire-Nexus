using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class TriggerList : MonoBehaviour
{
    public List<GameObject> Alltriggers;   

    public void triggercall(GameObject trigger)
    {
        Debug.Log("Reachedhere");

        for (int i = 0; i < Alltriggers.Count; i++) 
        {
            Triggerasset x = Alltriggers[i].GetComponent<Triggerasset>();
            for (int j = 0; j<x.Triggers.Count; j++)
            {
                if (x.Triggers[j].trigger==trigger)
                {
                    var temp = x.Triggers[j];
                    temp.completed= true;
                    
                    x.Triggers[j]= temp;
                }
            }
        }
    }
}
