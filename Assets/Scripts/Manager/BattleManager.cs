using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class BattleManager : MonoBehaviour
{
    #region Property

    public int PlayerAttack => _playerAttack;

    public int EnemyAttack => _enemyAttack;

    public int MagicAttack => _magicAttack;

    public int MPPortionRecovery => _mpRecovery;

    public int HPPoritonRecovery => _hpRecovery;

    public int AllDamage => _allDamage;

    #endregion

    #region Const

    const float WAIT_TIME = 1.2f;

    #endregion

    #region Inspector

    [SerializeField]
    [Header("Player Data")]
    PlayerData _playerData;

    [SerializeField]
    [Header("Enemy Data")]
    private EnemyData _enemyData;

    [SerializeField]
    [Header("防御力")]
    private int _defence;

    [SerializeField]
    [Header("プレイヤー攻撃力")]
    private int _playerAttack;

    [SerializeField]
    [Header("魔法攻撃力")]
    private int _magicAttack;

    [SerializeField]
    [Header("どのくらいMPを回復させるか")]
    private int _mpRecovery;

    [SerializeField]
    [Header("どのくらいHPを回復させるか")]
    private int _hpRecovery;

    [SerializeField]
    [Header("消費MP")]
    private int _portionMp;

    [SerializeField]
    [Header("敵の攻撃力")]
    private int _enemyAttack;

    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;

    [SerializeField]
    [Header("SoundManager")]
    private SoundManager _soundManager;

    [SerializeField]
    [Header("SceneManager")]
    private SceneLoader _sceneLoader;

    private int _allDamage;

    #endregion

    #region Method

    /// <summary>
    /// 攻撃する関数
    /// </summary>
    public async UniTask Attack()
    {
        _soundManager.PlaySFX(SFXType.Attack);
        Debug.Log("敵に攻撃");
        _enemyData.HpDamage(_playerAttack);
        _uiManager.EnemyDamageTextPopUp(_playerAttack);
        _uiManager.LogText.text = "Playerが敵に" + _playerAttack + "与えた";
        await UniTask.Delay(TimeSpan.FromSeconds(WAIT_TIME));
        _uiManager.LogText.text = "敵がPlayerに" + _enemyAttack + "与えた";
        BattleCheck();
        _uiManager.PlayerDamageTextPopUp(_enemyAttack);
        _playerData.HpDamage(_enemyAttack);
        BattleCheck();
    }

    /// <summary>
    /// 防御する関数
    /// </summary>
    public async UniTask Defence()
    {

        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MPが足りないよ");
            _uiManager.LogText.text = "MPが足りないよ";
            _playerData.Mp.Value = 0;
            return;
        }
        else if (_playerData.Mp.Value <= _portionMp)
        {
            Debug.Log("MPが足りないよ");
            _uiManager.LogText.text = "MPが足りないよ"; 
            return;
        }
        else
        {
            _allDamage = 0;
            _soundManager.PlaySFX(SFXType.Defence);
            _playerData.MpDamage(_portionMp);
            Debug.Log("防御");
            await UniTask.Delay(TimeSpan.FromSeconds(WAIT_TIME));
            BattleCheck();
            _allDamage = _enemyAttack - _defence;
            _uiManager.PlayerDamageTextPopUp(_allDamage);
            _playerData.HpDamage(_allDamage);
            _uiManager.LogText.text = "防御した" + _allDamage + "くらった";
            BattleCheck();
        }
    }

    /// <summary>
    /// ポーションで攻撃する関数
    /// </summary>
    public async UniTask Magic()
    {
        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MPが足りないよ");
            _uiManager.LogText.text = "MPが足りないよ";
            _playerData.Mp.Value = 0;
            return;
        }
        else if (_playerData.Mp.Value <= _portionMp)
        {
            Debug.Log("MPが足りないよ");
            _uiManager.LogText.text = "MPが足りないよ";
            return;
        }
        else
        {
            _soundManager.PlaySFX(SFXType.Portion);
            _enemyData.HpDamage(_magicAttack);
            _playerData.MpDamage(_portionMp);
            _uiManager.EnemyDamageTextPopUp(_magicAttack);
            _uiManager.LogText.text = "Playerが敵に" + _magicAttack + "与えた";
            await UniTask.Delay(TimeSpan.FromSeconds(WAIT_TIME));
            _uiManager.LogText.text = "敵がPlayerに" + _enemyAttack + "与えた";
            BattleCheck();
            _uiManager.PlayerDamageTextPopUp(_enemyAttack);
            _playerData.HpDamage(_enemyAttack);
            BattleCheck();
        }
    }

    /// <summary>
    /// ポーションを回復する関数
    /// </summary>
    public async UniTask MPRecovery()
    {
        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MPが足りないよ");
            _uiManager.LogText.text = "MPが足りないよ";
            _playerData.Mp.Value = 0;
        }
        else if (_playerData.Mp.Value >= 150)
        {
            _playerData.Mp.Value = 150;
            _uiManager.LogText.text = "MPがマックスだよ";
            return;
        }

        _allDamage = 0;
        _soundManager.PlaySFX(SFXType.PoritionRecovery);
        _playerData.MpRecovery(_mpRecovery);
        _uiManager.LogText.text = "MPを" + _mpRecovery + "回復した";
        await UniTask.Delay(TimeSpan.FromSeconds(WAIT_TIME));
        _uiManager.LogText.text = "敵がPlayerに" + _allDamage + "与えた";
        BattleCheck();
        _allDamage = _enemyAttack + 3;// マジックナンバー
        _uiManager.PlayerDamageTextPopUp(_allDamage);
        _playerData.HpDamage(_allDamage);

        if (_playerData.Mp.Value >= 150)
        {
            Debug.Log("MPマックス");
            _playerData.Mp.Value = 150;
        }
        BattleCheck();
    }

    /// <summary>
    /// HPを回復する関数
    /// </summary>
    public async UniTask HPRecovery()
    {
        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MPが足りないよ");
            _uiManager.LogText.text = "MPが足りないよ";
            _playerData.Mp.Value = 0;
            return;
        }
        else if (_playerData.Mp.Value <= _portionMp)
        {
            _uiManager.LogText.text = "MPが足りないよ";
            return;
        }
        else if (_playerData.Hp.Value >= 100)
        {
            Debug.Log("HPマックス");
            _uiManager.LogText.text = "HPマックスだよ";
            _playerData.Hp.Value = 100;
            return;
        }
        else
        {
            _allDamage = 0;

            _soundManager.PlaySFX(SFXType.HpRecovery);
            _allDamage = _enemyAttack + 3;// マジックナンバー
            _playerData.MpDamage(_portionMp);
            _playerData.HpRecovery(_hpRecovery);

            if (_playerData.Hp.Value >= 100)
            {
                Debug.Log("HPマックス");
                _uiManager.LogText.text = "HPマックスだよ";
                _playerData.Hp.Value = 100;
            }

            _uiManager.LogText.text = "HPを" + _hpRecovery + "回復した";
            await UniTask.Delay(TimeSpan.FromSeconds(WAIT_TIME));
            _uiManager.LogText.text = "敵がPlayerに" + _allDamage + "与えた";
            BattleCheck();
            _uiManager.PlayerDamageTextPopUp(_allDamage);
            _playerData.HpDamage(_allDamage);

            BattleCheck();
        }
    }

    /// <summary>
    /// 体力をチェックして
    /// ゲームクリアかゲームオーバーかを
    /// 監視する関数
    /// </summary>
    private void BattleCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            Debug.Log("ゲームオーバー");
            _soundManager.PlayBGM(BGMType.GameOver);
            _sceneLoader.FadeInSceneChange("GameOver");
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            Debug.Log("ゲームクリア");
            _soundManager.PlaySFX(SFXType.BattleWin);
            _soundManager.PlayBGM(BGMType.Game);
            _enemyData.Init();
            _uiManager.CanvasFalse();
        }
        else
        {
            Debug.Log("まだゲームは終わっていないよ！");
        }
    }

    private void HpCheck()
    {
        if (_playerData.Hp.Value >= 100)
        {
            Debug.Log("HPマックス");
            _playerData.Hp.Value = 100;
            return;
        }
    }

    private void MpCheck()
    {
        if (_playerData.Mp.Value <= 0)
        {
            Debug.Log("MPが足りないよ");
            _playerData.Mp.Value = 0;
            return;
        }
    }

    #endregion
}
