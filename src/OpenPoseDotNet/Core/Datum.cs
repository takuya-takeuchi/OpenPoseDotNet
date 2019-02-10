using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public class Datum : OpenPoseObject
    {

        #region Constructors

        public Datum()
        {
            this.NativePtr = NativeMethods.op_core_datum_new();
        }

        internal Datum(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public Mat CvInputData
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_cvInputData(this.NativePtr);

                // Datum.cvInputData is not pointer. Therefore, this object must not be disposed.
                return new Mat(ret, false);
            }
            set
            {
                this.ThrowIfDisposed();
                value?.ThrowIfDisposed();
                NativeMethods.op_core_datum_set_cvInputData(this.NativePtr, value?.NativePtr ?? IntPtr.Zero);
            }
        }

        public Mat CvOutputData
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_cvOutputData(this.NativePtr);

                // Datum.cvOutputData is not pointer. Therefore, this object must not be disposed.
                return new Mat(ret, false);
            }
            set
            {
                this.ThrowIfDisposed();
                value?.ThrowIfDisposed();
                NativeMethods.op_core_datum_set_cvOutputData(this.NativePtr, value?.NativePtr ?? IntPtr.Zero);
            }
        }

        public Rectangle<float>[] FaceRectangles
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_faceRectangles(this.NativePtr);

                using (var vector = new StdVector<Rectangle<float>>(ret))
                    return vector.ToArray();
            }
            set
            {
                this.ThrowIfDisposed();
                using (var vector = new StdVector<Rectangle<float>>(new List<Rectangle<float>>(value ?? new Rectangle<float>[0])))
                    NativeMethods.op_core_datum_set_faceRectangles(this.NativePtr, vector.NativePtr);
            }
        }

        public Rectangle<float>[][] HandRectangles
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_handRectangles(this.NativePtr);
                using (var vector = new StdVector<Rectangle<float>>(ret))
                {
                    var rectangles = vector.ToArray();

                    var result = new List<Rectangle<float>[]>();
                    for (var index = 0; index < rectangles.Length; index++)
                    {
                        if (index == 0)
                        {
                            var r = new Rectangle<float>[2];
                            r[0] = rectangles[index];
                            result.Add(r);
                        }
                        else
                        {
                            var r = result[index % 2];
                            r[1] = rectangles[index];
                        }
                    }

                    return result.ToArray();
                }
            }
            set
            {
                this.ThrowIfDisposed();

                // check whether each item has only 2 or not
                if (value != null)
                    if (value.Any(r => r.Length != 2))
                        throw new ArgumentOutOfRangeException();

                var rectangles = value != null ? value.SelectMany(r => r).ToList() : new List<Rectangle<float>>();
                using (var vector = new StdVector<Rectangle<float>>(rectangles))
                    NativeMethods.op_core_datum_set_handRectangles(this.NativePtr, vector.NativePtr);
            }
        }

        public ulong FrameNumber
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_core_datum_get_frameNumber(this.NativePtr);
            }
        }

        public ulong Id
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_core_datum_get_id(this.NativePtr);
            }
        }

        public Array<float>[] InputNetData
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_inputNetData(this.NativePtr);

                // Datum.poseKeypoints is not pointer. Therefore, this object must not be disposed.
                using (var array = new StdVector<Array<float>>(ret, false))
                    return array.ToArray();
            }
        }

        public Array<float> PoseHeatMaps
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_poseHeatMaps(this.NativePtr);

                // Datum.poseKeypoints is not pointer. Therefore, this object must not be disposed.
                return new Array<float>(ret, false);
            }
        }

        public Array<float> PoseKeyPoints
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_poseKeypoints(this.NativePtr);

                // Datum.poseKeypoints is not pointer. Therefore, this object must not be disposed.
                return new Array<float>(ret, false);
            }
        }

        public Array<float> FaceKeyPoints
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_faceKeypoints(this.NativePtr);

                // Datum.poseKeypoints is not pointer. Therefore, this object must not be disposed.
                return new Array<float>(ret, false);
            }
        }

        public Array<float> FaceHeatMaps
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_faceHeatMaps(this.NativePtr);

                // Datum.poseKeypoints is not pointer. Therefore, this object must not be disposed.
                return new Array<float>(ret, false);
            }
        }

        public Array<float>[] HandKeyPoints
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_handKeypoints(this.NativePtr);

                // Datum.poseKeypoints is not pointer. Therefore, this object must not be disposed.
                using (var array = new StdArray<Array<float>>(ret, 2, false))
                    return array.ToArray();
            }
        }

        public Array<float>[] HandHeatMaps
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.op_core_datum_get_handHeatMaps(this.NativePtr);

                // Datum.poseKeypoints is not pointer. Therefore, this object must not be disposed.
                using (var array = new StdArray<Array<float>>(ret, 2, false))
                    return array.ToArray();
            }
        }

        public ulong SubId
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_core_datum_get_subId(this.NativePtr);
            }
        }

        public ulong SubIdMax
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.op_core_datum_get_subIdMax(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.op_core_datum_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
