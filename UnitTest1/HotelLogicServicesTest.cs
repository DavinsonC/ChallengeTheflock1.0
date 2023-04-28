using ChallengeTheFlock1._0.Controllers;
using ChallengeTheFlock1._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeTheFlock1._0.UnitTest
{
    [TestClass]
    public class HotelLogicServicesTest
    {
        private HotelDbContext _context;
        private HotelLogicServices _hotelLogicServices;

        [TestInitialize]
        public void TestInitialize()
        {
            // Configurar el DbContext en memoria para las pruebas
            var options = new DbContextOptionsBuilder<HotelDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new HotelDbContext(options);

            _hotelLogicServices = new HotelLogicServices(_context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Eliminar la base de datos en memoria después de cada prueba
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetListaHoles_ShouldReturnListOfHotels()
        {
            // Instancia del objecto Moq
            var hotels = new List<Hotel>
            {
                new Hotel { IdHotel = 1, Name = "Hotel A", Address= "Mz casa 16", PhoneNumber="3014741112"},
                new Hotel { IdHotel = 2, Name = "Hotel B", Address= "Mz casa 16", PhoneNumber="3014741112" },
                new Hotel { IdHotel = 3, Name = "Hotel C", Address= "Mz casa 16", PhoneNumber="3014741112" }
            };
            _context.Hotels.AddRange(hotels);
            _context.SaveChanges();

            // Instancia al servicio
            var result = _hotelLogicServices.GetListaHoles();

            // Assert
            Assert.IsTrue(hotels.Count == result.Count());
            // Asegúrate de realizar más aserciones según los atributos de tu modelo Hotel
        }

        [TestMethod]
        public void AddHotel_ShouldAddHotelToDatabase()
        {
            // Instancia del objecto Moq
            var hotel = new Hotel { IdHotel = 1, Name = "Hotel A" };

            // Instancia al servicio
            var result = _hotelLogicServices.AddHotel(hotel);

            // Assert
            Assert.IsTrue(result.estado);
            Assert.AreEqual("Ok", result.response);
            Assert.AreEqual(true,result.estado);
        }

        [TestMethod]
        public void Delete_ShouldDeleteHotelFromDatabase()
        {
            // Instancia del objecto Moq
            var hotel = new Hotel { IdHotel = 1, Name = "Hotel A", Address = "Mz casa 16", PhoneNumber = "3014741112" };
            _context.Hotels.Add(hotel);
            _context.SaveChanges();

            // Act
            var result = _hotelLogicServices.Delete(hotel);

            // Instancia al servicio
            Assert.IsTrue(result.estado);
            Assert.AreEqual("Ok", result.response);
        }

    }
}
