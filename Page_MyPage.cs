using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class Page_MyPage : MonoBehaviour
{
    public CanvasGroup cg;

    public RectTransform rt;

    public RectTransform targetScroll;
    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    public void Scroll()
    {
        targetScroll.DOAnchorPosY(1351, 1.5f).SetEase(Ease.InOutCubic);
    }
}
