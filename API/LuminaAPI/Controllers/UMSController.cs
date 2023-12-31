using LuminaAPI.Business;
using LuminaAPI.Model.Config;
using LuminaAPI.Model.UMS;
using LuminaAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LuminaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UMSController : Controller
    {
        private readonly ConnectionConfig _connectionConfig;
        private readonly IUMSService _service;
        private readonly ILogger<UMSController> _logger;
        private readonly CollectionNames _collectionNames;

        public UMSController(ConnectionConfig connectionConfig, IUMSService service, ILogger<UMSController> logger, CollectionNames collectionNames)
        {
            this._connectionConfig = connectionConfig;
            this._service = service;
            _logger = logger;
            _collectionNames = collectionNames;
        }

        [Authorize]
        [HttpGet]
        public bool AuthenticateToken()
        {
            return true;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            try
            {
                UMSBusiness business = new UMSBusiness(this._service);
                var user = business.ValidateUser(loginModel.Username, loginModel.Password);

                if (user != null)
                {
                    var token = GenerateJwtToken(user);
                    return Ok(new { token, userId = user.UserID });
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return Unauthorized();
            }
        }

        private string GenerateJwtToken(User user)
        {
            try
            {
                var claims = new List<Claim>
                                {
                                    new Claim(ClaimTypes.Name, user.UserName),
                                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._connectionConfig.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    this._connectionConfig.Issuer,
                    this._connectionConfig.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(30), // Set expiration time as needed
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"An error occurred: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }
    }
}
