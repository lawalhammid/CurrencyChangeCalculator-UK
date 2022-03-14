using BusinessLogic.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Contracts
{
    public interface IChangeXchangeNomService
    {
        Task<List<ReturnedChange>> ReturnXChangeForCoin(decimal AmountPaid);
    }
}
