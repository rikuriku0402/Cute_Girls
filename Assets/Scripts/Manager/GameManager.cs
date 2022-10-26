using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const string SCENE_NAME_BATTLE = "Battle";

    public static void GameClear()
    {
        SceneLoader.SceneChange(SCENE_NAME_BATTLE);
    }

    public static void GameOver()
    {
        print("ゲームオーバー");
    }
}
