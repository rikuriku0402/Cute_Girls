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
    [Header("�L�����̖��O�e�L�X�g")]
    private TextMeshProUGUI _charaText;

    [SerializeField]
    [Header("�X�e�[�W��ɂł�L����")]
    private GameObject[] _anyStageIdol;

    [SerializeField]
    [Header("�L�����o�X�ɔz�u����L����")]
    private Image[] _anyCanvasIdol;

    [SerializeField]
    [Header("�L�����N�^�[�{�^��")]
    private Button[] _characterButtons;

    [SerializeField]
    [Header("�X�e�[�W�X�|�[���n�_")]
    private Transform _stageSpawnPos;

    [SerializeField]
    [Header("�L�����o�X�X�|�[���n�_")]
    private Transform _canvasSpawnPos;

    [SerializeField]
    [Header("�Q�[���X�^�[�g�{�^��")]
    private Button _gameStartButton;

    [SerializeField]
    [Header("�L�����o�X�O���[�v")]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    [Header("SoundManager")]
    private SoundManager _soundManager;

    private CharacterType _type;

    private string[] _charaName = { "�Ђ��", "������", "�ЂƂ�", "�W�����G�b�g", "���Ȃ�", "�͂��" };

    private int _charaNum;

    private void Start()
    {
        for (int i = 0; i < _characterButtons.Length; i++)
        {
            var i1 = i;
            _characterButtons[i].onClick.AddListener(() => Character(i1));
        }

        _charaNum = -1;
        _type = CharacterType.None;
        _gameStartButton.onClick.AddListener(() => GameStart());

    }

    /// <summary>
    /// �����ɃL�����N�^�[��I�Ԋ֐�
    /// </summary>
    /// <param name="charaNum">�L�����N�^�[�i���o�[</param>
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
    /// �Q�[�����J�n����֐�
    /// </summary>
    private async void GameStart()
    {
        _soundManager.PlaySFX(SFXType.Button);
        if (_type == CharacterType.None)
        {
            _charaText.text = "�����ɍs���L������I��łˁI";
        }
        else
        {
            // ��x�����֎~
            _gameStartButton.interactable = false;
            for (int i = 0; i < _characterButtons.Length; i++)
            {
                _characterButtons[i].interactable = false;
            }

            var anyIdol = Instantiate(_anyCanvasIdol[(int)_type], _canvasSpawnPos.localPosition, Quaternion.identity);
            GameManager.Instance.ChangeGameMode(true);
            _charaText.text = _charaName[(int)_type] + "�������ɍs��";
            Instantiate(_anyStageIdol[(int)_type], _stageSpawnPos.position, Quaternion.identity);
            anyIdol.transform.SetParent(_canvasSpawnPos.transform, false);
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
