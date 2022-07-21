using System.Text.RegularExpressions;

namespace RoomBooking.Core.Logic
{
    public class RoomAssignmentEngine
    {
        private SortedList<int, Room> _sortedRooms;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="roomNumbering">Room number for setting up room allocation priorities</param>
        public RoomAssignmentEngine(List<string> roomNumbering)
        {
            _sortedRooms = new SortedList<int, Room>();
            initSetup(roomNumbering);
        }

        /// <summary>
        /// Setup initial rooms
        /// </summary>
        /// <param name="roomNumbering"></param>
        public void initSetup(List<string> roomNumbering)
        {
            for (int i = 0; i < roomNumbering.Count; i++)
            {
                int priority = ConvertRoomPriority(roomNumbering[i]);
                Room r = new Room(roomNumbering[i], priority);
                _sortedRooms.Add(priority, r);
            }
        }

        /// <summary>
        /// Assumation room letter is only from A to Z
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns>Priority of room in terms of check in</returns>
        private int ConvertRoomPriority(string roomName)
        {
            int roomLevel;
            char roomLetter;
            int roomNumber;
            const int ASCII_OFFSET = 64;
            const int FLOOR_OFFSET = 100;
            const int NUM_LETTERS = 26;

            roomLevel = Int32.Parse(Regex.Match(roomName, @"\d+").Value) * FLOOR_OFFSET;
            roomLetter = char.Parse(roomName.Substring(roomName.Length - 1, 1));
            roomNumber = ((int) char.ToUpper(roomLetter)) - ASCII_OFFSET;

            if (roomLevel % 2 == 0) //Even floors
            {
                roomNumber = (roomNumber * -1) % NUM_LETTERS;
            }

            return roomLevel + roomNumber;
        }


    }
}
