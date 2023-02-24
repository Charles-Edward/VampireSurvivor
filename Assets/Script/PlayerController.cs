//  []
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    



    //  Private & Protected
    private Rigidbody2D _rb2D;
    private Vector2 _direction;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move(); 
    }

    private void FixedUpdate()
    {
        
        _rb2D.velocity = _direction * _speed;
    }
    private void Move()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    // Increase movement speed by 25%
    /*private void IncreaseMove()
    {

        _rb2D.velocity = _direction *_speed * 0.75f;
    }*/


}
