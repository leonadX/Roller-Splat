using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void replayGame(){
        SceneManager.LoadScene(0);
    }

    public void endGame(){
       Application.Quit();
    }
}
