using System.Collections.Generic;
using University.App.Helpers;

namespace University.App.ViewModels.Forms
{
    public class PQRSViewModel : BaseViewModel
    {
        #region Attributes
        public class TypeRequest
        {
            public string Name { get; set; }
        }

        public class RateService
        {
            public string Point { get; set; }
        }

        private List<TypeRequest> _typeRequests;
        private List<RateService> _rateService;
        #endregion

        #region Properties
        public List<TypeRequest> TypeRequests
        {
            get { return this._typeRequests; }
            set { this.SetValue(ref this._typeRequests, value); }
        }
        public List<RateService> RateServices
        {
            get { return this._rateService; }
            set { this.SetValue(ref this._rateService, value); }
        }
        #endregion

        #region Constructor
        public PQRSViewModel()
        {
            this.LoadTypeRequest();
            this.LoadPuntuation();
        }
        #endregion

        #region Methods
        private void LoadTypeRequest()
        {
            this.TypeRequests = new List<TypeRequest>
            {
                new TypeRequest { Name = Languages.PQRSPetition },
                new TypeRequest { Name = Languages.PQRSComplain},
                new TypeRequest { Name = Languages.PQRSClaim },
                new TypeRequest { Name = Languages.PQRSSuggestion }
            };
        }

        private void LoadPuntuation()
        {
            this.RateServices = new List<RateService>
            {
                new RateService { Point = Languages.PQRSBad},
                new RateService { Point = Languages.PQRSRegular},
                new RateService { Point = Languages.PQRSWell },
                new RateService { Point = Languages.PQRSAcceptable },
                new RateService { Point = Languages.PQRSExcellent}
            };
        }
        #endregion
    }
}
