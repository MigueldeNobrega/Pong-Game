using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{

    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayAudio(clip, "Musica de Fondo", volume, true);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


