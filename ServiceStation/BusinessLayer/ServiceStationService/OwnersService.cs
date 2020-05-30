using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.ServiceStationService
{
    public class OwnersService : IEntityService<Owner>
    {
        private readonly IRepository<OwnerDTO> _ownerRepository;
        private readonly IMapper _mapper;
        public OwnersService(IRepository<OwnerDTO> ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }
        public async Task<Owner> GetItem(int id)
        {
            var owner = await _ownerRepository.GetById(id);

            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            return new Owner
            {
                Id = owner.Id,
                Firstname = owner.Firstname,
                LastName = owner.LastName,
                MiddleName = owner.MiddleName,
                PhoneNum = owner.PhoneNum
            };
        }
        public async Task<IEnumerable<Owner>> GetItems()
        {
            return _mapper.Map<IEnumerable<OwnerDTO>, List<Owner>>(await _ownerRepository.GetAll());
        }

        public async Task Create(Owner item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await _ownerRepository.Add(_mapper.Map<OwnerDTO>(item));
            }
        }

        public async Task Update(Owner item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await _ownerRepository.Update(_mapper.Map<OwnerDTO>(item));
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
                await _ownerRepository.Delete(_mapper.Map<OwnerDTO>(item[0]).Id);
            }
        }
    }
}
