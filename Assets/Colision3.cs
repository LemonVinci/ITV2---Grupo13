using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colision3 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Nivel 1",LoadSceneMode.Single);
        }
    }
}
