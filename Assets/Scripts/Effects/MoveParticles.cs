using UnityEngine;

public class MoveParticles : MonoBehaviour {

    private ParticleSystem _particleSystem;
    [SerializeField]private Transform _destination;
    [SerializeField]private float t;
    private float timeToReach = 0.5f;
    private Vector3 _destinationPosition;

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();

        _destinationPosition = new Vector3(_destination.position.x, _destination.position.y, gameObject.transform.position.z);
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
            Vector3 startPos = particles[i].position;

            //particles[i].position = Vector3.MoveTowards(particles[i].position, _destination.position, 0.5f);

            //divide by amount of time to reach target
            t += Time.deltaTime / timeToReach;
            particles[i].position = Vector3.Lerp(startPos, _destinationPosition, t);

            t = 0;
        }

        _particleSystem.SetParticles(particles, _particleSystem.particleCount);
    }

    public void Emit()
    {
        _particleSystem.Play();
    }


}
