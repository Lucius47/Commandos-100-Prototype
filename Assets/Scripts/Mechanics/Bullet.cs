using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 20;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * bulletSpeed * Time.deltaTime;

        RaycastHit hitInfo;
        Physics.Raycast(transform.position, transform.forward, out hitInfo, 0.2f);

        Debug.DrawLine(transform.position, transform.position + transform.forward * 0.2f,Color.red);
        if (hitInfo.collider != null)
        {
            print(hitInfo.collider.transform.gameObject.name);
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
            Destroy(this.gameObject);
        }

        StartCoroutine(Die());
    }


    IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
