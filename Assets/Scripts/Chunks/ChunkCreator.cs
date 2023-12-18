
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChunkCreator : MonoBehaviour
{

    [SerializeField] private GameObject[] chunks;
   
    [SerializeField] private Transform lastChankPosition;

    private List<GameObject> chunkList=new List<GameObject>();
    
    private float distanceFromLustChank = 0;
    private GameEvents gameEvents;
    private GameObject player;

  [Inject] private void Inject(GameEvents _gameEvents,Player _player)
       {
        gameEvents=_gameEvents;
        player=_player.gameObject;
       } 
    


    void Start()
    {
        
        
        gameEvents.createChunk.AddListener(CreateChunk);


    }

    private void Update()
    {
        DestroyFirstChunk();

        DetectPlayerPoss();

    }

    private void DetectPlayerPoss()
    {
        if (player.transform.position.z - distanceFromLustChank > 30f)
        {
            gameEvents.createChunk.Invoke();
            distanceFromLustChank = player.transform.position.z;
        }
    }

    private void DestroyFirstChunk()
    {
        if (chunkList.Count > 5)
        {
            GameObject chank = chunkList[0];
            chunkList.RemoveAt(0);
            Destroy(chank.gameObject);

        }
    }

    private void CreateChunk()
    {
        int randChunk = Random.Range(0, chunks.Length-1);

        Vector3 chunkPosition = new Vector3(
              lastChankPosition.transform.position.x
            , lastChankPosition.transform.position.y
            , lastChankPosition.transform.position.z+30f);

        GameObject newChunk=  Instantiate(chunks[randChunk],chunkPosition,lastChankPosition.transform.rotation);
        newChunk.transform.parent = this.transform;
        lastChankPosition = newChunk.transform;
        chunkList.Add(newChunk);

    }
}
