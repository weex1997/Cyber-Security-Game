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
    public Transform parentBeforeDrag;
    RectTransform m_transform;

    bool itsPassword = false;
    public string collidedmesh;

    // void OnGUI()
    // {
    //     var position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    //     GUI.Label(new Rect(position.x - 50, Screen.height - position.y - 110, 100, 20), collidedmesh, "box");
    // }

    void Start()
    {
        collidedmesh = gameObject.tag;
        m_transform = GetComponent<RectTransform>();
        parentBeforeDrag = transform.parent;
        if (gameObject.tag == "Password")
        {
            itsPassword = true;
        }
        if (gameObject.transform.GetChild(0))
            tMP_Text = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        if (tMP_Text != null)
            tMP_Text.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 vec = Camera.main.WorldToScreenPoint(m_transform.position);
        vec.x += eventData.delta.x;
        vec.y += eventData.delta.y;
        m_transform.position = Camera.main.ScreenToWorldPoint(vec);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.SetParent(parentAfterDrag);
        transform.position = parentAfterDrag.position;

        if (itsPassword && parentBeforeDrag.childCount == 0)
        {
            Stage1Rules.Instance.cheackPassword();
            Stage1Rules.Instance.interactbleDoneButton(true);
        }
        else if (itsPassword)
            Stage1Rules.Instance.interactbleDoneButton(false);

        image.raycastTarget = true;
        if (tMP_Text != null)
            tMP_Text.raycastTarget = true;
    }


}
