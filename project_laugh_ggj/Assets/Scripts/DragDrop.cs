using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    public RectTransform dropZone;

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
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CustomerStateMachine.Instance.IsCustomerSellable)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(dropZone, eventData.position, eventData.pressEventCamera))
        {
            CustomerStateMachine.Instance.GaveGift = gameObject;
            gameObject.SetActive(false);
            CustomerStateMachine.Instance.ChangeState<CustomerReactionState>();
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}
