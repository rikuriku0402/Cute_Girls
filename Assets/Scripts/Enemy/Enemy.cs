using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IBattle
{
    [SerializeField]
    [Header("Enemy Canvas")]
    GameObject _enemyCanvas;

    public void GetBattle(GameObject panel)
    {
        _enemyCanvas.gameObject.SetActive(true);
    }

    public void EndBattle(GameObject panel)
    {
        _enemyCanvas.gameObject.SetActive(false);
    }
}