using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class Fade : MonoBehaviour
{
    [SerializeField] private float animationTime = 2f;
    private float animationDifference = 0f;

    private float alpha = 0f;

    private Image image;

    public UnityEvent OnAnimationEnd;

    private void Awake()
    {
        image = GetComponent<Image>();

        alpha = image.color.a;

        animationDifference = 1f/animationTime;

        StartCoroutine(PlayFade());
    }
    //private void Update()
    //{
    //    if(alpha > 0f)
    //    {
    //        alpha -=(1.0f/animationTime) * Time.deltaTime;

    //        Color color = image.color;
    //        color.a = alpha;
    //        image.color = color;
    //    }
    //}

    System.Collections.IEnumerator PlayFade()
    {
        while (alpha >= 0f)
        {
            yield return null;

            alpha -= (animationDifference) * Time.deltaTime;

            float sinAloha = Mathf.Sin(alpha);

            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }

        OnAnimationEnd?.Invoke();
    }
}
