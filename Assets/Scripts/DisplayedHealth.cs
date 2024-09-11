using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayedHealth : MonoBehaviour
{
    [SerializeField] private Text healthBar;
    [SerializeField] private GameObject deathImage;
    public float displayedHealth;

    public void RedrawHealthbar(float currentHealth)
    {
        displayedHealth = Mathf.Round(currentHealth);

        healthBar.text = displayedHealth.ToString();
    }

    public void DrawDeathBar()
    {
        deathImage.SetActive(true);
    }
}
