
using Unity.VisualScripting;
using UnityEngine;
using Zenject;


public class GameOverDetection : MonoBehaviour
{

    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask layerMask;
    private GameEvents gameEvents;
    private Rigidbody[] rbs;
     private Collider[] cls;
    private Rigidbody mainRigidbody;
    private Collider mainColider;
    private Animator  animator;
    private AudioService audioService;
      [Inject] private void Inject(GameEvents _gameEvents,AudioService _audioService)
       {
        gameEvents=_gameEvents;
        audioService=_audioService;
       } 
    
    private void Awake() {
        
        rbs=GetComponentsInChildren<Rigidbody>();
        cls=GetComponentsInChildren<Collider>();
        animator= GetComponent<Animator>();
        foreach (var rb in rbs)
        {
            rb.isKinematic=true;
            rb.useGravity=false;
        }
        foreach (var cl in cls)
        {
            cl.enabled=false;
        }

        mainRigidbody=GetComponent<Rigidbody>();
        mainColider=GetComponent<Collider>();
        mainRigidbody.isKinematic=false;
        mainRigidbody.useGravity=true;
        mainColider.enabled=true;
    }
  
    private void Update()
    {
       
    
        transform.localPosition = new Vector3(0f,transform.localPosition.y,0f);
        
    
        if (IsGrounded())
        {
           
            gameEvents.changeGameState.Invoke(LevelStates.GameOver);
            audioService.PlayGameOverFx();
            gameEvents.enableRestartButton.Invoke();
            Destroy(mainRigidbody);
            Destroy(mainColider);
            Destroy(animator);
            foreach (var rb in rbs)
            {
                rb.isKinematic=false;
                rb.useGravity=true;
            }
            foreach (var cl in cls)
            {
                cl.enabled=true;
            }
           
            
            Destroy(this);
             Debug.Log("Ground coll");
        }
        
    }
      
    bool IsGrounded()

    {
        return Physics.CheckSphere(groundChecker.position, 0.1f, layerMask);


    }

   
    

}
