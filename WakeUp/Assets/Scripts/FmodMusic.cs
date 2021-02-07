using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodMusic : MonoBehaviour
{
    private static FMOD.Studio.EventInstance Music;
    public GameObject pause;
    FMOD.Studio.PLAYBACK_STATE pbState;


    // Start is called before the first frame update
    void Start()
    {
        
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/lvl1_Music");
        Music.start();
        //Music.release();
    }

    // Update is called once per frame
    void Update()
    {
        pause = GameObject.FindGameObjectWithTag("PauseMenu");
        Music.getPlaybackState(out pbState);

        if(pause!=null&& pbState== FMOD.Studio.PLAYBACK_STATE.PLAYING)
            Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        else if(pause==null && pbState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            Music.start();


    }
    private void OnDestroy()
    {
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
