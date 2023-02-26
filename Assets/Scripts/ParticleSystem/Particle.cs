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
    [Header("vC[Uo")]
    private ParticleSystem _playerAttackParticle;

    [SerializeField]
    [Header("häo")]
    private ParticleSystem _defenceParticle;

    [SerializeField]
    [Header("@o")]
    private ParticleSystem _magicParticle;

    [SerializeField]
    [Header("ÌÍño")]
    private ParticleSystem _recoveryParticle;

    [SerializeField]
    [Header("MPño")]
    private ParticleSystem _mpRecoveryParticle;

    [SerializeField]
    [Header("GÌUo")]
    private ParticleSystem _enemyAttackParticle;

    [SerializeField]
    [Header("KEZo")]
    private ParticleSystem _deathblowParticle;

    [SerializeField]
    [Header("vC[p[eBN­¶Êu")]
    private Transform _playerPos;

    [SerializeField]
    [Header("Gp[eBN­¶Êu")]
    private Transform _enemyPos;


    public void ParticleInstantiate(ParticleSystem particle, Transform transform)
    {
        Instantiate(particle, transform.position, transform.localRotation);
    }
}
