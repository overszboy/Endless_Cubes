using UnityEngine;

public class ChunkMovementController : MonoBehaviour
{

    private Vector3 targetPosition;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float offset = 30f;

    private void Start()
    {

        targetPosition = new Vector3(gameObject.transform.position.x
          , gameObject.transform.position.y
          , gameObject.transform.position.z);

        gameObject.transform.position= new Vector3( gameObject.transform.position.x
          , gameObject.transform.position.y -offset
          , gameObject.transform.position.z);

        


    }
   
    void Update()
    {
      
        gameObject.transform.position = Vector3.Slerp(gameObject.transform.position,targetPosition,Time.deltaTime*speed);
        
    }
}
