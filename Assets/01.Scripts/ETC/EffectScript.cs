using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EffectScript : PoolableMono
{
    [SerializeField] private float _stopTime = 0.5f;
    [SerializeField] private float _lightOffTime = 1f;
    private float _initIntensity;

    private ParticleSystem _particleSystem;
    private Light2D _light;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _light = transform.Find("Light2D").GetComponent<Light2D>();
        _light.enabled = false;
        _initIntensity = _light.intensity;
    }

    public void PlayEffect()
    {
        _particleSystem.Play();
        _light.enabled = true;
    }

    public void StopEffect()
    {
        StartCoroutine(DelayOff());
    }

    IEnumerator DelayOff()
    {
        float currentTime = 0f;
        float remainTime = _lightOffTime;
        bool isStop = false;
        

        while (currentTime < _lightOffTime)
        {
            currentTime += Time.deltaTime;
            remainTime = _lightOffTime - currentTime;
            if(remainTime < _stopTime && isStop == false)
            {
                _particleSystem.Stop();
                isStop = true;
            }
            _light.intensity = Mathf.Lerp(_initIntensity, 0, currentTime / _lightOffTime);
            yield return null;
        }
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        _light.intensity = _initIntensity;
    }
}
