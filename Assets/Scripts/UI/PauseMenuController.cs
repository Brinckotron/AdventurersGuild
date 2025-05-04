using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuController : MonoBehaviour
{
    private VisualElement root;
    private Button settingsTab, tutorialTab, saveloadTab, quitTab;
    private VisualElement pauseContent;

    void Awake()
    {
        var uiDoc = GetComponent<UIDocument>();
        root = uiDoc.rootVisualElement;

        settingsTab = root.Q<Button>("settings-tab");
        tutorialTab = root.Q<Button>("tutorial-tab");
        saveloadTab = root.Q<Button>("saveload-tab");
        quitTab = root.Q<Button>("quit-tab");
        pauseContent = root.Q<VisualElement>("pause-content");

        settingsTab.clicked += () => SelectTab(settingsTab);
        tutorialTab.clicked += () => SelectTab(tutorialTab);
        saveloadTab.clicked += () => SelectTab(saveloadTab);
        quitTab.clicked += () => SelectTab(quitTab);

        // Default to settings tab
        SelectTab(settingsTab);
    }

    void SelectTab(Button selected)
    {
        foreach (var tab in new[] { settingsTab, tutorialTab, saveloadTab, quitTab })
            tab.RemoveFromClassList("selected");
        selected.AddToClassList("selected");

        // You can update pauseContent here based on the selected tab
        pauseContent.Clear();
        Label contentLabel = new Label($"Content for {selected.text}");
        contentLabel.style.unityTextAlign = TextAnchor.MiddleCenter;
        contentLabel.style.fontSize = 24;
        pauseContent.Add(contentLabel);
    }
} 