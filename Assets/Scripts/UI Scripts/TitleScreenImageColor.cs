
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenImageColor : MonoBehaviour
{

    private Graphic image;
    [SerializeField] private float TransitionSpeed = .2f;
    private void Start()
    {
        image = GetComponent<Graphic>();
    }

    // Update is called once per frame
    private void Update()
    {
        Color currentColor = image.color;

        float h, s, v;
        Color.RGBToHSV(currentColor,out h,out s,out v);

        h = (h + TransitionSpeed * Time.deltaTime);
        Color newColor = Color.HSVToRGB(h,s,v);

        image.color = newColor;
    }
}
