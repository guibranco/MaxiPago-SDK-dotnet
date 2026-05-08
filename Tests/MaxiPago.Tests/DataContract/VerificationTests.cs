using Bogus;
using FluentAssertions;
using MaxiPago.DataContract;
using Xunit;

namespace MaxiPago.Tests.DataContract
{
    public class VerificationTests
    {
        private static readonly Faker Faker = new();

        [Fact]
        public void DefaultConstructor_CreatesInstanceWithNullProperties()
        {
            var verification = new Verification();

            verification.MerchantId.Should().BeNull();
            verification.MerchantKey.Should().BeNull();
        }

        [Fact]
        public void ParameterizedConstructor_SetsMerchantId()
        {
            var merchantId = Faker.Random.AlphaNumeric(8);
            var merchantKey = Faker.Random.AlphaNumeric(32);

            var verification = new Verification(merchantId, merchantKey);

            verification.MerchantId.Should().Be(merchantId);
        }

        [Fact]
        public void ParameterizedConstructor_SetsMerchantKey()
        {
            var merchantId = Faker.Random.AlphaNumeric(8);
            var merchantKey = Faker.Random.AlphaNumeric(32);

            var verification = new Verification(merchantId, merchantKey);

            verification.MerchantKey.Should().Be(merchantKey);
        }

        [Fact]
        public void Properties_AreSettable()
        {
            var merchantId = Faker.Random.AlphaNumeric(8);
            var merchantKey = Faker.Random.AlphaNumeric(32);

            var verification = new Verification
            {
                MerchantId = merchantId,
                MerchantKey = merchantKey,
            };

            verification.MerchantId.Should().Be(merchantId);
            verification.MerchantKey.Should().Be(merchantKey);
        }
    }
}
