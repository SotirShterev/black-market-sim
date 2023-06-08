using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryBlackMarket
{
    public class ArtifactService : IArtifactService
    {
        private ArtifactManagementService artifactService = new ArtifactManagementService();
        public List<ArtifactDTO> GetArtifacts()
        {
            return artifactService.Get();
        }
        public IEnumerable<ArtifactDTO> GetArtifactsByPrice(double price)
        {
            return artifactService.GetArtifactsByPrice(price);
        }
        public ArtifactDTO GetArtifactById(int id)
        {
            return artifactService.GetById(id);
        }
        public string PostArtifact(ArtifactDTO artifactDTO)
        {
            if (!artifactService.Save(artifactDTO))
            {
                return "Artifact is not saved!";
            }
            else
            {
                return "Artifact is saved!";
            }
        }
        public string PutArtifact(ArtifactDTO artifactDTO)
        {
            if (!artifactService.Edit(artifactDTO))
            {
                return "Artifact is not edited!";
            }
            else
            {
                return "Artifact is edited!";
            }
        }
        public string DeleteArtifact(int id)
        {
            if (!artifactService.Delete(id))
            {
                return "Artifact is not deleted!";
            }
            else
            {
                return "Artifact is deleted!";
            }
        }
    }
}
