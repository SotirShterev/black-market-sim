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
    public interface IArtifactService
    {
        [OperationContract]
        List<ArtifactDTO> GetArtifacts();
        [OperationContract]
        IEnumerable<ArtifactDTO> GetArtifactsByPrice(double price);

        [OperationContract]
        ArtifactDTO GetArtifactById(int id);

        [OperationContract]
        string PostArtifact(ArtifactDTO artifactDTO);

        [OperationContract]
        string PutArtifact(ArtifactDTO artifactDTO);

        [OperationContract]
        string DeleteArtifact(int id);
    }
}
