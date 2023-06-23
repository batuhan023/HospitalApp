using HospitalApp.Shared;

namespace HospitalApp.Server.Services.ForPoliclinic
{
    public interface IPoliclinicService
    {
        Task<ServiceResponse<Policlinic>> AddPoly(Policlinic policlinic);
        Task<ServiceResponse<List<Policlinic>>> GetAll();
        Task<ServiceResponse<Policlinic>> UpdatePoly(Policlinic policlinic);
        Task<ServiceResponse<int>> DeletePoly(int poliId);
        Task<ServiceResponse<Policlinic>> GetById(int policid);
    }
}
