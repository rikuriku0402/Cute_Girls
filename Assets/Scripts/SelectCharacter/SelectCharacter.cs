using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;
using TMPro;

public class SelectCharacter : MonoBehaviour
{
    public int CharaNum => _charaNum;
    
    [SerializeField]
    [Header("キャラの名前テキスト")]
    private TMP_Text _charaText;

    [SerializeField]
    [Header("キャラクターボタン")]
    private Button[] _characterButtons;

    [SerializeField]
    [Header("ゲームスタートボタン")]
    private Button _gameStartButton;

    [SerializeField]
    [Header("キャンバスグループ")]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    [Header("SoundManager")]
    private SoundManager _soundManager;
    
    [SerializeField]
    [Header("ステージ")]
    private StageData _stageData;

    private CharacterType _type;

    private string[] _charaName = { "ひよみ", "あきこ", "ひとり", "ジュリエット", "かなえ", "はるみ" };

    private int _charaNum;

    private void Start()
    {
        for (int i = 0; i < _characterButtons.Length; i++)
        {
            var i1 = i;
            Debug.Log(_characterButtons.Length);
            _characterButtons[i].onClick.AddListener(() => Character(i1));
            if (i < _stageData.StageUnlock) _characterButtons[i].interactable = true;
            else _characterButtons[i].interactable = false;
        }
        
        

        _charaNum = -1;
        _type = CharacterType.None;
        _gameStartButton.onClick.AddListener(() => GameStart());

    }

    /// <summary>
    /// 助けにキャラクターを選ぶ関数
    /// </summary>
    /// <param name="charaNum">キャラクターナンバー</param>
    private void Character(int charaNum)
    {
        _soundManager.PlaySFX(SFXType.Click);
        switch (charaNum)
        {
            case 0:
                _type = CharacterType.Hiyori;
                _charaText.text = _charaName[(int)_type];
                break;

            case 1:
                _type = CharacterType.Aki;
                _charaText.text = _charaName[(int)_type];
                break;

            case 2:
                _type = CharacterType.Hitoka;
                _charaText.text = _charaName[(int)_type];
                break;

            case 3:
                _type = CharacterType.Julia;
                _charaText.text = _charaName[(int)_type];
                break;

            case 4:
                _type = CharacterType.Kanami;
                _charaText.text = _charaName[(int)_type];
                break;

            case 5:
                _type = CharacterType.Oharu;
                _charaText.text = _charaName[(int)_type];
                break;
        }

        _charaNum = charaNum;
    }

    /// <summary>
    /// ゲームを開始する関数
    /// </summary>
    private async void GameStart()
    {
        _soundManager.PlaySFX(SFXType.Button);
        
        if (_type == CharacterType.None)
        {
            _charaText.text = "助けに行くキャラを選んでね！";
        }
        else
        {
            // 二度押し禁止
            _gameStartButton.interactable = false;
            for (int i = 0; i < _characterButtons.Length; i++)
            {
                _characterButtons[i].interactable = false;
            }

            GameManager.Instance.ChangeGameMode(true);
            _charaText.text = _charaName[(int)_type] + "を助けに行く";
            await GameStartFade();
        }
    }

    private async UniTask GameStartFade()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        CanvasGroupExtensions.FadeOut(_canvasGroup, 1f);
        await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
        _canvasGroup.gameObject.SetActive(false);
    }
}
