using Microsoft.AspNetCore.Mvc;
using EVoucherManagementSystem.Context;
using EVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVoucherManagementSystem.Communication;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace EVoucherManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseEVoucherController : ControllerBase
    {
        static HttpClient client = new HttpClient();
        private DataContext myDbContext;
        public PurchaseEVoucherController(DataContext context)
        {
            myDbContext = context;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> PurchaseEVoucher([FromBody] PurchaseEVouchersModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                EVouchersModel eVouchersModel = await myDbContext.EVouchers.Where(x => x.id == model.eVoucher_id).FirstOrDefaultAsync();
                List<PurchaseEVouchersModel> purchaseEVouchersModel = await myDbContext.PurchaseEVouchers.Where(x => x.id == model.eVoucher_id).ToListAsync<PurchaseEVouchersModel>();
                if (eVouchersModel.isActive==1)
                {
                    List<PurchaseEVouchersModel> purchaseEVouchersModels = await myDbContext.PurchaseEVouchers.Where(x => x.eVoucher_id == model.eVoucher_id).ToListAsync<PurchaseEVouchersModel>();
                    PaymentMethodsModel paymentMethodsModel = await myDbContext.PaymentMethods.Where(x => x.id == model.paymentMethod_id).FirstOrDefaultAsync();
                    model.netAmount = eVouchersModel.amount - (eVouchersModel.amount * (paymentMethodsModel.discountPercent) / 100);

                    BuyTypesModel buyTypesModel = await myDbContext.BuyTypes.Where(x => x.id == model.buyType_id).FirstOrDefaultAsync();
                    if (purchaseEVouchersModels.Count() < buyTypesModel.eVoucher_maxlimit)
                    {
                        for (int i = purchaseEVouchersModels.Count(); i <= buyTypesModel.eVoucher_maxlimit; i++)
                        {
                            #region Generate PromoCode
                            using var client = new HttpClient();
                            string content = await client.GetStringAsync("https://localhost:44348/api/promocode/generate/phoneno/" + eVouchersModel.phoneNo);
                            BaseResponsePromoCode baseResponse = JsonConvert.DeserializeObject<BaseResponsePromoCode>(content);
                            #endregion
                            model.id = Guid.NewGuid().ToString();
                            model.promoCode = baseResponse.promocode;
                            model.isUsed = 0;
                            await myDbContext.PurchaseEVouchers.AddAsync(model);
                            await myDbContext.SaveChangesAsync();

                            responseModel.message = "Successfully purchase eVoucher!";
                            responseModel.success = true;
                            responseModel.error = false;
                            responseModel.warning = false;
                        }
                    }
                    else
                    {
                        responseModel.message = "Exceed eVoucher limit!";
                        responseModel.success = false;
                        responseModel.error = false;
                        responseModel.warning = true;
                    }
                }
                else
                {
                    responseModel.message = "Invalid eVoucher(InActive eVoucher)!";
                    responseModel.success = false;
                    responseModel.error = false;
                    responseModel.warning = true;
                }
                
                  
            }
            catch (Exception ex)
            {
                responseModel.message = ex.Message.ToString();
                responseModel.success = false;
                responseModel.error = true;
                responseModel.warning = false;
            }
            return Ok(responseModel);
        }

        [HttpGet]
        [Route("history/list/usedstatus/{usedstatus}")]
        public async Task<IActionResult> PurchasePromoCodeHistoryByUsedStatus(string usedstatus)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                List<PurchaseEVouchersModel> purchaseEVouchersModels = new List<PurchaseEVouchersModel>();
                if (usedstatus.ToLower() == "all") { purchaseEVouchersModels = await this.myDbContext.PurchaseEVouchers.ToListAsync(); }
                else if (usedstatus.ToLower() == "used")
                {
                    purchaseEVouchersModels = await myDbContext.PurchaseEVouchers.Where(x => x.isUsed == 1).ToListAsync();
                }
                else { purchaseEVouchersModels = await myDbContext.PurchaseEVouchers.Where(x => x.isUsed == 0).ToListAsync(); }
               
                baseResponse.message = "Successfully retrieve purchsed History by status";
                baseResponse.data = purchaseEVouchersModels;
                baseResponse.success = true;
                baseResponse.error = false;
            }
            catch (Exception ex)
            {
                baseResponse.message = ex.ToString();
                baseResponse.data = null;
                baseResponse.success = false;
                baseResponse.error = true;
            }

            return Ok(baseResponse);
        }

        

    }
}
