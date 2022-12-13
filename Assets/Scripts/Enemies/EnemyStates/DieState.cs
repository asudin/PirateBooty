using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    private void Start()
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
