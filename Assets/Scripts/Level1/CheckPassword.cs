using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckPassword : MonoBehaviour, IEndDragHandler
{
    //when the player end drag cheack the password
    public void OnEndDrag(PointerEventData eventData)
    {
        Stage1Rules.Instance.cheackPassword();
    }

}
