using UnityEngine;
using UnityEngine.UIElements;

// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

public class Adventurer : MonoBehaviour
{
    #region VariableDeclaration

// Meta variables
    private int id;
    private Image characterArt;
    private Image portrait;

// Base characteristics
    private string heroName;
    private int level;
    private int currentExp;
    private int expToNextLvl;
    private int maxHP;
    private int currentHP;
    private Race race;
    private Classe classe;
    private AdventuringStatus adventuringStatus;
    private CombatStatus combatStatus;

// Primary Stats
    private int end;
    private int endBonus;
    private int str;
    private int strBonus;
    private int agi;
    private int agiBonus;
    private int mag;
    private int magBonus;
    private int wil;
    private int wilBonus;

// Secondary Stats
    private int dodge;
    private int dodgeBonus;
    private int armor;
    private int armorBonus;
    private int criticalChance;
    private int criticalChanceBonus;
    private int resistance;
    private int resistanceBonus;

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

    public enum AdventuringStatus
    {
        Available,
        Adventuring,
        Injured,
        Resting,
        Dead
    }

    public enum CombatStatus
    {
        Normal,
        Dead,
        Stunned,
        Paralyzed,
        Charmed
    }

    #endregion

    #region GetterSetters

    // Meta variables getters/setters
    public int ID
    {
        get => id;
        set => id = value;
    }

    public Image CharacterArt
    {
        get => characterArt;
        set => characterArt = value;
    }

    public Image Portrait
    {
        get => portrait;
        set => portrait = value;
    }

    // Base characteristics getters/setters
    public string HeroName
    {
        get => heroName;
        set => heroName = value;
    }

    public int Level
    {
        get => level;
        set => level = value;
    }

    public int CurrentExp
    {
        get => currentExp;
        set => currentExp = value;
    }

    public int ExpToNextLvl
    {
        get => expToNextLvl;
        set => expToNextLvl = value;
    }

    public int MaxHP
    {
        get => maxHP;
        set => maxHP = value;
    }

    public int CurrentHP
    {
        get => currentHP;
        set => currentHP = value;
    }

    public Race CharacterRace
    {
        get => race;
        set => race = value;
    }

    public Classe CharacterClasse
    {
        get => classe;
        set => classe = value;
    }

    public AdventuringStatus CharacterAdventuringStatus
    {
        get => adventuringStatus;
        set => adventuringStatus = value;
    }

    public CombatStatus CharacterCombatStatus
    {
        get => combatStatus;
        set => combatStatus = value;
    }

    // Primary Stats getters/setters
    public int End
    {
        get => end;
        set => end = value;
    }

    public int EndBonus
    {
        get => endBonus;
        set => endBonus = value;
    }

    public int Str
    {
        get => str;
        set => str = value;
    }

    public int StrBonus
    {
        get => strBonus;
        set => strBonus = value;
    }

    public int Agi
    {
        get => agi;
        set => agi = value;
    }

    public int AgiBonus
    {
        get => agiBonus;
        set => agiBonus = value;
    }

    public int Mag
    {
        get => mag;
        set => mag = value;
    }

    public int MagBonus
    {
        get => magBonus;
        set => magBonus = value;
    }

    public int Wil
    {
        get => wil;
        set => wil = value;
    }

    public int WilBonus
    {
        get => wilBonus;
        set => wilBonus = value;
    }

    // Secondary Stats getters/setters
    public int Dodge
    {
        get => dodge;
        set => dodge = value;
    }

    public int DodgeBonus
    {
        get => dodgeBonus;
        set => dodgeBonus = value;
    }

    public int Armor
    {
        get => armor;
        set => armor = value;
    }

    public int ArmorBonus
    {
        get => armorBonus;
        set => armorBonus = value;
    }

    public int CriticalChance
    {
        get => criticalChance;
        set => criticalChance = value;
    }

    public int CriticalChanceBonus
    {
        get => criticalChanceBonus;
        set => criticalChanceBonus = value;
    }

    public int Resistance
    {
        get => resistance;
        set => resistance = value;
    }

    public int ResistanceBonus
    {
        get => resistanceBonus;
        set => resistanceBonus = value;
    }

    #endregion

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
        ChangeCombatStatus(CombatStatus.Dead);
        ChangeAdventuringStatus(AdventuringStatus.Dead);
    }

    private void LevelUp()
    {
        currentExp -= expToNextLvl;
        expToNextLvl += 10;
        maxHP += 5;
        currentHP += 5;
        level++;
    }

    public void ChangeAdventuringStatus(AdventuringStatus newStatus)
    {
        adventuringStatus = newStatus;
    }

    public void ChangeCombatStatus(CombatStatus newStatus)
    {
        combatStatus = newStatus;
    }
}