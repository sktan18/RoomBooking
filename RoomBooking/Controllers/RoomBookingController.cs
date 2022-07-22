using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core.Interface;
using RoomBooking.Core.Logic;

namespace RoomBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomBookingController : ControllerBase
    {

        private readonly ILogger<RoomBookingController> _logger;
        private readonly IEngine _engine;

        public RoomBookingController(ILogger<RoomBookingController> logger, IEngine engine)
        {
            _logger = logger;
            _engine = engine;
        }

        [HttpGet]
        public String Checkin()
        {
            Room? room = _engine.AssignRoom();
            if (room == null)
                return "No rooms are available at this moment. Please try again later";
            return $"You may now proceed to {room}";
        }

        [HttpPut("{roomName}/checkout")]
        public String Checkout(string roomName)
        {
            Room? room = _engine.GetRoom(roomName);
            if (room == null)
                return "Invalid room name";
            if (room.CheckoutRoom())
            {
                return $"You have successfully checked out {room}";
            }
            return "Failed to checkout room, please try again later";
        }

        [HttpPut("{roomName}/cleaned")]
        public String Cleaned(string roomName)
        {
            Room? room = _engine.GetRoom(roomName);
            if (room == null)
                return "Invalid room name";
            if (room.CleanRoom())
            {
                return $"You have successfully cleaned {room}";
            }
            return "Failed to clean room, please try again later";
        }

        [HttpPut("{roomName}/repair")]
        public String Repair(string roomName)
        {
            Room? room = _engine.GetRoom(roomName);
            if (room == null)
                return "Invalid room name";
            if (room.RepairRoom())
            {
                return $"You have successfully mark {room} for Repair";
            }
            return "Failed to repair room, please try again later";
        }

        [HttpGet("ListAvailableRooms")]
        public List<Room> GetRooms()
        {
            return _engine.GetAllAvailableRooms();
        }
    }
}