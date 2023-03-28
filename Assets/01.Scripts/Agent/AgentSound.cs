using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSound : AudioPlayer
{
    public AudioClip stepSound, hitClip, deathClip, attackSound;
    
    public void PlayStepSound()
    {
        PlayClipWithVariablePitch(stepSound);
    }

    public void PlayerHitClip()
    {
        PlayClipWithVariablePitch(hitClip);
    }

    public void PlayDeathClip()
    {
        playClip(deathClip);
    }

    public void PlayAttackClip()
    {
        playClip(attackSound);
    }
}
