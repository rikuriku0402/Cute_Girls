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


    public void ParticleInstantiate(ParticleSystem particle, Transform transform)
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
