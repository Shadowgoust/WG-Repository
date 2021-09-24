using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField] private TileEnum _tileEnum;
    [SerializeField] private float _tileDistance = 1.21f;

    public TileEnum GetTileEnum()
    {
        return _tileEnum;
    }
    private void OnMouseDown()
    {
        if (GameManager.Instance.SelectedTiles == null)
        {
            if (_tileEnum != TileEnum.emptySpace)
            {
                GameManager.Instance.SelectedTiles = this;
            }
        }
        else
        {
            SwapTiles();
        }
    }
    private void SwapTiles()
    {
        var clickedTile = gameObject;
        var clickedTilePosition = transform.position;
        var selectedTilePosition = GameManager.Instance.SelectedTiles.transform.position;
        var distance = Vector2.Distance(selectedTilePosition, clickedTilePosition);
        if (_tileEnum == TileEnum.emptySpace && distance < _tileDistance)
        {
            clickedTile.transform.position = selectedTilePosition;
            GameManager.Instance.SelectedTiles.transform.position = clickedTilePosition;
        }
        GameManager.Instance.SelectedTiles = null;
    }
}
