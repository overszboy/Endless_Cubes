using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] Player player;
    public override void InstallBindings()
    {
       Container.Bind<Player>().FromInstance(player).AsSingle();
       
    }
}

