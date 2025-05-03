using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //Managers References
    private UIManager uiManager;
    private InputHandler inputHandler;
    
    //GameState variables
    private string activeMainTab = "";
    
    // Game resources
    private int gold = 1000;
    private int wood = 500;
    private int iron = 200;
    private int magicCrystals = 50;
    
    // Game time tracking
    private int currentDay = 1;
    private int currentHour = 8;
    
    // List of adventurers in guild
    private List<Adventurer> adventurers = new List<Adventurer>();

    public string ActiveMainTab
    {
        get { return activeMainTab; }
        set { activeMainTab = value; }
    }
    
    

    protected override void OnAwake() 
    { 
            Initialize();
    }
    private void Initialize()
    {
        // Create some test adventurers
        CreateTestAdventurers();
        // Initialize InputHandler
        inputHandler = FindFirstObjectByType<InputHandler>();
        // Initialize UI
        uiManager = FindFirstObjectByType<UIManager>();
        InitializeUI();
        
    }
    
    private void InitializeUI()
    {
        // Set up the initial UI state
        uiManager.UpdateGuildName("Adventurer's Guild");
        uiManager.UpdateTimeDisplay($"Day {currentDay}, {currentHour:00}:00");
        uiManager.UpdateResources(gold, wood, iron, magicCrystals);
    }
    
    private void CreateTestAdventurers()
    {
        // Create a few test adventurers
        
        // Elf Wizard
        GameObject adventurer1GO = new GameObject("Adventurer_1");
        Adventurer adventurer1 = adventurer1GO.AddComponent<Adventurer>();
        adventurer1.ID = 1;
        adventurer1.HeroName = "Elindra";
        adventurer1.CharacterRace = Adventurer.Race.Elf;
        adventurer1.CharacterClasse = Adventurer.Classe.Wizard;
        adventurer1.Level = 3;
        adventurer1.MaxHP = 18;
        adventurer1.CurrentHP = 15;
        adventurer1.CharacterAdventuringStatus = Adventurer.AdventuringStatus.Available;
        adventurers.Add(adventurer1);
        
        // Human Fighter
        GameObject adventurer2GO = new GameObject("Adventurer_2");
        Adventurer adventurer2 = adventurer2GO.AddComponent<Adventurer>();
        adventurer2.ID = 2;
        adventurer2.HeroName = "Thormund";
        adventurer2.CharacterRace = Adventurer.Race.Human;
        adventurer2.CharacterClasse = Adventurer.Classe.Fighter;
        adventurer2.Level = 2;
        adventurer2.MaxHP = 24;
        adventurer2.CurrentHP = 10;
        adventurer2.CharacterAdventuringStatus = Adventurer.AdventuringStatus.Injured;
        adventurers.Add(adventurer2);
        
        // Dwarf Cleric
        GameObject adventurer3GO = new GameObject("Adventurer_3");
        Adventurer adventurer3 = adventurer3GO.AddComponent<Adventurer>();
        adventurer3.ID = 3;
        adventurer3.HeroName = "Durgan";
        adventurer3.CharacterRace = Adventurer.Race.Dwarf;
        adventurer3.CharacterClasse = Adventurer.Classe.Cleric;
        adventurer3.Level = 4;
        adventurer3.MaxHP = 28;
        adventurer3.CurrentHP = 28;
        adventurer3.CharacterAdventuringStatus = Adventurer.AdventuringStatus.Adventuring;
        adventurers.Add(adventurer3);
        
        // Halfling Rogue
        GameObject adventurer4GO = new GameObject("Adventurer_4");
        Adventurer adventurer4 = adventurer4GO.AddComponent<Adventurer>();
        adventurer4.ID = 4;
        adventurer4.HeroName = "Finnian";
        adventurer4.CharacterRace = Adventurer.Race.Halfling;
        adventurer4.CharacterClasse = Adventurer.Classe.Rogue;
        adventurer4.Level = 2;
        adventurer4.MaxHP = 16;
        adventurer4.CurrentHP = 16;
        adventurer4.CharacterAdventuringStatus = Adventurer.AdventuringStatus.Resting;
        adventurers.Add(adventurer4);
    }
    
    // Public methods to be called from UIManager
    
    public List<Adventurer> GetAdventurers()
    {
        return adventurers;
    }
    
    public Adventurer GetAdventurerById(int id)
    {
        return adventurers.Find(a => a.ID == id);
    }
}
    
