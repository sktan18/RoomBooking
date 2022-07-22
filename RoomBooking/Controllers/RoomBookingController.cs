using Microsoft.AspNetCore.Mvc;
using RoomBooking.Core.Interface;
using RoomBooking.Core.Logic;
using RoomBooking.Response;

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
        public ActionResult<ResponseDTO> Checkin()
        {
            ResponseDTO responseDTO = new ResponseDTO();
            Room? room = _engine.AssignRoom();

            if (room != null)
            {
                responseDTO.Description = $"You may now proceed to {room}";
                return Ok(responseDTO);
            }

            responseDTO.Description = "No rooms are available at this moment. Please try again later";

            return BadRequest(responseDTO);
        }

        [HttpPut("{roomName}/checkout")]
        public ActionResult<ResponseDTO> Checkout(string roomName)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            Room? room = _engine.GetRoom(roomName);

            if (room != null && room.CheckoutRoom())
            {
                responseDTO.Description = $"You have successfully checked out {room}";
                return Ok(responseDTO);
            }
            
            return HandleErrors(room, "Failed to checkout room, please try again later");
        }

        [HttpPut("{roomName}/cleaned")]
        public ActionResult<ResponseDTO> Cleaned(string roomName)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            Room? room = _engine.GetRoom(roomName);


            if (room != null && room.CleanRoom())
            {
                responseDTO.Description = $"You have successfully cleaned {room}";
                return Ok(responseDTO);
            }

            return HandleErrors(room, "Failed to clean room, please try again later");
        }

        [HttpPut("{roomName}/repair")]
        public ActionResult<ResponseDTO> Repair(string roomName)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            Room? room = _engine.GetRoom(roomName);

            if (room != null && room.RepairRoom())
            {
                responseDTO.Description = $"You have successfully mark {room} for Repair";
                return Ok(responseDTO);
            }

            return HandleErrors(room, "Failed to repair room, please try again later");
        }

        private ActionResult<ResponseDTO> HandleErrors(Room? room, string errorMsg)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            if (room == null)
                responseDTO.Description = "Invalid room name";
            else
                responseDTO.Description = errorMsg;
            return BadRequest(responseDTO);
        }

        [HttpGet("ListAvailableRooms")]
        public List<Room> GetRooms()
        {
            return _engine.GetAllAvailableRooms();
        }
    }
}