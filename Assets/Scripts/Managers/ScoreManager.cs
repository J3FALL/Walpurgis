using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private int tilesCounter = 0;
    private int lastTiles = 0;

    public int tilesToWin = 150;
    public int aliquotTilesValue = 5;
    private bool isWin = false;

    private void IncreaseTileCounter()
    {
        tilesCounter++;
        UIManager.ChangeTileText(tilesCounter);
    }

    void Awake()
    {
       
        EventAggregator.TileReached.Subscribe(IncreaseTileCounter);
        EventAggregator.LevelRestarted.Subscribe(OnLevelRestarted);
    }
	
    void OnLevelRestarted()
    {
        tilesCounter = 0;
        UIManager.ChangeTileText(tilesCounter);
    }

    void Update()
    {
        if (tilesCounter == tilesToWin && !isWin)
        {
            //publish win
            isWin = true;
            EventAggregator.LevelCompleted.Publish();
        } else if (tilesCounter % aliquotTilesValue == 0 && tilesCounter > 0 && lastTiles != tilesCounter)
        {
            lastTiles = tilesCounter;
            EventAggregator.AliquotTileReached.Publish();
        }

    }
  
}
