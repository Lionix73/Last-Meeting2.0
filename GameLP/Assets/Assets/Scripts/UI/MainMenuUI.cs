using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    #region  Header OBJECT REFERENCES
    [Space(10)]
    [Header("OBJECT REFERENCES")]
    #endregion Header OBJECT REFERENCES
    #region Tooltip
    [Tooltip("Populate with the enter the dungeon play button gameObject")]
    #endregion Tooltip
    [SerializeField] private GameObject playButton;

    #region Tooltip
    [Tooltip("Populate with the high scores button gameObject")]
    #endregion Tooltip
    [SerializeField] private GameObject highScoresButton;

    #region Tooltip
    [Tooltip("Populate with the enter the main menu button gameObject")]
    #endregion Tooltip
    [SerializeField] private GameObject returnToMainMenuButton;
    private bool isHighScoresSceneLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.PlayMusic(GameResources.Instance.mainMenuMusic, 0f, 2f);

        SceneManager.LoadScene("CharacterSelectorScene", LoadSceneMode.Additive);

        returnToMainMenuButton.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadHighScores()
    {
        playButton.SetActive(false);
        //quitButton.SetActive(false);
        highScoresButton.SetActive(false);
        //instructionsButton.SetActive(false);
        isHighScoresSceneLoaded = true;

        SceneManager.UnloadSceneAsync("CharacterSelectorScene");

        returnToMainMenuButton.SetActive(true);

        // Load High Score scene additively
        SceneManager.LoadScene("HighScoreScene", LoadSceneMode.Additive);
    }

    public void LoadCharacterSelector()
    {
        returnToMainMenuButton.SetActive(false);

        if (isHighScoresSceneLoaded)
        {
            SceneManager.UnloadSceneAsync("HighScoreScene");
            isHighScoresSceneLoaded = false;
        }
        // else if (isInstructionSceneLoaded)
        // {
        //     SceneManager.UnloadSceneAsync("InstructionsScene");
        //     isInstructionSceneLoaded = false;
        // }

        playButton.SetActive(true);
        //quitButton.SetActive(true);
        highScoresButton.SetActive(true);
        //instructionsButton.SetActive(true);

        // Load character selector scene additively
        SceneManager.LoadScene("CharacterSelectorScene", LoadSceneMode.Additive);
    }

    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(playButton), playButton);
        //HelperUtilities.ValidateCheckNullValue(this, nameof(quitButton), quitButton);
        HelperUtilities.ValidateCheckNullValue(this, nameof(highScoresButton), highScoresButton);
        //HelperUtilities.ValidateCheckNullValue(this, nameof(instructionsButton), instructionsButton);
        HelperUtilities.ValidateCheckNullValue(this, nameof(returnToMainMenuButton), returnToMainMenuButton);
    }
}
