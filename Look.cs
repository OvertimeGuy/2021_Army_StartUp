using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look : MonoBehaviour
{
    public static Look look;
    public Image up;

    public Image down;

    public RectTransform target;
    private float distance;
    public float targetDistance;
    private bool _use;
    public bool use
    {
        get
        {
            return _use;
        }
        set
        {
            
            if (value && !_use)
            {
                distance = targetDistance;
                
                float taregtY = (Screen.height - target.offsetMax.y - distance) / up.rectTransform.localScale.y;
                up.rectTransform.sizeDelta = new Vector2(up.rectTransform.sizeDelta.x, taregtY*0.5f);
                float targetY2=(target.offsetMin.y-distance)/down.rectTransform.localScale.y;
                down.rectTransform.sizeDelta = new Vector2(up.rectTransform.sizeDelta.x, targetY2*0.5f);
            }
            _use = value;
        }
    }

    private CanvasGroup cg;
    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        look = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (use) cg.alpha = Mathf.Lerp(cg.alpha, 1, 8 * Time.deltaTime);
        else cg.alpha = Mathf.Lerp(cg.alpha, 0, 8 * Time.deltaTime);
        distance = Mathf.Lerp(distance, targetDistance, 10 * Time.deltaTime);
        //print("Up"+target.anchoredPosition.y);
        //print("Down"+target.anchoredPosition.y);
        print("Max"+target.offsetMax);
        print("Min"+target.offsetMin);
        float taregtY = (Screen.height - target.offsetMax.y - distance) / up.rectTransform.localScale.y;
        up.rectTransform.sizeDelta = new Vector2(up.rectTransform.sizeDelta.x, 
            Mathf.Lerp(up.rectTransform.sizeDelta.y,taregtY,10*Time.deltaTime));
        float targetY2=(target.offsetMin.y-distance)/down.rectTransform.localScale.y;
        down.rectTransform.sizeDelta = new Vector2(up.rectTransform.sizeDelta.x, 
            Mathf.Lerp(down.rectTransform.sizeDelta.y,targetY2,10*Time.deltaTime));
    }
}
