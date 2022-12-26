using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    [Header("Button List")]
    List<Button> _buttons = new();

    [SerializeField]
    [Header("HP Slider")]
    Slider _hpSlider;

    [SerializeField]
    [Header("MP Slider")]
    Slider _mpSlider;

    [SerializeField]
    [Header("Attack Button")]
    Button _attackButton;

    [SerializeField]
    [Header("Defence Button")]
    Button _defenceButton;

    [SerializeField]
    [Header("Portion Attack Button")]
    Button _portionAttackButton;

    [SerializeField]
    [Header("Portion Recovery Button")]
    Button _portionRecoveryButton;

    [SerializeField]
    [Header("Log Text")]
    Text _logText;

    [SerializeField]
    [Header("Battle System")]
    BattleManager _battleSystem;

    #endregion

    #region Unity Method

    private void Start()
    {
        // ƒŠƒXƒg‚Åƒ{ƒ^ƒ“‚²‚Æ‚ÉŠÖ”‚ğ“o˜^‚µ‚½‚¢

        //_attackButton.onClick.AddListener(() => Attack());
        // ‚±‚ê‚ÅVoid‚Å‚àŒÄ‚Ño‚¹‚é


        _attackButton.onClick.AddListener(Attack);
        _defenceButton.onClick.AddListener(Defence);
        _portionAttackButton.onClick.AddListener(PortionAttack);
        _portionRecoveryButton.onClick.AddListener(MPRecovery);
    }

    #endregion

    #region Method

    public void SetHP(int hpCount) => _hpSlider.value = hpCount;

    public void SetMP(int mpCount) => _mpSlider.value = mpCount;

    #endregion

    #region Button Method

    /// <summary>
    /// ƒAƒ^ƒbƒNƒ{ƒ^ƒ“‚É“o˜^‚·‚éŠÖ”
    /// </summary>
    async void Attack()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "Player‚ª“G‚É" + _battleSystem.PlayerAttack + "—^‚¦‚½";
        await _battleSystem.Attack();
        _logText.text = "“G‚ªPlayer‚É" + _battleSystem.EnemyAttack + "—^‚¦‚½";
        _buttons.ForEach(x => x.interactable = true);

        #region ‚±‚ê‚Í”ğ‚¯‚½‚¢
        // ‚µ‚å‚¤‚ª‚È‚­List‚ÅŠÇ—‚µ‚Ä‚¢‚é
        //_attackButton.interactable = false;
        //_defenceButton.interactable = false;
        //_portionAttackButton.interactable = false;
        //_portionRecoveryButton.interactable = false;
        #endregion
    }

    /// <summary>
    /// –hŒäƒ{ƒ^ƒ“‚É“o˜^‚·‚éŠÖ”
    /// </summary>
    async void Defence()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "–hŒä‚µ‚½" + _battleSystem.EnemyAttack + "‚­‚ç‚Á‚½";
        await _battleSystem.Defence();
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// ƒ|[ƒVƒ‡ƒ“ƒ{ƒ^ƒ“‚É“o˜^‚·‚éŠÖ”
    /// </summary>
    async void PortionAttack()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "Player‚ª“G‚É" + _battleSystem.PortionAttack + "—^‚¦‚½";
        await _battleSystem.Portion();
        _logText.text = "“G‚ªPlayer‚É" + _battleSystem.EnemyAttack + "—^‚¦‚½";
        _buttons.ForEach(x => x.interactable = true);
    }

    /// <summary>
    /// MP‰ñ•œƒ{ƒ^ƒ“‚É“o˜^‚·‚éŠÖ”
    /// </summary>
    async void MPRecovery()
    {
        _buttons.ForEach(x => x.interactable = false);
        _logText.text = "MP‚ğ" + _battleSystem.MPPortionRecovery + "‰ñ•œ‚µ‚½";
        await _battleSystem.MPRecovery();
        _buttons.ForEach(x => x.interactable = true);
    }

    #endregion
}
