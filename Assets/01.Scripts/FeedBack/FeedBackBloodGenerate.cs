using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackBloodGenerate : FeedBack
{
    AIActionData _aiActionData;
    [SerializeField] [Range(0,1)]private float _sizeFactor;
    private void Awake()
    {
        _aiActionData = GameObject.Find("AI").GetComponent<AIActionData>();
    }
    public override void CompleteFeedback()
    {

    }

    public override void CreateFeedback()
    {
        TextureParticleManager.Instance.SpawnBlood(_aiActionData.hitPoint, 
                                                   _aiActionData.hitNormal, 
                                                   _sizeFactor);
    }

    
}
