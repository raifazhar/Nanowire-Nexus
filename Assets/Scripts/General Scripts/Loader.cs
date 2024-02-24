using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader{

    public enum Scene{
        GameScene,
        MainMenu
    }


    public static void Load(Scene sceneName) {

        SceneManager.LoadScene(sceneName.ToString());

    }

}
