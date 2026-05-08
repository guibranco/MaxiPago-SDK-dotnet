using Bogus;
using FluentAssertions;
using MaxiPago.DataContract.NonTransactional;
using MaxiPago.Gateway;
using NSubstitute;
using Xunit;

namespace MaxiPago.Tests.Gateway
{
    public class ApiGatewayTests
    {
        private static readonly Faker Faker = new();
        private readonly IUtils _utils;
        private readonly Api _api;

        public ApiGatewayTests()
        {
            _utils = Substitute.For<IUtils>();
            _api = new Api(_utils);
        }

        [Fact]
        public void DefaultConstructor_SetsEnvironmentToTest()
        {
            var api = new Api();

            api.Environment.Should().Be("TEST");
        }

        [Fact]
        public void InjectedConstructor_SetsEnvironmentToTest()
        {
            _api.Environment.Should().Be("TEST");
        }

        [Fact]
        public void AddConsumer_SendsAddConsumerCommand()
        {
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(new ApiResponse());

            _api.AddConsumer(
                Faker.Random.AlphaNumeric(8), Faker.Random.AlphaNumeric(32),
                Faker.Random.AlphaNumeric(10),
                Faker.Person.FirstName, Faker.Person.LastName,
                Faker.Address.StreetAddress(), null,
                Faker.Address.City(), Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(), Faker.Phone.PhoneNumber(),
                Faker.Internet.Email(), null, null, null
            );

            _utils.Received(1).SendRequest(
                Arg.Is<ApiRequest>(r => r.Command == "add-consumer"),
                "TEST"
            );
        }

        [Fact]
        public void AddConsumer_PopulatesConsumerFields()
        {
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(new ApiResponse());

            var merchantId = Faker.Random.AlphaNumeric(8);
            var merchantKey = Faker.Random.AlphaNumeric(32);
            var firstName = Faker.Person.FirstName;
            var lastName = Faker.Person.LastName;
            var email = Faker.Internet.Email();

            _api.AddConsumer(
                merchantId, merchantKey,
                Faker.Random.AlphaNumeric(10),
                firstName, lastName,
                Faker.Address.StreetAddress(), null,
                Faker.Address.City(), Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(), Faker.Phone.PhoneNumber(),
                email, null, null, null
            );

            _utils.Received(1).SendRequest(
                Arg.Is<ApiRequest>(r =>
                    r.Verification.MerchantId == merchantId &&
                    r.Verification.MerchantKey == merchantKey &&
                    r.CommandRequest.FirstName == firstName &&
                    r.CommandRequest.LastName == lastName &&
                    r.CommandRequest.Email == email),
                Arg.Any<string>()
            );
        }

        [Fact]
        public void AddConsumer_ReturnsApiResponse()
        {
            var expected = new ApiResponse { ErrorCode = "0" };
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(expected);

            var result = _api.AddConsumer(
                Faker.Random.AlphaNumeric(8), Faker.Random.AlphaNumeric(32),
                Faker.Random.AlphaNumeric(10),
                Faker.Person.FirstName, Faker.Person.LastName,
                Faker.Address.StreetAddress(), null,
                Faker.Address.City(), Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(), Faker.Phone.PhoneNumber(),
                Faker.Internet.Email(), null, null, null
            );

            result.Should().BeSameAs(expected);
            result.IsApiResponse.Should().BeTrue();
        }

        [Fact]
        public void DeleteConsumer_SendsDeleteConsumerCommand_WithCustomerId()
        {
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(new ApiResponse());
            var customerId = Faker.Random.AlphaNumeric(10);

            _api.DeleteConsumer(
                Faker.Random.AlphaNumeric(8), Faker.Random.AlphaNumeric(32),
                customerId
            );

            _utils.Received(1).SendRequest(
                Arg.Is<ApiRequest>(r =>
                    r.Command == "delete-consumer" &&
                    r.CommandRequest.CustomerId == customerId),
                "TEST"
            );
        }

        [Fact]
        public void DeleteConsumer_ReturnsApiResponse()
        {
            var expected = new ApiResponse();
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(expected);

            var result = _api.DeleteConsumer(
                Faker.Random.AlphaNumeric(8), Faker.Random.AlphaNumeric(32),
                Faker.Random.AlphaNumeric(10)
            );

            result.Should().BeSameAs(expected);
        }

        [Fact]
        public void UpdateConsumer_SendsUpdateConsumerCommand()
        {
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(new ApiResponse());
            var customerId = Faker.Random.AlphaNumeric(10);

            _api.UpdateConsumer(
                Faker.Random.AlphaNumeric(8), Faker.Random.AlphaNumeric(32),
                customerId, Faker.Random.AlphaNumeric(10),
                Faker.Person.FirstName, Faker.Person.LastName,
                Faker.Address.StreetAddress(), null,
                Faker.Address.City(), Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(), Faker.Phone.PhoneNumber(),
                Faker.Internet.Email(), null, null, null
            );

            _utils.Received(1).SendRequest(
                Arg.Is<ApiRequest>(r =>
                    r.Command == "update-consumer" &&
                    r.CommandRequest.CustomerId == customerId),
                "TEST"
            );
        }

        [Fact]
        public void AddCardOnFile_SendsAddCardOnFileCommand()
        {
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(new ApiResponse());
            var customerId = Faker.Random.AlphaNumeric(10);
            var cardNumber = Faker.Finance.CreditCardNumber();

            _api.AddCardOnFile(
                Faker.Random.AlphaNumeric(8), Faker.Random.AlphaNumeric(32),
                customerId, cardNumber, "12", "2030",
                Faker.Person.FullName,
                Faker.Address.StreetAddress(), null,
                Faker.Address.City(), Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(), "BR",
                Faker.Phone.PhoneNumber(), Faker.Internet.Email(),
                null, null, null, null
            );

            _utils.Received(1).SendRequest(
                Arg.Is<ApiRequest>(r =>
                    r.Command == "add-card-onfile" &&
                    r.CommandRequest.CustomerId == customerId &&
                    r.CommandRequest.CreditCardNumber == cardNumber),
                "TEST"
            );
        }

        [Fact]
        public void AddCardOnFile_PopulatesCardExpiryFields()
        {
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(new ApiResponse());

            _api.AddCardOnFile(
                Faker.Random.AlphaNumeric(8), Faker.Random.AlphaNumeric(32),
                Faker.Random.AlphaNumeric(10),
                Faker.Finance.CreditCardNumber(),
                "06", "2028",
                Faker.Person.FullName,
                Faker.Address.StreetAddress(), null,
                Faker.Address.City(), Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(), "BR",
                Faker.Phone.PhoneNumber(), Faker.Internet.Email(),
                null, null, null, null
            );

            _utils.Received(1).SendRequest(
                Arg.Is<ApiRequest>(r =>
                    r.CommandRequest.ExpirationMonth == "06" &&
                    r.CommandRequest.ExpirationYear == "2028"),
                Arg.Any<string>()
            );
        }

        [Fact]
        public void DeleteCardOnFile_SendsDeleteCardOnFileCommand()
        {
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(new ApiResponse());
            var customerId = Faker.Random.AlphaNumeric(10);
            var token = Faker.Random.AlphaNumeric(20);

            _api.DeleteCardOnFile(
                Faker.Random.AlphaNumeric(8), Faker.Random.AlphaNumeric(32),
                customerId, token
            );

            _utils.Received(1).SendRequest(
                Arg.Is<ApiRequest>(r =>
                    r.Command == "delete-card-onfile" &&
                    r.CommandRequest.CustomerId == customerId &&
                    r.CommandRequest.Token == token),
                "TEST"
            );
        }

        [Fact]
        public void CancelRecurring_SendsCancelRecurringCommand()
        {
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(new ApiResponse());
            var orderId = Faker.Random.AlphaNumeric(12);

            _api.CancelRecurring(
                Faker.Random.AlphaNumeric(8), Faker.Random.AlphaNumeric(32),
                orderId
            );

            _utils.Received(1).SendRequest(
                Arg.Is<ApiRequest>(r =>
                    r.Command == "cancel-recurring" &&
                    r.CommandRequest.OrderID == orderId),
                "TEST"
            );
        }

        [Fact]
        public void AllMethods_UseConfiguredEnvironment()
        {
            _utils.SendRequest(Arg.Any<ApiRequest>(), Arg.Any<string>())
                  .Returns(new ApiResponse());
            _api.Environment = "LIVE";

            _api.CancelRecurring(
                Faker.Random.AlphaNumeric(8), Faker.Random.AlphaNumeric(32),
                Faker.Random.AlphaNumeric(12)
            );

            _utils.Received(1).SendRequest(Arg.Any<ApiRequest>(), "LIVE");
        }
    }
}
