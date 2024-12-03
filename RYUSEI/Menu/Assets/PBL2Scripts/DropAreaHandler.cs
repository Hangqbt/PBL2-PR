using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropAreaHandler : MonoBehaviour, IDropHandler
{
    public string expectedItemID;
    public float snapRadius = 100f;
    private Image areaImage;


    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedItem = eventData.pointerDrag;


        if(draggedItem != null)
        {
            DragHandler dragHandler = draggedItem.GetComponent<DragHandler>();

            if (dragHandler != null && dragHandler.itemID ==expectedItemID)
            {
                RectTransform draggedRect = draggedItem.GetComponent<RectTransform>();
                float distance = Vector2.Distance(draggedRect.anchoredPosition, GetComponent<RectTransform>().anchoredPosition);

                if(distance <= snapRadius)
                {
                    Destroy(draggedItem);
                    areaImage.color = Color.red;
                    Debug.Log($"'{draggedItem.name}' successfully dropped into '{gameObject.name}'");
                }
                else
                {
                    draggedRect.anchoredPosition = dragHandler.originalPosition;
                    Debug.Log($"Drop failed: {draggedItem.name} is too far from {gameObject.name}");
                }
            }
            else
            {
                RectTransform draggedRect = draggedItem.GetComponent<RectTransform>();
                draggedRect.anchoredPosition = dragHandler.originalPosition;
                Debug.Log($"Drop failed: {draggedItem.name} does not match '{expectedItemID}'");
            }
        }
    }
}
