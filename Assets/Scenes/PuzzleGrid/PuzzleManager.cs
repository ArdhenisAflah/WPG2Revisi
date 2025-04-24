using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    [Header("Tile References")]
    public List<PuzzleTile> tileObjects; // Assign in inspector (Tile1-Tile9 in order)

    [Header("UI References")]
    public TextMeshProUGUI modeText;

    private PuzzleTile[,] tiles = new PuzzleTile[3, 3];
    private int currentRow = 0;
    private int currentCol = 0;
    private bool isHorizontal = true;
    private List<PuzzleTile> currentSelection = new List<PuzzleTile>();

    void Start()
    {
        // Initialize 2D array
        int index = 0;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                tiles[row, col] = tileObjects[index++];
                // Set random rotation (0-3, where 0=0°, 1=90° etc.)
                tiles[row, col].currentRotation = Random.Range(0, 4);
                tiles[row, col].RotateTile(); // Apply visual rotation
            }
        }

        UpdateSelection();
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ToggleSelectionMode();

        if (isHorizontal)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) MoveSelection(-1);
            if (Input.GetKeyDown(KeyCode.DownArrow)) MoveSelection(1);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) MoveSelection(-1);
            if (Input.GetKeyDown(KeyCode.RightArrow)) MoveSelection(1);
        }

        if (Input.GetMouseButtonDown(0)) RotateSelectedTiles();
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
            for (int col = 0; col < 3; col++)
            {
                currentSelection.Add(tiles[currentRow, col]);
                tiles[currentRow, col].SetHighlight(true, isHorizontal);
            }
        }
        else
        {
            for (int row = 0; row < 3; row++)
            {
                currentSelection.Add(tiles[row, currentCol]);
                tiles[row, currentCol].SetHighlight(true, isHorizontal);
            }
        }
    }

    void RotateSelectedTiles()
    {
        foreach (var tile in currentSelection)
            tile.RotateTile();

        if (CheckWinCondition())
            Debug.Log("Puzzle Solved!");
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