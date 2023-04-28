using ChallengeTheFlock1._0.Data;
using ChallengeTheFlock1._0.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeTheFlock1._0.Controllers
{
    public class HotelLogicServices
    {
        private readonly HotelDbContext _context;

        // Inyectamos el DbContext a nuestra clase
        public HotelLogicServices(HotelDbContext context)
        {
            _context = context;
        }

        // Obtenemos el listado de hoteles
        public List<Hotel> GetListaHoles()
        {
            return _context.Hotels.ToList();
        }

        // Obtenemos el listado de habitaciones ordenándolas por nombre del hotel al que pertenecen
        public List<Room> GetListaHabitacionesHoles()
        {
            return _context.Rooms.Include(x => x.Hotel).OrderBy(x => x.Hotel.Name).ToList();
        }

        // Agregamos un hotel
        public Response AddHotel(Hotel data)
        {
            // Instanciamos una clase para respuestas genéricas en nuestro proyecto, esto para todos los servicios
            Response response = new Response();
            try
            {
                _context.Add(data);
                _context.SaveChangesAsync();
                response.estado = true;
                response.response = "Ok";
                return response;
            }
            catch (Exception ex)
            {
                response.response = ex.Message;
                response.estado = false;
                return response;
            }
        }

        // Editamos un hotel
        public Response EdithHotel(Hotel data)
        {
            // Instanciamos una clase para respuestas genéricas en nuestro proyecto, esto para todos los servicios
            Response response = new Response();
            try
            {
                _context.Update(data);
                _context.SaveChangesAsync();
                response.estado = true;
                response.response = "Ok";
                return response;
            }
            catch (Exception ex)
            {
                response.response = ex.Message;
                response.estado = false;
                return response;
            }
        }

        // Editamos una habitación
        public Response EdithRoom(Room data)
        {
            // Instanciamos una clase para respuestas genéricas en nuestro proyecto, esto para todos los servicios
            Response response = new Response();
            try
            {
                _context.Update(data);
                _context.SaveChangesAsync();
                response.estado = true;
                response.response = "Ok";
                return response;
            }
            catch (Exception ex)
            {
                response.response = ex.Message;
                response.estado = false;
                return response;
            }
        }

        // Agregamos una habitación
        public Response AddRoom(Room data)
        {
            // Instanciamos una clase para respuestas genéricas en nuestro proyecto, esto para todos los servicios
            Response response = new Response();
            try
            {
                _context.Add(data);
                _context.SaveChangesAsync();
                response.estado = true;
                response.response = "Ok";
                return response;
            }
            catch (Exception ex)
            {
                response.response = ex.Message;
                response.estado = false;
                return response;
            }
        }

        // Eliminamos un hotel
        public Response Delete(Hotel dataHotel)
        {
            // Instanciamos una clase para respuestas genéricas en nuestro proyecto, esto para todos los servicios
            Response response = new Response();
            try
            {
                if (dataHotel != null)
                {
                    _context.Hotels.Remove(dataHotel);
                    _context.SaveChanges();
                    response.estado = true;
                    response.response = "Ok";
                }
                else
                {
                    response.estado = false;
                    return response;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.response = ex.Message;
                response.estado = false;
                return response;
            }

        }
        public Response DeleteRoom(Room dataRoom)
        {
            // Instanciamos una clase para respuestas genéricas en nuestro proyecto, esto para todos los servicios
            Response response = new Response();
            try
            {
                if (dataRoom != null)
                {
                    _context.Rooms.Remove(dataRoom);
                    _context.SaveChanges();
                    response.estado = true;
                    response.response = "Ok";
                }
                else
                {
                    response.estado = false;
                    return response;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.response = ex.Message;
                response.estado = false;
                return response;
            }
        }
    }
}
