using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.EntitiesRepository
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients(bool trackChanges);
    }
}
