using System.Collections;
using UnityEngine;


public class ServiceLocatorLoader : MonoBehaviour
{
    private const string GAME_SCENE = "GameScene";
    private GameEvents gameEvents = new GameEvents();
  
    [SerializeField] private GameObject audioServicePrefab;
    private AudioService audioService;
    
    void Awake()
    {

#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
        Debug.unityLogger.logEnabled = false;
#endif
       

        DontDestroyOnLoad(this.gameObject);
        GameObject _audioService = Instantiate(audioServicePrefab);
        DontDestroyOnLoad(_audioService);
        audioService = _audioService.GetComponent<AudioService>();

         
        ServiceLocator.Initialize();
        RegisterAllServices();
    }

    void RegisterAllServices()
    {
        ServiceLocator.Current.Register<GameEvents>(gameEvents);
       
        ServiceLocator.Current.Register<AudioService>(audioService);

       
        UnityEngine.SceneManagement.SceneManager.LoadScene(GAME_SCENE);
    }

   
}


   

