using UnityEngine;
using UnityEngine.EventSystems;

public class SlotPublic : MonoBehaviour, IDropHandler
{
    public Stage3Rules stage3Rules;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragDropUI dragDropUI = dropped.GetComponent<DragDropUI>();

        if (dragDropUI.gameObject.tag != "Public")
        {
            GameManager.Instance.LoseHeart(1);
            stage3Rules.runCorotine("WrongAnswer");
            GameManager.Instance.StartHint("اه، هناك معلومات شخصية تتجول في خطر!");
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
