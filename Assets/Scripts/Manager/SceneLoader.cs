using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    const string SCENE_NAME_MENU = "Menu";

    GameManagerData _gameManagerData;

    void Start()
    {
        _gameManagerData = FindObjectOfType<GameManager>().GetGameManagerData();
    }

    public void GoToOtherScene(string scene)
    {
        _gameManagerData.SetNextSceneName(scene);

        SceneChange(SCENE_NAME_MENU);
    }

    public static void SceneChange(string scene) => SceneManager.LoadSceneAsync(scene);
}
