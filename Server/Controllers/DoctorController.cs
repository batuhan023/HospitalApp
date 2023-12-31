﻿using HospitalApp.Server.Services.ForDoctor;
using HospitalApp.Shared;
using HospitalApp.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<ServiceResponse<List<Doctor>>>> GetAll()
        {
            var result = await _doctorService.GetAll();
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<Doctor>>> GetByDoctor([FromRoute]int id)
        {
            var result = await _doctorService.GetByDoctor(id);
            return Ok(result);
        }

        [HttpPost("addDoctor"),Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<DoctoDTO>>> CreateDoctor(DoctoDTO doctor)
        {
            var result = await _doctorService.AddDoctor(doctor);
            return Ok(result);
        }
    }
}
