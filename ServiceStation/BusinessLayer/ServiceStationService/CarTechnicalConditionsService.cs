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
    public class CarTechnicalConditionsService : IEntityService<CarTechnicalCondition>
    {
        private readonly IRepository<CarTechnicalConditionDTO> _conditionRepository;
        private readonly IRepository<CarDTO> _carRepository;
        private readonly IRepository<InspectorDTO> _inspectorRepository;
        private readonly IMapper _mapper;

        public CarTechnicalConditionsService(IRepository<CarTechnicalConditionDTO> conditionRepository,
            IRepository<CarDTO> carRepository, IRepository<InspectorDTO> inspectorRepository, IMapper mapper)
        {
            _conditionRepository = conditionRepository;
            _carRepository = carRepository;
            _inspectorRepository = inspectorRepository;
            _mapper = mapper;
        }

        public async Task<CarTechnicalCondition> GetItem(int id)
        {
            return _mapper.Map<CarTechnicalCondition>(await _conditionRepository.GetById(id));
        }

        public async Task<IEnumerable<CarTechnicalCondition>> GetItems()
        {
            return _mapper.Map<IEnumerable<CarTechnicalConditionDTO>, List<CarTechnicalCondition>>(await _conditionRepository.GetAll());
        }

        public async Task Create(CarTechnicalCondition condition)
        {
            if (condition == null)
            {
                throw new InvalidOperationException(nameof(condition));
            }
            else
            {
                try
                {
                    await _inspectorRepository.GetById(condition.InspectorId);
                    await _carRepository.GetById(condition.CarId);
                }
                catch
                {
                    throw new InvalidOperationException();
                }
                await _conditionRepository.Add(_mapper.Map<CarTechnicalConditionDTO>(condition));
            }
        }

        public async Task Update(CarTechnicalCondition condition)
        {
            if (condition == null)
            {
                throw new InvalidOperationException(nameof(condition));
            }
            else
            {
                await _conditionRepository.Update(_mapper.Map<CarTechnicalConditionDTO>(condition));
            }
        }

        public async Task Delete(int id)
        {
            var condition = (await GetItems()).Single(el => el.Id == id);
            await _conditionRepository.Delete(_mapper.Map<CarTechnicalConditionDTO>(condition).Id);
        }
    }
}
