using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private int health;
    [HideInInspector] public event Action<int> currentHealth;

    public void TakeDamage(int damage)
    {
        if(health > 0) health -= damage;
        if (health <= 0) currentHealth?.Invoke(health);
    }
}
