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
using Microsoft.AspNetCore.Authorization;

namespace EVoucherManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPurchaseController : ControllerBase
    {
        static HttpClient client = new HttpClient();
        private DataContext myDbContext;
        public ItemPurchaseController(DataContext context)
        {
            myDbContext = context;
        }
        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> CheckoutItemWithPromoCode([FromBody] ItemPurchaseModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                PurchaseEVouchersModel purchaseEVouchersModel = await myDbContext.PurchaseEVouchers.Where(x => x.promoCode == model.promocode).FirstOrDefaultAsync();
                EVouchersModel eVouchersModel = await myDbContext.EVouchers.Where(x => x.id == purchaseEVouchersModel.eVoucher_id).FirstOrDefaultAsync();
                if (eVouchersModel.expiryDate > DateTime.Now)
                {
                    #region Purchae Item
                    model.id = Guid.NewGuid().ToString();
                    await myDbContext.ItemPurchase.AddAsync(model);
                    await myDbContext.SaveChangesAsync();
                    #endregion

                    #region Update PromoCode Used Status
                    purchaseEVouchersModel.isUsed = 1;
                    purchaseEVouchersModel.updatedDateTime = DateTime.Now;
                    myDbContext.PurchaseEVouchers.Update(purchaseEVouchersModel);
                    await myDbContext.SaveChangesAsync();
                    #endregion

                    responseModel.message = "Successfully purchase Item with PromoCode!";
                    responseModel.success = true;
                    responseModel.error = false;
                    responseModel.warning = false;
                }
                else
                {
                    responseModel.message = "Expired Voucher!";
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

        

    }
}
