using UnityEngine;
using UnityEngine.UIElements;

public class Adventurer : MonoBehaviour
{
// Meta variables
    public int ID;
    public Image characterArt;
    public Image portrait;
    
// Base characteristics
    private string heroName;
    private int level;
    private int currentExp;
    private int expToNextLvl;
    private int maxHP;
    private int currentHP;
    private Race race;
    private Classe classe;
    private Status status;

// Primary Stats
    private int end;
    private int str;
    private int agi;
    private int mag;
    private int wil;

// Secondary Stats
    private int dodge;
    private int armor;
    private int criticalChance;

    public enum Race
    {
        Elf,
        Human,
        Dwarf,
        Tiefling,
        Halfling,
        HalfOrc,
        Dragonborn,
        Gnome,
        HalfElf
    }

    public enum Classe
    {
        Fighter,
        Cleric,
        Rogue,
        Wizard
    }

    public enum Status
    {
        Available,
        Adventuring,
        Injured,
        Resting
    }

    public void Damage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0) Die();
    }
    private void GainExp(int expGain)
    {
        currentExp += expGain;
        if (currentExp >= expToNextLvl)
        {
            LevelUp();
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP) currentHP = maxHP;
    }

    private void Die()
    {
        //death logic
    }

    private void LevelUp()
    {
        currentExp -= expToNextLvl;
        expToNextLvl += 10;
        maxHP += 5;
        currentHP += 5;
        level++;
    }

    public void ChangeStatus(Status newStatus)
    {
        status = newStatus;
    }
    
    
}