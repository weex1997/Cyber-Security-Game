using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardsGenerator : MonoBehaviour
{
    List<string> cardsText_privet = new List<string>();
    List<string> cardsText_public = new List<string>();

    public GameObject cardPrefab;
    public Transform cardsParent;
    string[] privet_info = {"Full name", "Street address", "Phone numbers", "Email addresses", "Birthdate", "School name",
     "Usernames", "Passwords","Health information","Bank Information","Parent's Names","Guardian's Names" };
    string[] public_info = {"First Name", "Hobbies", "Interests", "Favorite Animal", "Color", "Food",
     "Non-Specific Locations", "School Projects","Achievements","Art ","Creative Work","Fun Facts","Opinions","General Age Range" };
    // Start is called before the first frame update
    void Start()
    {
        foreach (string st in privet_info)
            cardsText_privet.Add(st);

        foreach (string st in public_info)
            cardsText_public.Add(st);

        for (int i = 0; i < 12; i++)
        {
            GameObject card = Instantiate(cardPrefab, cardsParent.position, cardsParent.rotation);
            card.transform.SetParent(cardsParent);
            card.transform.localScale = new Vector3(1, 1, 1); // change its local scale in x y z format

            int Rand_1 = Random.Range(0, 2);

            switch (Rand_1)
            {
                case 0:
                    int rand_2 = Random.Range(0, cardsText_privet.Count);
                    card.transform.GetChild(0).GetComponent<TMP_Text>().text = cardsText_privet[rand_2];
                    card.tag = "Privet";
                    cardsText_privet.RemoveAt(rand_2);
                    break;
                case 1:
                    int rand_3 = Random.Range(0, cardsText_public.Count);
                    card.transform.GetChild(0).GetComponent<TMP_Text>().text = cardsText_public[rand_3];
                    card.tag = "Public";
                    cardsText_public.RemoveAt(rand_3);
                    break;
            }

        }


    }

}
