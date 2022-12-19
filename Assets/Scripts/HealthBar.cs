using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
public class HealthBar : MonoBehaviour
{
    [SerializeField] public Image _HealthBarFilling;
    [SerializeField] Dragon _health;
    
    private void Awake() 
    {
        _health.HealthChanged += OnHealthChanged;    
    }
    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }
    private void OnHealthChanged(float valueAsPercantage)
    {
        _HealthBarFilling.fillAmount = valueAsPercantage;
    }
}
}

