using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que colisionó tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            // Cargar la escena con el índice 2 (asegúrate de que el índice sea correcto)
            SceneManager.LoadScene(1);
        }
    }
}