using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour, IGoal
{
    [SerializeField]
    [Header("�S�[����ɂǂ��̃V�[���ɔ�Ԃ�")]
    string _sceneName;

    public void GoalClear()
    {
        print("�S�[��");
        SceneLoader.SceneChange(_sceneName);
    }
}
