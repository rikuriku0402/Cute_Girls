using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerData : MonoBehaviour
{
    #region Property

    public IntReactiveProperty Hp => _hp;

    public IntReactiveProperty Mp => _mp;

    #endregion

    #region Inspector

    [SerializeField]
    [Header("�̗�(HP)")]
    private IntReactiveProperty _hp = new();

    [SerializeField]
    [Header("�}�i�|�C���g(MP)")]
    private IntReactiveProperty _mp = new();

    #endregion

    #region Unity Method

    public void OnDestroy()
    {
        Hp.Dispose();
        Mp.Dispose();
    }

    #endregion

    #region Method

    /// <summary>
    /// �v���C���[���_���[�W���󂯂�֐�
    /// </summary>
    public void HpDamage(int anyValue) => Hp.Value -= anyValue;

    /// <summary>
    /// �v���C���[Mp�����炷�֐�
    /// </summary>
    public void MpDamage(int anyValue) => Mp.Value -= anyValue;

    /// <summary>
    /// �v���C���[�̃|�[�V�������񕜂���֐�
    /// </summary>
    public void MpRecovery(int anyValue) => Mp.Value += anyValue;

    /// <summary>
    /// Hp�𑝂₷�֐�
    /// </summary>
    public void HpRecovery(int anuValue) => Hp.Value += anuValue;
    #endregion
}