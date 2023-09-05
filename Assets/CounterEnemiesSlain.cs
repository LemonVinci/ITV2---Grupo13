using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterEnemiesSlain : MonoBehaviour
{
    public TextMeshProUGUI slimeSlainedText;
    public TextMeshProUGUI slimeMaxText;
    public long slimeMax;
    public long slimeSlained;
    public GameObject stageClear;

    void Start()
    {
        slimeMaxText.text = "/ " + slimeMax.ToString();
        UpdateHealthUI();
    }


    public void UpdateHealthUI() {
        slimeSlainedText.text = slimeSlained.ToString();
        //condicion para pasar de nivel
        if (slimeSlained == slimeMax) {
        }
    }
    
    private void Update() {
        UpdateHealthUI();
    }
}
