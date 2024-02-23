using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCollider : MonoBehaviour
{
    [SerializeField] private Transform intereactBody;
    [SerializeField] private float intereactradius;
    [SerializeField] private LayerMask intereactMask;

    [SerializeField] private int numFound;
    private readonly Collider[] colliders= new Collider[2];
    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(intereactBody.position, intereactradius, colliders, intereactMask);
        if(numFound> 0) 
        {
            var Intereactable=colliders[0].GetComponent<IIntereactable>();
            if (Intereactable!=null)
            {
                Intereactable.interact(this);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(intereactBody.position,intereactradius);
    }
}
