
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
public class UpdateScore : MonoBehaviour
{
    private TextMeshProUGUI  scoreText;
    private int score=0;
    private GameEvents gameEvents;
    // Start is called before the first frame update
   
      [Inject] private void Inject(GameEvents _gameEvents)
       {
        gameEvents=_gameEvents;
       } 
    
    void Start()
    {
        
        gameEvents.ScoreUpdate.AddListener(ScoreUpdate);

        scoreText = GetComponent<TextMeshProUGUI>();

        
    }


   

    private  void ScoreUpdate( int addScore)

    {
        score += addScore;
        scoreText.text = score.ToString();

        
    }
}
