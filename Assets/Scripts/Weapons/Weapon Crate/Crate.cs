using UnityEngine;
using Random = UnityEngine.Random;

public class Crate : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapons;
    [SerializeField] private ParticleSystem _weaponPickedEffect;

    private int _generatedIndex;
    private int _score = 1;
    private CrateSpawner _spawner;

    public int Score => _score;
    public int GeneratedIndex => _generatedIndex;
    public string WeaponLabel => _weapons[_generatedIndex].WeaponData.Label;

    public int GetRandomWeaponIndex()
    {
        int currentIndex = Random.Range(0, _weapons.Length);

        while (_generatedIndex == currentIndex)
            currentIndex = Random.Range(0, _weapons.Length);

        _generatedIndex = currentIndex;
        return _generatedIndex;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.ChangeWeapon(GetRandomWeaponIndex());
            _spawner.InvokeEvent(this);
            this.gameObject.SetActive(false);
        }
    }

    public void SetSpawner(CrateSpawner spawner)
    {
        _spawner = spawner;
    }
}
