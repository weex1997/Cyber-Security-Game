using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShots : MonoBehaviour
{
    Camera mainCam;
    Vector3 mousePos;
    public Transform bulletTransform;
    public GameObject bulletPrefab;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity);


            }
        }
    }
}
