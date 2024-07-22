// ***********************************************************************
// Assembly         : MaxiPago.Tests
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
    public class PixPaymentTests
    {
        [Fact]
        public void ProcessPixPayment_Success()
        {
            var api = new Api { Environment = "TEST" };
            var response = api.ProcessPixPayment(
                "merchant-id",
                "merchant-key",
                "reference123",
                100.50m,
                "pix-key123",
                "127.0.0.1",
                "customer123"
            );
            Assert.NotNull(response);
            Assert.False(response.IsErrorResponse);
        }

        [Fact]
        public void ProcessPixPayment_Failure()
        {
            var api = new Api { Environment = "TEST" };
            var response = api.ProcessPixPayment(
                "merchant-id",
                "merchant-key",
                "reference123",
                100.50m,
                null, // Pix key is required
                "127.0.0.1",
                "customer123"
            );
            Assert.NotNull(response);
            Assert.True(response.IsErrorResponse);
        }
    }
// <copyright file="UnitTest1.cs" company="MaxiPago.Tests">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Xunit;

namespace MaxiPago.Tests
{
    /// <summary>
    /// Class UnitTest1.
    /// </summary>
    public class UnitTest1
    {
        /// <summary>
        /// Defines the test method Test1.
        /// </summary>
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
    }
}
