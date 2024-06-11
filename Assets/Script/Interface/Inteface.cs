using System;
using UnityEngine;

public interface IHealth 
{
    event Action<int> currentHealth;
    void TakeDamage(int damage);
}

public interface IEnemyStates
{

}