using DomainLayer.DTOs.DogDTOs;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IDogService
    {
        Task SetDogSize(Dog dog);
        
        Task AddDog(DogWithoutIdDTO dogDto);

        Task<DogDTO> GetDogById(int id);

        Task<List<DogDTO>> GetDogsByOwnerId(int ownerId);
    }
}
