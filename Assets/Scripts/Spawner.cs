using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;

    public float enemySpeed;
    public float baseSpeed = 3f;
    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
	private void Start()
	{
        enemySpeed = baseSpeed;
	}

	// Update is called once per frame
	void Update()
    {
        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            
            enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);

        }
    }

    private void OnSpeedChanged(float value)
	{
        enemySpeed = baseSpeed * value;
        
	}

	private void OnDestroy()
	{
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}
}
