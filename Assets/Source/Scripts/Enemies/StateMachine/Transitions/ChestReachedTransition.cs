using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestReachedTransition : Transition
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Chest chest))
            NeedTransit = true;
    }
}
