using UnityEngine.EventSystems;

public interface IDamageable : IEventSystemHandler{
    
    
    void TakeDamage(Character damageSource);
}
