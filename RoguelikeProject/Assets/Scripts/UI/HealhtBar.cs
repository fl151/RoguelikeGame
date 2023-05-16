using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealhtBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _filler;

    private int _maxHealth;

    private void Start()
    {
        _maxHealth = _player.MaxHealth;
        _player.HealthChanged += OnHealthCanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthCanged;
    }

    private void OnHealthCanged(int currentHealth)
    {
        _filler.fillAmount = (float)currentHealth / _maxHealth;
    }
}
