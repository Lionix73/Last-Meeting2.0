using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Room currentRoom;
    private Room previousRoom;
    private PlayerDetailsSO playerDetails;
    private Player player;

    [HideInInspector] public GameState gameState;

    protected override void Awake()
    {
        base.Awake();

        playerDetails = GameResources.Instance.currentPlayer.playerDetails;

        InstantiatePlayer();
    }

    private void InstantiatePlayer()
    {
        GameObject playerGameObject = Instantiate(playerDetails.playerPrefab);

        player = playerGameObject.GetComponent<Player>();

        player.Initialize(playerDetails);
    }

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

    public void SetCurrentRoom(Room room)
    {
        previousRoom = currentRoom;
        currentRoom = room;
    }

    private void PlayDungeonLevel(int dungeonLevelListIndex)
    {
        bool dungeonBuildSuccessfully = DungeonBuilder.Instance.GenerateDungeon(dungeonLevelList[dungeonLevelListIndex]);

        if(!dungeonBuildSuccessfully)
        {
            Debug.LogError("Couldnt build dungeon from specified rooms and node graphs");
        }

        player.gameObject.transform.position = new Vector3((currentRoom.lowerBounds.x + currentRoom.upperBounds.x) / 2f, (currentRoom.lowerBounds.y + currentRoom.upperBounds.y) / 2f, 0f);

        player.gameObject.transform.position = HelperUtilities.GetSpawnPositionNearestToPlayer(player.gameObject.transform.position);
    }

    public Player GetPlayer()
    {
        return player;
    }

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }

    private void OnValidate() 
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(dungeonLevelList), dungeonLevelList);
    }
}
