using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    public enum State { Logo=0,Login=1,Main=2,Ranking1=3,Ranking2=4,SNS=5,MyPage=6,Missoin = 7,News=8 }

    public Page_Login pageLogin;
    public Page_Start pageStart;
    public Page_Feed pageFeed;
    public Page_Ranking pageRanking;
    public Page_SNS pageSns;
    public Page_MyPage pageMyPage;
    public Image mainBtn, rankingBtn, SNSBtn, myPageBtn;
    public Color selectedColor, deselectedColor;

    [Button]
    public void GOGOGO()
    {
        StartCoroutine("GOGO");
    }
    public void Start()
    {
        //pageFeed.rt.anchoredPosition = new Vector2(Screen.width * 2f, pageSns.rt.anchoredPosition.y);
        pageRanking.rt.anchoredPosition = new Vector2(Screen.width * 2f, pageSns.rt.anchoredPosition.y);
        pageSns.rt.anchoredPosition = new Vector2(Screen.width * 2f, pageSns.rt.anchoredPosition.y);
        pageMyPage.rt.anchoredPosition = new Vector2(Screen.width * 2f, pageSns.rt.anchoredPosition.y);
        
        StartCoroutine("GOGO");
    }
    [Button]
    public void Enter()
    {
        pageStart.Remove();
        pageLogin.Enter();
    }
    [Button]
    public void Login()
    {
        pageLogin.Login();
    }

    [Button]
    public void MainEnter()
    {
        pageLogin.Remove();
        mainBtn.color = selectedColor;
        rankingBtn.color = deselectedColor;
        SNSBtn.color = deselectedColor;
        myPageBtn.color = deselectedColor;
        mainBtn.transform.DOPunchScale(Vector3.one * 0.1f, 0.3f, 2);
        
    }
    
    [Button]
    public void RankingEnter()
    {
        mainBtn.color = deselectedColor;
        rankingBtn.color = selectedColor;
        SNSBtn.color = deselectedColor;
        myPageBtn.color = deselectedColor;
        rankingBtn.transform.DOPunchScale(Vector3.one * 0.1f, 0.3f, 2);

        
        pageRanking.cg.alpha = 0;
        pageFeed.cg.alpha = 1;
        pageRanking.rt.anchoredPosition = new Vector2(Screen.width * 2f, pageRanking.rt.anchoredPosition.y);
        pageFeed.rt.anchoredPosition = new Vector2(0, pageRanking.rt.anchoredPosition.y);
        pageRanking.rt.DOAnchorPosX(0.0f, 0.3f).SetEase(Ease.OutQuint);
        pageFeed.rt.DOAnchorPosX(Screen.width * -2f, 0.3f).SetEase(Ease.OutQuint);
        pageRanking.cg.DOFade(1, 0.45f);
        pageFeed.cg.DOFade(0, 0.175f);
        
    }

    [Button]
    public void ChangeSection()
    {
        pageRanking.ChangeSection();
    }
    [Button]
    public void SNSEnter()
    {
        mainBtn.color = deselectedColor;
        rankingBtn.color = deselectedColor;
        SNSBtn.color = selectedColor;
        myPageBtn.color = deselectedColor;
        SNSBtn.transform.DOPunchScale(Vector3.one * 0.1f, 0.3f, 2);
        
        
        pageSns.cg.alpha = 0;
        pageRanking.cg.alpha = 1;
        pageSns.rt.anchoredPosition = new Vector2(Screen.width * 2f, pageSns.rt.anchoredPosition.y);
        pageRanking.rt.anchoredPosition = new Vector2(0, pageSns.rt.anchoredPosition.y);
        pageSns.rt.DOAnchorPosX(0.0f, 0.3f).SetEase(Ease.OutQuint);
        pageRanking.rt.DOAnchorPosX(Screen.width * -2f, 0.3f).SetEase(Ease.OutQuint);
        pageSns.cg.DOFade(1, 0.45f);
        pageRanking.cg.DOFade(0, 0.175f);
    }

    [Button]
    public void MyPageEnter()
    {
        mainBtn.color = deselectedColor;
        rankingBtn.color = deselectedColor;
        SNSBtn.color = deselectedColor;
        myPageBtn.color = selectedColor;
        myPageBtn.transform.DOPunchScale(Vector3.one * 0.1f, 0.3f, 2);
        
        pageMyPage.cg.alpha = 0;
        pageSns.cg.alpha = 1;
        pageMyPage.rt.anchoredPosition = new Vector2(Screen.width * 2f, pageMyPage.rt.anchoredPosition.y);
        pageSns.rt.anchoredPosition = new Vector2(0, pageMyPage.rt.anchoredPosition.y);
        pageMyPage.rt.DOAnchorPosX(0.0f, 0.3f).SetEase(Ease.OutQuint);
        pageSns.rt.DOAnchorPosX(Screen.width * -2f, 0.3f).SetEase(Ease.OutQuint);
        pageMyPage.cg.DOFade(1, 0.45f);
        pageSns.cg.DOFade(0, 0.175f);
    }
    
    IEnumerator GOGO ()
    {
        yield return new WaitForSeconds(1.5f);
        Enter();
        yield return new WaitForSeconds(0.5f);
        Login();
        yield return new WaitForSeconds(4.0f);
        MainEnter();
        yield return new WaitForSeconds(1.2f);
        pageFeed.Scroll();
        yield return new WaitForSeconds(2.0f);
        pageFeed.Heart();
        yield return new WaitForSeconds(2.5f);
        pageFeed.Reply();
        yield return new WaitForSeconds(8.0f);
        pageFeed.NewsFeed_Open();
        yield return new WaitForSeconds(3.7f);
        pageFeed.NewxFeed_Close();
        yield return new WaitForSeconds(1.2f);
        pageFeed.Participate();
        yield return new WaitForSeconds(1.5f);
        pageFeed.MissionFeed_Open();
        yield return new WaitForSeconds(3.7f);
        pageFeed.MissionFeed_Close();
        
        yield return new WaitForSeconds(1.5f);
        RankingEnter();
        yield return new WaitForSeconds(2.0f);
        ChangeSection();
        yield return new WaitForSeconds(2.0f);
        SNSEnter();
        yield return new WaitForSeconds(2.0f);
        MyPageEnter();
        yield return new WaitForSeconds(2.0f);
        pageMyPage.Scroll();
        yield return new WaitForSeconds(3.5f);
        pageStart.cg.alpha = 0;
        pageStart.transform.localScale = Vector3.one;
        pageStart.cg.DOFade(1, 1.5f);
    }
}
