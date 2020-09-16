using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour, IDropHandler
{
    [SerializeField] RectTransform _rectTransform = null;
    [SerializeField] HorizontalLayoutGroup _layoutGroup = null;

    private float _width, _heigth, _tempWidth;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            _tempWidth = _width;

            eventData.pointerDrag.TryGetComponent<Rectangle>(out Rectangle rectangle);
            eventData.pointerDrag.TryGetComponent<DragAndDrop>(out DragAndDrop drag);


            if (_width > rectangle.Width)
            {
                switch (rectangle.Type)
                {
                    case "Box":
                        if (rectangle.Width > _width || rectangle.Heigth > _heigth)
                        {
                            rectangle.LayoutElement.minHeight = _heigth;
                            rectangle.LayoutElement.minWidth = _heigth;

                            _width = _width - _heigth -_layoutGroup.spacing;
                            if(_width < 0)
                            {
                                _width = _tempWidth;
                            }
                            rectangle.CanvasGroup.interactable = false;
                            rectangle.CanvasGroup.blocksRaycasts = false;
                            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
                        }
                        else
                        {
                            rectangle.LayoutElement.minHeight = rectangle.Heigth;
                            rectangle.LayoutElement.minWidth = rectangle.Heigth;

                            _width = _width - rectangle.Heigth - _layoutGroup.spacing;
                            if (_width < 0)
                            {
                                _width = _tempWidth;
                            }
                            rectangle.CanvasGroup.interactable = false;
                            rectangle.CanvasGroup.blocksRaycasts = false;
                            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
                        }   
                        break;

                    case "Rectangle":
                        if (rectangle.Width > _width || rectangle.Heigth > _heigth)
                        {
                            if (rectangle.Width > _width)
                            {
                                rectangle.LayoutElement.minWidth = _width;
                            }
                            else
                            {
                                rectangle.LayoutElement.minWidth = rectangle.Width;
                            }

                            if (rectangle.Heigth > _heigth)
                            {
                                rectangle.LayoutElement.minHeight = _heigth;
                            }
                            else
                            {
                                rectangle.LayoutElement.minHeight = rectangle.Heigth;
                            }

                            _width = 0;
                            if (_width < 0)
                            {
                                _width = _tempWidth;
                            }
                            rectangle.CanvasGroup.interactable = false;
                            rectangle.CanvasGroup.blocksRaycasts = false;
                            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
                        }
                        else
                        {
                            rectangle.LayoutElement.minHeight = rectangle.Heigth;
                            rectangle.LayoutElement.minWidth = rectangle.Width;

                            _width = _width - rectangle.Width - _layoutGroup.spacing;
                            if (_width < 0)
                            {
                                _width = _tempWidth;
                            }
                            rectangle.CanvasGroup.interactable = false;
                            rectangle.CanvasGroup.blocksRaycasts = false;
                            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
                        }
                        break;

                }
            }
            else
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position = drag.StartPos;
            }

        }
    }

    void Start()
    {
        _width = _rectTransform.rect.width;
        print("width : " + _width);
        _heigth = _rectTransform.rect.height;
        print("heigth : " + _heigth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
