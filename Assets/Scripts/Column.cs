using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    [SerializeField] private TileEnum _tileEnum;
    private List<Tiles> _tiles;



    private void Start()
    {
        _tiles = new List<Tiles>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var triggeredTiles = collision.GetComponent<Tiles>();
        if (triggeredTiles != null)
        {
            if (triggeredTiles.GetTileEnum() == _tileEnum)
            {
                _tiles.Add(triggeredTiles);
            }
            GameManager.Instance.SetColumn(_tileEnum, _tiles.Count == 5);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var triggeredTiles = collision.GetComponent<Tiles>();
        _tiles.Remove(triggeredTiles);
    }
}
