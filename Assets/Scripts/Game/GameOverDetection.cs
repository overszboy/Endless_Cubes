
using UnityEngine;
using Zenject;


public class GameOverDetection : MonoBehaviour
{

    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask layerMask;
    private GameEvents gameEvents;

  
      [Inject] private void Inject(GameEvents _gameEvents)
       {
        gameEvents=_gameEvents;
       } 
    

  
    private void Update()
    {
        if (IsGrounded())
        {
           
            gameEvents.changeGameState.Invoke(LevelStates.Pause);
            gameEvents.audioFxEvent?.Invoke(AudioFxType.gameOvereFx);
            gameEvents.enableRestartButton.Invoke();

            Destroy(this);
        }
        
    }
    bool IsGrounded()

    {
        return Physics.CheckSphere(groundChecker.position, 0.1f, layerMask);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            gameEvents.changeGameState.Invoke(LevelStates.Pause);
            gameEvents.audioFxEvent?.Invoke(AudioFxType.gameOvereFx);
            gameEvents.enableRestartButton.Invoke();

            Destroy(this);
        }
    }

}
