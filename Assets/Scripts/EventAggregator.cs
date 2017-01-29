using UnityEngine;
public class EventAggregator : MonoBehaviour {

    public static EnemyDiedEvent EnemyDied = new EnemyDiedEvent();
    public static EnemyEnragedEvent EnemyEnraged = new EnemyEnragedEvent();
    public static EnemyDestroyedEvent EnemyDestroyed = new EnemyDestroyedEvent();
    public static EnemyLaunchedEvent EnemyLaunched = new EnemyLaunchedEvent();
    public static EnemyReactionEvent EnemyReacted = new EnemyReactionEvent();
    public static EnemyMovingEvent EnemyMoved = new EnemyMovingEvent();
    public static ToolUsedEvent ToolUsed = new ToolUsedEvent();
    public static TileReachedEvent TileReached = new TileReachedEvent();
    public static RestartLevelEvent LevelRestarted = new RestartLevelEvent();
    public static AliquotTileReachedEvent AliquotTileReached = new AliquotTileReachedEvent();
    public static LevelCompletedEvent LevelCompleted = new LevelCompletedEvent();
    public static AnimatedTextDisappearedEvent TextDisappeared = new AnimatedTextDisappearedEvent();
    public static InventoryFocusedEvent InventoryFocused = new InventoryFocusedEvent();
    public static ChangeInputModeEvent ChangeInputMode = new ChangeInputModeEvent();
    public static SymbolReachedEvent SymbolReached = new SymbolReachedEvent();
    public static MaxAmplitudeEvent MaxAmplitude = new MaxAmplitudeEvent();

    void Awake()
    {
        EnemyDied = new EnemyDiedEvent();
        EnemyEnraged = new EnemyEnragedEvent();
        EnemyDestroyed = new EnemyDestroyedEvent();
        EnemyLaunched = new EnemyLaunchedEvent();
        EnemyReacted = new EnemyReactionEvent();
        EnemyMoved = new EnemyMovingEvent();
        ToolUsed = new ToolUsedEvent();
        TileReached = new TileReachedEvent();
        LevelRestarted = new RestartLevelEvent();
        AliquotTileReached = new AliquotTileReachedEvent();
        LevelCompleted = new LevelCompletedEvent();
        TextDisappeared = new AnimatedTextDisappearedEvent();
        InventoryFocused = new InventoryFocusedEvent();
        ChangeInputMode = new ChangeInputModeEvent();
        SymbolReached = new SymbolReachedEvent();
        MaxAmplitude = new MaxAmplitudeEvent();
    }
}
