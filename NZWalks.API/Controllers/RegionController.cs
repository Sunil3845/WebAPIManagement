using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NZWalks.API.Data;
using NZWalks.API.Models;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly IMemoryCache memoryCache;

        public RegionController(NZWalksDbContext nZWalksDbContext,IRegionRepository regionRepository,IMapper mapper,IMemoryCache memoryCache)
        {
            this.nZWalksDbContext = nZWalksDbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cachekey = "EmployeeList";
            if (!memoryCache.TryGetValue(cachekey, out List<Region> regionsDTO))
            {
                 regionsDTO = await regionRepository.GetAllAsync();

                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                memoryCache.Set(cachekey, regionsDTO, cacheExpiryOptions);

                //var regionsDto = mapper.Map<List<RegionsDto>>(regionsDTO);
            }
            return Ok(regionsDTO);
        }   

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var regions = await nZWalksDbContext.regions.FirstOrDefaultAsync(a => a.Id == id);
            if (regions == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionsDto>(regions));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto )
        {
            var regionDomainMOdel = mapper.Map<Region>(addRegionRequestDto);

            regionDomainMOdel= await regionRepository.CreateAsync(regionDomainMOdel);
           

            var regionDto = mapper.Map<RegionsDto>(regionDomainMOdel);

            return CreatedAtAction(nameof(GetByID), new { id = regionDto.Id },regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRquestDto updateRegionRquestDto)
        {
            var regionDomainModel = mapper.Map<Region>(updateRegionRquestDto);
            regionDomainModel= await regionRepository.UpdateAsync(id, regionDomainModel);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            regionDomainModel.Code= updateRegionRquestDto.Code;
            regionDomainModel.Name= updateRegionRquestDto.Name;
            regionDomainModel.RegionImageURL=updateRegionRquestDto.RegionImageURL;

           await nZWalksDbContext.SaveChangesAsync();

            var regionDto = mapper.Map<RegionsDto>(regionDomainModel);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel=await regionRepository.DeleteAsync(id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

           
            var regionDto =mapper.Map<RegionsDto>(regionDomainModel);

            return Ok(regionDto);
        }
    }
}
