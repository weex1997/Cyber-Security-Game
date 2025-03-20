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
    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        currentTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (start && !GameManager.Instance.itsLose && !GameManager.Instance.itsWin && Time.timeScale != 0)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            //player active time
            currentTime -= Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity);

                currentTime = 10;

                //sound
                SoundManager.PlaySound(SoundType.Shoot);
            }

            if (currentTime <= 0.0f)
            {
                GameManager.Instance.StartHint("أيها المحارب لنقتل هذه الفيروسات الشريره.");
            }


        }
    }

}
