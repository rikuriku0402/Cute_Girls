using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyData : MonoBehaviour
{
    #region Property

    public IntReactiveProperty Hp => _hp;

    #endregion

    #region Inspector

    [SerializeField]
    [Header("HP")]
    private IntReactiveProperty _hp = new();

    #endregion

    #region Unity Method

    public void OnDestroy()
    {
        Hp.Dispose();
    }

    #endregion

    #region Method

    /// <summary>
    /// 敵がダメージを受ける関数
    /// </summary>
    public void HpDamage(int anyValue) => Hp.Value -= anyValue;

    /// <summary>
    /// 体力を初期値に戻す関数
    /// </summary>
    public void Init()
    {
        Hp.Value = 100;
    }
    #endregion
}
