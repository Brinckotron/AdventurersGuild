using Unity.VisualScripting;
public class GameManager : Singleton<GameManager>
{
    //Managers References
    private UIManager uiManager;
    private InputHandler inputHandler;
    
    //GameState variables
    private string activeMainTab = "";

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
        uiManager = FindFirstObjectByType<UIManager>();
        inputHandler = FindFirstObjectByType<InputHandler>();
    }
}
    
