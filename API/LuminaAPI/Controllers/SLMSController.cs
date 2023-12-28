using LuminaAPI.Business;
using LuminaAPI.Model.Config;
using LuminaAPI.Model.SLMS;
using LuminaAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuminaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SLMSController : ControllerBase
    {
        private readonly IPMSService _pmsService;
        private readonly IPADService _padService;
        private readonly IPADTransService _padTransService;
        private readonly ISLMSService _slmsService;
        private readonly IPRMSService _prmsService;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public SLMSController(ISLMSService slmsService, CollectionNames collectionNames, ConnectionConfig connectionConfig, IPADService padService, IPADTransService padTransService, IPMSService pmsService,IPRMSService pRMSService)
        {
            this._slmsService = slmsService;
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            this._pmsService = pmsService;
            this._padService = padService;
            this._padTransService = padTransService;
            this._prmsService = pRMSService;
        }
        [HttpGet(Name = "GetSales")]
        public List<SaleDetail> GetSales()
        {
            try
            {
                List<SaleDetail> sales = this._slmsService.GetAll();
                return sales;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetSaleByID")]
        public SaleDetail GetSaleByID(string id)
        {
            try
            {
                SaleDetail sale = this._slmsService.GetByID(id);
                return sale;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost(Name = "AddSale")]
        public bool AddSale([FromBody] SaleData saleData)
        {
            try
            {
                SLMSBusiness slmsBusiness = new SLMSBusiness(this._pmsService,this._padService,this._padTransService,this._prmsService,this._slmsService);
                bool isCreated = slmsBusiness.AddSale(saleData.padID, saleData.soldPrice, saleData.Count);
                return isCreated;
            }
            catch
            {
                throw;
            }
        }

        [HttpPut(Name = "UpdateSale")]
        public bool UpdateSale(SaleDetail sale)
        {
            try
            {
                bool isUpdated = this._slmsService.Update(sale);
                return isUpdated;
            }
            catch
            {
                throw;
            }
        }
    }
}
