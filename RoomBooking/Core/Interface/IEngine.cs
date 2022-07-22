using RoomBooking.Core.Logic;

namespace RoomBooking.Core.Interface
{
    public interface IEngine
    {
        /// <summary>
        /// Assign an available room and set it to Occupied
        /// </summary>
        /// <returns></returns>
        public Room? AssignRoom();
        
        /// <summary>
        /// Retrieve Room based on room name
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public Room? GetRoom(string roomName);
        
        /// <summary>
        /// Retrieve a list of available rooms
        /// </summary>
        /// <returns></returns>
        public List<Room> GetAllAvailableRooms();
    }
}
