using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource myAudio;
    public AudioClip audio;
    public int soundPeriod = 20;
    private bool keepPlaying = true;

    private void Start()
    {
        StartCoroutine(SoundOut());
    }

    private IEnumerator SoundOut()
    {
        while (keepPlaying){
            yield return new WaitForSeconds(soundPeriod);
            myAudio.PlayOneShot(audio);
            yield return new WaitForSeconds(soundPeriod);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
