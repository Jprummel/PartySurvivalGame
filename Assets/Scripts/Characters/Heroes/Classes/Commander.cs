public class Commander : PlayerCharacter {

    void Start()
    {
        _ability = GetComponent<ArrowRain>();
        Name = "Commander";
        _damageScaleFactor = 1.3f;
        _healthScaleFactor = 1.1f;
        base.Start();
    }
}
