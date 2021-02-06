using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonAudio : MonoBehaviour
{
    private Vector3 pos, oldpos;
    private FMOD.Studio.EventInstance pistonLoop;
    private FMOD.Studio.PLAYBACK_STATE pbState;
    private float Direction;
    

    // Start is called before the first frame update
    void Start()
    {
        CheckPistonDirection();
        pistonLoop = FMODUnity.RuntimeManager.CreateInstance("event:/LaunchingPiston");
        pistonLoop.setParameterByName("PistonDirection", Direction);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(pistonLoop, transform, GetComponent<Rigidbody2D>());
       // pistonLoop.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform, GetComponent<Rigidbody2D>()));

        oldpos = transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        pistonLoop.getPlaybackState(out pbState);
        pos = transform.position;
       // State = 0f;
        //pistonLoop.setParameterByName("PistonEnding", State);
        if (pos != oldpos)
        {
            if (pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                
                pistonLoop.start();
                
            }
        }
        else if (pos == oldpos && pbState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            //State = 1f;
           // pistonLoop.setParameterByName("PistonEnding", State); 
            pistonLoop.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            
        }
        oldpos = pos;
    }
    public void CheckPistonDirection()
    {
        if (gameObject.tag == "PistonLift")
            Direction = 0f;
        else
            Direction = 1f;
    }
     void OnDestroy()
    {
        pistonLoop.release();
    }
}
