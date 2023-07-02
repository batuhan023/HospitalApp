using AutoMapper;
using HospitalApp.Server.Context;
using HospitalApp.Shared;
using HospitalApp.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Server.Services.ForDoctor
{
    public class DoctorService : IDoctorService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DoctorService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<DoctoDTO>> AddDoctor(DoctoDTO doctor)
        {
            var result = _mapper.Map<DoctoDTO, Doctor>(doctor);
            var addObj = _context.Doctors.Add(result);
            var reverseMap = _mapper.Map<Doctor, DoctoDTO>(addObj.Entity);
            await _context.SaveChangesAsync();
            return new ServiceResponse<DoctoDTO>
            {
                Data = reverseMap,
                Success = true,
                Message = "Added Process Is Successfully"

            };
        }

        public async Task<ServiceResponse<List<Doctor>>> GetAll()
        {
            var result = await _context.Doctors.ToListAsync();
            if(result.Count == 0)
            {
                return new ServiceResponse<List<Doctor>>()
                {
                    Message = "Doctor is not found",
                    Success = false,

                };
            }
            return new ServiceResponse<List<Doctor>>()
            {
                Data = result,
                Success = true,
            };
        }

        public async Task<ServiceResponse<List<Doctor>>> GetByDoctor(int PoliclinicId)
        {
            var result = await _context.Doctors.Where(x=>x.PoliclinicId==PoliclinicId).ToListAsync();
            if(result == null)
            {
                return new ServiceResponse<List<Doctor>>
                {
                    Message = "Doctor is not found",
                    Success = false,
                };
            }
            return new ServiceResponse<List<Doctor>>()
            {
                Data = result,
                Success = true,
            };
        }
    }
}
