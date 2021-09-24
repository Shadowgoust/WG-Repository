using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuManager;
    public Tiles SelectedTiles;
    public static GameManager Instance { get; private set; }
    private bool _isSwordCollumnComplete;
    private bool _isBowCollumnComplete;
    private bool _isMagicCollumnComplete;
    

    private void Awake()
    {
        Instance = this;
    }
    public void SetColumn(TileEnum tileEnum, bool isComplete)
    {
        Debug.Log("Set Collumn");
        switch (tileEnum)
        {
            case TileEnum.swordTile:
                _isSwordCollumnComplete = isComplete;
                break;
            case TileEnum.bowTile:
                _isBowCollumnComplete = isComplete;
                break;
            case TileEnum.magicTile:
                _isMagicCollumnComplete = isComplete;
                break;
        }
        if(_isSwordCollumnComplete && _isBowCollumnComplete && _isMagicCollumnComplete)
        {
            Debug.Log("You win!");
            _menuManager.SetActive(true);
        }
    }
}

