using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class Page_Ranking : MonoBehaviour
{
    public CanvasGroup cg;
    public RectTransform rt;

    public Text trendingText;
    
    public Text lateText;

    public Image sectionImage;

    public CanvasGroup trendingCanvas;

    public CanvasGroup lateCanvas;
    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        rt = GetComponent<RectTransform>();
    }

    [Button]
    public void ChangeSection()
    {
        trendingText.DOColor(new Color(trendingText.color.r, trendingText.color.g, trendingText.color.b, 0), 0.3f);
        lateText.DOColor(new Color(lateText.color.r, lateText.color.g, lateText.color.b, 1), 0.3f);
        
        trendingText.gameObject.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(50, trendingText.gameObject.GetComponent<RectTransform>().anchoredPosition.y);
        trendingText.gameObject.GetComponent<RectTransform>().DOAnchorPosX(100,0.3f);
        
        lateText.gameObject.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(-100, lateText.gameObject.GetComponent<RectTransform>().anchoredPosition.y);
        lateText.gameObject.GetComponent<RectTransform>().DOAnchorPosX(-50,0.3f);
        float target = sectionImage.rectTransform.anchorMax.x;
        sectionImage.rectTransform.DOAnchorPosX(sectionImage.rectTransform.sizeDelta.x, 0.3f);
        
        lateCanvas.alpha = 0;
        
        lateCanvas.GetComponent<RectTransform>().anchoredPosition = 
            new Vector2(Screen.width * 2f, lateCanvas.GetComponent<RectTransform>().anchoredPosition.y);
        lateCanvas.GetComponent<RectTransform>().DOAnchorPosX(0.0f, 0.45f).SetEase(Ease.OutQuint);
        lateCanvas.DOFade(1, 0.55f);
        
        trendingCanvas.alpha = 1;
        trendingCanvas.GetComponent<RectTransform>().anchoredPosition = 
            new Vector2(0, trendingCanvas.GetComponent<RectTransform>().anchoredPosition.y);
        trendingCanvas.GetComponent<RectTransform>().DOAnchorPosX(Screen.width * -2f, 0.45f).SetEase(Ease.OutQuint);
        
        trendingCanvas.DOFade(0, 0.45f);
    }
}
