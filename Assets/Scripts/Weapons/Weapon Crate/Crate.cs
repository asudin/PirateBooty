using TMPro;
using UnityEngine;
using DG.Tweening;

public class Crate : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapons;
    [SerializeField] private TMP_Text _weaponLabel;

    private int _generatedIndex;
    private Tween _tween;

    public int GetRandomWeaponIndex()
    {
        int currentIndex = Random.Range(0, _weapons.Length);

        while (_generatedIndex == currentIndex)
            currentIndex = Random.Range(0, _weapons.Length);

        _generatedIndex = currentIndex;
        ShowInfo();
        return _generatedIndex;
    }

    private void ShowInfo()
    {
        _weaponLabel.text = _weapons[_generatedIndex].WeaponData.Label;
        ResetPosition();
        _weaponLabel.gameObject.SetActive(true);

        if (_tween != null)
            _tween.Kill();
        _tween = _weaponLabel.transform.DOLocalMoveY(2, 2f).OnComplete(() => _weaponLabel.gameObject.SetActive(false));
    }

    private void ResetPosition()
    {
        _weaponLabel.transform.position = transform.position;
    }
}
