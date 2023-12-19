
using UnityEngine;

public class PlayerAnimationController 
{
    
    private Animator animator;

    private const string ANIMATOR_TRIGGER_JUMP = "JUMP";
   
    
     
    public PlayerAnimationController( Animator _animator)
    {
        
        animator = _animator;
      
    }
    public void PlayJumpAnimation ()
    {
        animator.SetTrigger(ANIMATOR_TRIGGER_JUMP);

    }


   
   
    
}
