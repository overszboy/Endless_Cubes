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

    private int score=0;

  

      
    
  


    private void Start()
    {
       
        restartButton.onClick.AddListener(OnRestartButtonClick);
        startButton.onClick.AddListener (OnStartButtonClick);
       
    }

    private void OnStartButtonClick()
    {
       
        startButton.gameObject.SetActive(false);
        
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
    public void SetRestartButton (bool isEnabled)
    {
       restartButton.gameObject.SetActive(isEnabled);

    }

}

