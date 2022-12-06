using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyData : MonoBehaviour
{
    public IntReactiveProperty Hp => _hp;

    [SerializeField]
    [Header("“G‚Ì‘Ì—Í")]
    IntReactiveProperty _hp = new IntReactiveProperty();

    public virtual void Damage(int value) => Hp.Value -= value;

    public virtual void OnDestroy()
    {
        Hp.Dispose();
    }
}
