namespace LuminaAPI.Business
{
    using Imagekit;
    using Imagekit.Models;
    using Imagekit.Models.Response;
    using Imagekit.Sdk;
    using Newtonsoft.Json.Linq;
    using static Imagekit.Models.CustomMetaDataFieldSchemaObject;
    using LuminaAPI.Model.Config;
    using System.IO;
    using System.Threading.Tasks;

    public class ImageKitBusiness
    {
        private ImageKitConfig imageConfig;
        public ImageKitBusiness(ImageKitConfig config)
        {
            this.imageConfig = config;
        }
        public async Task<string> UploadFile(string filePath, string fileName)
        {
            try
            {
                ImagekitClient imagekit = new ImagekitClient(this.imageConfig.publicKey, this.imageConfig.privateKey, this.imageConfig.urlEndpoint);
   
            byte[] bytes = File.ReadAllBytes(filePath);
            FileCreateRequest ob = new FileCreateRequest
            {
                file = bytes,
                fileName = fileName
            };
                ob.isPrivateFile = false;
                ob.overwriteFile = true;
                Result response = imagekit.Upload(ob);
                return response.url;
        }
            catch
            {
                throw;
            }
        }   
    }

}
