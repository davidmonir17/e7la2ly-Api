using Contracts.EntitiesRepository;
using Domain.DatabaseContext;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EnititiesRepository
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Client> GetAllClients(bool trackChanges)
        {
            return FindAll(trackChanges).Include(x => x.location).OrderBy(c=>c.ClientId).ToList();
        }
    }
}
