using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRenderer : MonoBehaviour
{
    [SerializeField] protected int _playerSortingOrder = 5;
    protected SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSpriter(bool value)
    {
        Vector3 locationScale = new Vector3(1, 1, 1);
        if(value)
        {
            locationScale.y = -1;
        }
        transform.localScale = locationScale;
    }

    public void RenderBehindHead(bool value)
    {
        _spriteRenderer.sortingOrder = value ? _playerSortingOrder - 1 : _playerSortingOrder + 1;
    }
}
