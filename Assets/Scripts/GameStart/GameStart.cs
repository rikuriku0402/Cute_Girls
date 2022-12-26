using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    GameManagerData _gameManagerData;


    void Start()
    {
        _gameManagerData = FindObjectOfType<GameManager>().GetGameManagerData();
        Instantiate(_gameManagerData.GetCharacter(), Vector3.zero, Quaternion.identity);
        print(_gameManagerData.GetCharacter().transform.name);
    }
}