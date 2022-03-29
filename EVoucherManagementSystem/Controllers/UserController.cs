using Microsoft.AspNetCore.Mvc;
using EVoucherManagementSystem.Context;
using EVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVoucherManagementSystem.Communication;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace EVoucherManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private DataContext myDbContext;
        public UserController(DataContext context, IConfiguration config)
        {
            myDbContext = context;
            _config = config;
        }

        [HttpGet]
        public IList<UsersModel> Get()
        {
            return (this.myDbContext.Users.ToList());
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UsersModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            var userCount = myDbContext.Users.Where(x => x.phoneNo.Equals(model.phoneNo)).FirstOrDefault();
          
            if (userCount != null)
            {
                responseModel.message = "This Phone number have already registered!";
                responseModel.success = false;
                responseModel.error = false;
                responseModel.warning = true;
            }
            else
            {
                try
                {
                    model.id = Guid.NewGuid().ToString();
                    await myDbContext.AddAsync(model);
                    myDbContext.SaveChanges();
                    responseModel.message = "Successfully registered!";
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

      
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] UsersModel model)
        {
            IActionResult response = Unauthorized();
            BaseResponse baseResponse = new BaseResponse();
            var user =await myDbContext.Users.Where(x => x.phoneNo.Equals(model.phoneNo) && x.password.Equals(model.password) && x.userName.Equals(model.userName)).FirstOrDefaultAsync();
            if (user== null)
            {
                baseResponse.message = "Invalid Login information!";
                baseResponse.success = false;
                baseResponse.error = false;
            }
            else
            {
                var tokenString = GenerateJSONWebToken(model);
                AuthenticationResponse authenticationResponse = new AuthenticationResponse();
                authenticationResponse.accessToken = tokenString;
                AuthenticateUsers authenticateUsers = new AuthenticateUsers();
                authenticateUsers.id = user.id;authenticateUsers.userName= user.userName;authenticateUsers.phoneNo = user.phoneNo;
                authenticationResponse.user = authenticateUsers;
                baseResponse.message = "Successfully Login!";
                baseResponse.data = authenticationResponse;
                baseResponse.success = true;
                baseResponse.error = false;
            }

            return Ok(baseResponse);
        }
       
        private string GenerateJSONWebToken(UsersModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.UtcNow.AddDays(1),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
