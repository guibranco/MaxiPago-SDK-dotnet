using Bogus;
using FluentAssertions;
using MaxiPago.DataContract.Transactional;
using Xunit;

namespace MaxiPago.Tests.DataContract
{
    public class RequestBaseTests
    {
        private static readonly Faker Faker = new();

        [Fact]
        public void DefaultConstructor_InitializesPayment()
        {
            var requestBase = new RequestBase();

            requestBase.Payment.Should().NotBeNull();
        }

        [Fact]
        public void DefaultConstructor_InitializesTransactionDetail()
        {
            var requestBase = new RequestBase();

            requestBase.TransactionDetail.Should().NotBeNull();
        }

        [Fact]
        public void ShouldSerializeFraudCheck_ReturnsFalse_WhenNull()
        {
            var requestBase = new RequestBase { FraudCheck = null };

            requestBase.ShouldSerializeFraudCheck().Should().BeFalse();
        }

        [Fact]
        public void ShouldSerializeFraudCheck_ReturnsTrue_WhenSet()
        {
            var requestBase = new RequestBase { FraudCheck = "Y" };

            requestBase.ShouldSerializeFraudCheck().Should().BeTrue();
        }

        [Fact]
        public void ShouldSerializeBilling_ReturnsFalse_WhenNull()
        {
            var requestBase = new RequestBase { Billing = null };

            requestBase.ShouldSerializeBilling().Should().BeFalse();
        }

        [Fact]
        public void ShouldSerializeBilling_ReturnsTrue_WhenSet()
        {
            var requestBase = new RequestBase { Billing = new Billing() };

            requestBase.ShouldSerializeBilling().Should().BeTrue();
        }

        [Fact]
        public void ShouldSerializeShipping_ReturnsFalse_WhenNull()
        {
            var requestBase = new RequestBase { Shipping = null };

            requestBase.ShouldSerializeShipping().Should().BeFalse();
        }

        [Fact]
        public void ShouldSerializeShipping_ReturnsTrue_WhenSet()
        {
            var requestBase = new RequestBase { Shipping = new Shipping() };

            requestBase.ShouldSerializeShipping().Should().BeTrue();
        }

        [Fact]
        public void ShouldSerializeCustomerIdExt_ReturnsFalse_WhenNull()
        {
            var requestBase = new RequestBase { CustomerIdExt = null };

            requestBase.ShouldSerializeCustomerIdExt().Should().BeFalse();
        }

        [Fact]
        public void ShouldSerializeCustomerIdExt_ReturnsFalse_WhenEmpty()
        {
            var requestBase = new RequestBase { CustomerIdExt = string.Empty };

            requestBase.ShouldSerializeCustomerIdExt().Should().BeFalse();
        }

        [Fact]
        public void ShouldSerializeCustomerIdExt_ReturnsTrue_WhenSet()
        {
            var requestBase = new RequestBase
            {
                CustomerIdExt = Faker.Random.AlphaNumeric(10),
            };

            requestBase.ShouldSerializeCustomerIdExt().Should().BeTrue();
        }
    }
}
