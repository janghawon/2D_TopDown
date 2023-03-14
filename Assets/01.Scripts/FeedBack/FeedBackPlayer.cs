using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackPlayer : MonoBehaviour
{
    [SerializeField] private List<FeedBack> _feedbackToPlay = null;

    public void PlayFeedBack()
    {
        foreach (FeedBack f in _feedbackToPlay)
        {
            f.CreateFeedback();
        }
    }
    public void FinishFeedBack()
    {
        foreach (FeedBack f in _feedbackToPlay)
        {
            f.CompleteFeedback();
        }
    }
}
