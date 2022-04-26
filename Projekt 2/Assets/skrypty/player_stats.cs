using UnityEngine;

public class player_stats : MonoBehaviour
{
	public static player_stats Player;

	public float Experience;
	public float Character_Level;
	public stat Speed;
	public stat Health;
	public stat Mana;
	public stat Strength;
	public stat Magic;
	public stat Defence;
	public stat Luck;
	public stat Damage;
	public float currentHealth{ get; private set; }
	public float maxHealth = 100;
	public float currentMana { get; private set; }
	public float maxMana = 50;
	
    // Start is called before the first frame update
    void Awake()
    {
    Player=this;
	currentHealth = maxHealth;
    }

	public void TakeDamage (float Damage)
    {
		Damage = Strength.GetValue();

		currentHealth -= Damage;
		Debug.Log(transform.name + " takes " + Damage + " damage.");

		if (currentHealth <=0)
        {
			Die();
        }
    }

	public virtual void Die ()
    {
		Debug.Log(transform.name + " died.");
    }

	void Start()
	{
	currentHealth=Health.GetValue();
	currentMana=Mana.GetValue();
	}

	void Update()
	{
	if (Experience>Character_Level*1000)
		{
		Experience=0;
		Character_Level++;
		}
	
	if (currentHealth>Health.GetValue())
		{
		currentHealth=Health.GetValue();	
		}
	if (currentMana>Mana.GetValue())
		{
		currentMana=Mana.GetValue();	
		}
	
	}
}
