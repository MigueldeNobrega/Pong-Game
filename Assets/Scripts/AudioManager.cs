using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;    

    private List<GameObject> activeAudios; //LO QUE ESTÁ SONANDO EN EL JUEGO

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            activeAudios = new List<GameObject>(); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource PlayAudio(AudioClip clip ,string objectName, float volume=1, bool isLoop=false)
    {

        GameObject audioObject = new GameObject(objectName);
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>();
        audioSourceComponent.clip = clip;
        audioSourceComponent.volume = volume;   
        audioSourceComponent.loop = isLoop;
        audioSourceComponent.Play();

        if (!isLoop) { 
        
            activeAudios.Add(audioObject);

            StartCoroutine(CheckAudio(audioSourceComponent));

        
        }

       

        return audioSourceComponent;
    }


    IEnumerator CheckAudio(AudioSource audioSource) //SIMULA EL COMPORTAMIENTO DE UN HILO (NO ES UN HILO)
    {
        while(audioSource.isPlaying)
        {

            yield return new WaitForSeconds(.2f);  //PAUSA LA EJECUCION
            

        }

        activeAudios.Remove(audioSource.gameObject);
        Destroy(audioSource.gameObject);

    }

}
