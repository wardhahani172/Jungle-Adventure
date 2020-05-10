using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public void Mulai(){
        SceneManager.LoadScene("SampleScene");
    }

    public void Selesai(){
        SceneManager.LoadScene("GameOverScene");
    }

    public void Back(){
        SceneManager.LoadScene("MenuScene");
    }
}