using RoomBooking.Core.Interface;
using System.Text.RegularExpressions;

namespace RoomBooking.Core.Logic
{
    public class RoomAssignmentEngine : IEngine
    {
        private SortedList<int, Room> _sortedRooms;
        //private ILogger<RoomBookingController> logger;
        private object _lock = new object();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="roomNumbering">Room number for setting up room allocation priorities</param>
        public RoomAssignmentEngine(string[] rooms)
        {
            _sortedRooms = new SortedList<int, Room>();
            //this.logger = logger;
            initSetup(rooms);
        }

        /// <summary>
        /// Assign an available room and set it to Occupied
        /// </summary>
        /// <returns></returns>
        public Room? AssignRoom()
        {
            Room? room = null;
            lock (_lock)
            {
                room = _sortedRooms.Values.FirstOrDefault(r => r.isAvailable());
                if (room != null)
                {
                    if (room.CheckinRoom())
                        return room;
                }
            }
            
            return null;
        }

        /// <summary>
        /// Retrieve Room based on room name
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public Room? GetRoom(string roomName)
        {
            return _sortedRooms.Values.FirstOrDefault(r => r.Name == roomName);
        }

        /// <summary>
        /// Retrieve a list of available rooms
        /// </summary>
        /// <returns></returns>
        public List<Room> GetAllAvailableRooms()
        {
            return _sortedRooms.Values.Where(r => r.isAvailable()).ToList();
        }

        /// <summary>
        /// Setup initial rooms
        /// </summary>
        /// <param name="roomNumbering"></param>
        private void initSetup(string[] roomNumbering)
        {
            foreach (var room in roomNumbering)
            {
                int priority = ConvertRoomPriority(room);
                Room r = new Room(room, priority);
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

            roomLevel = Int32.Parse(Regex.Match(roomName, @"\d+").Value);
            roomLetter = char.Parse(roomName.Substring(roomName.Length - 1, 1));
            roomNumber = ((int) char.ToUpper(roomLetter)) - ASCII_OFFSET;

            if (roomLevel % 2 == 0) //Even floors
            {
                roomNumber = ((roomNumber * -1) % NUM_LETTERS) + NUM_LETTERS;
            }

            return roomLevel * FLOOR_OFFSET + roomNumber;
        }


    }
}
