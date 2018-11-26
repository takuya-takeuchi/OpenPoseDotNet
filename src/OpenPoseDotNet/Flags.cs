using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenPoseDotNet
{

    public static class Flags
    {

        #region Properties

        public static bool BodyDisabled
        {
            get => Native.op_flags_get_body_disable();
            set => Native.op_flags_set_body_disable(value);
        }

        public static bool Face
        {
            get => Native.op_flags_get_face();
            set => Native.op_flags_set_face(value);
        }

        public static bool Hand
        {
            get => Native.op_flags_get_hand();
            set => Native.op_flags_set_hand(value);
        }

        public static bool Enable3D
        {
            get => Native.op_flags_get_3d();
            set => Native.op_flags_set_3d(value);
        }

        public static int Views3D
        {
            get => Native.op_flags_get_3d_views();
            set => Native.op_flags_set_3d_views(value);
        }

        public static int MinViews3D
        {
            get => Native.op_flags_get_3d_min_views();
            set => Native.op_flags_set_3d_min_views(value);
        }

        public static double AlphaHeatmap
        {
            get => Native.op_flags_get_alpha_heatmap();
            set => Native.op_flags_set_alpha_heatmap(value);
        }

        public static double AlphaPose
        {
            get => Native.op_flags_get_alpha_pose();
            set => Native.op_flags_set_alpha_pose(value);
        }

        public static int Camera
        {
            get => Native.op_flags_get_camera();
            set => Native.op_flags_set_camera(value);
        }

        public static double CliVerbose
        {
            get => Native.op_flags_get_cli_verbose();
            set => Native.op_flags_set_cli_verbose(value);
        }

        public static int Display
        {
            get => Native.op_flags_get_display();
            set => Native.op_flags_set_display(value);
        }

        public static bool DisableBlending
        {
            get => Native.op_flags_get_disable_blending();
            set => Native.op_flags_set_disable_blending(value);
        }

        public static double FaceAlphaHeatmap
        {
            get => Native.op_flags_get_face_alpha_heatmap();
            set => Native.op_flags_set_face_alpha_heatmap(value);
        }

        public static double FaceAlphaPose
        {
            get => Native.op_flags_get_face_alpha_pose();
            set => Native.op_flags_set_face_alpha_pose(value);
        }

        public static int FaceRender
        {
            get => Native.op_flags_get_face_render();
            set => Native.op_flags_set_face_render(value);
        }

        public static double FaceRenderThreshold
        {
            get => Native.op_flags_get_face_render_threshold();
            set => Native.op_flags_set_face_render_threshold(value);
        }

        public static bool FlirCamera
        {
            get => Native.op_flags_get_flir_camera();
            set => Native.op_flags_set_flir_camera(value);
        }

        public static int FlirCameraIndex
        {
            get => Native.op_flags_get_flir_camera_index();
            set => Native.op_flags_set_flir_camera_index(value);
        }

        public static ulong FrameFirst
        {
            get => Native.op_flags_get_frame_first();
            set => Native.op_flags_set_frame_first(value);
        }

        public static bool FrameFlip
        {
            get => Native.op_flags_get_frame_flip();
            set => Native.op_flags_set_frame_flip(value);
        }

        public static bool FrameKeepDistortion
        {
            get => Native.op_flags_get_frame_keep_distortion();
            set => Native.op_flags_set_frame_keep_distortion(value);
        }

        public static ulong FrameLast
        {
            get => Native.op_flags_get_frame_last();
            set => Native.op_flags_set_frame_last(value);
        }

        public static int FrameRotate
        {
            get => Native.op_flags_get_frame_rotate();
            set => Native.op_flags_set_frame_rotate(value);
        }

        public static bool FramesRepeat
        {
            get => Native.op_flags_get_frames_repeat();
            set => Native.op_flags_set_frames_repeat(value);
        }

        public static ulong FrameStep
        {
            get => Native.op_flags_get_frame_step();
            set => Native.op_flags_set_frame_step(value);
        }

        public static double FpsMax
        {
            get => Native.op_flags_get_fps_max();
            set => Native.op_flags_set_fps_max(value);
        }

        public static bool FullScreen
        {
            get => Native.op_flags_get_fullscreen();
            set => Native.op_flags_set_fullscreen(value);
        }

        public static double HandAlphaHeatmap
        {
            get => Native.op_flags_get_hand_alpha_heatmap();
            set => Native.op_flags_set_hand_alpha_heatmap(value);
        }

        public static double HandAlphaPose
        {
            get => Native.op_flags_get_hand_alpha_pose();
            set => Native.op_flags_set_hand_alpha_pose(value);
        }

        public static int HandRender
        {
            get => Native.op_flags_get_hand_render();
            set => Native.op_flags_set_hand_render(value);
        }

        public static double HandRenderThreshold
        {
            get => Native.op_flags_get_hand_render_threshold();
            set => Native.op_flags_set_hand_render_threshold(value);
        }

        public static int HandScaleNumber
        {
            get => Native.op_flags_get_hand_scale_number();
            set => Native.op_flags_set_hand_scale_number(value);
        }

        public static double HandScaleRange
        {
            get => Native.op_flags_get_hand_scale_range();
            set => Native.op_flags_set_hand_scale_range(value);
        }
        
        public static bool HandTracking
        {
            get => Native.op_flags_get_hand_tracking();
            set => Native.op_flags_set_hand_tracking(value);
        }

        public static bool Identification
        {
            get => Native.op_flags_get_identification();
            set => Native.op_flags_set_identification(value);
        }

        public static int IkThreads
        {
            get => Native.op_flags_get_ik_threads();
            set => Native.op_flags_set_ik_threads(value);
        }

        public static bool MaximizePositives
        {
            get => Native.op_flags_get_maximize_positives();
            set => Native.op_flags_set_maximize_positives(value);
        }

        public static bool NoGuiVerbose
        {
            get => Native.op_flags_get_no_gui_verbose();
            set => Native.op_flags_set_no_gui_verbose(value);
        }

        public static bool PartCandidates
        {
            get => Native.op_flags_get_part_candidates();
            set => Native.op_flags_set_part_candidates(value);
        }

        public static bool ProcessRealTime
        {
            get => Native.op_flags_get_process_real_time();
            set => Native.op_flags_set_process_real_time(value);
        }

        public static int NumGpu
        {
            get => Native.op_flags_get_num_gpu();
            set => Native.op_flags_set_num_gpu(value);
        }

        public static int NumGpuStart
        {
            get => Native.op_flags_get_num_gpu_start();
            set => Native.op_flags_set_num_gpu_start(value);
        }

        public static int NumberPeopleMax
        {
            get => Native.op_flags_get_number_people_max();
            set => Native.op_flags_set_number_people_max(value);
        }

        public static int PartToShow
        {
            get => Native.op_flags_get_part_to_show();
            set => Native.op_flags_set_part_to_show(value);
        }

        public static double RenderThreshold
        {
            get => Native.op_flags_get_render_threshold();
            set => Native.op_flags_set_render_threshold(value);
        }

        public static double ScaleGap
        {
            get => Native.op_flags_get_scale_gap();
            set => Native.op_flags_set_scale_gap(value);
        }

        public static double WriteVideoFps
        {
            get => Native.op_flags_get_write_video_fps();
            set => Native.op_flags_set_write_video_fps(value);
        }

        public static int RenderPose
        {
            get => Native.op_flags_get_render_pose();
            set => Native.op_flags_set_render_pose(value);
        }

        public static int ScaleNumber
        {
            get => Native.op_flags_get_scale_number();
            set => Native.op_flags_set_scale_number(value);
        }

        public static int Tracking
        {
            get => Native.op_flags_get_tracking();
            set => Native.op_flags_set_tracking(value);
        }

        public static int WriteCocoJsonVariant
        {
            get => Native.op_flags_get_write_coco_json_variant();
            set => Native.op_flags_set_write_coco_json_variant(value);
        }

        public static int HeatmapsScale
        {
            get => Native.op_flags_get_heatmaps_scale();
            set => Native.op_flags_set_heatmaps_scale(value);
        }

        public static bool HeatmapsAddParts
        {
            get => Native.op_flags_get_heatmaps_add_parts();
            set => Native.op_flags_set_heatmaps_add_parts(value);
        }

        public static bool HeatmapsAddBackground
        {
            get => Native.op_flags_get_heatmaps_add_bkg();
            set => Native.op_flags_set_heatmaps_add_bkg(value);
        }

        public static bool HeatmapsAddPAFs
        {
            get => Native.op_flags_get_heatmaps_add_PAFs();
            set => Native.op_flags_set_heatmaps_add_PAFs(value);
        }

        public static int KeyPointScale
        {
            get => Native.op_flags_get_keypoint_scale();
            set => Native.op_flags_set_keypoint_scale(value);
        }

        public static bool DisableMultiThread
        {
            get => Native.op_flags_get_disable_multi_thread();
            set => Native.op_flags_set_disable_multi_thread(value);
        }

        public static int LoggingLevel
        {
            get => Native.op_flags_get_logging_level();
            set => Native.op_flags_set_logging_level(value);
        }

        public static string CameraParameterFolder
        {
            get
            {
                var stdstr = Native.op_flags_get_camera_parameter_folder();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_camera_parameter_folder(str);
            }
        }

        public static string CameraResolution
        {
            get
            {
                var stdstr = Native.op_flags_get_camera_resolution();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_camera_resolution(str);
            }
        }

        public static string OutputResolution
        {
            get
            {
                var stdstr = Native.op_flags_get_output_resolution();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_output_resolution(str);
            }
        }

        public static string NetResolution
        {
            get
            {
                var stdstr = Native.op_flags_get_net_resolution();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_net_resolution(str);
            }
        }

        public static string FaceNetResolution
        {
            get
            {
                var stdstr = Native.op_flags_get_face_net_resolution();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_face_net_resolution(str);
            }
        }

        public static string HandNetResolution
        {
            get
            {
                var stdstr = Native.op_flags_get_hand_net_resolution();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_hand_net_resolution(str);
            }
        }

        public static string ImageDir
        {
            get
            {
                var stdstr = Native.op_flags_get_image_dir();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_image_dir(str);
            }
        }

        public static string IpCamera
        {
            get
            {
                var stdstr = Native.op_flags_get_ip_camera();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_ip_camera(str);
            }
        }

        public static string Video
        {
            get
            {
                var stdstr = Native.op_flags_get_video();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_video(str);
            }
        }

        public static string WriteKeyPoint
        {
            get
            {
                var stdstr = Native.op_flags_get_write_keypoint();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_keypoint(str);
            }
        }

        public static int ProfileSpeed
        {
            get => Native.op_flags_get_profile_speed();
            set => Native.op_flags_set_profile_speed(value);
        }
        
        public static string ModelFolder
        {
            get
            {
                var stdstr = Native.op_flags_get_model_folder();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_model_folder(str);
            }
        }

        public static string ModelPose
        {
            get
            {
                var stdstr = Native.op_flags_get_model_pose();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_model_pose(str);
            }
        }

        public static string UdpHost
        {
            get
            {
                var stdstr = Native.op_flags_get_udp_host();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_udp_host(str);
            }
        }

        public static string UdpPort
        {
            get
            {
                var stdstr = Native.op_flags_get_udp_port();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_udp_port(str);
            }
        }

        public static string WriteBvh
        {
            get
            {
                var stdstr = Native.op_flags_get_write_bvh();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_bvh(str);
            }
        }

        public static string WriteCocoFootJson
        {
            get
            {
                var stdstr = Native.op_flags_get_write_coco_foot_json();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_coco_foot_json(str);
            }
        }

        public static string WriteCocoJson
        {
            get
            {
                var stdstr = Native.op_flags_get_write_coco_json();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_coco_json(str);
            }
        }

        public static string WriteHeatmaps
        {
            get
            {
                var stdstr = Native.op_flags_get_write_heatmaps();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_heatmaps(str);
            }
        }

        public static string WriteHeatmapsFormat
        {
            get
            {
                var stdstr = Native.op_flags_get_write_heatmaps_format();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_heatmaps_format(str);
            }
        }

        public static string WriteImages
        {
            get
            {
                var stdstr = Native.op_flags_get_write_images();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_images(str);
            }
        }

        public static string WriteImagesFormat
        {
            get
            {
                var stdstr = Native.op_flags_get_write_images_format();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_images_format(str);
            }
        }

        public static string WriteJson
        {
            get
            {
                var stdstr = Native.op_flags_get_write_json();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_json(str);
            }
        }

        public static string WriteKeyPointFormat
        {
            get
            {
                var stdstr = Native.op_flags_get_write_keypoint_format();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_keypoint_format(str);
            }
        }

        public static string WriteVideo
        {
            get
            {
                var stdstr = Native.op_flags_get_write_video();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_video(str);
            }
        }

        public static string WriteVideoAdam
        {
            get
            {
                var stdstr = Native.op_flags_get_write_video_adam();
                var ret = StringHelper.FromStdString(stdstr);
                if (stdstr != IntPtr.Zero)
                    OpenPose.Native.std_string_delete(stdstr);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                Native.op_flags_set_write_video_adam(str);
            }
        }

        #endregion

        internal sealed class Native
        {
            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_3d();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_3d(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_3d_min_views();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_3d_min_views(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_3d_views();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_3d_views(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_alpha_heatmap();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_alpha_heatmap(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_alpha_pose();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_alpha_pose(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_body_disable();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_body_disable(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_camera();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_camera(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_cli_verbose();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_cli_verbose(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_disable_blending();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_disable_blending(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_disable_multi_thread();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_disable_multi_thread(bool value);
            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_display();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_display(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_face();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_face(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_face_alpha_heatmap();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_face_alpha_heatmap(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_face_alpha_pose();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_face_alpha_pose(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_face_render();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_face_render(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_face_render_threshold();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_face_render_threshold(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_flir_camera();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_flir_camera(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_flir_camera_index();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_flir_camera_index(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_fps_max();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_fps_max(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ulong op_flags_get_frame_first();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_frame_first(ulong value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_frame_flip();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_frame_flip(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_frame_keep_distortion();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_frame_keep_distortion(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ulong op_flags_get_frame_last();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_frame_last(ulong value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_frame_rotate();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_frame_rotate(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_frames_repeat();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_frames_repeat(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ulong op_flags_get_frame_step();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_frame_step(ulong value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_fullscreen();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_fullscreen(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_hand();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_hand(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_hand_alpha_heatmap();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_hand_alpha_heatmap(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_hand_alpha_pose();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_hand_alpha_pose(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_hand_render();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_hand_render(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_hand_render_threshold();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_hand_render_threshold(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_hand_scale_number();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_hand_scale_number(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_hand_scale_range();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_hand_scale_range(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_hand_tracking();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_hand_tracking(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_heatmaps_scale();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_heatmaps_scale(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_heatmaps_add_parts();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_heatmaps_add_parts(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_heatmaps_add_bkg();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_heatmaps_add_bkg(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_heatmaps_add_PAFs();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_heatmaps_add_PAFs(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_keypoint_scale();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_keypoint_scale(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_identification();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_identification(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_ik_threads();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_ik_threads(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_logging_level();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_logging_level(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_maximize_positives();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_maximize_positives(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_no_gui_verbose();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_no_gui_verbose(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_num_gpu();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_num_gpu(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_num_gpu_start();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_num_gpu_start(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_number_people_max();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_number_people_max(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_part_candidates();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_part_candidates(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_part_to_show();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_part_to_show(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool op_flags_get_process_real_time();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_process_real_time(bool value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_profile_speed();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_profile_speed(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_render_pose();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_render_pose(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_render_threshold();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_render_threshold(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_scale_gap();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_scale_gap(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_scale_number();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_scale_number(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_tracking();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_tracking(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern int op_flags_get_write_coco_json_variant();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_coco_json_variant(int value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern double op_flags_get_write_video_fps();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_video_fps(double value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_camera_parameter_folder();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_camera_parameter_folder(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_camera_resolution();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_camera_resolution(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_face_net_resolution();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_face_net_resolution(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_hand_net_resolution();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_hand_net_resolution(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_image_dir();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_image_dir(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_ip_camera();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_ip_camera(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_model_folder();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_model_folder(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_model_pose();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_model_pose(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_net_resolution();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_net_resolution(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_output_resolution();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_output_resolution(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_udp_host();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_udp_host(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_udp_port();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_udp_port(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_bvh();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_bvh(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_coco_foot_json();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_coco_foot_json(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_coco_json();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_coco_json(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_heatmaps();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_heatmaps(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_heatmaps_format();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_heatmaps_format(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_images();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_images(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_images_format();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_images_format(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_json();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_json(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_keypoint();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_keypoint(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_keypoint_format();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_keypoint_format(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_video();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_video(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_write_video_adam();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_write_video_adam(byte[] value);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_flags_get_video();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_flags_set_video(byte[] value);

        }

    }

}
