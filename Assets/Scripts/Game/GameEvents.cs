
using UnityEngine;
using UnityEngine.Events;
public class GameEvents 
{

    public  UnityEvent createGube = new UnityEvent();
    public  UnityEvent createChunk = new UnityEvent();
    public  UnityEvent<LevelStates> changeGameState= new UnityEvent<LevelStates>();
    public  UnityEvent cameraShake = new UnityEvent();
    public  UnityEvent<int> ScoreUpdate= new UnityEvent<int>();
    public UnityEvent enableRestartButton = new UnityEvent();
    public UnityEvent<AudioFxType> audioFxEvent = new UnityEvent<AudioFxType>();

 
    

}


