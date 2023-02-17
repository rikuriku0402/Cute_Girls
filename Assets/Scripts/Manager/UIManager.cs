using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public Canvas BattleCanvas => _battleCanvas;

    const float MOVE_Y = 50f;// �ǂ̂��炢��ɓ�����

    const float MOVE_TIME = 0.8f;// ���b�ŏ�ɍs����

    [SerializeField]
    [Header("�o�g���L�����o�X")]
    private Canvas _battleCanvas;

    [SerializeField]
    [Header("�L�����I���L�����o�X")]
    private Canvas _charaCanvas;

    [SerializeField]
    [Header("�G�̃_���[�W�e�L�X�g")]
    private Text _enemyDamageText;

    [SerializeField]
    [Header("�G�̃_���[�W�e�L�X�g")]
    private CanvasGroup _enemyText;

    [SerializeField]
    [Header("�v���C���[�̃_���[�W�e�L�X�g")]
    private Text _playerDamageText;

    [SerializeField]
    [Header("�v���C���[�̃_���[�W�e�L�X�g")]
    private CanvasGroup _playerText;

    [SerializeField]
    [Header("�I���y�[�W1")]
    private GameObject _page_1;

    [SerializeField]
    [Header("�I���y�[�W2")]
    private GameObject _page_2;

    private Vector3 _enemyTextPosition = new Vector3(-113f, -65f, 0f);// �Œ�l

    private Vector3 _playerTextPosition = new Vector3(100f, -34f, 0f);// �Œ�l

    private void Start()
    {
        _enemyDamageText.text = null;   
        _playerDamageText.text = null;   
        _battleCanvas.gameObject.SetActive(false);
        _charaCanvas.gameObject.SetActive(true);
    }

    public void EnemyDamageTextPopUp(float value)
    {
        FadeInOutText(_enemyText, _enemyDamageText, value, _enemyTextPosition);
    }

    public void PlayerDamageTextPopUp(float value)
    {
        FadeInOutText(_playerText, _playerDamageText, value, _playerTextPosition);
    }

    /// <summary>
    /// �e�L�X�g���|�b�v�A�b�v��������
    /// �\����\����؂�ւ��邽�߂̊֐�
    /// </summary>
    private void FadeInOutText(CanvasGroup canvasGroup, Text damageText, float value, Vector3 vector3)
    {
        canvasGroup.alpha = 1f;// �����l�ɖ߂�

        damageText.transform.localPosition = vector3;
        damageText.text = value.ToString();

        DOTween.Sequence()
            .Append(damageText.transform.DOLocalMoveY(MOVE_Y, MOVE_TIME))
            .Join(CanvasGroupExtensions.FadeOut(canvasGroup, MOVE_TIME));
    }

    /// <summary>
    /// �A�N�V�����I����ʂ�؂�ւ��邽�߂̊֐�
    /// </summary>
    public void ActionPageChange()
    {
        if (_page_1.activeSelf)
        {
            _page_1.gameObject.SetActive(false);
            _page_2.gameObject.SetActive(true);
        }
        else
        {
            _page_1.gameObject.SetActive(true);
            _page_2.gameObject.SetActive(false);
        }
    }
}
