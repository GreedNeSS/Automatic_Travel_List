using Automatic_Sheet_DAL;

namespace Automatic_Sheet_BL
{
    public interface ITableGenerator
    {
        string CreateDataList(int rowCount);
    }

    public interface IDateGenerator
    {
        DateTime GetTravelDate();
        List<string> CreateTravelDate(DateTime date);
        List<string> CreateTravelDateList(int rowCount, DateTime date);
        string GetDateListString(List<string> travelDateList);
    }

    public interface ITripListGenerator
    {
        void GetTicketPrice(int ticketPrice);
        TripEntity GetTrip(int vehicleCount);
        List<TripEntity> GetTripList(int rowCount, int ticketCount);
        string GetTripsString(List<TripEntity> trips);
    }
}