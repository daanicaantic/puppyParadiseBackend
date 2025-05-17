﻿using System;
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
using AutoMapper;

namespace BusinessLogicLayer.Services.Implementations
{
    public class DogService : IDogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SetDogSize(Dog dog)
        {
            var dogSize = await _unitOfWork.DogSizes.GetDogSizeByWeight(dog.Weight);
            if (dogSize == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenWeightNotFound);

            dog.DogSize = dogSize; 
            dog.DogSizeId = dogSize.Id; 
        }


        public async Task AddDog(AddDogDTO dogDTO, int userId)
        { 
            if (dogDTO.Weight < 0)
            {
                throw new Exception(DogExceptionsConstants.NegativeDogWeight);
            }

            var dog = _mapper.Map<Dog>(dogDTO);
            dog.OwnerId = userId;
            await SetDogSize(dog);
            await _unitOfWork.Dogs.Add(dog);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetDogDTO> GetDogById(int id)
        {
            var dog = await _unitOfWork.Dogs.GetDogById(id);
            if(dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            return _mapper.Map<GetDogDTO>(dog);
        }

        public async Task<List<GetDogDTO>> GetDogsByOwnerId(int ownerId)
        {
            var dogs = await _unitOfWork.Dogs.GetDogsByOwnerId(ownerId);

            return _mapper.Map<List<GetDogDTO>>(dogs);
        }

        public async Task UpdateDog(UpdateDogDTO dogUpdateDTO)
        {
            var dog = await _unitOfWork.Dogs.GetDogById(dogUpdateDTO.Id);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            _mapper.Map(dogUpdateDTO, dog);

            await SetDogSize(dog); 

            _unitOfWork.Dogs.Update(dog); 
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDog(int id)
        {
            var dog = await _unitOfWork.Dogs.GetDogById(id);
            if (dog == null)
                throw new Exception(DogExceptionsConstants.DogWithGivenIdNotFound);

            _unitOfWork.Dogs.Delete(dog);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
