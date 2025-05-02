using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private UIDocument uiDocument;
    private VisualElement root;
    
    // Header elements
    private Label guildNameLabel;
    private Label timeDisplayLabel;
    private Label goldLabel;
    private Label woodLabel;
    private Label ironLabel;
    private Label magicCrystalsLabel;
    
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
    
    // Notifications
    private VisualElement notificationsContainer;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;
        
        
        
        // Get references to UI elements
        GetHeaderElements();
        GetMainPanelElements();
        GetSecondaryPanelElements();
        GetNotificationElements();
        mainContent = root.Q<VisualElement>("main-content");
        
        // Set up event handlers
        SetupEventHandlers();
    }
    
    

    private void GetHeaderElements()
    {
        guildNameLabel = root.Q<Label>("guild-name");
        timeDisplayLabel = root.Q<Label>("time-display");
        goldLabel = root.Q<Label>("gold");
        woodLabel = root.Q<Label>("wood");
        ironLabel = root.Q<Label>("iron");
        magicCrystalsLabel = root.Q<Label>("magic-crystals");
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
    }

    private void SwitchSecondaryTab(string tabName)
    {
        // Remove selected class from all secondary tab buttons
        detailsTabButton.RemoveFromClassList("selected");
        questsTabButton.RemoveFromClassList("selected");
        adventurersTabButton.RemoveFromClassList("selected");
        
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
                // TODO: Load adventurers content
                break;
        }
    }

    public void ShowNotification(string message, NotificationType type = NotificationType.Info)
    {
        var notification = new Label(message);
        notification.AddToClassList("notification");
        notification.AddToClassList(type.ToString().ToLower());
        notificationsContainer.Add(notification);
        
        // Auto-remove notification after 5 seconds
        StartCoroutine(RemoveNotificationAfterDelay(notification, 5f));
    }

    private System.Collections.IEnumerator RemoveNotificationAfterDelay(VisualElement notification, float delay)
    {
        yield return new WaitForSeconds(delay);
        notification.RemoveFromHierarchy();
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

    public void UpdateResources(int gold, int wood, int iron, int magicCrystals)
    {
        goldLabel.text = $"Gold: {gold}";
        woodLabel.text = $"Wood: {wood}";
        ironLabel.text = $"Iron: {iron}";
        magicCrystalsLabel.text = $"Magic Crystals: {magicCrystals}";
    }
}

public enum NotificationType
{
    Info,
    Warning,
    Error,
    Success
} 