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
    [SerializeField] TextMeshProUGUI livesText;
    private GameEvents gameEvents;
    private AudioService audioService;
    private InterstitialAd adsService;
     [Inject]
     private void Inject(GameEvents _gameEvents, AudioService _audioService,InterstitialAd _adsService) {
        gameEvents=_gameEvents;
        audioService=_audioService;
        adsService=_adsService;
     } 
     

    private int score=0;

  

      
    
  


    private void Awake()
    {
       
        restartButton.onClick.AddListener(OnRestartButtonClick);
        startButton.onClick.AddListener (OnStartButtonClick);
         gameEvents.ScoreUpdate.AddListener( ChangeScore);
         gameEvents.changeGameState.AddListener(OnGameOver);
         audioService.PlayPauseMusic();
         livesText.text=adsService.Lives.ToString();
       
    }

    private void OnStartButtonClick()
    {
        audioService.PlayLevelMusic();
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
         audioService.PlayPauseMusic();
         livesText.text=adsService.Lives.ToString();
    }

    }

}

