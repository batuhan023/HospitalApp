using HospitalApp.Shared;

namespace HospitalApp.Server.Services.ForMeet
{
    public interface IMeetService
    {
        Task<ServiceResponse<Meet>> CreateMeet(Meet meet);
        Task<ServiceResponse<Meet>> CancelMeet(int id);
        Task<ServiceResponse<List<Meet>>> GetMeetById();
    }
}
