using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities.Interfaces
{
    public interface IBaseEntity
    {

         int Id { get; set; }

         DateTime DateTimeUtcNow { get; set; }

         bool IsRemoved { get; set; }

    }
}
