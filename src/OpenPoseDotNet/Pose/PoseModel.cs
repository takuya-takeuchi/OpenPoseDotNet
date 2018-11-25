// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public enum PoseModel : byte
    {

        Body25 = 0,
        Coco18,        /**< COCO model + neck, with 18+1 components (see poseParameters.hpp for details). */
        Mpi15,         /**< MPI model, with 15+1 components (see poseParameters.hpp for details). */
        Mpi15_4,       /**< Variation of the MPI model, reduced number of CNN stages to 4: faster but less accurate.*/
        Body19,        /**< Experimental. Do not use. */
        Body19_X2,     /**< Experimental. Do not use. */
        Body59,        /**< Experimental. Do not use. */
        Body19N,       /**< Experimental. Do not use. */
        Body25E,       /**< Experimental. Do not use. */
        Body25_19,     /**< Experimental. Do not use. */
        Body65,        /**< Experimental. Do not use. */
        Car12,         /**< Experimental. Do not use. */
        Body25D,       /**< Experimental. Do not use. */
        Body23,        /**< Experimental. Do not use. */
        Car22,         /**< Experimental. Do not use. */
        Body19E,       /**< Experimental. Do not use. */
        Size,
    }

}
