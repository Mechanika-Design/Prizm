﻿using Vector = System.Collections.Generic.IReadOnlyList<double>;

namespace Prizm
{
    /// <summary>
    /// Color represented as a vector in its color space
    /// </summary>
    public interface IColorVector
    {
        /// <summary>
        /// Vector
        /// </summary>
        Vector Vector { get; }
    }
}