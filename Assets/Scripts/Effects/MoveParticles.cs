using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParticles : MonoBehaviour {

    private ParticleSystem _particleSystem;
    [SerializeField]private Transform _destination;

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(_particleSystem.particleCount > 0)
        {
            MoveTheParticles();
        }
    }

    void MoveTheParticles()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[_particleSystem.particleCount];
        _particleSystem.GetParticles(particles);

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].position = Vector3.MoveTowards(particles[i].position, _destination.position, 0.5f);
        }

        _particleSystem.SetParticles(particles, _particleSystem.particleCount);
    }

    public void Emit()
    {
        _particleSystem.Play();
    }

}
