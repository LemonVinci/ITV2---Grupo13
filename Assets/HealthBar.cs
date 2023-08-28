using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public DamageableCharacter playerHealth;

    void Start()
    {
        UpdateHealthUI();
    }


    public void UpdateHealthUI() {
        healthText.text = playerHealth._health.ToString();
        healthBar.fillAmount = playerHealth._health / playerHealth._maxHealth;
    }
    
    private void Update() {
        UpdateHealthUI();
    }
}
