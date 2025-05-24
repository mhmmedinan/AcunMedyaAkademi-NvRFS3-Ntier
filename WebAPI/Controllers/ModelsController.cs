﻿using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Requests.Model;
using Business.Dtos.Responses.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }


        [HttpPost]
        public ActionResult<CreatedModelResponse> Add([FromBody] CreateModelRequest request)
        {
            return Created("", _modelService.Add(request));
        }

        [HttpGet]
        [Authorize(Roles =OperationClaims.Admin)]
        public ActionResult<List<GetListModelResponse>> GetAll()
        {
            return Ok(_modelService.GetList());
        }
    }
}
