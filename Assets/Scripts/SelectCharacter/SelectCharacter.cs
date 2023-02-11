using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField]
    [Header("キャラの名前テキスト")]
    private Text _charaText;

    [SerializeField]
    [Header("キャンバス")]
    private Canvas _canvas;

    [SerializeField]
    [Header("キャラ")]
    private GameObject[] _anyIdol;

    [SerializeField]
    [Header("スポーン地点")]
    private Transform _spawnPos;

    [SerializeField]
    [Header("ゲームスタートボタン")]
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
            _charaText.text = "助けに行くキャラを選んでください";
        }
        else
        {
            GameManager.Instance.ChangeGameMode(true);
            _charaText.text = _type.ToString() + "を助けに行く";
            _canvas.gameObject.SetActive(false);
            var anyIdol = Instantiate(_anyIdol[(int)_type], _spawnPos.position, Quaternion.identity); ;
        }
    }
}
