using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;
    public bool isAlive => currentHealth > 0;

    [SerializeField] private UnityEvent<float> itTookDamage;
    [SerializeField] private UnityEvent itDead;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        TakeDamage(0);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0)
        {
            currentHealth = 0;
            itDead.Invoke();
        }

        itTookDamage.Invoke(currentHealth);
    }

    public void TakeDamageToDie()
    {
        TakeDamage(maxHealth + 1);
    }
}
