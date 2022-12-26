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
    [Header("HP")]
    IntReactiveProperty _hp = new();

    [SerializeField]
    [Header("MP")]
    IntReactiveProperty _mp = new();

    #endregion

    #region Unity Method

    public void OnDestroy()
    {
        Hp.Dispose();
        Mp.Dispose();
    }

    #endregion

    #region Method

    public void HpDamage(int anyValue) => Hp.Value -= anyValue;

    public void MpDamage(int anyValue) => Mp.Value -= anyValue;

    public void MpRecovery(int anyValue) => Mp.Value += anyValue;

    #endregion
}