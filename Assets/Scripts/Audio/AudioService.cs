using UnityEngine;
using Zenject;

public class AudioService : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceOne;
    [SerializeField] private AudioSource audioSourceTwo;
    [SerializeField] private AudioSource audioSourceThree;
    [SerializeField] private AudioClip cubeFX;
    [SerializeField] private AudioClip wallFX;
    [SerializeField] private AudioClip gameOverFX;
    [SerializeField] private AudioClip pause;
    [SerializeField] private AudioClip soundtrack;

    private GameEvents gameEvents;

  [Inject] private void Inject(GameEvents _gameEvents,Player _player)
       {
        gameEvents=_gameEvents;

       } 
    

    private void Start()
    {

        audioSourceOne.Stop();
        audioSourceOne.clip = pause;
        audioSourceOne.Play();

        gameEvents.changeGameState.AddListener(onChangeGameState);
        gameEvents.audioFxEvent?.AddListener(AudioFxEvent);

    }

    private void AudioFxEvent(AudioFxType fxType)
    {
        switch (fxType)
        {

            case AudioFxType.cubeFx:
                audioSourceTwo.clip = cubeFX;
                audioSourceTwo.Play();
                break;
            case AudioFxType.wallFX:
                audioSourceTwo.clip = wallFX;
                audioSourceTwo.Play();
                break;
            case AudioFxType.gameOvereFx:
                audioSourceThree.clip = gameOverFX;
                audioSourceThree.Play();
                break;
            default:
                break;
        }


    }

   private void  onChangeGameState(LevelStates gameState)
    {

        switch (gameState)
        {

            case LevelStates.Pause:
                audioSourceOne.Stop();
                audioSourceOne.clip = pause;
                audioSourceOne.Play();
                
                break;
            case LevelStates.GameOver:
                audioSourceOne.Stop();
                audioSourceOne.clip = pause;
                audioSourceOne.Play();
                
                break;
            case LevelStates.Playing:
                audioSourceOne.Stop();
                audioSourceOne.clip = soundtrack;
                audioSourceOne.Play();

                break;
            default:
                break;
        }

    }

}
