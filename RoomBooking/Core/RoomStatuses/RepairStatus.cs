using RoomBooking.Core.Interface;
using RoomBooking.Core.Logic;

namespace RoomBooking.Core.RoomStatuses
{
    public class RepairStatus : BaseStatus, IStatus
    {
        public RepairStatus(Room room) : base(room)
        {
        }

        public bool CheckinRoom()
        {
            return false;
        }

        public bool CheckoutRoom()
        {
            return false;
        }

        public bool CleanRoom()
        {
            return false;
        }

        public bool RepairRoom()
        {
            return false;
        }

        public bool RoomRepaired()
        {
            this._room.ChangeRoomStatus(new VacantStatus(this._room));
            return true;
        }
    }
}
