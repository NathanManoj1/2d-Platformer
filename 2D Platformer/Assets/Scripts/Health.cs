using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _MaxHealth;
    [SerializeField]
    private int _MinHealth;
    [SerializeField]
    private int _CurrentHealth;
    private void Start()
    {
        _CurrentHealth = _MaxHealth;
    }
    private void Update()
    {
    }
    public void Damage(int _DamageAmount)
    {
        _CurrentHealth -= _DamageAmount;
        if (_CurrentHealth < _MinHealth)
        {
            Debug.Log("Ded");
        }
    }
}

