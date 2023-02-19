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
    [Header("�v���C���[�U�����o")]
    private ParticleSystem _playerAttackParticle;

    [SerializeField]
    [Header("�h�䉉�o")]
    private ParticleSystem _defenceParticle;

    [SerializeField]
    [Header("���@���o")]
    private ParticleSystem _magicParticle;

    [SerializeField]
    [Header("�̗͉񕜉��o")]
    private ParticleSystem _recoveryParticle;

    [SerializeField]
    [Header("MP�񕜉��o")]
    private ParticleSystem _mpRecoveryParticle;


    public void ParticleInstantiate(ParticleSystem particle, Transform transform)
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
