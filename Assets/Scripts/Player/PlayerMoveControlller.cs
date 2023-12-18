
using UnityEngine;
public class PlayerMoveControlller 
{
    
   
    private PlayerControllerOF controllerOF;
    private PlayerControllerON controllerON;

    private IPlayerControllerState curentController;
    



    public PlayerMoveControlller ( GameObject _player)
    {
        
       
        controllerON = new PlayerControllerON(_player);
        controllerOF = new PlayerControllerOF();
        curentController = controllerOF;
    }

    
   public void Update()
    {
        curentController.Update();
        

    }



   public void  ChangeController( LevelStates state)
    {
        switch (state)
        {

            case LevelStates.Pause:
                curentController = controllerOF;
                break;
            case LevelStates.Playing:
                curentController = controllerON;
                break;
            case LevelStates.Start:
                curentController = controllerOF;
                break;
            case LevelStates.GameOver:
                curentController = controllerOF;
                break;
                 case LevelStates.Ads:
                curentController = controllerOF;
                break;
           

        }

    }
    
}
