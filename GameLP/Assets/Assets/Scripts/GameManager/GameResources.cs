using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Audio;

public class GameResources : MonoBehaviour
{
    private static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }
            return instance;
        }
    }

    #region Header DUNGEON
    [Space(10)]
    [Header("DUNGEON")]
    #endregion
    #region Tooltip
    [Tooltip("Populate with the dungeon RoomNodeTypeListSO")]
    #endregion

    public RoomNodeTypeListSO roomNodeTypeList;

    #region  header MUSIC
    [Space(10)]
    [Header("MUSIC")]
    #endregion
    public AudioMixerGroup musicMasterMixerGroup;
    public MusicTrackSO mainMenuMusic;
    public AudioMixerSnapshot musicOnFullSnapShot;
    public AudioMixerSnapshot musicLowSnapShot;
    public AudioMixerSnapshot musicOffSnapShot;

    #region Header PLAYER
    [Space(10)]
    [Header("PLAYER")]
    #endregion Header PLAYER
    #region Tooltip
    [Tooltip("The current player scriptable object")]
    #endregion Tooltip
    public CurrentPlayerSO currentPlayer;

    #region  Header SOUNDS
    [Space(10)]
    [Header("SOUNDS")]
    #endregion Header
    #region Tooltip
    [Tooltip("populate with the sounds master mixer group")]
    #endregion Tooltip
    public AudioMixerGroup soundsMasterMixerGroup;

    #region Tooltip
    [Tooltip("Door open close sound effect")]
    #endregion Tooltip
    public SoundEffectSO doorOpenCloseSoundEffect;

    public SoundEffectSO tableFlip;

    public SoundEffectSO chestOpen;

    public SoundEffectSO healthPickUp;

    public SoundEffectSO weaponPickUp;

    public SoundEffectSO ammoPickUp;

    #region Header MATERIALS

    [Space(10)]
    [Header("MATERIALS")]
    #endregion
    #region Tooltip

    [Tooltip("Dimmed Material")]
    #endregion

    public Material dimmedMaterial;

    public Material litMaterial;

    public Shader variableLitShader;

    public Shader materializeShader;

    #region  Header SPECIAL TILEMAP TILES
    [Space(10)]
    [Header("SPECIAL TILEMAP TILES")]
    #endregion Header SPECIAL TILEMAP TILES
    #region Tooltip
    [Tooltip("Collision tiles that the enemies can navigate to")]
    #endregion Tooltip

    public TileBase[] enemyUnwalkableCollisionTilesArray;

    #region Tooltip
    [Tooltip("Preferred path tile for enemy navigation")]
    #endregion Tooltip

    public TileBase preferredEnemyPathTile;


    #region Header UI
    [Space(10)]
    [Header("UI")]
    #endregion
    public GameObject heartPrefab;
    public GameObject ammoIconPrefab;

    #region Header CHESTS
    [Space(10)]
    [Header("CHESTS")]
    #endregion
    public GameObject chestItemPrefab;
    public Sprite heartIcon;
    public Sprite bulletIcon;

    #region Header MINIMAP
    [Space(10)]
    [Header("MINIMAP")]
    #endregion
    #region Tooltip
    [Tooltip("Minimap skull prefab")]
    #endregion
    public GameObject minimapSkullPrefab;

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(roomNodeTypeList), roomNodeTypeList);
        HelperUtilities.ValidateCheckNullValue(this, nameof(currentPlayer), currentPlayer);
        HelperUtilities.ValidateCheckNullValue(this, nameof(mainMenuMusic), mainMenuMusic);
        HelperUtilities.ValidateCheckNullValue(this, nameof(soundsMasterMixerGroup), soundsMasterMixerGroup);
        HelperUtilities.ValidateCheckNullValue(this, nameof(doorOpenCloseSoundEffect), doorOpenCloseSoundEffect);
        HelperUtilities.ValidateCheckNullValue(this, nameof(tableFlip), tableFlip);
        HelperUtilities.ValidateCheckNullValue(this, nameof(chestOpen), chestOpen);
        HelperUtilities.ValidateCheckNullValue(this, nameof(healthPickUp), healthPickUp);
        HelperUtilities.ValidateCheckNullValue(this, nameof(ammoPickUp), ammoPickUp);
        HelperUtilities.ValidateCheckNullValue(this, nameof(weaponPickUp), weaponPickUp);
        HelperUtilities.ValidateCheckNullValue(this, nameof(litMaterial), litMaterial);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicMasterMixerGroup), musicMasterMixerGroup);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicOnFullSnapShot), musicOnFullSnapShot);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicLowSnapShot), musicLowSnapShot);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicOffSnapShot), musicOffSnapShot);
        HelperUtilities.ValidateCheckNullValue(this, nameof(dimmedMaterial), dimmedMaterial);
        HelperUtilities.ValidateCheckNullValue(this, nameof(variableLitShader), variableLitShader);
        HelperUtilities.ValidateCheckNullValue(this, nameof(materializeShader), materializeShader);
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(enemyUnwalkableCollisionTilesArray), enemyUnwalkableCollisionTilesArray);
        HelperUtilities.ValidateCheckNullValue(this, nameof(preferredEnemyPathTile), preferredEnemyPathTile);
        HelperUtilities.ValidateCheckNullValue(this, nameof(heartPrefab), heartPrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(ammoIconPrefab), ammoIconPrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(chestItemPrefab), chestItemPrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(heartIcon), heartIcon);
        HelperUtilities.ValidateCheckNullValue(this, nameof(bulletIcon), bulletIcon);
        HelperUtilities.ValidateCheckNullValue(this, nameof(minimapSkullPrefab), minimapSkullPrefab);
    }
#endif
    #endregion

}
