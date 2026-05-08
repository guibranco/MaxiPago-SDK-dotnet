using Bogus;
using FluentAssertions;
using MaxiPago.DataContract.Transactional;
using Xunit;

namespace MaxiPago.Tests.DataContract
{
    public class TransactionRequestTests
    {
        private static readonly Faker Faker = new();

        [Fact]
        public void DefaultConstructor_SetsVersionTo3_1_1_15()
        {
            var request = new TransactionRequest();

            request.Version.Should().Be("3.1.1.15");
        }

        [Fact]
        public void DefaultConstructor_InitializesVerification()
        {
            var request = new TransactionRequest();

            request.Verification.Should().NotBeNull();
        }

        [Fact]
        public void DefaultConstructor_InitializesOrder()
        {
            var request = new TransactionRequest();

            request.Order.Should().NotBeNull();
        }

        [Fact]
        public void ParameterizedConstructor_SetsMerchantCredentials()
        {
            var merchantId = Faker.Random.AlphaNumeric(8);
            var merchantKey = Faker.Random.AlphaNumeric(32);

            var request = new TransactionRequest(merchantId, merchantKey);

            request.Verification.MerchantId.Should().Be(merchantId);
            request.Verification.MerchantKey.Should().Be(merchantKey);
        }

        [Fact]
        public void ParameterizedConstructor_SetsVersionTo3_1_1_15()
        {
            var request = new TransactionRequest(
                Faker.Random.AlphaNumeric(8),
                Faker.Random.AlphaNumeric(32)
            );

            request.Version.Should().Be("3.1.1.15");
        }

        [Fact]
        public void ParameterizedConstructor_InitializesOrder()
        {
            var request = new TransactionRequest(
                Faker.Random.AlphaNumeric(8),
                Faker.Random.AlphaNumeric(32)
            );

            request.Order.Should().NotBeNull();
        }
    }
}
