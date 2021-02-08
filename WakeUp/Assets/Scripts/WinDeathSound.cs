using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDeathSound : MonoBehaviour
{
    public string Path;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        FMODUnity.RuntimeManager.PlayOneShotAttached(Path, gameObject);
    }
}
