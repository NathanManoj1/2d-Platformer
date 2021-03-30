using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pets : MonoBehaviour
{
    private enum PetState
    {
        FollowPlayer,
        GoToEnemy,
        AttackEnemy,
        idle
    }

    private Vector3 point;
    
    [SerializeField]
    private float _speed = 10;
    private Transform _player;
    private PetState _currentState;
    Health health;
    private void Start()
    {
        _currentState = PetState.idle;
        health = GetComponent<Health>();
        if (health == null)
            Debug.LogError("Health is NULL");
        _player = GameObject.Find("Player").transform;
;    }
    private void Update()
    {
        if (health.isPet == true && _currentState != PetState.GoToEnemy)
            _currentState = PetState.FollowPlayer;
    }
    private void FixedUpdate()
    {
        if (_currentState == PetState.FollowPlayer)
        {
            if (Vector3.Distance(transform.position, _player.position) > 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
            }
        }
        if (_currentState == PetState.GoToEnemy)
        {
            transform.position = Vector3.MoveTowards(transform.position, point, Time.deltaTime * _speed);
        }
    }
    public void MoveTowards(Vector3 _point)
    {
      
        point = _point;
        _currentState = PetState.GoToEnemy;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        
           // _currentState = PetState.AttackEnemy;

    }

}
