using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class SelectCharacter : MonoBehaviour
{
    public int CharaNum => _charaNum;

    [SerializeField]
    [Header("キャラの名前テキスト")]
    private Text _charaText;

    [SerializeField]
    [Header("キャラ")]
    private GameObject[] _anyIdol;

    [SerializeField]
    [Header("スポーン地点")]
    private Transform _spawnPos;

    [SerializeField]
    [Header("ゲームスタートボタン")]
    private Button _gameStartButton;

    [SerializeField]
    [Header("キャンバスグループ")]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    [Header("SoundManager")]
    private SoundManager _soundManager;

    private CharacterType _type;

    private int _charaNum;

    private void Start()
    {
        _charaNum = -1;
        _type = CharacterType.None;
        _gameStartButton.onClick.AddListener(() => GameStart());
    }

    /// <summary>
    /// 助けにキャラクターを選ぶ関数
    /// </summary>
    /// <param name="charaNum">キャラクターナンバー</param>
    public void Character(int charaNum)
    {
        _soundManager.PlaySFX(SFXType.Click);
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
        _charaNum = charaNum;
    }

    /// <summary>
    /// ゲームを開始する関数
    /// </summary>
    public async void GameStart()
    {
        _soundManager.PlaySFX(SFXType.Button);
        if (_type == CharacterType.None)
        {
            _charaText.text = "助けに行くキャラを選んでください";
        }
        else
        {
            GameManager.Instance.ChangeGameMode(true);
            _charaText.text = _type.ToString() + "を助けに行く";
            Instantiate(_anyIdol[(int)_type], _spawnPos.position, Quaternion.identity);
            await GameStartFade();
        }
    }

    private async UniTask GameStartFade()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(2f));
        CanvasGroupExtensions.FadeOut(_canvasGroup, 2f);
    }
}
