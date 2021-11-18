using DatingApp.Api.DTOs;
using DatingAppUaa.UnitTests.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DatingAppUaa.UnitTests.Pruebas
{
    public class AccountControllerTests
    {
        private string apiRoute = "api/account";
        private readonly HttpClient _client;
        private HttpResponseMessage HttpResponse;
        private string requestUri;
        private string registeredObject;
        private HttpContent httpContent;
        public AccountControllerTests()
        {
            _client = TestHelper.Instance.Client;
        }

        [Theory]
        [InlineData("BadRequest", "", "KnownAs", "Gender", "2000-01-01", "City", "Country", "Password")]
        [InlineData("BadRequest", "lisa", "KnownAs", "Gender", "2000-01-01", "City", "Country", "Password")]
        public async Task Register_ShouldFail(string statusCode, string username, string knownAs, string gender, DateTime dateOfBirth, string city, string country, string password)
        {

        }


        #region Privated methods
        private static string GetRegisterObject(RegisterDto registerDto)
        {
            var entityObject = new JObject()
            {
                { nameof(registerDto.Username), registerDto.Username },
                { nameof(registerDto.KnownAs), registerDto.KnownAs },
                { nameof(registerDto.Gender), registerDto.Gender },
                { nameof(registerDto.DateOfBirth), registerDto.DateOfBirth },
                { nameof(registerDto.City), registerDto.City },
                { nameof(registerDto.Country), registerDto.Country },
                { nameof(registerDto.Password), registerDto.Password }
            };

            return entityObject.ToString();
        }

        private StringContent GetHttpContent(string entity)
        {
            return new StringContent(entity, Encoding.UTF8, "application/json");
        }

        #endregion
    }
}
