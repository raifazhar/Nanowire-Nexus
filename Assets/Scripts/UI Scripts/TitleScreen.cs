using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{

    [SerializeField] private Button PlayButton;
    [SerializeField] private Button QuitButton;

    private void Awake() {
        PlayButton.Select();

        QuitButton.onClick.AddListener(() => {
            Application.Quit();
        });

        PlayButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.GameScene);
        });


    }
}