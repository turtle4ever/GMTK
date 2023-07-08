using UnityEngine;

namespace Rooms
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private GameObject _northMap;
        [SerializeField] private GameObject _eastMap;
        [SerializeField] private GameObject _southMap;
        [SerializeField] private GameObject _westMap;

        public void TogglePosition(Direction direction)
        {
            _northMap.SetActive(false);
            _eastMap.SetActive(false);
            _southMap.SetActive(false);
            _westMap.SetActive(false);
            
            if (direction == Direction.North)
                _northMap.SetActive(true);
            else if (direction == Direction.East)
                _eastMap.SetActive(true);
            else if (direction == Direction.South)
                _southMap.SetActive(true);
            else if (direction == Direction.West)
                _westMap.SetActive(true);
        }
    }
}
