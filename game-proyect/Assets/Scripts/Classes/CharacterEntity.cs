using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public enum Behaviour { Idle, Attacking, Moving, Patrolling, Charging}

public class CharacterEntity : MonoBehaviour {

    protected string _name;
    protected int   _level;
    protected float _baseDamage;
    protected float _baseDefense;
    protected float _hp;
    protected float _moveSpeed;
    protected float _attackSpeed;
    protected float _experience;

    public string Name { get { return _name; } set { _name = value; } }
    public int Level { get { return _level; } set { _level = value; } }
    public float BaseDamage { get { return _baseDamage; }set { _baseDamage = value; } }
    public float BaseDefense { get { return _baseDefense; }set { _baseDefense = value; } }
    public float Hp { get { return _hp; }set { _hp = value; } }
    public float MoveSpeed { get { return _moveSpeed; }set { _moveSpeed = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public float Experience { get { return _experience; } }

    public delegate void ExperienceEarned(CharacterEntity sender, float experience);

    public void AddExperience(float experience)
    {

        
    }


    public CharacterEntity(string Name,int Level,float BaseDamage,float BaseDefense,float Hp,float MoveSpeed, float AttackSpeed)
    {
        _name = Name;
        _level = Level;
        _baseDamage = BaseDamage;
        _baseDefense = BaseDefense;
        _hp = Hp;
        _moveSpeed = MoveSpeed;
        _attackSpeed = AttackSpeed;
    }

    public CharacterEntity() { }
    

}

public class EntityEventArgs : EventArgs
{
    protected string _name;
    protected int _level;
    protected float _baseDamage;
    protected float _baseDefense;
    protected float _hp;
    protected float _moveSpeed;
    protected float _attackSpeed;
    protected float _experience;
    protected string _newName;
    protected int _newLevel;
    protected float _newBaseDamage;
    protected float _newBaseDefense;
    protected float _newHp;
    protected float _newMoveSpeed;
    protected float _newAttackSpeed;
    protected float _newExperience;

    public string Name { get { return _name; } set { _name = value; } }
    public int Level { get { return _level; } set { _level = value; } }
    public float BaseDamage { get { return _baseDamage; } set { _baseDamage = value; } }
    public float BaseDefense { get { return _baseDefense; } set { _baseDefense = value; } }
    public float Hp { get { return _hp; } set { _hp = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public float Experience { get { return _experience; } }

    public string NewName { get { return _newName; } set { _newName = value; } }
    public int NewLevel { get { return _newLevel; } set { _newLevel = value; } }
    public float NewBaseDamage { get { return _newBaseDamage; } set { _newBaseDamage = value; } }
    public float NewBaseDefense { get { return _newBaseDefense; } set { _newBaseDefense = value; } }
    public float NewHp { get { return _newHp; } set { _newHp = value; } }
    public float NewMoveSpeed { get { return _newMoveSpeed; } set { _newMoveSpeed = value; } }
    public float NewAttackSpeed { get { return _newAttackSpeed; } set { _newAttackSpeed = value; } }
    public float NewExperience { get { return _newExperience; } }
}
