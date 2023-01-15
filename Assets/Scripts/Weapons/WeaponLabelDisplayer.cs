using TMPro;
using UnityEngine;
using DG.Tweening;

public class WeaponLabelDisplayer : MonoBehaviour
{
    [SerializeField] private CrateSpawner _spawner;
    [SerializeField] private TMP_Text _weaponLabel;
    [SerializeField] private Player _player;

    private Tween _tween;

    private void OnEnable()
    {
        _spawner.Collected += ShowInfo;
    }

    private void OnDisable()
    {
        _spawner.Collected -= ShowInfo;
    }

    private void ShowInfo(Crate crate)
    {
        _weaponLabel.gameObject.SetActive(true);
        _weaponLabel.text = _player.GetCurrentWeaponLabel();
        transform.position = crate.transform.position;

        if (_tween != null)
            _tween.Kill();

        _tween = _weaponLabel.transform.DOLocalMoveY(1f, 0.6f).OnComplete(() => _weaponLabel.gameObject.SetActive(false));
    }
}
