using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    private GameObject targetPosition;
    private void Start()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerInteractions>().loseHeart();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "EnergyWall")
        {
            other.gameObject.GetComponentInParent<EnergyBar>().loseEnergy(10);
            Destroy(gameObject);
        }

    }
}
