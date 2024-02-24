using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wirecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        wireTask.instance.wiretaskcompleted += Instance_wiretaskcompleted;
        gameObject.SetActive(false);
        MinigameSelect.Instance.OnWiresSelect += Instance_OnWiresSelect;
    }

    private void Instance_wiretaskcompleted(object sender, System.EventArgs e)
    {
        gameObject.SetActive(false);
        Cursor.lockState= CursorLockMode.Locked;
    }

    private void Instance_OnWiresSelect(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
