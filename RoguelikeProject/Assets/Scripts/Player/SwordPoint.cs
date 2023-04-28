using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPoint : MonoBehaviour
{
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = FindObjectOfType<PlayerMover>();
    }

    private void Update()
    {
        
    }
}
