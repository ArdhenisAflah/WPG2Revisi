using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
// using System.Numerics;

public class PuzzleManager : MonoBehaviour
{
    [Header("Tile References")]
    public List<PuzzleTile> tileObjects; // Assign in inspector (Tile1-Tile4 in order)

    [Header("UI References")]
    public TextMeshProUGUI modeText;

    private PuzzleTile[,] tiles = new PuzzleTile[2, 2];
    private int currentRow = 0;
    private int currentCol = 0;
    private bool isHorizontal = true;
    private List<PuzzleTile> currentSelection = new List<PuzzleTile>();

    [SerializeField]
    public int Day;
    public GameObject selector;
    public int nextday;


    [SerializeField]
    GameObject questPopUp;
    Animator animQuest;
    AnimatorStateInfo stateInfo;
    public GameObject selectorVertical;
    void Start()
    {


        var trm = questPopUp.GetComponent<Transform>();
        var trmfirst = trm.GetChild(1);
        animQuest = trmfirst.GetComponent<Animator>();
        Init();
    }

    void Init()
    {
        // Initialize 2D array
        int index = 0;
        for (int row = 0; row < 2; row++)
        {
            for (int col = 0; col < 2; col++)
            {
                if (Day == 1)
                {
                    tiles[row, col] = tileObjects[index++];
                    if (row == 0 && col == 0)
                    {
                        tiles[row, col].currentRotation = 0;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 0 && col == 1)
                    {
                        tiles[row, col].currentRotation = 0;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 1 && col == 0)
                    {
                        tiles[row, col].currentRotation = 3;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 1 && col == 1)
                    {
                        tiles[row, col].currentRotation = 3;
                        tiles[row, col].RotateTile();
                    }
                    else
                    {
                        // Set random rotation (0-3, where 0=0°, 1=90° etc.)
                        tiles[row, col].currentRotation = Random.Range(0, 4);
                        tiles[row, col].RotateTile(); // Apply visual rotation
                    }
                }
                if (Day == 2)
                {
                    tiles[row, col] = tileObjects[index++];
                    if (row == 0 && col == 0)
                    {
                        tiles[row, col].currentRotation = 2;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 0 && col == 1)
                    {
                        tiles[row, col].currentRotation = 2;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 1 && col == 0)
                    {
                        tiles[row, col].currentRotation = 2;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 1 && col == 1)
                    {
                        tiles[row, col].currentRotation = 2;
                        tiles[row, col].RotateTile();
                    }
                    else
                    {
                        // Set random rotation (0-3, where 0=0°, 1=90° etc.)
                        tiles[row, col].currentRotation = Random.Range(0, 4);
                        tiles[row, col].RotateTile(); // Apply visual rotation
                    }
                }
                if (Day == 3)
                {
                    tiles[row, col] = tileObjects[index++];
                    if (row == 0 && col == 0)
                    {
                        tiles[row, col].currentRotation = 0;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 0 && col == 1)
                    {
                        tiles[row, col].currentRotation = 3;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 1 && col == 0)
                    {
                        tiles[row, col].currentRotation = 3;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 1 && col == 1)
                    {
                        tiles[row, col].currentRotation = 2;
                        tiles[row, col].RotateTile();
                    }
                    else
                    {
                        // Set random rotation (0-3, where 0=0°, 1=90° etc.)
                        tiles[row, col].currentRotation = Random.Range(0, 4);
                        tiles[row, col].RotateTile(); // Apply visual rotation
                    }
                }
                if (Day == 4)
                {
                    tiles[row, col] = tileObjects[index++];
                    if (row == 0 && col == 0)
                    {
                        tiles[row, col].currentRotation = 1;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 0 && col == 1)
                    {
                        tiles[row, col].currentRotation = 3;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 1 && col == 0)
                    {
                        tiles[row, col].currentRotation = 2;
                        tiles[row, col].RotateTile();
                    }
                    else if (row == 1 && col == 1)
                    {
                        tiles[row, col].currentRotation = 0;
                        tiles[row, col].RotateTile();
                    }
                    else
                    {
                        // Set random rotation (0-3, where 0=0°, 1=90° etc.)
                        tiles[row, col].currentRotation = Random.Range(0, 4);
                        tiles[row, col].RotateTile(); // Apply visual rotation
                    }
                }
            }
        }

        UpdateSelection();
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ToggleSelectionMode();
        if (Input.GetKeyDown(KeyCode.R)) Init();

        if (isHorizontal)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && currentRow > -1) MoveSelection(-1);

            if (Input.GetKeyDown(KeyCode.DownArrow) && currentRow < 1) MoveSelection(1);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentCol > -1) MoveSelection(-1);
            if (Input.GetKeyDown(KeyCode.RightArrow) && currentCol < 1) MoveSelection(1);
        }

        if (Input.GetMouseButtonDown(1)) RotateSelectedTiles();


        // Get the current animation state information for the base layer
        stateInfo = animQuest.GetCurrentAnimatorStateInfo(0);
        // Check if the "Attack" animation is playing and has completed
        if (stateInfo.IsName("QuestSuccess") && stateInfo.normalizedTime >= 1.0f)
        {
            // Debug.Log("animation has finished.");
            UtilityVarLikeDislike.MissingPiece = 0;
            SceneManager.LoadScene(nextday);
            // Add your logic here, e.g., allow the player to move again.
        }
    }

    void ToggleSelectionMode()
    {
        isHorizontal = !isHorizontal;
        UpdateSelection();
        UpdateUI();
    }

    void MoveSelection(int direction)
    {
        if (isHorizontal)
            currentRow = Mathf.Clamp(currentRow + direction, 0, 2);
        else
            currentCol = Mathf.Clamp(currentCol + direction, 0, 2);

        UpdateSelection();
        UpdateUI();
    }

    void UpdateSelection()
    {
        // Clear previous selection
        foreach (var tile in currentSelection)
            tile.SetHighlight(false, isHorizontal);

        currentSelection.Clear();

        // Add new selection
        if (isHorizontal)
        {
            selectorVertical.SetActive(false);
            selector.SetActive(true);
            if (currentRow > -1 && currentRow < 2)
            {
                // Debug.Log(currentRow); atas 0 bawah 1
                for (int col = 0; col < 2; col++)
                {
                    if (currentRow == 1)
                    {
                        selector.GetComponent<RectTransform>().anchoredPosition = new Vector2(-155.51f, -179);
                        currentSelection.Add(tiles[currentRow, col]);
                        tiles[currentRow, col].SetHighlight(true, isHorizontal);
                    }
                    else if (currentRow == 0)
                    {
                        selector.GetComponent<RectTransform>().anchoredPosition = new Vector2(-155.51f, 47.85178f);
                        currentSelection.Add(tiles[currentRow, col]);
                        tiles[currentRow, col].SetHighlight(true, isHorizontal);
                    }
                }
            }
        }
        else
        {
            selectorVertical.SetActive(true);
            selector.SetActive(false);
            for (int row = 0; row < 2; row++)
            {
                if (currentCol == 0)
                {
                    selectorVertical.GetComponent<RectTransform>().anchoredPosition = new Vector2(-33, -315f);
                    currentSelection.Add(tiles[row, currentCol]);
                    tiles[row, currentCol].SetHighlight(true, isHorizontal);
                }
                else if (currentCol == 1)
                {
                    selectorVertical.GetComponent<RectTransform>().anchoredPosition = new Vector2(196, -315f);
                    currentSelection.Add(tiles[row, currentCol]);
                    tiles[row, currentCol].SetHighlight(true, isHorizontal);
                }
            }
        }
    }

    void RotateSelectedTiles()
    {
        foreach (var tile in currentSelection)
            tile.RotateTile();

        if (CheckWinCondition())
        {
            questPopUp.SetActive(true);
            Debug.Log("Puzzle Solved!");
        }
    }

    bool CheckWinCondition()
    {
        foreach (var tile in tileObjects)
            if (tile.currentRotation != 0) return false;
        return true;
    }

    void UpdateUI()
    {
        modeText.text = isHorizontal ?
            $"Horizontal: Row {currentRow + 1}" :
            $"Vertical: Column {currentCol + 1}";
    }
}