using RoomBooking.Core.Interface;
using RoomBooking.Core.Logic;

namespace RoomBooking.Core.RoomStatuses
{
    public class VacantStatus : BaseStatus, IStatus
    {
        public VacantStatus(Room room) : base(room)
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
            this._room.ChangeRoomStatus(new AvailableStatus(this._room));
            return true;
        }

        public bool RepairRoom()
        {
            this._room.ChangeRoomStatus(new RepairStatus(this._room));
            return true;
        }

        public bool RoomRepaired()
        {
            return false;
        }
    }
}
