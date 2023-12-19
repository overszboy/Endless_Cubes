using UnityEngine;
using Zenject;

public class AudioServiceInstaller : MonoInstaller
{
 [SerializeField] private GameObject audioService;
    public override void InstallBindings()
    {
        Container.Bind<AudioService>().FromComponentInNewPrefab(audioService).AsSingle().NonLazy();
    }
}