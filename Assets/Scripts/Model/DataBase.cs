using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class DataBase : MonoBehaviour
{
    public IntReactiveProperty Life => _life;

    IntReactiveProperty _life = new IntReactiveProperty(100);

    public virtual void Damage(int value) => Life.Value -= value;


    public virtual void OnDestroy()
    {
        Life.Dispose();
    }
}