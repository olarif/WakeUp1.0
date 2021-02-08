using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuSound : MonoBehaviour
{
    private static FMOD.Studio.EventInstance Music;
    // Start is called before the first frame update
    public Scene play;
    void Start()
    {
        play = SceneManager.GetSceneAt(1);
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/DeathMenu");
        
        Music.start();
    }
    private void Update()
    {
        if(play.isLoaded)
        {
            Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Music.release();
        }
    }
    private void OnDestroy()
    {
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Music.release();
    }
}
