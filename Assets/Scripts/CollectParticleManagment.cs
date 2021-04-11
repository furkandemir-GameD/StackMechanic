using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectParticleManagment : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer referenceObject;
    private ParticleSystem _Particle;
    public ParticleSystem _particle
    {
        get { return _Particle; }
        [SerializeField]
        private set { _Particle = value; }
    }
    void Awake() => _Particle.startColor = referenceObject.material.color;
}
