
using UnityEngine;

public class Player : MonoBehaviour , IService
{

    [SerializeField] private Animator playerAnimator;
   [HideInInspector] public PlayerMoveControlller playerMoveControlller;
    [HideInInspector] public  PlayerAnimationController playerAnimationController;
     

    private void Awake()
    { 
        playerMoveControlller=new PlayerMoveControlller (this.gameObject);
        playerAnimationController= new PlayerAnimationController(playerAnimator);
       
    }

    private void Update() {
        playerMoveControlller.Update();
       
    }
    
}
