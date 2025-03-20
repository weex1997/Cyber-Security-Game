using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Prefabs;

    public List<GameObject> Spawns = new List<GameObject>();    // In seconds
    float interval = 1f;
    private float timer = 0f;
    GameObject Prefab;
    public bool start = false;
    // Update is called once per frame
    void Start()
    {
        foreach (Transform child in transform)
        {

            Spawns.Add(child.gameObject);

        }
    }
    void Update()
    {
        if (start)
        {
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                timer = 0f;
                int rand = Random.Range(0, Prefabs.Length);
                while (rand == 4 && GameObject.FindGameObjectsWithTag("Energy").Length > 2)
                    rand = Random.Range(0, Prefabs.Length);

                Prefab = Prefabs[rand];
                Instantiate(Prefab, Spawns[Random.Range(0, Spawns.Count)].transform.position, transform.rotation);

            }
        }
        //stop the spawner and kill all live enemies if the game end
        if (GameManager.Instance.itsLose || GameManager.Instance.itsWin && start)
        {
            start = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
}
