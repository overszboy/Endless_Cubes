using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class UIController : MonoBehaviour
{

    [SerializeField] Button restartButton;
    [SerializeField] Button startButton;
    [SerializeField] TextMeshProUGUI scoreText;
    private GameEvents gameEvents;

     [Inject]
     private void Inject(GameEvents _gameEvents) {
        gameEvents=_gameEvents;
     
     } 
     

    private int score=0;

  

      
    
  


    private void Awake()
    {
       
        restartButton.onClick.AddListener(OnRestartButtonClick);
        startButton.onClick.AddListener (OnStartButtonClick);
         gameEvents.ScoreUpdate.AddListener( ChangeScore);
         gameEvents.changeGameState.AddListener(OnGameOver);
       
    }

    private void OnStartButtonClick()
    {
       
        startButton.gameObject.SetActive(false);
        gameEvents.changeGameState.Invoke(LevelStates.Playing);
        
    }

    private void OnRestartButtonClick()
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            

        }
  

     public void ChangeScore(int _scrore)
     {
        score+=_scrore;
        scoreText.text=score.ToString();

     }
   
    private void OnGameOver(LevelStates levelState)
    {
        if (levelState==LevelStates.GameOver)
    {
         restartButton.gameObject.SetActive(true);

    }

    }

}

