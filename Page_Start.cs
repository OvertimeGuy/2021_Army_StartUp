using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class Page_Start : MonoBehaviour
{
    public float removeDuration=0.3f;
    public Ease removeEase;
    public CanvasGroup cg;
    public void Start()
    {
        cg = GetComponent<CanvasGroup>();
    }
    [Button]
    public void Remove()
    {
        
        transform.DOScale(1.2f, removeDuration).SetEase(removeEase);
        cg.DOFade(0, removeDuration).SetEase(removeEase);;
    }
}
