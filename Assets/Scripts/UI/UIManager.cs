using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class UIManager : Singleton<UIManager>
{
    //GameManager Reference
    private GameManager gameManager;
    private TimeManager timeManager;
    
    private UIDocument uiDocument;
    private VisualElement root;
    
    // Header elements
    private Label guildNameLabel;
    private Label timeDisplayLabel;
    private Label goldLabel;
    private Label woodLabel;
    private Label ironLabel;
    private Label magicCrystalsLabel;
    
    // Time control buttons
    private VisualElement timeControlContainer;
    private Button pauseButton;
    private Button resumeButton;
    private Button fastForwardButton;
    
    // Main panel elements
    private VisualElement mainPanel;
    private Button guildTabButton;
    private Button mapTabButton;
    private VisualElement mainPanelContent;
    private VisualElement mainContent;
    
    // Secondary panel elements
    private VisualElement secondaryPanel;
    private Button detailsTabButton;
    private Button questsTabButton;
    private Button adventurersTabButton;
    private VisualElement secondaryPanelContent;
    
    // Adventurers panel elements
    private ScrollView adventurersList;
    
    // Notifications
    private VisualElement notificationsContainer;
    
    // Card factory
    private AdventurerCardFactory cardFactory;

    protected override void OnAwake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        timeManager = FindFirstObjectByType<TimeManager>();
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;
        
        // Initialize card factory
        cardFactory = new AdventurerCardFactory(this);
        
        // Get references to UI elements
        GetHeaderElements();
        GetMainPanelElements();
        GetSecondaryPanelElements();
        GetNotificationElements();
        mainContent = root.Q<VisualElement>("main-content");
        
        // Create adventurers list container
        CreateAdventurersListContainer();
        
        // Set up event handlers
        SetupEventHandlers();
        
        //Set Active Tabs
        SwitchMainTab("guild");
        SwitchSecondaryTab("adventurers");
    }
    
    private void GetHeaderElements()
    {
        guildNameLabel = root.Q<Label>("guild-name");
        timeDisplayLabel = root.Q<Label>("time-display");
        goldLabel = root.Q<Label>("gold");
        woodLabel = root.Q<Label>("wood");
        ironLabel = root.Q<Label>("iron");
        magicCrystalsLabel = root.Q<Label>("magic-crystals");
        
        // Get time control elements
        timeControlContainer = root.Q<VisualElement>("time-controls");
        pauseButton = root.Q<Button>("pause-button");
        resumeButton = root.Q<Button>("resume-button");
        fastForwardButton = root.Q<Button>("fast-forward-button");
        
        // Set up time control event handlers
        if (pauseButton != null) pauseButton.clicked += () => timeManager.PauseTime();
        if (resumeButton != null) resumeButton.clicked += () => timeManager.ResumeTime();
        if (fastForwardButton != null) fastForwardButton.clicked += () => timeManager.FastForwardTime();
        
        // Initial button states
        UpdateTimeControlUI(1f); // Default to normal speed
    }

    private void GetMainPanelElements()
    {
        mainPanel = root.Q<VisualElement>("main-panel");
        guildTabButton = root.Q<Button>("guild-tab");
        mapTabButton = root.Q<Button>("map-tab");
        mainPanelContent = root.Q<VisualElement>("main-panel-content");
    }

    private void GetSecondaryPanelElements()
    {
        secondaryPanel = root.Q<VisualElement>("secondary-panel");
        detailsTabButton = root.Q<Button>("details-tab");
        questsTabButton = root.Q<Button>("quests-tab");
        adventurersTabButton = root.Q<Button>("adventurers-tab");
        secondaryPanelContent = root.Q<VisualElement>("secondary-panel-content");
    }

    private void GetNotificationElements()
    {
        notificationsContainer = root.Q<VisualElement>("notifications");
    }

    private void CreateAdventurersListContainer()
    {
        adventurersList = new ScrollView();
        adventurersList.name = "adventurers-list";
        adventurersList.AddToClassList("adventurers-list");
    }

    private void SetupEventHandlers()
    {
        // Main tab buttons
        guildTabButton.clicked += () => SwitchMainTab("guild");
        mapTabButton.clicked += () => SwitchMainTab("map");
        
        // Secondary tab buttons
        detailsTabButton.clicked += () => SwitchSecondaryTab("details");
        questsTabButton.clicked += () => SwitchSecondaryTab("quests");
        adventurersTabButton.clicked += () => SwitchSecondaryTab("adventurers");
    }

    private void SwitchMainTab(string tabName)
    {
        guildTabButton.RemoveFromClassList("selected");
        mapTabButton.RemoveFromClassList("selected");

        switch (tabName)
        {
            case "guild":
                guildTabButton.AddToClassList("selected");
                mainPanel.AddToClassList("transparent");
                mainPanelContent.AddToClassList("transparent");
                mainContent.AddToClassList("transparent");
                break;
            case "map":
                mapTabButton.AddToClassList("selected");
                mainPanel.RemoveFromClassList("transparent");
                mainPanelContent.RemoveFromClassList("transparent");
                mainContent.RemoveFromClassList("transparent");
                break;
        }
        gameManager.ActiveMainTab = tabName;
    }

    private void SwitchSecondaryTab(string tabName)
    {
        // Remove selected class from all secondary tab buttons
        detailsTabButton.RemoveFromClassList("selected");
        questsTabButton.RemoveFromClassList("selected");
        adventurersTabButton.RemoveFromClassList("selected");
        
        // Clear the content
        secondaryPanelContent.Clear();
        
        // Add selected class to clicked tab
        switch (tabName)
        {
            case "details":
                detailsTabButton.AddToClassList("selected");
                // TODO: Load details content
                break;
            case "quests":
                questsTabButton.AddToClassList("selected");
                // TODO: Load quests content
                break;
            case "adventurers":
                adventurersTabButton.AddToClassList("selected");
                LoadAdventurersTab();
                break;
        }
    }

    private void LoadAdventurersTab()
    {
        // Clear existing content
        adventurersList.Clear();
        
        // Add the scroll view to the secondary panel content
        secondaryPanelContent.Add(adventurersList);

        // Load adventurers from GameManager and create cards
        List<Adventurer> adventurers = gameManager.GetAdventurers();
        
        if (adventurers != null && adventurers.Count > 0)
        {
            foreach (Adventurer adventurer in adventurers)
            {
                adventurersList.Add(cardFactory.CreateAdventurerCard(adventurer));
            }
        }
        else
        {
            // Create a message if no adventurers are available
            Label noAdventurersLabel = new Label("No adventurers available.");
            noAdventurersLabel.AddToClassList("no-adventurers-message");
            adventurersList.Add(noAdventurersLabel);
        }
    }
    
    // Method to show adventurer details - needs to be public for the card factory
    public void ShowAdventurerDetails(int adventurerId)
    {
        // Switch to details tab and load details for this adventurer
        detailsTabButton.AddToClassList("selected");
        adventurersTabButton.RemoveFromClassList("selected");
        
        // Clear the content
        secondaryPanelContent.Clear();
        
        // Get the adventurer from GameManager
        Adventurer adventurer = gameManager.GetAdventurerById(adventurerId);
        
        if (adventurer != null)
        {
            // TODO: Implement detailed adventurer view here
            // For now just display a message
            Label detailsLabel = new Label($"Showing details for {adventurer.HeroName}");
            secondaryPanelContent.Add(detailsLabel);
        }
    }

    // Update UI with game data
    public void UpdateGuildName(string name)
    {
        guildNameLabel.text = name;
    }

    public void UpdateTimeDisplay(string time)
    {
        timeDisplayLabel.text = time;
    }

    // Update the time control UI based on the current time scale
    public void UpdateTimeControlUI(float timeScale)
    {
        if (pauseButton == null || resumeButton == null || fastForwardButton == null) return;
        
        // Set button states based on current time scale
        pauseButton.SetEnabled(timeScale > 0f); // Can only pause if not already paused
        resumeButton.SetEnabled(timeScale != 1f); // Can only resume if not at normal speed
        fastForwardButton.SetEnabled(timeScale != 10f); // Can only fast forward if not already fast forwarding
        
        // Add visual indication of active button
        pauseButton.RemoveFromClassList("active-time-control");
        resumeButton.RemoveFromClassList("active-time-control");
        fastForwardButton.RemoveFromClassList("active-time-control");
        
        if (timeScale == 0f)
            pauseButton.AddToClassList("active-time-control");
        else if (timeScale == 1f)
            resumeButton.AddToClassList("active-time-control");
        else if (timeScale == 10f)
            fastForwardButton.AddToClassList("active-time-control");
    }

    public void UpdateResources(int gold, int wood, int iron, int magicCrystals)
    {
        goldLabel.text = $"Gold: {gold}";
        woodLabel.text = $"Wood: {wood}";
        ironLabel.text = $"Iron: {iron}";
        magicCrystalsLabel.text = $"Magic Crystals: {magicCrystals}";
    }
    
    // Method to refresh the adventurers list if it's currently visible
    public void RefreshAdventurersList()
    {
        if (adventurersTabButton.ClassListContains("selected"))
        {
            LoadAdventurersTab();
        }
    }
}