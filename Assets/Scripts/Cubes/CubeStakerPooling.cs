using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CubeStakerPooling : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefub;
    [SerializeField] private GameObject cubeHolder;
    [SerializeField] private ParticleSystem cubeEffect;
    [SerializeField] private GameObject textEffect;
    [SerializeField] private GameObject playerObject;
    [Inject] private DiContainer diContainer;


    public Stack<GameObject> cubeStack;
    private GameEvents gameEvents;
    private PoolingFabric plusOneFabric;
    private AudioService audioService;
   
    public int poolCount = 0;



      [Inject] private void Inject(GameEvents _gameEvents , AudioService _audioService)
       {
        gameEvents=_gameEvents;
        audioService=_audioService;
       } 
    
     private void Awake() {
        
     }

    private void Start()
    { 
       
        plusOneFabric= new PoolingFabric(textEffect);
        gameEvents.createGube.AddListener(MakeNewCube);
        cubeStack = new();
    }






    public void MakeNewCube()
    {
        
        Vector3 newCubePosition = new Vector3(playerObject.transform.position.x,
                                               playerObject.transform.position.y,
                                               playerObject.transform.position.z);

        Quaternion newCubeRotation = playerObject.transform.rotation;


        if (cubeStack.Count > 0)
        {
           var obj = cubeStack.Pop();
            
            playerObject.transform.position = new Vector3(playerObject.transform.position.x,
                                                          playerObject.transform.position.y + 2f,
                                                          playerObject.transform.position.z);
            obj.transform.position = newCubePosition;
            obj.transform.parent = cubeHolder.transform;
            obj.SetActive(true);
            obj.name = "CubeFromPool";
            poolCount--;


        }

        else
        {
            playerObject.transform.position = new Vector3(playerObject.transform.position.x,
                                                          playerObject.transform.position.y + 2f,
                                                          playerObject.transform.position.z);

           var obj= diContainer.InstantiatePrefab(cubePrefub, newCubePosition, newCubeRotation, cubeHolder.transform);
            obj.name = "newCUbe";
 
        }

        


        PlayEffets(newCubePosition, newCubeRotation);

    }

    private void PlayEffets(Vector3 newCubePosition, Quaternion newCubeRotation)
    {
        
        GameObject textEffectObject = plusOneFabric.CreateObject( newCubePosition, newCubeRotation);
        audioService.PlayCubeFx();
        StartCoroutine(HideTextObj(textEffectObject));
        cubeEffect.Play();
    }
    IEnumerator  HideTextObj( GameObject textObj) {


        yield return new  WaitForSeconds(1f);

        plusOneFabric.PushToStack(textObj);
    }
}


