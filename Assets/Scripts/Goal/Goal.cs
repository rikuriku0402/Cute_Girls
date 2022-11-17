using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour, IGoal
{
    [SerializeField]
    [Header("ゴール後にどこのシーンに飛ぶか")]
    string _sceneName;

    public void GoalClear()
    {
        print("ゴール");
        SceneLoader.SceneChange(_sceneName);
    }
}
