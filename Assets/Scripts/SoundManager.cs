using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    AudioSource ronron;

    bool m_ToggleChange;
    public bool m_Play;

    // Start is called before the first frame update
    void Start()
    {
        ronron = GetComponent<AudioSource>();
        ronron.Stop();
        m_Play = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMusic();
    }

    private void CheckMusic()
    {
        if (PetManager.cat.catFeeling == ECatStateType.RonronStart && !ronron.isPlaying)
        {
            Debug.Log("ronron start");
            ronron.Play();
            m_ToggleChange = false;
            m_Play = true;
        }

        if (PetManager.cat.catFeeling == ECatStateType.RonronSucces && ronron.isPlaying)
        {
            Debug.Log("ronron stop feeling");
            ronron.Stop();
            m_Play = false;
            m_ToggleChange = false;
        }

        if (m_Play == false && m_ToggleChange == true)
        {
            //Stop the audio
            ronron.Stop();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
        if (PetManager.cat.catScore <= 15)
        {

            if (m_Play == true)
            {
                Debug.Log("ronron stop score");
                ronron.Stop();

            }
        }
    }
}
