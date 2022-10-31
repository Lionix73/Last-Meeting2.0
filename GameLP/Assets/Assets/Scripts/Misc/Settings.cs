using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Settings
{
    #region UNITS
    public const float pixelsPerUnit = 192f;
    public const float tilesSizePixel = 192f;
    #endregion

    #region DUNGEON ROOMS SETTINGS

    public const int maxDungeonRebuildAttemptsForRoomGraph = 1000;
    public const int maxDungeonBuildAttempts = 10;
    #endregion

    #region ROOM SETTINGS

    public const float fadeInTime = 0.5f; //Time to fade in the room
    public const int maxChildCorridors = 3; //Max Number of child corridors leading from a room. 
    public const float doorUnlockDelay = 1f;
    #endregion

    #region ANIMATOR PARAMETERS
    //For Player
    public static int aimUp = Animator.StringToHash("aimUp");
    public static int aimDown = Animator.StringToHash("aimDown");
    public static int aimUpRight = Animator.StringToHash("aimRight");
    public static int aimUpLeft = Animator.StringToHash("aimLeft");
    public static int aimRight = Animator.StringToHash("aimRight");
    public static int aimLeft = Animator.StringToHash("aimLeft");
    public static int isIdle = Animator.StringToHash("isIdle");
    public static int isMoving = Animator.StringToHash("isMoving");
    public static int rollUp = Animator.StringToHash("rollUp");
    public static int rollRight = Animator.StringToHash("rollRight");
    public static int rollLeft = Animator.StringToHash("rollLeft");
    public static int rollDown = Animator.StringToHash("rollDown");
    public static float baseSpeedForPlayerAnimation = 8f;

    //For Enemy
    public static float baseSpeedForEnemyAnimations = 3f;

    //For Door
    public static int open = Animator.StringToHash("open");
    public static int destroy = Animator.StringToHash("destroy");
    public static String stateDestroyed = "Destroyed";
    #endregion

    #region GAMEOBJECT TAGS
    public const string playerTag = "Player";
    public const string playerWeapon = "playerWeapon";
    #endregion

    #region FIRIGN CONTROL
    public const float useAimAngleDistance = 3.5f;
    #endregion

    #region ASTAR PATHFINDING PARAMETERS 
    public const int defaultAStarMovementPenalty = 40;
    public const int preferredPathAStarMovementPenalty= 1;
    public const int targetFrameRateToSpreadPathfindingOver = 60;
    public const float playerMoveDistanceToRebuildPath = 3f;
    public const float enemyPathToRebuildCooldown = 2f;
    #endregion

    #region ENEMY PARAMETERS
    public const int defaultEnemyHealth = 20;
    #endregion

    #region UI PARAMETERS
    public const float uiHeartSpacing = 80f;
    public const float uiAmmoIconSpacing = 15f;
    #endregion

    #region CONTACT DAMAGE PARAMETERS
    public const float contactDamageCollisionResetDelay = 0.5f;
    #endregion 
}
