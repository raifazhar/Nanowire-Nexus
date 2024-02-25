using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InteractCollider : MonoBehaviour
{
    [SerializeField] private Transform intereactBody;
    [SerializeField] private float intereactradius;
    [SerializeField] private LayerMask intereactMask;
    [SerializeField] private int numFound;
    private readonly Collider[] colliders= new Collider[1];
    public Canvas Foward;
    private bool isIntereactable=true;

    public delegate void onNear();
    public static event onNear OnNearIntereactable;
    public delegate void onFar();
    public static event onFar OnFarIntereactable;

    private void Start()
    {
        MinigameSelect.Instance.onIntereact += Instance_onIntereact;
    }

    private void Instance_onIntereact(object sender, System.EventArgs e)
    {
        if (isIntereactable == true)
        {
            isIntereactable = false;
        }
        else
        {
            isIntereactable = true;
        }
    }

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(intereactBody.position, intereactradius, colliders, intereactMask);
        Debug.Log(numFound);
        if(numFound> 0 && isIntereactable) 
        {
            var Intereactable=colliders[0].GetComponent<IIntereactable>();
            
            if (Intereactable!=null )
            {
                Debug.Log("Door is working");
                OnNearIntereactable?.Invoke();
                if (Input.GetKeyDown(KeyCode.Tab))
                Intereactable.interact(this);
            }
           
        }
        else
        {
            OnFarIntereactable?.Invoke();
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(intereactBody.position,intereactradius);
    }
}
