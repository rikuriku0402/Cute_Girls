using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class DataBase : MonoBehaviour
{
    public IntReactiveProperty Hp => _hp;

    public IntReactiveProperty Mp => _mp;

    IntReactiveProperty _hp = new IntReactiveProperty(100);

    IntReactiveProperty _mp = new IntReactiveProperty(150);

    public virtual void HpDamage(int value) => Hp.Value -= value;

    public virtual void MpDamage(int value) => Mp.Value -= value;


    public virtual void OnDestroy()
    {
        Hp.Dispose();
        Mp.Dispose();
    }
}