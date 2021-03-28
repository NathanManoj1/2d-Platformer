using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _MaxHealth;
    [SerializeField]
    private int _CurrentHealth;
    [SerializeField]
    private int _number;
    [SerializeField]
    private int _rare = 3;
   
    private Backpack backpack;
    private void Start()
    {
        
        backpack = GameObject.Find("Player").GetComponent<Backpack>();
        if (backpack == null)
            Debug.LogError("BackPack is NULL");
        _CurrentHealth = _MaxHealth;
        if (this.tag != "Player")
            Damage(1000);
    }
    private void Update()
    {
       
    }
    public void Damage(int _DamageAmount)
    {
        _CurrentHealth -= _DamageAmount;
        if (_CurrentHealth < 1)
        {
           _number = Random.Range(1, _rare);
            if(_number == 2 && backpack._currentBackpackItems != backpack._backpackSpace)
            {
                var component = GetComponent<Crawler>();
                component._currentstate = Crawler.EnemyState.Pet;
                backpack.pets.Add(gameObject);
                backpack._currentBackpackItems++;
            }

        }
    }
}

