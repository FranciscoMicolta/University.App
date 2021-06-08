using System.Collections.Generic;

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
                new TypeRequest { Name = "Petition" },
                new TypeRequest { Name = "Complain" },
                new TypeRequest { Name = "Claim" },
                new TypeRequest { Name = "Suggestion" }
            };
        }

        private void LoadPuntuation()
        {
            this.RateServices = new List<RateService>
            {
                new RateService { Point = "Bad" },
                new RateService { Point = "Regular" },
                new RateService { Point = "Well" },
                new RateService { Point = "Acceptable" },
                new RateService { Point = "Excellent" }
            };
        }
        #endregion
    }
}
