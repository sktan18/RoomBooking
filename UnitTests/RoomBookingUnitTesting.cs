using RoomBooking.Core.Logic;
using RoomBooking.Core.Interface;
using RoomBooking.Core.RoomStatuses;

namespace UnitTests
{
    public class Tests
    {
        IEngine _engine;

        [SetUp]
        public void Setup()
        {
            string[] Rooms = new[] { "2A", "1B", "3C", "4D", "2E" };
            _engine = new RoomAssignmentEngine(Rooms);
        }

        [Test]
        public void TestAllocation()
        {
            Room? r = _engine.AssignRoom();

            Assert.That(r, Is.Not.Null);
            Assert.That(r.Name, Is.EqualTo("1B"));
        }

        [Test]
        public void TestCheckout()
        {
            Room? r = _engine.AssignRoom();
            r = _engine.AssignRoom();

            Assert.That(r, Is.Not.Null);
            Assert.That(r.Name, Is.EqualTo("2E"));
            Assert.That(r.CheckoutRoom, Is.EqualTo(true));
            Assert.That(r.isAvailable, Is.EqualTo(false));
        }

        [Test]
        public void TestRepairRoom()
        {
            Room? r = _engine.AssignRoom();
            r = _engine.AssignRoom();
            r = _engine.GetRoom("2E");
            Assert.That(r, Is.Not.Null);
            
            r.CheckoutRoom();
            
            Assert.That(r.RepairRoom, Is.EqualTo(true));
            Assert.IsInstanceOf<RepairStatus>(r.Status);
        }

        [Test]
        public void TestRoomRepaired()
        {
            Room? r = _engine.AssignRoom();
            r = _engine.AssignRoom();
            r = _engine.GetRoom("2E");
            Assert.That(r, Is.Not.Null);

            r.CheckoutRoom();
            r.RepairRoom();
            Assert.That(r.RoomRepaired, Is.EqualTo(true));
            Assert.IsInstanceOf<VacantStatus>(r.Status);
        }

        [Test]
        public void TestRoomCleaned()
        {
            Room? r = _engine.AssignRoom();
            r = _engine.AssignRoom();
            r = _engine.GetRoom("2E");
            Assert.That(r, Is.Not.Null);

            r.CheckoutRoom();
            r.RepairRoom();
            r.RoomRepaired();
            Assert.That(r.CleanRoom, Is.EqualTo(true));
            Assert.IsInstanceOf<AvailableStatus>(r.Status);
        }

        [Test]
        public void TestGetAvailableRooms()
        {
            Room? r = _engine.AssignRoom();
            r = _engine.AssignRoom();

            List<Room> rooms = _engine.GetAllAvailableRooms();

            Assert.That(rooms.Count, Is.EqualTo(3));
            Assert.That(rooms[0].Name, Is.EqualTo("2A"));
        }
    }
}