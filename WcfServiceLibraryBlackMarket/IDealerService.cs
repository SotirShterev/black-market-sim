using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryBlackMarket
{
    [ServiceContract]
    public interface IDealerService
    {
        [OperationContract]
        List<DealerDTO> GetDealers();
        [OperationContract]
        IEnumerable<DealerDTO> GetDealersByAge(int age);

        [OperationContract]
        DealerDTO GetDealerById(int id);

        [OperationContract]
        string PostDealer(DealerDTO dealerDTO);

        [OperationContract]
        string PutDealer(DealerDTO dealerDTO);

        [OperationContract]
        string DeleteDealer(int id);
    }
}
