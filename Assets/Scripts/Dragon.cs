using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
public class Dragon : MonoBehaviour
{
    [SerializeField]
    private Transform drago;
    [SerializeField]
    public int _maxHealth = 100;
    public int _currentHealth = 100;
    [SerializeField]
    private AnimationDragon DragonAnimation;
    
    
    public bool Fly = false;

    public delegate void MyDelegate(float a);
    public event MyDelegate HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    

    private void OnCollisionEnter(Collision stoneother)
    {
        ChangedHealth(-10);
        
        Debug.Log(_currentHealth);
    }

    private void ChangedHealth(int value)
    {
        _currentHealth += value;
        if (_currentHealth <= 0)
        {
            Death();
        }
        else
        {
            float _currentHealthAsPercantage = (float)_currentHealth / _maxHealth;
            HealthChanged?.Invoke(_currentHealthAsPercantage);
        } 
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
        Debug.Log("Kill");
        Fly = true;
        DragonAnimation.true_FlyAnim();
        Debug.Log(Fly);
        //Destroy(gameObject, 10f);
    }
}
}

