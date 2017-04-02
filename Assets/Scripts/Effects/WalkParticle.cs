using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkParticle : MonoBehaviour {

    private Animator _particleAnimator;

    void Awake()
    {
        _particleAnimator = GetComponent<Animator>();
    }

    public void ShowParticle()
    {
        _particleAnimator.SetBool ("Walking",true);
    }

    public void DisableParticle()
    {
        _particleAnimator.SetBool("Walking", false);
    }
}
