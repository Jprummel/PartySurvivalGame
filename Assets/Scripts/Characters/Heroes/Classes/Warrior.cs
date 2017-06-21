public class Warrior : PlayerCharacter {

    void Start()
    {
        _ability = GetComponent<Whirlwind>();
        Name = "Warrior";
        _damageScaleFactor = 1.2f;
        _healthScaleFactor = 1.2f;
        base.Start();
    }
}
