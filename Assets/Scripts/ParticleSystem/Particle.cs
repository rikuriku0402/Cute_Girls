using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem PlayerAttackParticle => _playerAttackParticle;

    public ParticleSystem DefenceParticle => _defenceParticle;

    public ParticleSystem MagicParticle => _magicParticle;

    public ParticleSystem RecoveryParticle => _recoveryParticle;

    public ParticleSystem MpRecoveryParticle => _mpRecoveryParticle;

    public ParticleSystem EnemyAttackParticle => _enemyAttackParticle;

    public ParticleSystem DeathblowParticle => _deathblowParticle;

    public Transform PlayerPos => _playerPos;

    public Transform EnemyPos => _enemyPos;

    [SerializeField]
    [Header("プレイヤー攻撃演出")]
    private ParticleSystem _playerAttackParticle;

    [SerializeField]
    [Header("防御演出")]
    private ParticleSystem _defenceParticle;

    [SerializeField]
    [Header("魔法演出")]
    private ParticleSystem _magicParticle;

    [SerializeField]
    [Header("体力回復演出")]
    private ParticleSystem _recoveryParticle;

    [SerializeField]
    [Header("MP回復演出")]
    private ParticleSystem _mpRecoveryParticle;

    [SerializeField]
    [Header("敵の攻撃演出")]
    private ParticleSystem _enemyAttackParticle;

    [SerializeField]
    [Header("必殺技演出")]
    private ParticleSystem _deathblowParticle;

    [SerializeField]
    [Header("プレイヤーパーティクル発生位置")]
    private Transform _playerPos;

    [SerializeField]
    [Header("敵パーティクル発生位置")]
    private Transform _enemyPos;


    public void ParticleInstantiate(ParticleSystem particle, Transform transform)
    {
        Instantiate(particle, transform.position, transform.rotation);
    }
}
