using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
    public TileRow[] rows { get; private set; }
    public TileCell[] cells { get;  set; }

    public int size => cells.Length;
    public int height => rows.Length;
    public int width => size / height;

    private void Awake()
    {
        rows = GetComponentsInChildren<TileRow>();
        List<TileCell> cellList = new List<TileCell>();

        foreach (TileRow row in rows)
        {
            foreach (TileCell cell in row.cells)
            {
                cellList.Add(cell);
            }
        }

        cells = cellList.ToArray();

        Debug.Log("Number of cells: " + cells.Length);
        Debug.Log("Number of rows: " + rows.Length);
    }

    private void Start()
    {
        InitializeCellCoordinates();
    }

    private void InitializeCellCoordinates()
    {
        for (int y = 0; y < rows.Length; y++)
        {
            for (int x = 0; x < rows[y].cells.Length; x++)
            {
                rows[y].cells[x].coordinates = new Vector2Int(x, y);
            }
        }
    }

    public TileCell GetCell(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return rows[y].cells[x];
        }
        else
        {
            return null;
        }
    }

    public TileCell GetAdjacentCell(TileCell cell, Vector2Int direction)
    {
        Vector2Int coordinates = cell.coordinates + direction;
        return GetCell(coordinates.x, coordinates.y);
    }

    public TileCell GetRandomEmptyCell()
    {
        List<TileCell> emptyCells = new List<TileCell>();

        foreach (var cell in cells)
        {
            if (!cell.occupied)
            {
                emptyCells.Add(cell);
            }
        }

        if (emptyCells.Count == 0)
        {
            return null;
        }

        int index = Random.Range(0, emptyCells.Count);
        return emptyCells[index];
    }
}
