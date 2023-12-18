using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class CubeColisionDetection : MonoBehaviour
{
   
      private bool coll = false;
      private GameEvents gameEvents;
    private CubeStakerPooling cubeStacker;
      
    private int  scoreValue = 100;

  
      [Inject] private void Inject(GameEvents _gameEvents,CubeStakerPooling _cubeStakerPooling)
       {
        gameEvents=_gameEvents;
        cubeStacker=_cubeStakerPooling;
        
        
       } 
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PickUp>(out PickUp pickUp))
        {

            if (gameEvents!=null)
            {
            gameEvents.createGube.Invoke();
           
            }
            else 
            {
               
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.TryGetComponent<Wall>(out Wall wall) && !coll)
        {
             
            coll = true;
            this.gameObject.transform.parent.transform.parent= null;
            
            cubeStacker.cubeStack.Push(this.gameObject.transform.parent.gameObject);
            cubeStacker.poolCount++;
           
            
            int scoreCoeff = (int)other.gameObject.transform.parent.localPosition.y + 1;
            gameEvents.ScoreUpdate.Invoke(scoreValue*scoreCoeff);

            gameEvents.cameraShake.Invoke();
            gameEvents.audioFxEvent?.Invoke(AudioFxType.wallFX);
          

           
            Invoke("SetActiveFalse", 1f);
        }




    }
   
        
    

   private void SetActiveFalse() {

        this.gameObject.transform.parent.gameObject.SetActive(false);
        this.transform.localPosition = new Vector3(0f, 0f, 0f);
        coll = false;
      
    }
    void Update()
    {
        transform.localPosition = new Vector3(0f,transform.localPosition.y,0f);
        
    }
   
}
