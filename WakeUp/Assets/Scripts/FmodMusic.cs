using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodMusic : MonoBehaviour
{
    private static FMOD.Studio.EventInstance backgroundMusic;
    public GameObject pause,win,sleep;
    FMOD.Studio.PLAYBACK_STATE pbState;


    // Start is called before the first frame update
    void Start()
    {
        
        backgroundMusic = FMODUnity.RuntimeManager.CreateInstance("event:/lvl1_Music");
        
        backgroundMusic.start();
        //Music.release();
    }

    // Update is called once per frame
    void Update()
    {
        pause = GameObject.FindGameObjectWithTag("PauseMenu");
        win = GameObject.FindGameObjectWithTag("WinMenu");
        sleep = GameObject.FindGameObjectWithTag("DeathMenu");
        backgroundMusic.getPlaybackState(out pbState);

        pauseCheck();
        winCheck();
        deathCheck();


    }

    private void pauseCheck()
    {
        if ((pause != null) && pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        else if ((pause == null) && pbState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            backgroundMusic.start();
    }    
    private void winCheck()
    {
        if ((win != null) && pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        else if ((win == null) && pbState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
            backgroundMusic.start();
    }   
    private void deathCheck()
    {
        if ((sleep != null) && pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            
        }
            
        else if ((sleep == null) && pbState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
        {
           
            backgroundMusic.start();
        }
            
    }
    private void OnDestroy()
    {
        backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        backgroundMusic.release();
    }


}
