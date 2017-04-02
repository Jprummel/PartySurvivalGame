using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScreen : MonoBehaviour {

    [SerializeField]private GameObject _mapEventSystem;
    [SerializeField]private List<CharacterSelect> _characterSelect = new List<CharacterSelect>();
    private Animator _animator;
    
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
    public IEnumerator SwitchToCharacterSelect()
    {
        //Animation slide to character select
        _animator.SetBool("SwitchToCharSelect", true);
        _animator.SetBool("SwitchToMap", false);
        yield return new WaitForSeconds(1); //Wait a second
        for (int i = 0; i < _characterSelect.Count; i++)
        {
            _characterSelect[i].CharacterSelectState = true; //Tells every character select script that they are in the character select state
        }
    }

    public IEnumerator SwitchToMapSelect()
    {
        //Animation slide to map select
        _animator.SetBool("SwitchToMap", true);
        _animator.SetBool("SwitchToCharSelect", false);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < _characterSelect.Count; i++)
        {
            _characterSelect[i].CharacterSelectState = false; //Tells every character select script that they are not in the character select state anymore
        }
        _mapEventSystem.SetActive(true); //Enables the eventsystem in the map selection screen
    }
}
