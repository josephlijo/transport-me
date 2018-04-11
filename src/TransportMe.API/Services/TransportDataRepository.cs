using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TransportMe.Entities;

namespace TransportMe.API.Services
{
    public class TransportDataRepository : ITransportDataRepository
    {
        private readonly TransportMeContext context;

        public TransportDataRepository(TransportMeContext context)
        {
            this.context = context;
        }

        public IEnumerable<TransportMode> GetTransportModes()
        {
            return context.TransportModes.ToList<TransportMode>();
        }

        public IEnumerable<TransportService> GetTransportService(int cityId)
        {
            return context.TransportServices.Where(s => s.CityId == cityId)
                          .Include("TransportMode") // Eager loading
                          .ToList<TransportService>();
        }
    }
}
