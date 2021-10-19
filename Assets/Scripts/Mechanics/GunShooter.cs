using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour
{
    [SerializeField] Transform barrel;
    [SerializeField] GameObject bulletPrefab;

    private Camera _camera;
    Vector3 screenCenter;

    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        }
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        screenCenter = new Vector3(posX, 0, posY);
        GUI.Label(new Rect(screenCenter.x, screenCenter.z, size, size), "*");
    }
}
