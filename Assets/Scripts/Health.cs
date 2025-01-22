using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth { get; private set; }
    public int health;
    public bool isDead => health <= 0;
    public event Action OnDead;
    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }
    public void TakeDame()
    {
        health--;
        if (isDead)
        {
            OnDead?.Invoke();
        }
    }
}
