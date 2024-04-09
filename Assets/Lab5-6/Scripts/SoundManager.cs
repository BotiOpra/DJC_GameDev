using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource _Source;
    [SerializeField] private AudioClip _JumpSound;
    [SerializeField] private AudioClip _HurtSound;
    [SerializeField] private AudioClip _SuccessSound;

    void Start()
    {
        _Source = GetComponent<AudioSource>();

        int numAudioSources = FindObjectsOfType<AudioSource>().Length;
        if (numAudioSources > 1)
            Destroy(_Source);
        else
            DontDestroyOnLoad(_Source);
    }

    public void PlayJumpSound()
    {
        _Source.PlayOneShot(_JumpSound);
    }

    public void PlayHurtSound()
    {
        _Source.PlayOneShot(_HurtSound);
    }

    public void PlaySuccessSound()
    {
        _Source.PlayOneShot(_SuccessSound);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
