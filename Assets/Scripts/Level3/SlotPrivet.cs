using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotPrivet : MonoBehaviour, IDropHandler
{
    public Stage3Rules stage3Rules;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragDropUI dragDropUI = dropped.GetComponent<DragDropUI>();

        if (dragDropUI.gameObject.tag != "Privet")
        {
            GameManager.Instance.LoseHeart();
            stage3Rules.runCorotine("WrongAnswer");
            GameManager.Instance.StartHint("يا الهي المعلومات الغير شخصيه ضائعه (تذكر انها ليست سرا) .");
        }
        else
        {
            stage3Rules.runCorotine("RightAnswer");


        }
        stage3Rules.cardsNum++;

        if (stage3Rules.cardsNum == 12)
            GameManager.Instance.checkEndTheGame();

        Destroy(dragDropUI.gameObject);
    }



}
