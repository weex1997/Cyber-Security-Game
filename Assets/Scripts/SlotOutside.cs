using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotOutside : MonoBehaviour, IDropHandler
{
    public Transform startPostion;

    public void OnDrop(PointerEventData eventData)
    {

        GameObject dropped = eventData.pointerDrag;
        DragDropUI draggableItem = dropped.GetComponent<DragDropUI>();
        draggableItem.parentAfterDrag = startPostion;
        draggableItem.transform.position = startPostion.position;


    }
}
