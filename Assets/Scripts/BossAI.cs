using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float speed = 3f;
    public float maxZ;
    public float minZ;

    private int direction = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);

        bool bounced = false;
        if (transform.position.z > maxZ || transform.position.z < minZ)
		{
            direction = -direction;
            bounced = true;
		}
        if (bounced)
		{
            transform.Translate(0, 0, direction * speed * Time.deltaTime);
		}
    }
}
