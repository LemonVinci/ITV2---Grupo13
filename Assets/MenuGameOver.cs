using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private DamageableCharacter damageableCharacter;

    private void Start()
    {
        damageableCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageableCharacter>();
        damageableCharacter.MuerteJugador += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e)
        {
            menuGameOver.SetActive(true);
        }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string MenuInicio)
    {
        SceneManager.LoadScene(MenuInicio);
    }

    public void Salir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

}
