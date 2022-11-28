using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const string SCENE_NAME_STSGE = "Stage";

    public static GameManager Instance;

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


    public void GameClear()
    {
        print("�Q�[���N���A");
    }

    public void GameOver()
    {
        print("�Q�[���I�[�o�[");
        SceneLoader.SceneChange(SCENE_NAME_STSGE);
    }

    public GameManagerData GetGameManagerData() => _gameManagerData;
}
