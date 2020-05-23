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
    public class CarTechnicalConditionService : IEntityService<CarTechnicalCondition>
    {
        private readonly IRepository<CarTechnicalConditionDTO> _conditionRepository;
        private readonly IRepository<CarDTO> _carRepository;
        private readonly IRepository<InspectorDTO> _inspectorRepository;
        private readonly IMapper _mapper;


        public CarTechnicalConditionService(IRepository<CarTechnicalConditionDTO> conditionRepository,
            IRepository<CarDTO> carRepository, IRepository<InspectorDTO> inspectorRepository, IMapper mapper)
        {
            _conditionRepository = conditionRepository;
            _carRepository = carRepository;
            _inspectorRepository = inspectorRepository;
            _mapper = mapper;
        }

        public async Task<CarTechnicalCondition> GetItem(int id)
        {
            var condition = await _conditionRepository.GetById(id);

            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            return new CarTechnicalCondition
            {
                Id = condition.Id,
                Date = condition.Date,
                Milleage = condition.Milleage,
                BreakSystem = condition.BreakSystem,
                Suspension = condition.Suspension,
                Wheels = condition.Wheels,
                Lighting = condition.Lighting,
                CarbonDioxideContent = condition.CarbonDioxideContent,
                InspectorId = condition.InspectorId,
                CarId = condition.CarId,
                InspectionMark = condition.InspectionMark
            };
        }
        public async Task<IEnumerable<CarTechnicalCondition>> GetItems()
        {
            return _mapper.Map<IEnumerable<CarTechnicalConditionDTO>, List<CarTechnicalCondition>>(await _conditionRepository.GetAll());
        }

        public async Task Create(CarTechnicalCondition condition)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
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
                    throw new ArgumentNullException();
                }
                await _conditionRepository.Add(_mapper.Map<CarTechnicalConditionDTO>(condition));
            }
        }

        public async Task Update(CarTechnicalCondition condition)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }
            else
            {
                await _conditionRepository.Update(_mapper.Map<CarTechnicalConditionDTO>(condition));
            }
        }

        public async Task Delete(int id)
        {
            var condition = GetItems().Result.Where(el => el.Id == id).ToList();
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }
            else
            {
                await _conditionRepository.Delete(_mapper.Map<CarTechnicalConditionDTO>(condition[0]).Id);
            }
        }
    }
}
