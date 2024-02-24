using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class wireTask : MonoBehaviour {

    [SerializeField] private List<Color> wireColors = new List<Color>();
    [SerializeField] private List<gloWire> leftWires = new List<gloWire>();
    [SerializeField] private List<gloWire> rightWires = new List<gloWire>();

    public gloWire currentDraggedWire;
    public gloWire currentHoveredWire;
    [SerializeField] private bool isComplete = false;

    private List<Color> avablColors;
    private List<int> avabl_LWireIndex;
    private List<int> avabl_RWireIndex;

    private void Start() {

        avablColors = new List<Color>(wireColors);
        avabl_LWireIndex = new List<int>();
        avabl_RWireIndex = new List<int>();

        for (int i = 0; i < leftWires.Count; i++) {
            avabl_LWireIndex.Add(i);
        }
        for (int i = 0; i < rightWires.Count; i++) {
            avabl_RWireIndex.Add(i);
        }

        while (avablColors.Count > 0 && avabl_LWireIndex.Count > 0 && avabl_RWireIndex.Count > 0) {

            Color pickedColor = avablColors[Random.Range(0, avablColors.Count)];
            int picked_LWireIndex = Random.Range(0, avabl_LWireIndex.Count);
            int picked_RWireIndex = Random.Range(0, avabl_RWireIndex.Count);

            leftWires[avabl_LWireIndex[picked_LWireIndex]].SetColor(pickedColor);
            rightWires[avabl_RWireIndex[picked_RWireIndex]].SetColor(pickedColor);

            avablColors.Remove(pickedColor);
            avabl_LWireIndex.RemoveAt(picked_LWireIndex);
            avabl_RWireIndex.RemoveAt(picked_RWireIndex);

        }

        //StartCoroutine(checkIfComplete());

    }

    private void Update() {

        if (!isComplete) {

            int successfulWires = 0;

            for (int i = 0; i < rightWires.Count; i++) {
                if (rightWires[i].isSuccess) {
                    successfulWires++;
                }
            }

            if (successfulWires >= rightWires.Count) {
                isComplete = true;
                Debug.Log("Task Complete\n");
            }

        }

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
