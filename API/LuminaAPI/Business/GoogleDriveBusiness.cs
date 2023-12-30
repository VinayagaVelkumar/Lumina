namespace LuminaAPI.Business
{
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Auth.OAuth2.Flows;
    using Google.Apis.Auth.OAuth2.Responses;
    using Google.Apis.Drive.v3;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using LuminaAPI.Model.Config;
    using Microsoft.AspNetCore.DataProtection.KeyManagement;
    using System.IO;
    using System.Threading.Tasks;
    using static Google.Apis.Drive.v3.DriveService;

    public class GoogleDriveBusiness
    {
        private DriveConfig driveConfig;
        public GoogleDriveBusiness(DriveConfig config)
        {
            this.driveConfig = config;
        }
        public async Task<string> UploadFile(string filePath, string fileName)
        {
            try
            {
                DriveService service = GetService();
                string folder = CreateFolder("Home","Files");

    var driveFile = new Google.Apis.Drive.v3.Data.File();
                driveFile.Name = fileName;
                driveFile.Parents = new string[] { folder };

                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    var request = service.Files.Create(driveFile, stream, "application/pdf");
                    request.Fields = "id";

                    var response = request.Upload();

                    if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                        throw response.Exception;

                    return request.ResponseBody.WebViewLink;
                }
            }
            catch
            {
                throw;
            }
        }

        private static DriveService GetService()
        {
            var tokenResponse = new TokenResponse
            {
                AccessToken = "ya29.a0AfB_byCM8ewIjZv8Bdeiu2nrNRDxfnRqVp5bJ8IkLzinf2gRZ3tuJov-5bcJvbLxS4zVhXsWpWztULQrJxxZfvULqfl274ZCcIluRm1LpfZjQFUYSdJaPYGyWnhS85NsbCngPWFABwmR8gSBQfrXuJr0Ml-CzJBeKVSvaCgYKAeQSARESFQHGX2MiCBstWE7yEHgKjjrfcUdTzA0171",
                RefreshToken = "1//04-q0QW_4AeMlCgYIARAAGAQSNwF-L9Irz6WKr8NQpmlxFLduXmSXDecXV_IguatvXJFvtncElxXs-0SY4fQgoPZ30YEi1Dm1JEE",
            };


            var applicationName = "Lumina"; // Use the name of the project in Google Cloud
            var username = "vinayafancystorea@gmail.com"; // Use your email


            var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "1017442943406-ld0ejlb0jvegehqare3g20gdtbsgb4hb.apps.googleusercontent.com",
                    ClientSecret = "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"
                },
                Scopes = new[] { Scope.Drive },
                DataStore = new FileDataStore(applicationName)
            });


            var credential = new UserCredential(apiCodeFlow, username, tokenResponse);


    var service = new DriveService(new BaseClientService.Initializer
    {
        HttpClientInitializer = credential,
        ApplicationName = applicationName
    });
    return service;
        }

        public string CreateFolder(string parent, string folderName)
        {
            var service = GetService();
            var driveFolder = new Google.Apis.Drive.v3.Data.File();
            driveFolder.Name = folderName;
            driveFolder.MimeType = "application/vnd.google-apps.folder";
            driveFolder.Parents = new string[] { parent };
            var command = service.Files.Create(driveFolder);
            var file = command.Execute();
            return file.Id;
        }
    }


}
