using UnityEngine;
using UnityEngine.UIElements;

public class AdventurerCardFactory
{
    // Reference to UIManager for callbacks
    private UIManager uiManager;

    public AdventurerCardFactory(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    public VisualElement CreateAdventurerCard(Adventurer adventurer)
    {
        // Create card container
        VisualElement card = new VisualElement();
        card.name = $"adventurer-card-{adventurer.ID}";
        card.AddToClassList("adventurer-card");

        // Left section with portrait
        VisualElement portraitSection = new VisualElement();
        portraitSection.AddToClassList("adventurer-portrait-section");
        
        // Create container for portrait and level badge
        VisualElement portraitContainer = new VisualElement();
        portraitContainer.AddToClassList("portrait-container");
        
        if (adventurer.Portrait != null)
        {
            Image portrait = new Image();
            portrait.sprite = adventurer.Portrait.sprite;
            portrait.AddToClassList("adventurer-portrait");
            portraitContainer.Add(portrait);
        }
        else
        {
            // Placeholder for missing portrait
            VisualElement portraitPlaceholder = new VisualElement();
            portraitPlaceholder.AddToClassList("adventurer-portrait-placeholder");
            portraitContainer.Add(portraitPlaceholder);
        }
        
        // Create level badge
        VisualElement levelBadge = new VisualElement();
        levelBadge.AddToClassList("level-badge");
        Label levelLabel = new Label(adventurer.Level.ToString());
        levelLabel.AddToClassList("level-label");
        levelBadge.Add(levelLabel);
        
        // Add portrait and badge to portrait section
        portraitSection.Add(portraitContainer);
        portraitSection.Add(levelBadge);
        
        // Info section
        VisualElement infoSection = new VisualElement();
        infoSection.AddToClassList("adventurer-info-section");
        
        // Create name label
        Label nameLabel = new Label(adventurer.HeroName);
        nameLabel.AddToClassList("adventurer-name-info");
        infoSection.Add(nameLabel);
        
        // Create race and class label
        Label raceClassLabel = new Label($"{adventurer.CharacterRace} {adventurer.CharacterClasse}");
        raceClassLabel.AddToClassList("adventurer-race-class-info");
        infoSection.Add(raceClassLabel);
        
        // Create HP bar
        VisualElement hpBarContainer = new VisualElement();
        hpBarContainer.AddToClassList("hp-bar-container");
        
        VisualElement hpBarFill = new VisualElement();
        hpBarFill.AddToClassList("hp-bar-fill");
        
        // Calculate HP percentage for the bar width
        float hpPercentage = (float)adventurer.CurrentHP / adventurer.MaxHP;
        hpBarFill.style.width = Length.Percent(hpPercentage * 100);
        
        Label hpLabel = new Label($"HP: {adventurer.CurrentHP}/{adventurer.MaxHP}");
        hpLabel.AddToClassList("hp-label");
        
        hpBarContainer.Add(hpBarFill);
        hpBarContainer.Add(hpLabel);
        infoSection.Add(hpBarContainer);
        
        // Create status label
        Label statusLabel = new Label($"{adventurer.CharacterAdventuringStatus}");
        statusLabel.AddToClassList("adventurer-status");
        
        // Add color based on status
        switch (adventurer.CharacterAdventuringStatus)
        {
            case Adventurer.AdventuringStatus.Available:
                statusLabel.AddToClassList("status-available");
                break;
            case Adventurer.AdventuringStatus.Adventuring:
                statusLabel.AddToClassList("status-adventuring");
                break;
            case Adventurer.AdventuringStatus.Injured:
                statusLabel.AddToClassList("status-injured");
                break;
            case Adventurer.AdventuringStatus.Resting:
                statusLabel.AddToClassList("status-resting");
                break;
            case Adventurer.AdventuringStatus.Dead:
                statusLabel.AddToClassList("status-dead");
                break;
        }
        
        infoSection.Add(statusLabel);
        
        // Add sections to card
        card.Add(portraitSection);
        card.Add(infoSection);
        
        // Add click handler to show adventurer details
        card.RegisterCallback<ClickEvent>(evt => uiManager.ShowAdventurerDetails(adventurer.ID));
        
        return card;
    }
}