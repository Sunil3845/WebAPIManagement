﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository) {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var walksDomainModel=await walkRepository.GetById(Id);
            if(walksDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto> (walksDomainModel));
        }

        [HttpPost]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdateWalkRequestDto updateWalkRequestDto)
        {
           var walkDomainModel= mapper.Map<Walk> (updateWalkRequestDto);
            return Ok();
        }
    }
}
