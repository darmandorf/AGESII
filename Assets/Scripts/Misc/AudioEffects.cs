using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    private AudioSource musicPlayer;
    public float leftPan = -1f;
    public float rightPan = 1f;
    public float panRate = .5f;
    private float targetPan = -1f;
    private float currentPan;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = gameObject.GetComponent<AudioSource>();
        currentPan = musicPlayer.panStereo;
    }

    // Update is called once per frame
    void Update()
    {
        currentPan = Mathf.MoveTowards(musicPlayer.panStereo, targetPan, Time.deltaTime * panRate);
        if (currentPan >= rightPan)
        {
           currentPan = rightPan;
           targetPan = leftPan;
        }
        else if (currentPan <= leftPan)
        {
            currentPan = leftPan;
            targetPan = rightPan;
        }
       musicPlayer.panStereo = currentPan;
    }
}
