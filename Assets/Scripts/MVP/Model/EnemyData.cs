using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyData : MonoBehaviour
{
    public IntReactiveProperty Hp => _hp;

    [SerializeField]
    IntReactiveProperty _hp = new IntReactiveProperty();

    public virtual void HpDamage(int value) => Hp.Value -= value;

    public virtual void OnDestroy()
    {
        Hp.Dispose();
    }
}
