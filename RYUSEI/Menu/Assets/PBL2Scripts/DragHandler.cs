using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string itemID;

    public RectTransform rectTransform;
    public Canvas canvas;
    public Vector2 originalPosition;
    private Transform originalParent;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;
        image = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //During being dragged, it is dispached from parent object
        transform.SetParent(canvas.transform);

        //Change the color of the object while being draged
        if (image != null)
        {
            image.color = Color.gray;
        }
        originalPosition = rectTransform.anchoredPosition;
        //record the original position
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);

        rectTransform.anchoredPosition = originalPosition;
        if (image != null)
        {
            image.color = Color.white;
        }
        
    }

}
