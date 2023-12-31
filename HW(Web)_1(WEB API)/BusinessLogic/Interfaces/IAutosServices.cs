﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataProject.Data.Entitys;
using System.Threading.Tasks;
using BusinessLogic.ApiModels.Autos;
using BusinessLogic.Dtos;

namespace BusinessLogic.Interfaces
{
    public interface IAutosServices
    {
        Task<int> Create(CreateAutoModel auto);
        Task<int> Edit(EditAutoModel auto);
        Task<int> Delete(int id);
        List<AutoDtos> Get();
        Task<List<AutoDtos>> GetAsync();
        AutoDtos? Get(int id);
        Task<AutoDtos>? GetAsync(int id);
        
    }
}
