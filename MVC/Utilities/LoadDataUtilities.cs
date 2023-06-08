using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Utilities
{
    public class LoadDataUtilities
    {
        public static SelectList LoadDealersData()
        {
            using (DealerService.DealerServiceClient service = new DealerService.DealerServiceClient())
            {
                return new SelectList(service.GetDealers(), "Id", "Name");
            }
        }
        public static SelectList LoadArtifactsData()
        {
            using (ArtifactService.ArtifactServiceClient service = new ArtifactService.ArtifactServiceClient())
            {
                return new SelectList(service.GetArtifacts(), "Id", "Name");
            }
        }
    }
}