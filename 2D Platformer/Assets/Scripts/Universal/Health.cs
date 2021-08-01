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
    [SerializeField]
    Animator _anim;
    UIManager _uiManager;
    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
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
            if(this.tag == "Player")
            {
                _anim.SetTrigger("Hurt");
                _uiManager.died();
            }
          

        }
    }
}

