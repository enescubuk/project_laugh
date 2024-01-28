using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    public RectTransform dropZone;

    public AudioClip ClickSound;
    public GameObject GiftBoxTop;
    public GameObject GiftBoxBottom;

    public Vector2 aPos;
    public Vector2 bPos;
    public Vector2 cPos;
    


    void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        CustomerStateMachine.Instance.SoundFeedBack(ClickSound);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(dropZone, eventData.position, eventData.pressEventCamera)&&CustomerStateMachine.Instance.IsCustomerSellable)
        {
            CustomerStateMachine.Instance.GaveGift = gameObject;

            gameObject.SetActive(false);
            GetComponentInParent<AudioSource>().Play();
            CustomerStateMachine.Instance.ChangeState<CustomerReactionState>();
            //GiftBoxAnim();
        }
        rectTransform.DOAnchorPos(originalPosition, 0.5f);
    }

    private void GiftBoxAnim()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(GiftBoxTop.transform.DOMove(bPos, 1.0f));
        mySequence.Append(GiftBoxTop.transform.DOMove(cPos, 0.5f).SetEase(Ease.OutElastic)); 
        mySequence.Play();
    }

    private void GiftPosReset()
    {
        GiftBoxTop.transform.DOMove(aPos, 1f).SetEase(Ease.InOutElastic);
    }
}
