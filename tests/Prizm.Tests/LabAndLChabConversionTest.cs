﻿using System.Collections.Generic;
using Prizm.Conversion;
using Xunit;

namespace Prizm.Tests
{
    /// <summary>
    /// Tests <see cref="LabColor" />-<see cref="LChabColor" /> conversions.
    /// </summary>
    /// <remarks>
    /// Test data generated using:
    /// http://www.brucelindbloom.com/index.html?ColorCalculator.html
    /// </remarks>
    public class LabAndLChabConversionTest
    {
        private static readonly IEqualityComparer<double> DoubleComparer = new DoubleRoundingComparer(4);

        private static ColourfulConverter Converter => new ColourfulConverter();

        /// <summary>
        /// Tests conversion from <see cref="LChabColor" /> to <see cref="LabColor" />.
        /// </summary>
        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(54.2917, 106.8391, 40.8526, 54.2917, 80.8125, 69.8851)]
        [InlineData(100, 0, 0, 100, 0, 0)]
        [InlineData(100, 50, 180, 100, -50, 0)]
        [InlineData(10, 36.0555, 56.3099, 10, 20, 30)]
        [InlineData(10, 36.0555, 123.6901, 10, -20, 30)]
        [InlineData(10, 36.0555, 303.6901, 10, 20, -30)]
        [InlineData(10, 36.0555, 236.3099, 10, -20, -30)]
        public void Convert_LCHab_to_Lab(double l, double c, double h, double l2, double a, double b)
        {
            // arrange
            var input = new LChabColor(l, c, h);

            // act
            var output = Converter.ToLab(input);

            // assert
            Assert.Equal(output.L, l2, DoubleComparer);
            Assert.Equal(output.a, a, DoubleComparer);
            Assert.Equal(output.b, b, DoubleComparer);
        }

        /// <summary>
        /// Tests conversion from <see cref="LabColor" /> to <see cref="LChabColor" />.
        /// </summary>
        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(54.2917, 80.8125, 69.8851, 54.2917, 106.8391, 40.8526)]
        [InlineData(100, 0, 0, 100, 0, 0)]
        [InlineData(100, -50, 0, 100, 50, 180)]
        [InlineData(10, 20, 30, 10, 36.0555, 56.3099)]
        [InlineData(10, -20, 30, 10, 36.0555, 123.6901)]
        [InlineData(10, 20, -30, 10, 36.0555, 303.6901)]
        [InlineData(10, -20, -30, 10, 36.0555, 236.3099)]
        public void Convert_Lab_to_LCHab(double l, double a, double b, double l2, double c, double h)
        {
            // arrange
            var input = new LabColor(l, a, b);

            // act
            var output = Converter.ToLChab(input);

            // assert
            Assert.Equal(output.L, l2, DoubleComparer);
            Assert.Equal(output.C, c, DoubleComparer);
            Assert.Equal(output.h, h, DoubleComparer);
        }
    }
}