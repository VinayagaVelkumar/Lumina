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
        private readonly ISLMSService _slmsService;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public SLMSController(ISLMSService slmsService, CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._slmsService = slmsService;
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
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

        [HttpPost(Name = "InsertSale")]
        public bool InsertSale(SaleDetail sale)
        {
            try
            {
                bool isCreated = this._slmsService.Insert(sale);
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
