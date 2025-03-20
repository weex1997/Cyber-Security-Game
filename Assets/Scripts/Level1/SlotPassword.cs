using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotPassword : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        GameObject dropped = eventData.pointerDrag;
        DragDropUI draggableItem = dropped.GetComponent<DragDropUI>();

        if (transform.childCount != 0)
        {
            GameObject current = transform.GetChild(0).gameObject;
            DragDropUI currentDraggable = current.GetComponent<DragDropUI>();

            currentDraggable.transform.SetParent(draggableItem.parentAfterDrag);
            currentDraggable.transform.position = draggableItem.parentAfterDrag.position;
        }

        draggableItem.parentAfterDrag = transform;
        draggableItem.transform.position = transform.position;

        //sound
        SoundManager.PlaySound(SoundType.iPad);
    }
}
