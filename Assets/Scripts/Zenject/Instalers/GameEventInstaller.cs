using UnityEngine;
using Zenject;

public class GameEventInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
        Container.Bind<GameEvents>().AsSingle();
        
    }
}