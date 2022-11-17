using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const string SCENE_NAME_STSGE = "Stage";

    static GameManager Instance;

    [SerializeField]
    GameManagerData _gameManagerData;

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


    public static void GameClear()
    {

    }

    public static void GameOver()
    {
        print("ゲームオーバー");
        SceneLoader.SceneChange("Stage");
    }

    public GameManagerData GetGameManagerData() => _gameManagerData;
}
