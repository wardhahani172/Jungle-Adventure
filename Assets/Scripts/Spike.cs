using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{

    // fungsi berguna untuk mengecek collision/tabrakan yg terjadi
    private void OnTriggerEnter2D(Collider2D other)
    {

        // kondisi saat game object tabrakan dg game object lain (gameobject player)
        if (other.CompareTag("Player"))
        {

            // ketika mati maka game akan diulangi lagi dari awal
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
