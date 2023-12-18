using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraMovementController : MonoBehaviour
{
  
    [SerializeField] private Vector3 offset;

    private float smootheSpeed = 10f;
    private float shakeTime = 0;
    private GameEvents gameEvents;
    private Transform player;
    private Transform ragdoll;
    private Transform target;
    private bool isGameOver=false;

    [Inject] private void Inject(GameEvents _gameEvents,Player _player)
       {
        gameEvents=_gameEvents;
        player=_player.gameObject.transform;
        ragdoll=_player.RagDollTransform;
       } 
    
    private void Awake() {
        target= player;
        gameEvents.changeGameState.AddListener(OnGameOver);
    }

   
    private void Start()
    {
      

        gameEvents.cameraShake.AddListener(SetShakeTime);


        transform.position = player.position + offset;
    }


    

    void LateUpdate()
    {
        if (shakeTime < 0)
        {
            transform.position = Vector3.Lerp(transform.position, (target.position + offset), Time.deltaTime * smootheSpeed);
            
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, (target.position + offset), Time.deltaTime * smootheSpeed) + new Vector3((float)Random.Range(-1, 1) * shakeTime, (float)Random.Range(-1, 1) * shakeTime, 0f);
            shakeTime -= Time.deltaTime;
        }
         if (isGameOver)
         {
            transform.LookAt(ragdoll.transform.position);
         }

    }

    void SetShakeTime()
    {
        shakeTime = 0.3f;
    }
  private void OnGameOver(LevelStates levelState)
  {  
    if (levelState==LevelStates.GameOver)
    {
        target=ragdoll;
        isGameOver=true;
        offset= new Vector3(0f,2f,-5);
        
        Debug.Log("foolow to rag doll");

    }

  }

}
