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
            throw new NotImplementedException();
        }

        public bool CheckoutRoom()
        {
            throw new NotImplementedException();
        }

        public bool CleanRoom()
        {
            throw new NotImplementedException();
        }

        public bool RepairRoom()
        {
            throw new NotImplementedException();
        }
    }
}
