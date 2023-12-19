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

    
       private void Awake() {
        audioSourceOne.loop=true;
       }
   

    
    
       public void PlayPauseMusic ()
    {   audioSourceOne.Stop();
        audioSourceOne.clip = pause;
        audioSourceOne.Play();
        
    }
      public void PlayLevelMusic ()
    {
        audioSourceOne.Stop();
        audioSourceOne.clip = soundtrack;
        audioSourceOne.Play();
        
    }
    public void PlayCubeFx ()
    {
        audioSourceTwo.clip = cubeFX;
        audioSourceTwo.Play();
        
    }
 
       public void PlayWallFx ()
    {
        audioSourceTwo.clip = wallFX;
        audioSourceTwo.Play();
        
    }
       public void PlayGameOverFx ()
    {
        audioSourceTwo.clip = gameOverFX;
        audioSourceTwo.Play();
        
    }

   

}
