using UnityEngine.UI;
using UnityEngine;

public class Rectangle : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform = null;
    [SerializeField] private LayoutElement _layoutElement = null;
    [SerializeField] private CanvasGroup _canvasGroup = null;

    private float _width, _heigth;
    private string _type;

    public float Width => _width;
    public float Heigth => _heigth;
    public string Type => _type;
    public LayoutElement LayoutElement => _layoutElement;

    public CanvasGroup CanvasGroup => _canvasGroup;


    void Start()
    {
        _width = _rectTransform.rect.width;
        print("width : " + _width);
        _heigth = _rectTransform.rect.height;
        print("heigth : " + _heigth);

        if(_width == _heigth)
        {
            _type = "Box";
            print(_type);
        }
        else
        {
            _type = "Rectangle";
            print(_type);
        }
    }



}
