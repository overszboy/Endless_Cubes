
using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour 
{

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ParticleSystem trailFX;
     public  Transform RagDollTransform;
    [HideInInspector] public PlayerMoveControlller playerMoveControlller;
    [HideInInspector] public  PlayerAnimationController playerAnimationController;
      private GameEvents gameEvents;
  [Inject]
     private void Inject(GameEvents _gameEvents) {
        gameEvents=_gameEvents;
     
     } 
     
    private void Awake()
    { 
        playerMoveControlller=new PlayerMoveControlller (this.gameObject);
        playerAnimationController= new PlayerAnimationController(playerAnimator);
        gameEvents.changeGameState.AddListener(ChangeController);
        gameEvents.createGube.AddListener(OnCubeCreation);
    }

    private void Update() {
        playerMoveControlller.Update();
       
    }
  public void ChangeController(LevelStates levelState)
  {
    playerMoveControlller.ChangeController(levelState);
    if(levelState==LevelStates.GameOver)
    {
       trailFX.Stop();
    }
  }
  private void OnCubeCreation()
  {

    playerAnimationController.PlayJumpAnimation();
  }
    
    
}
