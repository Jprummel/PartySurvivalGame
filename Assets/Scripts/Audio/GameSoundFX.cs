using UnityEngine;

public class GameSoundFX : MonoBehaviour {

    [SerializeField]private AudioClip _warhorn;
    private AudioSource _audio;

    void Start () {
		_audio = GetComponent<AudioSource>();
	}
	
    public void PlayStartWaveSound()
    {
        if (!_audio.isPlaying)
        {
            _audio.PlayOneShot(_warhorn);
        }
    }
}
