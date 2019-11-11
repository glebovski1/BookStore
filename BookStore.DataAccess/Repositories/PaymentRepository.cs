using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(TestAppContext dataBase) : base(dataBase)
        {

        }
        public async Task<int> GetIdAfterCreate(Payment payment)
        {
            await base.Create(payment);
            _dataBase.Entry(payment).GetDatabaseValues();
            return payment.Id;
        }

    }
}
