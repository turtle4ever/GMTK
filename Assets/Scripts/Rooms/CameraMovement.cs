using Rooms.Extensions;
using UnityEngine;

namespace Rooms
{
    public class CameraMovement : MonoBehaviour
    {
        [field: SerializeField] public Room CurrentRoom { get; private set; }
        [field: SerializeField] public Direction CurrentDir { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown (KeyCode.RightArrow))
            {
                CurrentDir = CurrentDir.Clockwise();
                CurrentRoom.TogglePosition(CurrentDir);
            }
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CurrentDir = CurrentDir.CounterClockwise();
                CurrentRoom.TogglePosition(CurrentDir);
            }
        }
    }
}
