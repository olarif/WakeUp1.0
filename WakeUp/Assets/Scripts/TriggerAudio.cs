using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string Event;
    public bool PlayOnAwake;
    public bool playOnDestroy;

    public void playOneShot()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
    }


    private void Start()
    {
        if (PlayOnAwake)
            playOneShot();
    }

    private void OnDestroy()
    {
        if (playOnDestroy)
            playOneShot();
        
    }

}
