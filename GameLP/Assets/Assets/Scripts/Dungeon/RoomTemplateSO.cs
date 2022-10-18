using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Room_", menuName = "Scriptable Objects/Dungeon/Room")]

public class RoomTemplateSO : ScriptableObject
{
    [HideInInspector] public string guid;

    public GameObject prefab; 

    [Space(10)]
    [Header("ROOM PREFAB")]

    [HideInInspector] public GameObject previousPrefab;

    [Space(10)]
    [Header("ROOM CONFIGURATION")]

    public RoomNodeTypeSO roomNodeType;

    public Vector2Int lowerBounds;

    public Vector2Int upperBounds;

    [SerializeField] public List<Doorway> doorwayList;  

    public Vector2Int[] spawnPositionArray;

    public List<Doorway> GetDoorwayList()
    {
        return doorwayList;
    }

    private void OnValidate()
    {
        if(guid == "" || previousPrefab != prefab)
        {
            guid = GUID.Generate().ToString();
            previousPrefab = prefab;
            EditorUtility.SetDirty(this);
        }

        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(doorwayList), doorwayList);

        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(spawnPositionArray), spawnPositionArray);
    }
}
