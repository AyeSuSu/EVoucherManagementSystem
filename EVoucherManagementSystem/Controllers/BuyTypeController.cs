using Microsoft.AspNetCore.Mvc;
using EVoucherManagementSystem.Context;
using EVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVoucherManagementSystem.Communication;
using Microsoft.EntityFrameworkCore;

namespace EVoucherManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyTypeController : ControllerBase
    {
        private DataContext myDbContext;
        public BuyTypeController(DataContext context)
        {
            myDbContext = context;
        }

        

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBuyType([FromBody] BuyTypesModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                model.id = Guid.NewGuid().ToString();
                await myDbContext.AddAsync(model);
                myDbContext.SaveChanges();
                responseModel.message = "Successfully create Buy Type!";
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
           
            return Ok(responseModel);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllBuyTypes()
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                List<BuyTypesModel> buyTypesModels =await  this.myDbContext.BuyTypes.ToListAsync();
                baseResponse.message = "Successfully retrieve Buy Types";
                baseResponse.data = buyTypesModels;
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
        [Route("detail/buytypeid/{buytypeid}")]
        public async Task<IActionResult> GetBuyTypeById(string buytypeid)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                BuyTypesModel buyTypesModel =await myDbContext.BuyTypes.Where(x => x.id==buytypeid).FirstOrDefaultAsync();
                baseResponse.message = "Successfully retrieve Buy Type";
                baseResponse.data = buyTypesModel;
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
        public async Task<IActionResult> UpdateBuyType([FromBody] BuyTypesModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            if (string.IsNullOrEmpty(model.id))
            {
                responseModel.message = "Invalid Buy Type Id!";
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
                    responseModel.message = "Successfully update Buy Type!";
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
