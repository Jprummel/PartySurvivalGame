using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParticles : MonoBehaviour {

    private ParticleSystem _particleSystem;
    [SerializeField]private Transform _destination;
    [SerializeField]private float t;
    private float timeToReach = 0.5f;

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
            Vector2 startPos = particles[i].position;

            //particles[i].position = Vector3.MoveTowards(particles[i].position, _destination.position, 0.5f);

            //divide by amount of time to reach target
            t += Time.deltaTime / timeToReach;
            particles[i].position = Vector2.Lerp(startPos, _destination.position, t);

            t = 0;
        }

        _particleSystem.SetParticles(particles, _particleSystem.particleCount);
    }

    public void Emit()
    {
        _particleSystem.Play();
    }


}
