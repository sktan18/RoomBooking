using RoomBooking.Core.Interface;
using RoomBooking.Core.RoomStatuses;

namespace RoomBooking.Core.Logic
{
    public class Room
    {
        public string Name { get; set; }
        private IStatus Status { get; set; }
        private int RoomPriority { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Room name</param>
        /// <param name="roomPriority">Allocation priority (Lower gets allocated first)</param>
        public Room(string name, int roomPriority)
        {
            Name = name;
            Status = new AvailableStatus(this);
            RoomPriority = roomPriority;
        }

        /// <summary>
        /// Check in room and change to Occupied
        /// </summary>
        /// <returns></returns>
        public bool CheckinRoom()
        {
            if (Status.CheckinRoom())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check out room and change to Vacant
        /// </summary>
        /// <returns></returns>
        public bool CheckoutRoom()
        {
            if (Status.CheckoutRoom())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clean Room and change to Available
        /// </summary>
        /// <returns></returns>
        public bool CleanRoom()
        {
            if (Status.CleanRoom())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Repair room and change to Repair
        /// </summary>
        /// <returns></returns>
        public bool RepairRoom()
        {
            if (Status.RepairRoom())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Repair is completed and change room to Vacant
        /// </summary>
        /// <returns></returns>
        public bool RoomRepaired()
        {
            if (Status.RoomRepaired())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns if room is Available
        /// </summary>
        /// <returns></returns>
        public bool isAvailable()
        {
            return Status is AvailableStatus;
        }

        /// <summary>
        /// Change room to given status
        /// </summary>
        /// <param name="status"></param>
        internal void ChangeRoomStatus(IStatus status)
        {
            this.Status = status;
        }

        /// <summary>
        /// Override ToString printing
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Room {Name}";
        }


    }
}
