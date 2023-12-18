
using UnityEngine;
using Zenject;

public class GameStarter : MonoBehaviour
{
    private GameEvents gameEvents;

   
      [Inject] private void Inject(GameEvents _gameEvents)
       {
        gameEvents=_gameEvents;
        Debug.Log("Events Registred");
        gameEvents.createGube.Invoke();
       } 
    

    // Update is called once per frame
    void Update()
    {
        Touch[] touches = Input.touches;
        if (touches.Length > 0)
        {
            if (touches[0].phase == TouchPhase.Ended)
            {
                gameEvents.changeGameState.Invoke(LevelStates.Playing);

                Destroy(this.gameObject);
            }

        }
      

    }
}
