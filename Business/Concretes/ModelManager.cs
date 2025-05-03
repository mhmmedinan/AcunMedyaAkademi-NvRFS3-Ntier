﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Model;
using Business.Dtos.Responses.Model;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;

namespace Business.Concretes;

public class ModelManager : IModelService
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public ModelManager(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public CreatedModelResponse Add(CreateModelRequest request)
    {
        Model model = _mapper.Map<Model>(request);
        Model createdModel = _modelRepository.Add(model);
        CreatedModelResponse response = _mapper.Map<CreatedModelResponse>(createdModel);
        return response;
    }

    public List<GetListModelResponse> GetList()
    {
        List<Model> models = _modelRepository.GetAll(include:x=>x.Include(x=>x.Brand));
        List<GetListModelResponse> responses = _mapper.Map<List<GetListModelResponse>>(models);
        return responses;
    }
}
