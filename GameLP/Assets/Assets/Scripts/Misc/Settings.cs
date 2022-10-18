using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    #region DUNGEON ROOMS SETTINGS

    public const int maxDungeonRebuildAttemptsForRoomGraph = 1000;
    public const int maxDungeonBuildAttempts = 10;
    #endregion

    #region ROOM SETTINGS

    public const int maxChildCorridors = 3; //Max Number of child corridors leading from a room. 
    
    #endregion
}
