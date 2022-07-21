using RoomBooking.Core.Interface;
using RoomBooking.Core.Logic;

namespace RoomBooking.Core.RoomStatuses
{
    public class AvailableStatus : BaseStatus, IStatus
    {
        public AvailableStatus(Room room) : base(room)
        {
        }

        public bool CheckinRoom()
        {
            this._room.ChangeRoomStatus(new OccupiedStatus(this._room));
            return true;
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
            return false;
        }
    }
}
