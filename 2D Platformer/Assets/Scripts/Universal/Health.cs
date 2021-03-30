using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _MaxHealth;
    [SerializeField]
    private float _CurrentHealth;
    [SerializeField]
    private int _number;
    [SerializeField]
    private int _rare = 3;
    public bool isPet;
    Backpack _backpack;
    private void Start()
    {
        _CurrentHealth = _MaxHealth;
        _backpack = GameObject.Find("Backpack").GetComponent<Backpack>();
        if (_backpack == null)
            Debug.LogError("Backpack is NULL");
    }
 
    public void Damage(float _DamageAmount)
    {
        _CurrentHealth -= _DamageAmount;
        if (_CurrentHealth < 0)
        {
            if(this.tag != "Player")
            {
                _number = 2;//Random.Range(1, _rare);
                if (_number == 2 && isPet == false)
                {
                    var component = GetComponent<Pets>();
                    _backpack.ConvertToPet(component);
                    _CurrentHealth = _MaxHealth;
                    isPet = true;
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
          

        }
    }
}

