using System.Collections;
using UnityEngine;

public class Stage3Rules : MonoBehaviour
{
    public int cardsNum = 0;
    public GameObject cardComputer;
    public GameObject right;
    public GameObject wrong;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "CardComputer")
                {
                    cardComputer.SetActive(true);
                }

            }
        }
    }
    public void runCorotine(string corotinMethod)
    {
        StartCoroutine(corotinMethod);
    }

    public IEnumerator RightAnswer()
    {

        right.SetActive(true);

        // suspend execution for 1 seconds
        yield return new WaitForSeconds(1f);

        right.SetActive(false);
        StopCoroutine(RightAnswer());

    }
    public IEnumerator WrongAnswer()
    {

        wrong.SetActive(true);

        // suspend execution for 1 seconds
        yield return new WaitForSeconds(1f);

        wrong.SetActive(false);
        StopCoroutine(WrongAnswer());

    }
}
