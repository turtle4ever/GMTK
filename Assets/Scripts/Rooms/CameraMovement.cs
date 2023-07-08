using Rooms.Extensions;
using UnityEngine;

namespace Rooms
{
    public class CameraMovement : MonoBehaviour
    {
        public Direction CurrentDir { get; private set; }
        public Room CurrentRoom { get; private set; }

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
