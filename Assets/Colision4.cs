using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colision4 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("The End",LoadSceneMode.Single);
        }
    }
}
