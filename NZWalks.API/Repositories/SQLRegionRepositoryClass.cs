using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepositoryClass : IRegionRepository
    {
        private readonly NZWalksDbContext _nZWalksDbContext;

        public SQLRegionRepositoryClass(NZWalksDbContext nZWalksDbContext)
        {
            this._nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
           await  _nZWalksDbContext.regions.AddAsync(region);
            await _nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _nZWalksDbContext.regions.ToListAsync();
        }


        public async Task<Region?> GetAllByIdAsync(Guid Id)
        {
            return await _nZWalksDbContext.regions.FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _nZWalksDbContext.regions.FirstOrDefaultAsync(x=>x.Id==id);

            if(existingRegion==null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageURL = region.RegionImageURL;

            await _nZWalksDbContext.SaveChangesAsync();
            return existingRegion;
        }

       public async Task<Region> DeleteAsync(Guid id)
        {
            var existingRegion=_nZWalksDbContext.regions.FirstOrDefault(x=>x.Id==id);

            if(existingRegion==null)
            {
                return null;
            }

            _nZWalksDbContext.regions.Remove(existingRegion);
            await _nZWalksDbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
