using UnityEngine.UI;
using UnityEngine;

/*
 * Этот скрипт содержит информацию о прямоугольнике а так же переменные для выравнивания
 */
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

    public GameData Data;

    private float MinWidth, MaxWidth, MinHeigth, MaxHeigth;


    void Start()
    {
        MinWidth = Data.RectMinWidth;
        MaxWidth = Data.RectMathWidth;
        MinHeigth = Data.RectMinHeigth;
        MaxHeigth = Data.RectMaxHeigth;

        _width = Random.Range(MinWidth,MaxWidth);
        _heigth = Random.Range(MinHeigth, MaxHeigth);

        _rectTransform.sizeDelta = new Vector2(_width,_heigth);

        print("width : " + _width);        
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
