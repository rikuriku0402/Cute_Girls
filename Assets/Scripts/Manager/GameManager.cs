using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const string SCENE_NAME_STSGE = "Stage";

    public static GameManager Instance;

    private bool _isGame;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void GameClear()
    {
        print("ゲームクリア");
    }

    public void GameOver()
    {
        print("ゲームオーバー");
        SceneLoader.SceneChange(SCENE_NAME_STSGE);
    }
}
