using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : AudioPlayer
{
    public AudioClip shootBulletClip, outBulletClip, reloadClip = null;

    public void PlayShootSound()
    {
        playClip(shootBulletClip);
    }
    public void PlayOutofBulletSound()
    {
        playClip(shootBulletClip);
    }
    public void PlayReloadSound()
    {
        playClip(reloadClip);
    }
}
