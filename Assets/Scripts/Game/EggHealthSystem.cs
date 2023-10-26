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

	public static int HealerStatic;

	public SpriteRenderer egg;
	public Sprite[] eggStages = new Sprite[5];

	public Text eggStageText;
	public static Text eggStageTextStatic;
	public static int eggStageInt;
	
	//Sets UI Graphic to correct values at start of game
  	void Awake()
	{
		eggStageInt = 1;
		eggStageTextStatic = eggStageText;
		eggStageTextStatic.text = "Stage " + eggStageInt;
        UpdateHealthBar();
    }

    private void FixedUpdate()
    {
		//If rat is atacking and game is not paused, damage the egg
        if (RatCode.AttackState && Time.timeScale == 1)
		{
			Attacked(0.005f);
		}

		//Checks if player is healing egg and heals the egg for that amount
		if (HealerStatic != 0)
		{
			Heal(HealerStatic);
			//resets heal amount
			HealerStatic = 0;
		}
		//If the egg stage text does not match the text, update the healthbar and text
		if (eggStageText.text != eggStageTextStatic.text)
		{
			UpdateHealthBar();
		}

		//checks if game has been won yet
		if (eggStageText.text == "Stage 5")
		{
			GameOverviewer.GameWon = true;
		}
    }

    //Updates helath bar and text
    private void UpdateHealthBar()
	{
		//Converts eggpercent number into a decimal with max of 1 and min of 0
		float healthpercent = hitPoint / 100;
		//Calculates the width needed for the healthbar and sets it so that is displays the correct fill percentage of the egg health bar
		currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * healthpercent - currentHealthBar.rectTransform.rect.width, 0, 0);
		//Sets the text to show the percentage value as a whole number out of 100
		healthText.text = hitPoint.ToString ("0") + "/" + maxHitPoint.ToString ("0");

		//Updates the egg stage text to match the global value
        eggStageText.text = eggStageTextStatic.text;

		//sets egg image to reflect egg health
        if (hitPoint >= 90 )
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

	//When void is called, remove designated health
	public void Attacked(float Damage)
	{
		hitPoint -= Damage;

		//If health value is less than one set health to zero
		if (hitPoint < 1)
			hitPoint = 0;

		//Call update void
        UpdateHealthBar();

		//check if player is dead
		StartCoroutine(TakeDamage());
	}

	public void Heal(float Heal)
	{
		hitPoint += Heal;
		if (hitPoint > maxHitPoint) 
			hitPoint = maxHitPoint;

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
		GameOverviewer.GameOver = true;
		HeartSystemManager.GameStateMaster = false;

		yield return null;
	}
}
