using LuminaAPI.Model.Config;
using LuminaAPI.Model.PMS;
using LuminaAPI.Model.PRMS;
using LuminaAPI.Service;
using LuminaAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuminaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PRMSController : ControllerBase
    {
        private readonly IPRMSService _pmrsService;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public PRMSController(IPRMSService prmsService, CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._pmrsService = prmsService;
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
        }
        [HttpGet(Name = "GetPurchases")]
        public List<PurchaseDetail> GetPurchases()
        {
            try
            {
                List<PurchaseDetail> purchases = this._pmrsService.GetAll();
                return purchases;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet(Name = "GetPurchaseByID")]
        public PurchaseDetail GetPurcahseByID(string id)
        {
            try
            {
                PurchaseDetail purchase = this._pmrsService.GetByID(id);
                return purchase;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost(Name = "AddPurchase")]
        public bool AddPurchase(PurchaseDetail purchase)
        {
            try
            {
                bool isCreated = this._pmrsService.Insert(purchase);
                return isCreated;
            }
            catch
            {
                throw;
            }
        }

        [HttpPut(Name = "UpdatePurchase")]
        public bool UpdatePurchase(PurchaseDetail purchase)
        {
            try
            {
                bool isUpdated = this._pmrsService.Update(purchase);
                return isUpdated;
            }
            catch
            {
                throw;
            }
        }
    }
}
