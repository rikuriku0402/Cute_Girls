using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour
{
    GameManagerData _gameManagerData;

    GameObject _gameStartButton;


    void Start()
    {
        _gameManagerData = FindObjectOfType<GameManager>().GetGameManagerData();

        _gameStartButton = transform.parent.Find("ButtonPanel/GameStart").gameObject;

        _gameStartButton.SetActive(false);
    }

    public void OnSelectCharacter(GameObject character)
    {
        EventSystem.current.SetSelectedGameObject(null);

        _gameManagerData.SetCharacter(character);

        _gameStartButton.SetActive(true);
        
    }

    public void SwitchButtonBackGround(int buttonNum)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == buttonNum - 1)
            {
                transform.GetChild(i).Find("BackGround").gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).Find("BackGround").gameObject.SetActive(false);
            }
        }
    }
}