using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    [SerializeField]
    [Header("飛びたいシーン名")]
    const string SCENE_NAME_BATTLE = "Battle";

    public void GetEnemy()
    {
        SceneLoader.SceneChange(SCENE_NAME_BATTLE);
    }
}
