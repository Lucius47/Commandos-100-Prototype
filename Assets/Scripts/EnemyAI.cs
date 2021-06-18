using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    private GameObject fireball;

    
    private Spawner spawner;


    public float speed;
    //public float baseSpeed = 3f;
    public float obstacleDistance = 5f;

    public bool alive;


	/*private void Awake()
	{
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}*/
	void Start()
    {
        spawner = FindObjectOfType<Spawner>().GetComponent<Spawner>();
        
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
		{
            speed = spawner.enemySpeed;
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hitInfo;

            if (Physics.SphereCast(ray, 0.75f, out hitInfo))
            {
                GameObject hitObject = hitInfo.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
				{
                    if (fireball == null)
					{
                        fireball = Instantiate(fireballPrefab) as GameObject;
                        fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball.transform.rotation = transform.rotation;
					}
				}



                else if (hitInfo.distance < obstacleDistance)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
            
    }


	/*private void OnDestroy()
	{
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}*/

    /*private void OnSpeedChanged(float value)
	{
        speed = baseSpeed * value;
	}*/


    public void SetAlive(bool _alive)
	{
        alive = _alive;
    }
}
