using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class News : MonoBehaviour
{
    public CanvasGroup cg;
    public RectTransform rt;

    public void Start()
    {
        cg = GetComponent<CanvasGroup>();
        rt = GetComponent<RectTransform>();
    }
    [Button]
    public void Enter()
    {
        cg.alpha = 0;
        rt.anchoredPosition = new Vector2(Screen.width * 2f, rt.anchoredPosition.y);
        rt.DOAnchorPosX(0.0f, 0.3f).SetEase(Ease.OutQuint);
        cg.DOFade(1, 0.45f);
    }
    [Button]
    public void Exit()
    {
        cg.alpha = 1;
        rt.anchoredPosition = new Vector2(0.0f, rt.anchoredPosition.y);
        rt.DOAnchorPosX(Screen.width * 2f, 0.3f).SetEase(Ease.OutQuint);
        cg.DOFade(0, 0.45f);
    }
}
