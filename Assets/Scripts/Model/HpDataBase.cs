using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class HpDataBase : MonoBehaviour
{
    public IntReactiveProperty Life => _life;

    IntReactiveProperty _life = new IntReactiveProperty(100);

    public virtual void AddDamage(int value) => Life.Value -= value;

    public virtual void OnDestroy()
    {
        Life.Dispose();
    }
}