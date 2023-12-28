using LuminaAPI.Business;
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
        private readonly IPRMSService _prmsService;
        private readonly IPMSService _pmsService;
        private readonly IPADService _padService;
        private readonly IPADTransService _padTransService;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;
        private readonly ILogger<PRMSController> _logger;

        public PRMSController(IPRMSService prmsService, IPMSService pMSService, IPADService padService, CollectionNames collectionNames, ConnectionConfig connectionConfig, IPADTransService pADTransService, ILogger<PRMSController> logger)
        {
            this._prmsService = prmsService;
            this._pmsService = pMSService;
            this._padService = padService;
            this._padTransService = pADTransService;
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            _logger = logger;
        }
        [HttpGet(Name = "GetPurchases")]
        public List<PurchaseDetail> GetPurchases()
        {
            try
            {
                List<PurchaseDetail> purchases = this._prmsService.GetAll();
                return purchases;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw; ;
            }
        }

        [HttpGet(Name = "GetPurchaseByID")]
        public PurchaseDetail GetPurcahseByID(string id)
        {
            try
            {
                PurchaseDetail purchase = this._prmsService.GetByID(id);
                return purchase;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw; ;
            }
        }

        [HttpPost(Name = "AddPurchase")]
        public bool AddPurchase([FromBody] PurchaseDetailFromUI purDetail)
        {
            try
            {
                PRMSBusiness pRMSBusiness = new PRMSBusiness(this._prmsService, this._pmsService, this._padService, this._padTransService);
                bool isCreated = pRMSBusiness.AddPurchaseDetail(purDetail);
                return isCreated;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw; ;
            }
        }

        [HttpPut(Name = "UpdatePurchase")]
        public bool UpdatePurchase(PurchaseDetail purchase)
        {
            try
            {
                bool isUpdated = this._prmsService.Update(purchase);
                return isUpdated;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}"); throw; ;
            }
        }
    }
}
