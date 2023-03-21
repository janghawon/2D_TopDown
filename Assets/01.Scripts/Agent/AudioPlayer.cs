using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    protected AudioSource _audioSource;
    [SerializeField] protected float _pitchRandmness = 0.2f;
    protected float _basePitch;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _basePitch = _audioSource.pitch;
    }

    public void PlayClipWithVariablePitch(AudioClip clip)
    {
        float randomPitch = Random.Range(-_pitchRandmness, _pitchRandmness);
        _audioSource.pitch = _basePitch + randomPitch;
        playClip(clip);
    }

    public void playClip(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
