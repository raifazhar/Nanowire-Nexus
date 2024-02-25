using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

public class wireTask : MonoBehaviour {

    [SerializeField] private List<Color> wireColors = new List<Color>();
    [SerializeField] private List<gloWire> leftWires = new List<gloWire>();
    [SerializeField] private List<gloWire> rightWires = new List<gloWire>();

    public gloWire currentDraggedWire;
    public gloWire currentHoveredWire;
    [SerializeField] private bool isComplete = false;
    [SerializeField] private bool reset = false;

    private List<Color> avablColors;
    private List<int> avabl_LWireIndex;
    private List<int> avabl_RWireIndex;

    public event EventHandler wiretaskcompleted;

    public static wireTask instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start() {

        gameObject.SetActive(false);
        setcolor();

        //StartCoroutine(checkIfComplete());

    }

    private void Update() {
        if (!reset)
        {
            if (!isComplete)
            {

                int successfulWires = 0;

                for (int i = 0; i < rightWires.Count; i++)
                {
                    if (rightWires[i].isSuccess)
                    {
                        successfulWires++;

                    }
                }

                if (successfulWires >= rightWires.Count)
                {
                    isComplete = true;
                    reset = true;
                    wiretaskcompleted?.Invoke(this, EventArgs.Empty);
                }

            }
           
        }
        else
        {
            setcolor();
        }

    }
    private void setcolor()
    {
        avablColors = new List<Color>(wireColors);
        avabl_LWireIndex = new List<int>();
        avabl_RWireIndex = new List<int>();

        for (int i = 0; i < leftWires.Count; i++)
        {
            avabl_LWireIndex.Add(i);
        }
        for (int i = 0; i < rightWires.Count; i++)
        {
            avabl_RWireIndex.Add(i);
        }

        while (avablColors.Count > 0 && avabl_LWireIndex.Count > 0 && avabl_RWireIndex.Count > 0)
        {

            Color pickedColor = avablColors[UnityEngine.Random.Range(0, avablColors.Count)];
            int picked_LWireIndex = UnityEngine.Random.Range(0, avabl_LWireIndex.Count);
            int picked_RWireIndex = UnityEngine.Random.Range(0, avabl_RWireIndex.Count);

            leftWires[avabl_LWireIndex[picked_LWireIndex]].SetColor(pickedColor);
            rightWires[avabl_RWireIndex[picked_RWireIndex]].SetColor(pickedColor);

            avablColors.Remove(pickedColor);
            avabl_LWireIndex.RemoveAt(picked_LWireIndex);
            avabl_RWireIndex.RemoveAt(picked_RWireIndex);

        }
        for (int i = 0; i < rightWires.Count; i++)
        {
            if (rightWires[i].isSuccess)
            {
                rightWires[i].isSuccess = false;
                leftWires[i].isSuccess = false;
                rightWires[i].liRenderer.SetPosition(0, Vector3.zero);
                rightWires[i].liRenderer.SetPosition(1, Vector3.zero);
                leftWires[i].liRenderer.SetPosition(0, Vector3.zero);
                leftWires[i].liRenderer.SetPosition(1, Vector3.zero);
            }
            


        }
        reset = false;
        isComplete = false;
    }

    private IEnumerator checkIfComplete() {

        while (!isComplete) {

            int successfulWires = 0;
            Debug.Log("Keep going");

            for (int i = 0; i < rightWires.Count; i++) {
                if (rightWires[i].isSuccess) {
                    successfulWires++;
                }
            }

            if (successfulWires >= rightWires.Count) {
                //isComplete = true;
                Debug.Log("Task Complete\n");
            }
            else {
                Debug.Log("Not complete\n");
            }

            yield return new WaitForSeconds(0.5f);

        }

    }

}
