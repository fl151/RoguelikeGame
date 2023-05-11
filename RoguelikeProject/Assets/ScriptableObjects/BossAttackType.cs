using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BossAttackType", fileName = "BossAttackState", order = 52)]
public class BossAttackType : ScriptableObject
{
    [SerializeField] private int _countBullets;
    [SerializeField] private float _angleChange;
    [SerializeField] private float _delay;
    [SerializeField] private float _delayAfter;

    public int Count => _countBullets;
    public float Angle => _angleChange;
    public float Delay => _delay;
    public float DelayAfter => _delayAfter;
}
