using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    public enum EnemyState
    {
        Crawl,
        Attack,
        Pet,
        PetAttack
    }

    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 3.0f;
    private bool _switching = false;
    public EnemyState _currentstate;
    [SerializeField]
    private Transform _player;
    private bool _move;
    private Vector3 point;
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
        if (_currentstate == EnemyState.Pet)
        {
            if (Vector3.Distance(transform.position, _player.position) > 3)
            {
                 transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
            }
        }
        if (_move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(point.x, point.y, point.z), Time.deltaTime * _speed);
        }
    }
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _currentstate != EnemyState.Pet && _currentstate != EnemyState.PetAttack)
        {
           _currentstate = EnemyState.Attack;
            collision.GetComponent<Health>().Damage(.01f);
        }
        else if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().Damage(10);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _currentstate != EnemyState.Pet)
        {
           _currentstate = EnemyState.Crawl;
        }
    }
    public void MoveTowards(Vector3 _point)
    {
        point = _point;
        _move = true;
        _currentstate = EnemyState.PetAttack;

    }

}
