using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TileEnum _tileEnum;
    [SerializeField] private float _tileDistance = 1.21f;

    public TileEnum GetTileEnum()
    {
        return _tileEnum;
    }
    private void OnMouseDown()
    {
        if (_gameManager.SelectedTiles == null)
        {
            if (_tileEnum != TileEnum.emptySpace)
            {
                _gameManager.SelectedTiles = this;
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
        var selectedTilePosition = _gameManager.SelectedTiles.transform.position;
        var distance = Vector2.Distance(selectedTilePosition, clickedTilePosition);
        if (_tileEnum == TileEnum.emptySpace && distance < _tileDistance)
        {
            clickedTile.transform.position = selectedTilePosition;
            _gameManager.SelectedTiles.transform.position = clickedTilePosition;
        }
        _gameManager.SelectedTiles = null;
    }
}
