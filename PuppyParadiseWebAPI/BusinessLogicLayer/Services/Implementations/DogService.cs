using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Constants.ExceptionsConstants;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Constants;
using DomainLayer.DTOs.DogDTOs;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusinessLogicLayer.Services.Implementations
{
    public class DogService : IDogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SetDogSize(Dog dog)
        {
            var dogSize = await _unitOfWork.DogSizes.GetDogSizeByWeight(dog.Weight);
            if (dogSize == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenWeightNotFound);

            dog.DogSize = dogSize; 
            dog.DogSizeId = dogSize.Id; 
        }


        public async Task AddDog(DogWithoutIdDTO dogDTO)
        {
            var owner = await _unitOfWork.Users.GetById(dogDTO.OwnerId);
            if (owner == null)
                throw new Exception(UserExceptionsConstants.UserWithGivenIdNotFound);

            var dog = new Dog
            {
                Name = dogDTO.Name,
                Breed = dogDTO.Breed,
                Weight = dogDTO.Weight,
                OwnerId = dogDTO.OwnerId,
            };
            await SetDogSize(dog);
            await _unitOfWork.Dogs.Add(dog);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<DogDTO> GetDogById(int id)
        {
            var dog = await _unitOfWork.Dogs.GetDogById(id);
            if(dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            var dogDTO = new DogDTO
            {
                Id = dog.Id,
                Name = dog.Name,
                Breed = dog.Breed,
                Weight = dog.Weight,
                DogSize = dog.DogSize.Name,
                OwnerName = dog.Owner.Name,
                OwnerSurname = dog.Owner.Surname
            };

            return dogDTO;
        }

        public async Task<List<DogDTO>> GetDogsByOwnerId(int ownerId)
        {
            var dogs = await _unitOfWork.Dogs.GetDogsByOwnerId(ownerId);

            return dogs.Select(dog => new DogDTO
            {
                Id = dog.Id,
                Name = dog.Name,
                Breed = dog.Breed,
                Weight = dog.Weight,
                DogSize = dog.DogSize.Name,
                OwnerName = dog.Owner.Name,
                OwnerSurname = dog.Owner.Surname,

            }).ToList();   
        }

    }
}
