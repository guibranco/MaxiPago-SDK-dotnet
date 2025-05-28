using System;
using Bogus;
using FluentAssertions;
using MaxiPago.DataContract.NonTransactional;
using MaxiPago.Gateway;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace MaxiPago.Tests.IntegrationTests
{
    public class ApiIntegrationTests : IDisposable
    {
        private readonly WireMockServer _server;

        public ApiIntegrationTests()
        {
            _server = WireMockServer.Start();
        }

        public void Dispose()
        {
            _server.Stop();
            _server.Dispose();
        }

        [Fact]
        public void AddConsumer_ShouldReturnSuccessResponse()
        {
            // Arrange: setup WireMock stub to simulate API endpoint
            string fakeXmlResponse = "<api-response><result>Success</result></api-response>";
            _server
                .Given(Request.Create().WithPath("/").UsingPost())
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBody(fakeXmlResponse)
                        .WithHeader("Content-Type", "application/xml")
                );

            // Using Bogus to generate fake consumer data
            var faker = new Faker();
            string merchantId = faker.Finance.Account(); // dummy
            string merchantKey = faker.Random.AlphaNumeric(10);
            string customerIdExt = faker.Random.AlphaNumeric(8);
            string firstName = faker.Name.FirstName();
            string lastName = faker.Name.LastName();
            string address1 = faker.Address.StreetAddress();
            string address2 = faker.Address.SecondaryAddress();
            string city = faker.Address.City();
            string state = faker.Address.State();
            string zip = faker.Address.ZipCode();
            string phone = faker.Phone.PhoneNumber();
            string email = faker.Internet.Email();
            string dob = faker.Date.Past(30).ToString("yyyy-MM-dd");
            string ssn = faker.Random.Replace("###-##-####");
            string sex = faker.PickRandom(new[] { "M", "F" });

            // Instantiate Api and set its Environment to WireMock server URL
            var api = new Api();
            api.Environment = _server.Urls[0];

            // Act: Call AddConsumer. Note: Use try-catch since actual implementation might try to parse XML response.
            ApiResponse response = null;
            try
            {
                response = api.AddConsumer(
                    merchantId,
                    merchantKey,
                    customerIdExt,
                    firstName,
                    lastName,
                    address1,
                    address2,
                    city,
                    state,
                    zip,
                    phone,
                    email,
                    dob,
                    ssn,
                    sex
                );
            }
            catch (Exception ex)
            {
                // For integration testing, if an exception occurs, capture it.
                Assert.True(false, $"Exception occurred: {ex.Message}");
            }

            // Assert: Use FluentAssertions to assert expected response
            response.Should().NotBeNull();
            // Since we simulate fake XML, we expect result "Success" to appear in some property.
            // Assuming the ApiResponse has a property called Result or similar.
            // We'll use ToString() to check if it contains "Success".
            response.ToString().Should().Contain("Success");
        }
    }
}
