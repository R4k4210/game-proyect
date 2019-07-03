using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

//[RequireComponent(typeof(InputManager))]
public class PlayerHandler : MonoBehaviour {

    public CharacterEntity personaje = new CharacterEntity();
    [SerializeField]
    private float _moveSpeed = 1;
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    private Rigidbody rigid;

    private void MoveHorizontal(float movement)
    {
        rigid.velocity = new Vector2(movement * _moveSpeed, rigid.velocity.y);
    }

    public void Move(float movement, Axis axis)
    {
        
    }

    private void MoveVertical()
    {

    }

    public void TakeDamage(float damage)
    {

    }

    virtual public void Attack()
    {

    }

    public void Die()
    {

    }

    public void Respawn()
    {

    }

}
