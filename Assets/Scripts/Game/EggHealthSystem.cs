//==============================================================
// HealthSystem
// HealthSystem.Instance.TakeDamage (float Damage);
// HealthSystem.Instance.HealDamage (float Heal);
// HealthSystem.Instance.UseMana (float Mana);
// HealthSystem.Instance.RestoreMana (float Mana);
// Attach to the Hero.
//==============================================================

using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EggHealthSystem : MonoBehaviour
{
	public Image currentHealthBar;
	public Text healthText;
	public float hitPoint = 5f;
	public float maxHitPoint = 100f;
	
	//Sets UI Graphic to correct values at start of game
  	void Start()
	{
		UpdateGraphics();
	}

	//Updates helath bar and text
	private void UpdateHealthBar()
	{
		float healthpercent = hitPoint / 100;
		currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * healthpercent - currentHealthBar.rectTransform.rect.width, 0, 0);
		healthText.text = hitPoint.ToString ("0") + "/" + maxHitPoint.ToString ("0");
	}


	public void TakeDamage(float Damage)
	{
		hitPoint -= Damage;
		if (hitPoint < 1)
			hitPoint = 0;

		UpdateGraphics();

		StartCoroutine(PlayerHurts());
	}

	public void HealDamage(float Heal)
	{
		hitPoint += Heal;
		if (hitPoint > maxHitPoint) 
			hitPoint = maxHitPoint;

		UpdateGraphics();
	}
	public void SetMaxHealth(float max)
	{
		maxHitPoint += (int)(maxHitPoint * max / 100);

		UpdateGraphics();
	}
	private void UpdateGraphics()
	{
		UpdateHealthBar();
	}

	// Coroutine of what happens when the egg gets hurt
	IEnumerator PlayerHurts()
	{
		// Player gets hurt. Do stuff.. play anim, sound..

		//When players health is zero, player is dead
		if (hitPoint <= 0)
		{
			yield return StartCoroutine(PlayerDied());
		}

		else
		{
			yield return null;
		}

        Debug.Log("Egg Hurt");
    }

	// Coroutine of what happens when the egg dies
	IEnumerator PlayerDied()
	{
		// Player is dead. Do stuff.. play anim, sound..
		Debug.Log("Egg died");

		yield return null;
	}
}
