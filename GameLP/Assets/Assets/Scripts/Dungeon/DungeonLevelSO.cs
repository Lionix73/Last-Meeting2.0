using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonLevel_", menuName = "Scriptable Objects/Dungeon/Dungeon Level")]

public class DungeonLevelSO : ScriptableObject
{
    #region Header BASIC LEVEL DETAILS
    [Space(10)]

    [Header("BASIC LEVEL DETAILS")]
    #endregion Header BASIC LEVEL DETAILS

    #region Tooltip

    [Tooltip("the name of the level")]
    #endregion Tooltip


    public string levelName;

    #region Header ROOM TEMPLATES FOR LEVEL

    [Space(10)]
    [Header("ROOM TEMPLATES FOR LEVEL")]
    #endregion Header ROOM TEMPLATES FOR LEVEL

    #region Tooltip

    [Tooltip("Populate the list with the room templates that you want to be part of the level. You need to ensure that room templates are included for all room node types that are specified  in the Room Node Graphs for the level.")]
    #endregion Tooltip

    public List<RoomTemplateSO> roomTemplateList;

    #region Header ROOM NODES GRAPHS FOR LEVEL

    [Space(10)]
    [Header("ROOM NODES GRAPHS FOR LEVEL")]
    #endregion Header ROOM NODES GRAPHS FOR LEVEL

    #region Tooltip
    [Tooltip("Populate this list with the room node grahps which should be randomly selected from the level.")]
    #endregion Tooltip

    public List<RoomNodeGraphSO> roomNodeGraphList; 

    private void OnValidate() 
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(levelName), levelName);

        if(HelperUtilities.ValidateCheckEnumerableValues(this, nameof(roomTemplateList), roomTemplateList))
            return;

        if(HelperUtilities.ValidateCheckEnumerableValues(this, nameof(roomNodeGraphList), roomNodeGraphList))
            return;

        // First check that north/south corridor, east/west corridor and entrance types have been specified
        bool isEWCorridor = false;
        bool isNSCorridor = false; 
        bool isEntrance = false;

        foreach(RoomTemplateSO roomTemplateSO in roomTemplateList)
        {
            if(roomTemplateSO == null)
                return;

            if(roomTemplateSO.roomNodeType.isCorridorEW)
                isEWCorridor = true;

            if(roomTemplateSO.roomNodeType.isCorridorNS)
                isNSCorridor = true;

            if(roomTemplateSO.roomNodeType.isEntrance)
                isEntrance = true;
        }

        if(isEWCorridor == false)
        {
            Debug.Log("In " + this.name.ToString() + " : No E/W Corridor Room Type Specified");
        }

        if(isNSCorridor == false)
        {
            Debug.Log("In " + this.name.ToString() + " : No E/W Corridor Room Type Specified");
        }

        if(isEntrance == false)
        {
            Debug.Log("In " + this.name.ToString() + " : No E/W Corridor Room Type Specified");
        }

        // Loop through all node graphs
        foreach(RoomNodeGraphSO roomNodeGraph in roomNodeGraphList)
        {

            if(roomNodeGraph == null)
                return;

            // Loop through all nodes in node graphs
            foreach(RoomNodeSO roomNodeSO in roomNodeGraph.roomNodeList)
            {
                if(roomNodeSO == null)
                    continue;

                // check that room template has been specified for each roomNode type

                // Corridors and entrance already checked
                if(roomNodeSO.roomNodeType.isEntrance || roomNodeSO.roomNodeType.isCorridorEW || roomNodeSO.roomNodeType.isCorridorNS ||
                    roomNodeSO.roomNodeType.isCorridor || roomNodeSO.roomNodeType.isNone) 
                    continue;

                bool isRoomNodeTypeFound = false;

                foreach(RoomTemplateSO roomTemplateSO in roomTemplateList)
                {
                    if(roomTemplateSO == null)
                        continue;

                    if(roomTemplateSO.roomNodeType == roomNodeSO.roomNodeType)
                    {
                        isRoomNodeTypeFound =  true;
                        break;
                    }
                }

                if(!isRoomNodeTypeFound)
                {
                    Debug.Log("In " + this.name.ToString() + " : No room template " + roomNodeSO.roomNodeType.name.ToString() + " found for name graph " + roomNodeGraph.name.ToString());
                }
            }
        }
    }
}
