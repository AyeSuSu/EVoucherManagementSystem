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
using Aspose.BarCode;
using Aspose.BarCode.Generation;
using Microsoft.AspNetCore.Authorization;
using StackExchange.Redis;

namespace EVoucherManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EVoucherController : ControllerBase
    {
        private DataContext myDbContext;
        public EVoucherController(DataContext context)
        {
            myDbContext = context;
        }
        [HttpPost]
       
        [Route("create")]
        public async Task<IActionResult> CreateEVoucher([FromForm] EVouchersModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                List<EVouchersModel> eVouchersModels = await myDbContext.EVouchers.Where(x =>x.phoneNo==model.phoneNo && x.isActive == 1).ToListAsync<EVouchersModel>();
                if (eVouchersModels.Count > 0)
                {
                    responseModel.message = "Duplicate Phone No";
                    responseModel.success = false;
                    responseModel.error = false;
                    responseModel.warning = true;
                }
                else
                {
                    model.id = Guid.NewGuid().ToString();
                    #region Voucher Image
                    var fileName = ContentDispositionHeaderValue.Parse(model.imageFile.ContentDisposition).FileName.Trim('"');
                    var folderPath = Path.Combine("EVoucherImages", fileName);
                    using (var stream = new FileStream(folderPath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        await model.imageFile.CopyToAsync(stream);
                    }
                    model.image = fileName;
                    #endregion

                    #region QrCode generate

                    BarcodeGenerator QRCodeGenerator = new BarcodeGenerator(EncodeTypes.QR);
                    QRCodeGenerator.CodeText = model.phoneNo;
                    string qrName = model.phoneNo + "_QRCode" + ".png";
                    QRCodeGenerator.Save(qrName, BarCodeImageFormat.Png);
                    #endregion
                    model.qrCode = qrName;
                    await myDbContext.EVouchers.AddAsync(model);
                    await myDbContext.SaveChangesAsync();
                    responseModel.message = "Successfully create eVoucher!";
                    responseModel.success = true;
                    responseModel.error = false;
                    responseModel.warning = false;
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
        [Route("list")]
        public async Task<IActionResult> GetAllEVouchers()
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                List<EVouchersModel> eVouchersModels = await this.myDbContext.EVouchers.ToListAsync();
                baseResponse.message = "Successfully retrieve eVouchers";
                baseResponse.data = eVouchersModels;
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

        [HttpGet]
        [Route("list/isactive/{isactive}")]
        public async Task<IActionResult> GetAllEVouchersByAciveStatus(int isactive)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                List<EVouchersModel> eVouchersModels = await myDbContext.EVouchers.Where(x => x.isActive == isactive).ToListAsync<EVouchersModel>();
                baseResponse.message = "Successfully retrieve eVouchers by active status";
                baseResponse.data = eVouchersModels;
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
        [Route("detail/evoucherid/{evoucherid}")]
        public async Task<IActionResult> GetEVoucherById(string evoucherid)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                EVouchersModel eVouchersModel = await myDbContext.EVouchers.Where(x => x.id == evoucherid && x.isActive==1).FirstOrDefaultAsync();
                baseResponse.message = "Successfully retrieve eVoucher";
                baseResponse.data = eVouchersModel;
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

        [HttpGet]
        [Route("detail/phoneno/{phoneno}")]
        public async Task<IActionResult> GetEVoucherByPhoneNo(string phoneno)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                EVouchersModel eVouchersModel = await myDbContext.EVouchers.Where(x => x.phoneNo == phoneno && x.isActive==1).FirstOrDefaultAsync();
                baseResponse.message = "Successfully retrieve eVoucher";
                baseResponse.data = eVouchersModel;
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
        public async Task<IActionResult> UpdateEVoucher([FromBody] EVouchersModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            if (string.IsNullOrEmpty(model.phoneNo))
            {
                responseModel.message = "Invalid Phone No!";
                responseModel.success = false;
                responseModel.error = false;
                responseModel.warning = true;
            }
            else
            {
                try
                {
                  
                    EVouchersModel eVouchersModel = await myDbContext.EVouchers.Where(x => x.phoneNo == model.phoneNo).FirstOrDefaultAsync();
                    if (eVouchersModel == null)
                    {
                        responseModel.message = "Invalid EVoucher for this Phoen No!";
                        responseModel.success = false;
                        responseModel.error = false;
                        responseModel.warning = true;
                    }
                    else
                    {
                        eVouchersModel.title = model.title;
                        eVouchersModel.description = model.description;
                        eVouchersModel.amount = model.amount;
                        eVouchersModel.expiryDate = model.expiryDate;
                        eVouchersModel.isActive = model.isActive;
                        myDbContext.Update(eVouchersModel);
                        await myDbContext.SaveChangesAsync();
                        responseModel.message = "Successfully update eVoucher!";
                        responseModel.success = true;
                        responseModel.error = false;
                        responseModel.warning = false;
                    }
                   
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

        [HttpPut]
        [Route("update/active/status")]
        public async Task<IActionResult> UpdateEVoucherActiveStatus([FromBody] EVouchersModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            if (string.IsNullOrEmpty(model.phoneNo))
            {
                responseModel.message = "Invalid Phone No!";
                responseModel.success = false;
                responseModel.error = false;
                responseModel.warning = true;
            }
            else
            {
                try
                {

                    EVouchersModel eVouchersModel = await myDbContext.EVouchers.Where(x => x.phoneNo == model.phoneNo).FirstOrDefaultAsync();
                    if (eVouchersModel == null)
                    {
                        responseModel.message = "Invalid EVoucher for this Phoen No!";
                        responseModel.success = false;
                        responseModel.error = false;
                        responseModel.warning = true;
                    }
                    else
                    {
                        eVouchersModel.isActive = model.isActive;
                        myDbContext.Update(eVouchersModel);
                        await myDbContext.SaveChangesAsync();
                        responseModel.message = "Successfully update eVoucher Acive Status!";
                        responseModel.success = true;
                        responseModel.error = false;
                        responseModel.warning = false;
                    }
                    
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
