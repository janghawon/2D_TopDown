using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using DG.Tweening;

public class SheepManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> movePos = new List<GameObject>();

    public void MovePos(PosList pos)
    {
        GameObject[] sheeps = GameObject.FindGameObjectsWithTag("Sheep");
        foreach(GameObject sheep in sheeps)
        {
            sheep.gameObject.transform.DOMove(ChoosePos(pos));
        }
    }

    private Vector2 ChoosePos(PosList pos)
    {
        switch(pos)
        {
            case PosList.pos1:
                return movePos[1].transform.position;
        }
        return Vector2.zero;
    }
}
