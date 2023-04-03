using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public void ApplyDamage(int damage)
    {
        if (damage > 0)
        {
            _health -= damage;
        }
    }
}
