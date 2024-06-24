using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotAnimation : MonoBehaviour
{
    public void AnimationItemSlot()
    {
        transform.DOScale(1.1f, 0.2f).OnComplete(() =>
        {
            transform.DOScale(1f, 0.2f);
        });
    }
}
