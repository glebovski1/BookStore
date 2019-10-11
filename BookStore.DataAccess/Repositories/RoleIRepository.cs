using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    class RoleIRepository : BaseRepository<Role>, IRoleIRepository
    {

        RoleIRepository(TestAppContext dataBase) : base(dataBase)
        {
        }

       
    }
}
