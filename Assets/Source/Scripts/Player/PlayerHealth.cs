using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] 
    public int MaxHealth { get; private set; }
    public int Health { get; private set; }
    public event UnityAction<int, int> Changed;
    public event UnityAction Die;

    private void Start()
    {
        Health = MaxHealth;
        //Changed?.Invoke(Health, MaxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            return;

        Health -= damage;
        Changed?.Invoke(Health, MaxHealth);

        if (Health <= 0)
        {
            Destroy(gameObject);
            //Die?.Invoke();
        }
    }
}
