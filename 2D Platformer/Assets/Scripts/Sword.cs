using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator _sword;
    private void Start()
    {
        _sword = GetComponent<Animator>();
        if (_sword == null)
            Debug.LogError("Animator is NULL");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _sword.SetTrigger("Swing");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.E))
        {

            Health health = collision.GetComponent<Health>();
            if (health.isPet == false)
                health.Damage(10);
            _sword.SetTrigger("Swing");
        }
    }
}
