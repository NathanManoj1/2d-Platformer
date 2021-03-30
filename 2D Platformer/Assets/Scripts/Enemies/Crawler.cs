using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    public enum EnemyState
    {
        Crawl,
        Attack,
        Idle
        
    }
    
    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 3.0f;
    private bool _switching = false;
    public EnemyState _currentstate;
    [SerializeField]
    private Transform _player;
    Health health;
    private void Start()
    {
       health =  GetComponent<Health>();
    }
    private void Update()
    {
        if (health.isPet == true)
            _currentstate = EnemyState.Idle;
    }
    void FixedUpdate()
    {
        SideToSide();
        
    }
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _currentstate != EnemyState.Idle)
        {
           _currentstate = EnemyState.Attack;
            collision.GetComponent<Health>().Damage(.01f);
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _currentstate != EnemyState.Idle)
        {
           _currentstate = EnemyState.Crawl;
        }
    }
    private void SideToSide()
    {
        if (_currentstate == EnemyState.Crawl)
        {
            if (_switching == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
            }
            else if (_switching == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
            }

            if (transform.position == _targetB.position)
            {
                _switching = true;
            }
            else if (transform.position == _targetA.position)
            {
                _switching = false;
            }
        }

    }


}
