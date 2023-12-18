
using UnityEngine;

public class SceneServiceLoader : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private CubeStakerPooling cubeStucker;
    public static SceneServiceLocator sceneServiceLocator { get; private set; }

    void Awake()
    {

        sceneServiceLocator = new SceneServiceLocator();

        
        RegisterSceneServices();
    }

    void RegisterSceneServices()
    {
        sceneServiceLocator.Register<Player>(player);

        sceneServiceLocator.Register<CubeStakerPooling>(cubeStucker);
        

    }
}
