using UnityEngine;
using Zenject;

public class CubeStucker : MonoBehaviour 
{
    [SerializeField] private GameObject cubePrefub;
    [SerializeField] private GameObject cubeHolder;
    [SerializeField] private ParticleSystem cubeEffect;
    [SerializeField] private GameObject textEffect;
    [SerializeField] private GameObject playerObject;
    
   
    private GameEvents gameEvents;

 
      [Inject] private void Inject(GameEvents _gameEvents)
       {
        gameEvents=_gameEvents;
       } 
    



    private void Start()
    {
        
        gameEvents.createGube.AddListener(MakeNewCube);
    }






    public void MakeNewCube()
    {

        Vector3 newCubePosition = new Vector3(playerObject.transform.position.x,
                                               playerObject.transform.position.y,
                                               playerObject.transform.position.z);

        Quaternion newCubeRotation = playerObject.transform.rotation;
        
        playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y +2f, playerObject.transform.position.z);

        Instantiate(cubePrefub, newCubePosition, newCubeRotation, cubeHolder.transform);



        //// Play effects after creation
        GameObject textEffectObject = Instantiate(textEffect, newCubePosition, newCubeRotation);
        gameEvents.audioFxEvent?.Invoke(AudioFxType.cubeFx);
        Destroy(textEffectObject, 1f);
        cubeEffect.Play();





    }
    
    
}
