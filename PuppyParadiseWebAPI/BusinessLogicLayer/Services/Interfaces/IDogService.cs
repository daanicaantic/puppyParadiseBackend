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
        
        Task AddDog(AddDogDTO dogDto);

        Task<GetDogDTO> GetDogById(int id);

        Task<List<GetDogDTO>> GetDogsByOwnerId(int ownerId);

        Task UpdateDog(UpdateDogDTO dog);

        Task DeleteDog(int id);
    }
}
