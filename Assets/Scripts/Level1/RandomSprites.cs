using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSprites : MonoBehaviour
{
    //this script for random sprite images to password character
    Sprite[] sprites1;
    Sprite[] sprites2;
    [Tooltip("must be the same name as the resource file name")]
    public string imageName1;
    [Tooltip("must be the same name as the resource file name")]
    //leave it empty if the sprite type has one type
    [SerializeField] string imageName2;
    public GameObject spriteKeeper;
    int rand = 0;
    int lastRand = 0;
    void Awake()
    {
        //load from the resource the file has this string variable name
        //will load all sprites on this file
        sprites1 = Resources.LoadAll<Sprite>(imageName1);

        //in the game we have two types of sprites file at the same time and we need to separate them from each other
        //so we load it individual
        if (imageName2 != null)
        {
            sprites2 = Resources.LoadAll<Sprite>(imageName2);
        }
    }
    void Start()
    {
        //loop to give 3 sprite image
        for (int i = 0; i < 6; i++)
        {
            //if the second string variable is not empty means we have two type of sprite file
            if (imageName2 != "")
            {
                //create a random number between 0 and 1 to choose from two type of files, numbe 2 in the range not
                rand = Random.Range(0, 2);
                //this loop to make sure rand number does not equal the previous number
                while (rand == lastRand)
                    rand = Random.Range(0, 2);
                lastRand = rand;

                switch (rand)
                {
                    //if rand = 0 enter this, and change image sprite to random of file one sprites
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
            //if the sprite file one type
            else
            {
                spriteKeeper.GetComponent<Image>().sprite = sprites1[Random.Range(0, sprites1.Length)];
                spriteKeeper.name = imageName1;

            }
            //creat prefab with the spite image
            Instantiate(spriteKeeper, transform);

        }

    }



}
