using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GridType
{
    multiplication,
    squares
}
public class TableGenerator : MonoBehaviour
{
    public TableComponent prefab;
    public List<TableComponent> components = new List<TableComponent>();
    public int gridSize = 10;
    public GridType gridType = GridType.multiplication;
    public Color color_default;
    public Color color_around;
    public Color color_numbersIsSame;

    private void Start()
    {
        SpawnGrid();
        FillGrid(gridType);
    }
    private void SpawnGrid()
    {
        for (int i = 0; i < gridSize * gridSize; i++)
        {
            components.Add(Instantiate(prefab, transform));
        }
    }
    private void FillGrid(GridType type)
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {

                if(type == GridType.multiplication)
                {
                    if (y == 0)
                        components[x].SetText((x + 1).ToString());
                    else
                    {
                        int result = components[x].GetInt32FromText() * (y + 1);
                        components[y * gridSize + x].SetText(result.ToString());
                    }
                }
                else if(type == GridType.squares)
                {
                    if (y == 0)
                        components[x].SetText((x).ToString());
                    else if (x == 0)
                    {
                        components[y * gridSize + x].SetText(y.ToString());
                    }
                    else
                    {
                        float a = (components[y * gridSize].GetInt32FromText() * 10) + components[x].GetInt32FromText();
                        float result = Mathf.Pow(a, 2);
                        components[y * gridSize + x].SetText(result.ToString());
                    }
                }

                if (y == x)
                    components[y * gridSize + x].SetColor(color_numbersIsSame);
                else if (y == 0 || x == 0)
                    components[y * gridSize + x].SetColor(color_around);
                else
                    components[y * gridSize + x].SetColor(color_default);
                
            }
        }
    }
}
