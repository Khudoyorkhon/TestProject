using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Этот скрипт получает информацию прямоугольнике и на основе этой информации выравнивает его и проверятет может ли прямоугольник 
 * помястится в него
 */
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
                                _width = 0;
                            }
                            rectangle.CanvasGroup.interactable = false;
                            rectangle.CanvasGroup.blocksRaycasts = false;
                            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);

                            Debug.Log("new Heigth is : " + rectangle.LayoutElement.minHeight + " new Width  is : " + rectangle.LayoutElement.minWidth);
                        }
                        else
                        {
                            rectangle.LayoutElement.minHeight = rectangle.Heigth;
                            rectangle.LayoutElement.minWidth = rectangle.Heigth;

                            _width = _width - rectangle.Heigth - _layoutGroup.spacing;
                            if (_width < 0)
                            {
                                _width = 0;
                            }
                            rectangle.CanvasGroup.interactable = false;
                            rectangle.CanvasGroup.blocksRaycasts = false;
                            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);

                            Debug.Log("new Heigth is : " + rectangle.LayoutElement.minHeight + " new Width  is : " + rectangle.LayoutElement.minWidth);
                        }   
                        break;

                    case "Rectangle":
                        if (rectangle.Width > _width || rectangle.Heigth > _heigth)
                        {
                            if (rectangle.Width > _width)
                            {
                                rectangle.LayoutElement.minWidth = _width;
                                _width = _width - _width;
                            }
                            else
                            {
                                rectangle.LayoutElement.minWidth = rectangle.Width;
                                _width = _width - rectangle.Width- _layoutGroup.spacing;
                            }

                            if (rectangle.Heigth > _heigth)
                            {
                                rectangle.LayoutElement.minHeight = _heigth;
                                _width = _width - rectangle.Width - _layoutGroup.spacing;
                            }
                            else
                            {
                                rectangle.LayoutElement.minHeight = rectangle.Heigth;
                                _width = _width - rectangle.Width - _layoutGroup.spacing;
                            }

                            
                            if (_width < 0)
                            {
                                _width = 0;
                            }

                            Debug.Log("new Heigth is : " + rectangle.LayoutElement.minHeight + " new Width  is : " + rectangle.LayoutElement.minWidth);
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
                                _width = 0;
                            }

                            Debug.Log("new Heigth is : " + rectangle.LayoutElement.minHeight + " new Width  is : " + rectangle.LayoutElement.minWidth);

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
