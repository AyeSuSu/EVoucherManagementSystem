using Microsoft.AspNetCore.Mvc;
using EVoucherManagementSystem.Context;
using EVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVoucherManagementSystem.Communication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EVoucherManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private DataContext myDbContext;
        public PaymentMethodController(DataContext context)
        {
            myDbContext = context;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePaymentMethod([FromBody] PaymentMethodsModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            var paymentMethodCount = myDbContext.PaymentMethods.Where(x => x.name.Equals(model.name)).FirstOrDefault();

            if (paymentMethodCount != null)
            {
                responseModel.message = "Duplicate Payment Method!";
                responseModel.success = false;
                responseModel.error = false;
                responseModel.warning = true;
            }
            else
            {
                if (model.discountPercent > 100)
                {
                    responseModel.message = "Invalid Discount Amount!";
                    responseModel.success = false;
                    responseModel.error = false;
                    responseModel.warning = true;
                }
                else
                {
                    try
                    {
                        model.id = Guid.NewGuid().ToString();
                        model.createdDateTime = DateTime.Now;
                        model.updatedDateTime = DateTime.Now;
                        await myDbContext.AddAsync(model);
                        myDbContext.SaveChanges();
                        responseModel.message = "Successfully create Payment Method!";
                        responseModel.success = true;
                        responseModel.error = false;
                        responseModel.warning = false;
                    }
                    catch (Exception ex)
                    {
                        responseModel.message = ex.Message.ToString();
                        responseModel.success = false;
                        responseModel.error = true;
                        responseModel.warning = false;
                    }
                }
            }

           
            
            
           
            return Ok(responseModel);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllPaymentMethods()
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                List<PaymentMethodsModel> paymentMethods =await  this.myDbContext.PaymentMethods.ToListAsync();
                baseResponse.message = "Successfully retrieve Payment Methods";
                baseResponse.data = paymentMethods;
                baseResponse.success = true;
                baseResponse.error = false;
            }
            catch(Exception ex)
            {
                baseResponse.message = ex.ToString();
                baseResponse.data = null;
                baseResponse.success = false;
                baseResponse.error = true;
            }
           
            return Ok(baseResponse);
        }

        [HttpGet]
        [Route("detail/paymentmethodid/{paymentmethodid}")]
        public async Task<IActionResult> GetPaymentMethodById(string paymentmethodid)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                PaymentMethodsModel paymentMethodsModel = await myDbContext.PaymentMethods.Where(x => x.id == paymentmethodid).FirstOrDefaultAsync();
                baseResponse.message = "Successfully retrieve Payment Method";
                baseResponse.data = paymentMethodsModel;
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


        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePaymentMethod([FromBody] PaymentMethodsModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            if (string.IsNullOrEmpty(model.id))
            {
                responseModel.message = "Invalid Pyement Method Id!";
                responseModel.success = false;
                responseModel.error = false;
                responseModel.warning = true;
            }
            else
            {
                try
                {

                    myDbContext.Update(model);
                    await myDbContext.SaveChangesAsync();
                    responseModel.message = "Successfully update Payment Method!";
                    responseModel.success = true;
                    responseModel.error = false;
                    responseModel.warning = false;
                }
                catch (Exception ex)
                {
                    responseModel.message = ex.Message.ToString();
                    responseModel.success = false;
                    responseModel.error = true;
                    responseModel.warning = false;
                }
            }
           

            return Ok(responseModel);
        }

    }
}
