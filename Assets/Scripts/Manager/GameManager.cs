using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGame => _isGame;

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

    private void Start()
    {
        _isGame = false;
    }

    public bool ChangeGameMode(bool isGame)
    {
        _isGame = isGame;
        return _isGame;
    }
}
