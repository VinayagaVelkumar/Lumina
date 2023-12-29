using LuminaAPI.Model.UMS;
using LuminaAPI.Service.Interface;

namespace LuminaAPI.Business
{
    public class UMSBusiness
    {
        private IUMSService service;
        public UMSBusiness(IUMSService umsService)
        {
            this.service = umsService;
        }

        public User ValidateUser(string userName, string passWord)
        {
            try
            {

                User dbUserDetail = this.service.GetAll().Where(x => x.UserID == int.Parse(userName)).FirstOrDefault();
                if (dbUserDetail != null)
                {

                    // Validate the password
                    bool isPasswordValid = ValidatePassword(passWord, dbUserDetail.Hash, dbUserDetail.Salt);

                    if (isPasswordValid)
                    {
                        return dbUserDetail;
                    }
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        private bool ValidatePassword(string password, string storedHash, string storedSalt)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(storedHash);
                byte[] saltBytes = Convert.FromBase64String(storedSalt);

                using (var hmac = new System.Security.Cryptography.HMACSHA512(saltBytes))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != hashBytes[i])
                            return false;
                    }
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        private void GeneratePasswordHashAndSalt(string password, out string hash, out string salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = Convert.ToBase64String(hmac.Key);
                hash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
