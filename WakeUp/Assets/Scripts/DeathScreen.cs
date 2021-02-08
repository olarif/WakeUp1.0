using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    void Start()
    {
        Destroy(GameObject.FindGameObjectWithTag("GM"));
    }

    void Update()
    {
        
    }
}
