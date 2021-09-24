using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Page_Login : MonoBehaviour
{
    public float removeDuration=0.3f;
    public Ease removeEase;
    public float enterDuration=0.3f;
    public Ease enterEase;
    public Text id;
    public Text pw;
    public GameObject enterBTN;
    private CanvasGroup cg;
    public void Start()
    {
        cg = GetComponent<CanvasGroup>();
    }
    [Button]
    public void Remove()
    {
        
        transform.DOScale(1.2f, removeDuration).SetEase(removeEase);
        cg.DOFade(0, removeDuration).SetEase(removeEase);
    }
    [Button]
    public void Enter()
    {
        transform.localScale = Vector3.one*0.8f;
        transform.DOScale(1.0f, removeDuration).SetEase(enterEase);
    }

    [Button]
    public void Login()
    {
        id.DOText("army2022@army.com", 1.0f, false).OnComplete(() =>
        {
            pw.DOText("",0.0f).SetDelay(0.4f);
        });
        
        pw.DOText("************", 1.0f, false).SetDelay(1.5f);
        enterBTN.transform.DOPunchScale(Vector3.one * -0.05f, 0.15f, 2).SetDelay(3.0f);
    }
}
