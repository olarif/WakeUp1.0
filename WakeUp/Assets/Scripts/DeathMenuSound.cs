using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuSound : MonoBehaviour
{
    private static FMOD.Studio.EventInstance Music;
    FMOD.Studio.PLAYBACK_STATE pbState;
    public GameObject Death;
    // Start is called before the first frame update
    void Start()
    {
       
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/DeathMenu");
        
        Music.start();
    }
    private void Update()
    {
        Death = GameObject.FindGameObjectWithTag("DeathMenu");
        Music.getPlaybackState(out pbState);

        if (Death == null && pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        else if (Death != null && pbState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            Music.start();

    }
    private void OnDestroy()
    {
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Music.release();
    }
}
