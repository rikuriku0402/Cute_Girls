using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField]
    [Header("�L�����̖��O�e�L�X�g")]
    private Text _charaText;

    [SerializeField]
    [Header("�L�����o�X")]
    private Canvas _canvas;

    [SerializeField]
    [Header("�L����")]
    private GameObject[] _anyIdol;

    [SerializeField]
    [Header("�X�|�[���n�_")]
    private Transform _spawnPos;

    [SerializeField]
    [Header("�Q�[���X�^�[�g�{�^��")]
    private Button _gameStartButton;

    private CharacterType _type;

    private void Start()
    {
        _type = CharacterType.None;
        _gameStartButton.onClick.AddListener(() => GameStart());
    }

    public void Character(int charaNum)
    {
        switch (charaNum)
        {
            case 0:
                _type = CharacterType.Hiyori;
                _charaText.text = CharacterType.Hiyori.ToString();
                break;

            case 1:
                _type = CharacterType.Aki;
                _charaText.text = CharacterType.Aki.ToString();
                break;

            case 2:
                _type = CharacterType.Hitoka;
                _charaText.text = CharacterType.Hitoka.ToString();
                break;

            case 3:
                _type = CharacterType.Julia;
                _charaText.text = CharacterType.Julia.ToString();
                break;

            case 4:
                _type = CharacterType.Kanami;
                _charaText.text = CharacterType.Kanami.ToString();
                break;

            case 5:
                _type = CharacterType.Oharu;
                _charaText.text = CharacterType.Oharu.ToString();
                break;
        }

    }


    public void GameStart()
    {
        if (_type == CharacterType.None)
        {
            _charaText.text = "�����ɍs���L������I��ł�������";
        }
        else
        {
            GameManager.Instance.ChangeGameMode(true);
            _charaText.text = _type.ToString() + "�������ɍs��";
            _canvas.gameObject.SetActive(false);
            var anyIdol = Instantiate(_anyIdol[(int)_type], _spawnPos.position, Quaternion.identity); ;
        }
    }
}
