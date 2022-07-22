namespace RoomBooking.TestData
{
    public static class TestData
    {
        private static readonly string[] Rooms = new[]
       {
        "1A", "1B", "1C", "1D", "1E", "2A", "2B", "2C", "2D", "2E", "3A", "3B", "3C", "3D", "3E", "4A", "4B", "4C", "4D", "4E"
        };

        public static string[] GetRooms()
        {
            return Rooms;
        }
    }
}
