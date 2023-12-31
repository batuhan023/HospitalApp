﻿using HospitalApp.Server.Services.ForPoliclinic;
using HospitalApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliclinicController : ControllerBase
    {
        private readonly IPoliclinicService _policlinicService;
        public PoliclinicController(IPoliclinicService policlinicService)
        {
            _policlinicService = policlinicService;
        }


        [HttpPost("add"),Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Policlinic>>> CreatePoliclinic(Policlinic policlinic)
        {
            var result = await _policlinicService.AddPoly(policlinic);
            return Ok(result);
        }

        [HttpGet("gelall")]
        public async Task<ActionResult<ServiceResponse<List<Policlinic>>>> GetPoliclinics()
        {
            var result = await _policlinicService.GetAll();
            return Ok(result);
        }

        [HttpPut("update"),Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Policlinic>>> UpdatePoliclinic(Policlinic poli)
        {
            var result = await _policlinicService.UpdatePoly(poli);
            return Ok(result);
        }

        [HttpDelete("delete"),Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<int>>> DeletePoliclinic(int poliId)
        {
            var result = await _policlinicService.DeletePoly(poliId);
            return Ok(result);
        }

        [HttpGet("{id}"),Authorize]
        public async Task<ActionResult<ServiceResponse<Policlinic>>> GetById([FromRoute] int id)
        {
            var result = await _policlinicService.GetById(id);
            return Ok(result);
        }
    }
}
