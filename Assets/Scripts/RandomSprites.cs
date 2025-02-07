using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSprites : MonoBehaviour
{
    Sprite[] sprites1;
    Sprite[] sprites2;
    public string imageName1;
    [SerializeField] string imageName2;
    public GameObject spriteKeeper;
    int rand = 0;
    int lastRand = 0;
    void Awake()
    {
        sprites1 = Resources.LoadAll<Sprite>(imageName1);

        if (imageName2 != null)
        {
            sprites2 = Resources.LoadAll<Sprite>(imageName2);
        }
    }
    void Start()
    {

        for (int i = 0; i < 3; i++)
        {
            if (imageName2 != "")
            {
                rand = Random.Range(0, 2);
                while (rand == lastRand)
                    rand = Random.Range(0, 2);
                lastRand = rand;

                switch (rand)
                {
                    case 0:
                        spriteKeeper.GetComponent<Image>().sprite = sprites1[Random.Range(0, sprites1.Length)];
                        spriteKeeper.name = imageName1;

                        break;
                    case 1:
                        spriteKeeper.GetComponent<Image>().sprite = sprites2[Random.Range(0, sprites2.Length)];
                        spriteKeeper.name = imageName2;

                        break;
                }
            }
            else
            {
                spriteKeeper.GetComponent<Image>().sprite = sprites1[Random.Range(0, sprites1.Length)];
                spriteKeeper.name = imageName1;

            }

            Instantiate(spriteKeeper, transform);

        }

    }



}
