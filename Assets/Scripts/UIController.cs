using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private SettingsPopup popup;

	private int score;

	private void Awake()
	{
		Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
		
	}
	private void Start()
	{
		score = 0;
		scoreText.text = score.ToString();


		popup.Close();
	}
	private void OnDestroy()
	{
		Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	public void OnOpenSettings()
	{
        popup.Open();
	}

    public void OnPointerDown()
    {
        
    }


	private void OnEnemyHit()
	{
		score += 1;
		scoreText.text = score.ToString();
	}
}
