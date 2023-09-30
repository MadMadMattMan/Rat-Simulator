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

	public SpriteRenderer egg;
	public Sprite[] eggStages = new Sprite[5];
	
	//Sets UI Graphic to correct values at start of game
  	void Awake()
	{
		UpdateGraphics();
	}

    private void FixedUpdate()
    {
        if (RatCode.AttackState && Time.timeScale == 1)
		{
			Attacked(0.005f);
		}
    }

    //Updates helath bar and text
    private void UpdateHealthBar()
	{
		float healthpercent = hitPoint / 100;
		currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * healthpercent - currentHealthBar.rectTransform.rect.width, 0, 0);
		healthText.text = hitPoint.ToString ("0") + "/" + maxHitPoint.ToString ("0");

		if (hitPoint >= 90)
		{
			egg.sprite = eggStages[0];
		}
		else if (hitPoint >= 60)
        {
            egg.sprite = eggStages[1];
        }
        else if (hitPoint >= 40)
        {
            egg.sprite = eggStages[2];
        }
        else if (hitPoint >= 20)
        {
            egg.sprite = eggStages[3];
        }
        else if (hitPoint > 0)
        {
            egg.sprite = eggStages[4];
        }
        else if (hitPoint == 0)
        {
            egg.gameObject.SetActive(false);
        }
    }


	public void Attacked(float Damage)
	{
		hitPoint -= Damage;
		if (hitPoint < 1)
			hitPoint = 0;

		UpdateGraphics();

		StartCoroutine(TakeDamage());
	}

	public void Healer(float Heal)
	{
		hitPoint += Heal;
		if (hitPoint > maxHitPoint) 
			hitPoint = maxHitPoint;

		UpdateGraphics();
	}
	private void UpdateGraphics()
	{
		UpdateHealthBar();
	}

	// Coroutine of what happens when the egg gets hurt
	IEnumerator TakeDamage()
	{
		if (hitPoint <= 0)
		{
			yield return StartCoroutine(PlayerDied());
		}

		else
		{
			yield return null;
		}
    }

	// Coroutine of what happens when the egg dies
	IEnumerator PlayerDied()
	{
		Debug.Log("Egg died - Game Over");
		HeartSystemManager.GameStateMaster = false;

		yield return null;
	}
}
