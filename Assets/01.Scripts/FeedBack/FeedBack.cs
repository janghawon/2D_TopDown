using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FeedBack : MonoBehaviour
{
    public abstract void CreateFeedback();
    public abstract void CompleteFeedback();

    protected virtual void OnDestroy()
    {
        CompleteFeedback();
    }
    protected virtual void OnDisable()
    {
        CompleteFeedback();
    }
}
