using System;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class ScaleAndSizeExtractor : OpenPoseObject
    {

        #region Constructors

        public ScaleAndSizeExtractor(Point<int> netInputResolution,
                                     Point<int> outputResolution,
                                     int scaleNumber = 1,
                                     double scaleGap = 0.25)
        {
            using (var input = netInputResolution.ToNative())
            using (var output = outputResolution.ToNative())
                this.NativePtr = NativeMethods.op_core_ScaleAndSizeExtractor_new(input.NativePtr, output.NativePtr, scaleNumber, scaleGap);
        }

        #endregion

        #region Methods

        public Tuple<double[], Point<int>[], double, Point<int>> Extract(Point<int> inputResolution)
        {
            using (var input = inputResolution.ToNative())
            {
                NativeMethods.op_core_ScaleAndSizeExtractor_extract(this.NativePtr,
                                                                    input.NativePtr,
                                                                    out var vector,
                                                                    out var points,
                                                                    out var value,
                                                                    out var x,
                                                                    out var y);

                using (var tmpVector = new StdVector<double>(vector))
                using (var tmpPoints = new StdVector<Point<int>>(points))
                    return new Tuple<double[], Point<int>[], double, Point<int>>(tmpVector.ToArray(),
                                                                                 tmpPoints.ToArray(),
                                                                                 value,
                                                                                 new Point<int>(x, y));
            }
        }

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.op_core_ScaleAndSizeExtractor_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
