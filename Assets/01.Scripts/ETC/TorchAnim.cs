using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class TorchAnim : MonoBehaviour
{
    private Light2D _light;

    private float _baseIntensity;
    private float _baseRadius;
    private int _toggle = 1;

    [SerializeField] private float _radiusRandomness = 1f;
    private void Awake()
    {
        _light = GetComponent<Light2D>();
        _baseRadius = _light.pointLightOuterRadius;
        _baseIntensity = _light.intensity;
    }
    private void Start()
    {
        StartShake();
    }

    private void StartShake()
    {
        float randTime = Random.Range(0.1f, 0.5f);
        float targetRadius = _baseRadius + Random.Range(0, _radiusRandomness);
        float targetRadiusInner = Random.Range(0.5f, 0.9f);
        float targetIntensity = _baseIntensity + _toggle * Random.Range(0, _radiusRandomness * 0.5f);
        _toggle *= -1;

        Sequence seq = DOTween.Sequence();

        var t0 = DOTween.To(() => _light.pointLightInnerRadius,
                    value => _light.pointLightInnerRadius = value,
                    targetRadiusInner,
                    randTime);

        var t1 = DOTween.To(() => _light.pointLightOuterRadius,
                    value => _light.pointLightOuterRadius = value,
                    targetRadius,
                    randTime);

        var t2 = DOTween.To(() => _light.pointLightOuterRadius,
                value => _light.pointLightOuterRadius = value,
                targetRadius,
                randTime).OnComplete(() => StartShake());

        seq.Append(t1);
        seq.Join(t2);
        seq.Join(t0);
        seq.AppendCallback(() => StartShake());
    }
}
