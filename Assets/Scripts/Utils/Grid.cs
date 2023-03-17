using System;
using UnityEngine;


public class Grid<TGridObject>
{
    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs: EventArgs
    {
        public int x;
        public int y;

    }

    private Vector3 originPosition;
    private int width, height;
    private float cellSize;
    private TGridObject[,] grid;

    public Grid(int width, int height, float cellSize, Vector3 originPosition, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;   

        grid = new TGridObject[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                grid[i, j] = createGridObject(this, i, j);
                Debug.DrawLine(GetWorldPosition(i,j), GetWorldPosition(i,j+1), Color.red, 100f);
                Debug.DrawLine(GetWorldPosition(i,j), GetWorldPosition(i+1,j), Color.red, 100f);

            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.red, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.red, 100f);
    }
    
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;    
    }

    public Vector2Int GetXandY(Vector3 worldPosition)
    {
        Vector2Int vec = Vector2Int.zero;

        vec.x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        vec.y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);

        return vec;
    }

    public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x < width && x >= 0 && y >= 0 && y < height)
        {
            grid[x, y] = value;
            if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y }); 

            Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x+1, y+1), Color.red, 100f);
        }
    }

    public void SetGridObject(Vector3 worldPosition, TGridObject value)
    {
        Vector2Int gridXY = GetXandY(worldPosition);
        SetGridObject(gridXY.x, gridXY.y, value);
    }

    public TGridObject GetGridObject(int x, int y)
    {
        if (x < width && x >= 0 && y >= 0 && y < height)
        {
            return grid[x, y];
        }

        return default(TGridObject);
    }

    public TGridObject GetGridObject(Vector3 worldPosition, int value)
    {
        Vector2Int gridXY = GetXandY(worldPosition);
        return GetGridObject(gridXY.x, gridXY.y);
    }

    public void TriggerOnGridValueChanged(int x, int y)
    {
        if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
    }
}
