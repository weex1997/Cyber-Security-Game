using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    TMP_Text tMP_Text;
    public Transform parentAfterDrag;
    RectTransform m_transform;

    //public string collidedmesh;

    // void OnGUI()
    // {
    //     var position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    //     GUI.Label(new Rect(position.x - 50, Screen.height - position.y - 110, 100, 20), collidedmesh, "box");
    // }

    void Start()
    {
        //collidedmesh = gameObject.tag;

        m_transform = GetComponent<RectTransform>();

        //for the cards game have text as child conflict with read for collider I need to disable it
        if (gameObject.transform.childCount > 0)
            tMP_Text = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
    }

    //when the player start drag the object
    public void OnBeginDrag(PointerEventData eventData)
    {
        //need to know the postion of the object that was in
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        //we need to hide the image of the object we drag, for the reader to see what behind the object we drag
        image.raycastTarget = false;

        //this for card game,have text we nee hide it for the reader
        if (tMP_Text != null)
            tMP_Text.raycastTarget = false;
    }

    //when the drag present
    public void OnDrag(PointerEventData eventData)
    {
        //the object folow the mouse
        Vector3 vec = Camera.main.WorldToScreenPoint(m_transform.position);
        vec.x += eventData.delta.x;
        vec.y += eventData.delta.y;
        m_transform.position = Camera.main.ScreenToWorldPoint(vec);
        //transform.position = Input.mousePosition;
    }

    //the drang end
    public void OnEndDrag(PointerEventData eventData)
    {

        transform.SetParent(parentAfterDrag);
        transform.position = parentAfterDrag.position;

        image.raycastTarget = true;

        if (tMP_Text != null)
            tMP_Text.raycastTarget = true;
    }


}
