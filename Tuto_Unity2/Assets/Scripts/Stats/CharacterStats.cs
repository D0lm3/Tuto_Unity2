using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth{get; private set; }
    public Stat damage;  
    public Stat armor;

    void Awake() {
        currentHealth = maxHealth;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.T)){
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damage){
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); // to avoid a negative damage which in definitive will heal the target !
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damages.");
        if (currentHealth <= 0){
            Die();
        }
    }
    public virtual void Die(){
        // Die in some way
        //this method is meant to be overwritten
        Debug.Log(transform.name + " died !");
    }
}
