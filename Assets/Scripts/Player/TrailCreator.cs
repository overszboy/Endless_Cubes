using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrailCreator : MonoBehaviour
{
   
    [SerializeField] GameObject trailPrefab;
    private LevelStates gameState = LevelStates.Pause;
    private GameEvents gameEvents;
    private Transform player;
    private Stack<GameObject> trailItems = new();

  
     [Inject] private void Inject(GameEvents _gameEvents,Player _player)
       {
        gameEvents=_gameEvents;
        player=_player.transform;
       } 
    

    private void Start()
    {
    
        gameEvents.changeGameState.AddListener(ChangeGameState);
      
    }
    
  


    // Update is called once per frame
    void FixedUpdate()
    {
        switch (gameState)
        {

            case LevelStates.Pause:
                break;

            case LevelStates.Playing:
                CreateTrailItem();
                break;

        }

       
    }

    private void CreateTrailItem()
    {

        if (trailItems.Count > 0)
        {
            var obj = trailItems.Pop();

            obj.transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
            obj.SetActive(true);
            StartCoroutine(DeactivateItem(obj));

        }

        else {
            Vector3 position = new Vector3(player.position.x, transform.position.y, player.position.z);
            GameObject obj = Instantiate(trailPrefab, position, transform.rotation);
            StartCoroutine(DeactivateItem(obj));


        }

        


    }
    IEnumerator DeactivateItem(GameObject obj)
    {

        
        yield return new WaitForSeconds(1);
        obj.SetActive(false);
        trailItems.Push(obj);

    }


    void ChangeGameState(LevelStates state)
    {
        gameState = state;

    }

    private void OnDestroy()
    {
        foreach (var item in trailItems)
        {
            Destroy(item);
        }
    }

}
