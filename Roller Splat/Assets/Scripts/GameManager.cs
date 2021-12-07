using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    private GroundPiece[] allGroundPieces;

    void Start()
    {
       SetUpNewLevel();
    }

    private void SetUpNewLevel()
    {
      allGroundPieces = FindObjectsOfType<GroundPiece>();
    }

    private void Awake()
    {
        if(singleton == null)
        {
           singleton = this;
        }else if(singleton != this)
        {
           Destroy(gameObject);
           DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
       SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
       SetUpNewLevel();
    }

    public void CheckComplete()
    {
       bool isFinished = true;

        for(int i = 0; i < allGroundPieces.Length ; i++){
            if(allGroundPieces[i].isColored == false){
                isFinished = false;
                break;
            }
        }

         if(isFinished){
            NextLevel();
         }

    }

    private void NextLevel(){
      //if(SceneManager.GetActiveScene().buildIndex == 6){
      //    SceneManager.LoadScene(0);
      // }
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
