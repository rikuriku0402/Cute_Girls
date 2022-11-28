using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PlayerData : MonoBehaviour
{
    public IntReactiveProperty Hp => _hp;

    public IntReactiveProperty Mp => _mp;

    [SerializeField]
    IntReactiveProperty _hp = new IntReactiveProperty();

    [SerializeField]
    IntReactiveProperty _mp = new IntReactiveProperty();

    public virtual void HpDamage(int value) => Hp.Value -= value;

    public virtual void MpDamage(int value) => Mp.Value -= value;


    public virtual void OnDestroy()
    {
        Hp.Dispose();
        Mp.Dispose();
    }
}