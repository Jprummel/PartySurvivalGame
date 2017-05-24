using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParticles : MonoBehaviour {

    private ParticleSystem _particleSystem;
    private ParticleEmitter _emitter;
    [SerializeField]private Transform _destination;
    [SerializeField]private int _particleSpeed;

	// Use this for initialization
	void Start () {
        _particleSystem = GetComponent<ParticleSystem>();
        _emitter = GetComponent<ParticleEmitter>();
	}
	
	public void SpawnParticles()
    {
        _particleSystem.Play();

        Particle[] particles = _emitter.particles;

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].position = Vector3.MoveTowards(_emitter.particles[i].position, _destination.position, Time.deltaTime * _particleSpeed);
        }

        _emitter.particles = particles;
    }
}
