using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using LeTai.TrueShadow;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class Page_Feed : MonoBehaviour
{
    public GameObject point;
    public CanvasGroup cg;
    public RectTransform rt;

    public Color selectedColor;
    public TrueShadow shadow;
    public Text parText;
    public List<Image> parImages = new List<Image>();
    public Animator parAtnimator;
    
    
    public RectTransform scrollTarget;
    public Text reply;
    public Image sendImage;
    public Text replyCount;
    public Text heartText;

    public Ease scrollEase;
    public Animator heart;
    public Animator txt;

    public float scrollDuration=1.5f;

    public News targetNews;

    public Mission targetMission;
    public GameObject targetNewsG;

    public GameObject targetMissionG;
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
        scrollTarget.DOAnchorPosY(1400, scrollDuration).SetEase(scrollEase);
    }
    [Button]
    public void Heart()
    {
        StartCoroutine("C_Heart");
    }

    IEnumerator C_Heart()
    {
        
        Vector3 t = Look.look.target.transform.position;
        t.y = heart.transform.position.y;
        Look.look.target.transform.position= t;
        Look.look.targetDistance = 0;
        Look.look.use = true;
        yield return new WaitForSeconds(1.0f);
        heart.SetTrigger("Trigger");
        heart.transform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 2);
        heart.transform.parent.DOPunchScale(Vector3.one * 0.15f, 0.2f, 2);
        heartText.text = "5";
        Look.look.use = false;
    }

    [Button]
    public void Reply()
    {
        StartCoroutine("C_Reply");
    }

    IEnumerator C_Reply()
    {
        Look.look.use = true;
        yield return new WaitForSeconds(0.5f);
        Vector3 t = Look.look.target.transform.position;
        t.y = txt.transform.position.y;
        Look.look.target.transform.position= t;
        yield return new WaitForSeconds(0.5f);
        //메세지 반짝
        txt.SetTrigger("Trigger");
        txt.transform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 2);
        txt.transform.parent.DOPunchScale(Vector3.one * 0.15f, 0.2f, 2);
        //댓글상자 나옴
        yield return new WaitForSeconds(1.3f);
        Look.look.targetDistance = 100;
        t.y = point.transform.position.y;
        Look.look.target.transform.position= t;
        yield return new WaitForSeconds(1.2f);
        reply.rectTransform.parent.GetComponent<RectTransform>().DOAnchorPosY(150, 0.5f);
        yield return new WaitForSeconds(0.8f);
        reply.DOText("역시 109여단 최고인것 같습니다!",0.5f);
        //전송버튼 반짝
        yield return new WaitForSeconds(1.25f);
        sendImage.transform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 2);
        //댓글상자 복귀
        yield return new WaitForSeconds(0.55f);
        reply.rectTransform.parent.GetComponent<RectTransform>().DOAnchorPosY(0, 0.5f);
        //업데이트
        txt.SetTrigger("Trigger");
        txt.transform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 2);
        txt.transform.parent.DOPunchScale(Vector3.one * 0.15f, 0.2f, 2);
        replyCount.text = "5";
        
        Look.look.use = false;
        
    }

    [Button]
    public void NewsFeed_Open()
    {
        StartCoroutine("C_NewsFeed");
    }

    [Button]
    public void NewxFeed_Close()
    {
        targetNews.cg.alpha = 1;
        targetNews.rt.anchoredPosition = new Vector2(0.0f, rt.anchoredPosition.y);
        targetNews.rt.DOAnchorPosX(1100, 0.3f).SetEase(Ease.OutQuint);
        targetNews.cg.DOFade(0, 0.45f);
    }
    IEnumerator C_NewsFeed()
    {
        //뉴스 펀치
        targetNewsG.transform.DOPunchScale(Vector3.one * 0.025f, 0.2f, 2);
        //뉴스 진입,복귀
        yield return new WaitForSeconds(0.5f);
            targetNews.cg.alpha = 0;
            targetNews.rt.anchoredPosition = new Vector2(1100, rt.anchoredPosition.y);
            targetNews.rt.DOAnchorPosX(0.0f, 0.3f).SetEase(Ease.OutQuint);
            targetNews.cg.DOFade(1, 0.45f);
        
        
    }

    [Button]
    public void Participate()
    {
        StartCoroutine("C_Participate");
        
    }

    IEnumerator C_Participate()
    {
        Vector3 t = Look.look.target.transform.position;
        t.y = parAtnimator.transform.position.y;
        Look.look.target.transform.position = t;
        Look.look.targetDistance = 0;
        Look.look.use = true;
        yield return new WaitForSeconds(0.75f);
        shadow.Color = selectedColor;
        foreach (var image in parImages)
        {
            image.color = selectedColor;
        }

        parText.text = " 참여중";
        parText.color = selectedColor;
        parAtnimator.SetTrigger("Trigger");
        parAtnimator.transform.parent.DOPunchScale(Vector3.one *-0.15f, 0.2f, 2);
    }
    [Button]
    public void MissionFeed_Open()
    {
        StartCoroutine("C_MissionFeed");
    }

    [Button]
    public void MissionFeed_Close()
    {
        
        
        targetMission.cg.alpha = 1;
        targetMission.rt.anchoredPosition = new Vector2(0.0f, rt.anchoredPosition.y);
        targetMission.rt.DOAnchorPosX(1100, 0.3f).SetEase(Ease.OutQuint);
        targetMission.cg.DOFade(0, 0.45f);
    }
    IEnumerator C_MissionFeed()
    {
        Look.look.use = false;
        yield return new WaitForSeconds(0.75f);
        //미션 펀치
        targetMissionG.transform.DOPunchScale(Vector3.one * 0.025f, 0.2f, 2);
        //미션 진입,복귀
        yield return new WaitForSeconds(0.9f);
        targetMission.cg.alpha = 0;
        targetMission.rt.anchoredPosition = new Vector2(1100, rt.anchoredPosition.y);
        targetMission.rt.DOAnchorPosX(0.0f, 0.3f).SetEase(Ease.OutQuint);
        targetMission.cg.DOFade(1, 0.45f);
    }
}
