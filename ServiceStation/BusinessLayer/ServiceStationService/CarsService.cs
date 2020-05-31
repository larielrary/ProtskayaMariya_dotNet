using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Services.ServiceStationService
{
    public class CarsService : IEntityService<Car>
    {
        private readonly IRepository<CarDTO> _carRepository;

        private readonly IRepository<OwnerDTO> _ownerRepository;

        private readonly IMapper _mapper;

        public CarsService(IRepository<CarDTO> carRepository, IRepository<OwnerDTO> ownerRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task Create(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            else
            {
                if (_ownerRepository.GetById(car.OwnerId) == null)
                {
                    throw new ArgumentException("Owner id is null");
                }
                else
                {
                    await _carRepository.Add(_mapper.Map<CarDTO>(car));
                }
            }
        }

        public async Task Delete(int id)
        {
            var car = GetItems().Result.Where(el => el.Id == id).ToList();
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            else
            {
                await _carRepository.Delete(_mapper.Map<CarDTO>(car[0]).Id);
            }
        }
        public async Task Update(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            else
            {
                if (_ownerRepository.GetById(car.OwnerId) == null)
                {
                    throw new ArgumentException("Check owner id");
                }

                await _carRepository.Update(_mapper.Map<CarDTO>(car));
            }
        }
        public async Task<IEnumerable<Car>> GetItems()
        {
            return _mapper.Map<IEnumerable<CarDTO>, List<Car>>(await _carRepository.GetAll());
        }
        public async Task<Car> GetItem(int id)
        {
            var car = await _carRepository.GetById(id);
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            return new Car
            {
                CarNumber = car.CarNumber,
                CarModel = car.CarModel,
                EngineCapacity = car.EngineCapacity,
                BodyNubmer = car.BodyNubmer,
                YearOfProduction = car.YearOfProduction,
                OwnerId = car.OwnerId,
                Id = car.Id
            };
        }
    }
}
