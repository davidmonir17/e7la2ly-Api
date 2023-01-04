using Contracts.EntitiesRepository;
using Contracts;
using Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using DataTransferObjects;
using AutoMapper;

namespace Services.EntitiesServices
{
    public class ClientServices: IClientService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ClientServices(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper=mapper;
        }

        public IEnumerable<ClientDTO> GetAllClients(bool trackChanges)
        {
            
                var client = _repository.Client.GetAllClients(trackChanges);
                var clientsDTo = _mapper.Map<IEnumerable<ClientDTO>>(client);
                return clientsDTo;
           
        }
    }
}
