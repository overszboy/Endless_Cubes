using UnityEngine;
using Zenject;

public class AdsServiceInstaller : MonoInstaller
{
 [SerializeField] private GameObject adsService;
    public override void InstallBindings()
    {
        Container.Bind<InterstitialAd>().FromComponentInNewPrefab(adsService).AsSingle().NonLazy();
    }
}