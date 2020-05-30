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
    public class InspectorsService : IEntityService<Inspector>
    {
        private readonly IRepository<InspectorDTO> _inspectorRepository;
        private readonly IMapper _mapper;
        public InspectorsService(IRepository<InspectorDTO> inspectorRepository, IMapper mapper)
        {
            _inspectorRepository = inspectorRepository;
            _mapper = mapper;
        }
        public async Task<Inspector> GetItem(int id)
        {
            var inspector = await _inspectorRepository.GetById(id);

            if (inspector == null)
            {
                throw new ArgumentNullException(nameof(inspector));
            }

            return new Inspector
            {
                Id = inspector.Id,
                Firstname = inspector.Firstname,
                LastName = inspector.LastName,
                MiddleName = inspector.MiddleName,
                Position = inspector.Position,
                Salary = inspector.Salary
            };
        }
        public async Task<IEnumerable<Inspector>> GetItems()
        {
            return _mapper.Map<IEnumerable<InspectorDTO>, List<Inspector>>(await _inspectorRepository.GetAll());
        }

        public async Task Create(Inspector item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await _inspectorRepository.Add(_mapper.Map<InspectorDTO>(item));
            }
        }

        public async Task Update(Inspector item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await _inspectorRepository.Update(_mapper.Map<InspectorDTO>(item));
            }
        }

        public async Task Delete(int id)
        {
            var item = GetItems().Result.Where(el => el.Id == id).ToList();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await _inspectorRepository.Delete(_mapper.Map<InspectorDTO>(item[0]).Id);
            }
        }
    }
}
