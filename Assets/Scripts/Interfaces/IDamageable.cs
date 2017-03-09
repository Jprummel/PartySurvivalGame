using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IDamageable : IEventSystemHandler{
    
    
    void TakeDamage(Character damageSource);
}
