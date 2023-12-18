using System.ComponentModel;
using UnityEngine;
using Zenject;

public class CubeStackerPoolingInstaller : MonoInstaller
{

    [SerializeField] private CubeStakerPooling cubeStakerPooling;
    public override void InstallBindings()
    {
        Container.Bind<CubeStakerPooling>().FromInstance(cubeStakerPooling).AsSingle().NonLazy();
    }
}