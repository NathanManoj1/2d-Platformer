using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    public enum EnemyState
    {
        Crawl,
        Attack,
        Pet
    }

    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 3.0f;
    private bool _switching = false;
    public EnemyState _currentstate;
    [SerializeField]
    private Transform _player;
    // Update is called once per frame
    void FixedUpdate()
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
    private void Update()
    {
        if(_currentstate == EnemyState.Pet)
        {
            if(Vector3.Distance(transform.position, _player.position) > 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _currentstate != EnemyState.Pet)
        {
           _currentstate = EnemyState.Attack;
            collision.GetComponent<Health>().Damage(1);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _currentstate != EnemyState.Pet)
        {
           _currentstate = EnemyState.Crawl;
        }
    }

}
