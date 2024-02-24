using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class gloWire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    private Image _img;
    private LineRenderer liRenderer;
    private Canvas canv;
    private wireTask wTask;

    public Color wireCol;
    public bool isSuccess = false;

    private bool isDragStarted = false;
    [SerializeField] private bool isLeftWire;


    private void Awake() {
        _img = GetComponent<Image>();
        liRenderer = GetComponent<LineRenderer>();
        canv = GetComponentInParent<Canvas>();
        wTask = GetComponentInParent<wireTask>();
    }

    private void Update() {

        if (isDragStarted) {
            Vector2 movePos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canv.transform as RectTransform,
                Input.mousePosition,
                canv.worldCamera,
                out movePos);

            //Debug.Log("Transforming, " + liRenderer.GetPosition(0) + 
            //    ", " + liRenderer.GetPosition(1));
            liRenderer.SetPosition(0, transform.position);
            liRenderer.SetPosition(1, canv.transform.TransformPoint(movePos));
        }
        else {

            if (!isSuccess) {
                liRenderer.SetPosition(0, Vector3.zero);
                liRenderer.SetPosition(1, Vector3.zero);
            }
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, canv.worldCamera);

        if (isHovered) {
            wTask.currentHoveredWire = this;
        }

    }

    public void SetColor(Color color) {
        _img.color = color;
        liRenderer.startColor = color;
        liRenderer.endColor = color;
        wireCol = color;
    }

    public void OnDrag(PointerEventData eventData) {
        // needed for drag, but not used
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (!isLeftWire) { return; }
        if (isSuccess) { return; }
        
        isDragStarted = true;
        wTask.currentDraggedWire = this;
    }

    public void OnEndDrag(PointerEventData eventData) {

        if (wTask.currentHoveredWire != null) {
            if (wTask.currentHoveredWire.wireCol == wireCol && wTask.currentHoveredWire.isLeftWire == false) {
                isSuccess = true;
                wTask.currentHoveredWire.isSuccess = true;
            }
        }

        isDragStarted = false;
        wTask.currentDraggedWire = null;
    }
}
