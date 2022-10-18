using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class GameManager : SingletonMonobehaviour<GameManager>
{
    #region Header DUNGEON LEVELS

    [Space(10)]
    [Header("DUNGEON LEVELS")]

    #endregion Header DUNGEON LEVELS

    #region Tooltip

    [Tooltip("populate with the dungeon level scriptable objects")]

    #endregion Tooltip

    [SerializeField] private List<DungeonLevelSO> dungeonLevelList; 

    #region Tooltip

    [Tooltip("populate with the starting dungeon level for testing, first level = 0")]

    #endregion Tooltip

    [SerializeField] private int currentDungeonLevelListIndex = 0;

    [HideInInspector] public GameState gameState;

    void Start()
    {
        gameState = GameState.gameStarted;
    }

    void Update() 
    {
        HandleGameState();    

        // for testing
        if(Input.GetKeyDown(KeyCode.R))
        {
            gameState = GameState.gameStarted;
        }   
    }

    private void HandleGameState()
    {
        switch(gameState)
        {
            case GameState.gameStarted:
                
                PlayDungeonLevel(currentDungeonLevelListIndex);

                gameState = GameState.playingLevel;
                break;
        }
    }

    private void PlayDungeonLevel(int dungeonLevelListIndex)
    {
        bool dungeonBuildSuccessfully = DungeonBuilder.Instance.GenerateDungeon(dungeonLevelList[dungeonLevelListIndex]);

        if(!dungeonBuildSuccessfully)
        {
            Debug.LogError("Couldnt build dungeon from specified rooms and node graphs");
        }    
    }

    private void OnValidate() 
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(dungeonLevelList), dungeonLevelList);
    }
}
