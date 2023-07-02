using HospitalApp.Shared;
using HospitalApp.Shared.Model;

namespace HospitalApp.Server.Services.ForDoctor
{
    public interface IDoctorService
    {
        Task<ServiceResponse<List<Doctor>>> GetAll();
        Task<ServiceResponse<List<Doctor>>> GetByDoctor(int PoliclinicId);
        Task<ServiceResponse<DoctoDTO>> AddDoctor(DoctoDTO doctor);
    }
}
