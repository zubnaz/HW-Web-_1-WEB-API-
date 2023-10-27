using AutoMapper;
using BusinessLogic.ApiModels.Autos;
using BusinessLogic.Dtos;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using DataProject.Data;
using DataProject.Data.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AutoServices : IAutosServices
    {
        public AutoServices(AutoDbContext adc, IMapper im)
        {
            Adc = adc;
            Im = im;
        }

        public AutoDbContext Adc { get; }
        private readonly IMapper Im;


        
        
        public async Task<int> Create(CreateAutoModel auto)
        {
            Adc.Autos.Add(Im.Map<Auto>(auto));
            return await Adc.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var auto = Adc.Autos.Find(id);
            if (auto == null) return 0;
            Adc.Autos.Remove(auto);
            return await Adc.SaveChangesAsync();
        }

        public async Task<int> Edit(EditAutoModel auto)
        {
            Adc.Autos.Update(Im.Map<Auto>(auto));
            return await Adc.SaveChangesAsync();
        }

        public Task<List<AutoDtos>> GetAsync()
        {
            return Task.Run(() =>
            {
                var list = Adc.Autos.Include(a => a.Color).ToList();
                return Im.Map<List<AutoDtos>>(list);
            });
        }

        public AutoDtos? Get(int id)
        {
            return Im.Map<AutoDtos>(Adc.Autos.Find(id));
        }

        public List<AutoDtos> Get()
        {
            var list = Adc.Autos.Include(a => a.Color).ToList();
            return Im.Map<List<AutoDtos>>(list);
        }

        public Task<AutoDtos>? GetAsync(int id)
        {
            return Task.Run(() =>
            {
                return Im.Map<AutoDtos>(Adc.Autos.Find(id));
            });
        }
    }
}
