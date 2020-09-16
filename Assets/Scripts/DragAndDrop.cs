using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

/*
 * Этот скрипт содержит функию DragAndDrop 
 * Было использованно Unity Events System
 */
public class DragAndDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{

    [SerializeField] private Canvas _canvas = null;
    [SerializeField] private RectTransform _rectTransform = null;

    private Vector2 _startPos;

    public Vector2 StartPos => _startPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPos = _rectTransform.transform.position;
    }
    
}
