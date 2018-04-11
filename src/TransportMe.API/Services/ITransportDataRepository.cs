using System.Collections.Generic;
using TransportMe.Entities;

namespace TransportMe.API.Services
{
    public interface ITransportDataRepository
    {
        IEnumerable<TransportMode> GetTransportModes();

        IEnumerable<TransportService> GetTransportService(int cityId);
    }
}
