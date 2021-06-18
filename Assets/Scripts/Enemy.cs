using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	

	

	public void gotHit()
	{
		EnemyAI enemyAI = GetComponent<EnemyAI>();
		if (enemyAI != null && enemyAI.alive)
		{
			Messenger.Broadcast(GameEvent.ENEMY_HIT);
			enemyAI.SetAlive(false);
			StartCoroutine(Die());
		}
		
		
		
		
	}

	


	private IEnumerator Die()
	{
		
		this.transform.Rotate(-75, 0, 0);
		
		yield return new WaitForSeconds(1.5f);

		
		Destroy(this.gameObject);
	}
}
