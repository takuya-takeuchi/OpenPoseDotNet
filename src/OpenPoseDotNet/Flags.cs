using System.Text;

namespace OpenPoseDotNet
{

    public static class Flags
    {

        #region Properties

        public static int Body
        {
            get => NativeMethods.op_flags_get_body();
            set => NativeMethods.op_flags_set_body(value);
        }

        public static string CaffeModelPath
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_caffemodel_path();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_caffemodel_path(str);
            }
        }

        public static bool Face
        {
            get => NativeMethods.op_flags_get_face();
            set => NativeMethods.op_flags_set_face(value);
        }

        public static bool Hand
        {
            get => NativeMethods.op_flags_get_hand();
            set => NativeMethods.op_flags_set_hand(value);
        }

        public static bool Enable3D
        {
            get => NativeMethods.op_flags_get_3d();
            set => NativeMethods.op_flags_set_3d(value);
        }

        public static int Views3D
        {
            get => NativeMethods.op_flags_get_3d_views();
            set => NativeMethods.op_flags_set_3d_views(value);
        }

        public static int MinViews3D
        {
            get => NativeMethods.op_flags_get_3d_min_views();
            set => NativeMethods.op_flags_set_3d_min_views(value);
        }

        public static double AlphaHeatmap
        {
            get => NativeMethods.op_flags_get_alpha_heatmap();
            set => NativeMethods.op_flags_set_alpha_heatmap(value);
        }

        public static double AlphaPose
        {
            get => NativeMethods.op_flags_get_alpha_pose();
            set => NativeMethods.op_flags_set_alpha_pose(value);
        }

        public static int Camera
        {
            get => NativeMethods.op_flags_get_camera();
            set => NativeMethods.op_flags_set_camera(value);
        }

        public static double CliVerbose
        {
            get => NativeMethods.op_flags_get_cli_verbose();
            set => NativeMethods.op_flags_set_cli_verbose(value);
        }

        public static int Display
        {
            get => NativeMethods.op_flags_get_display();
            set => NativeMethods.op_flags_set_display(value);
        }

        public static bool DisableBlending
        {
            get => NativeMethods.op_flags_get_disable_blending();
            set => NativeMethods.op_flags_set_disable_blending(value);
        }

        public static double FaceAlphaHeatmap
        {
            get => NativeMethods.op_flags_get_face_alpha_heatmap();
            set => NativeMethods.op_flags_set_face_alpha_heatmap(value);
        }

        public static double FaceAlphaPose
        {
            get => NativeMethods.op_flags_get_face_alpha_pose();
            set => NativeMethods.op_flags_set_face_alpha_pose(value);
        }

        public static int FaceRender
        {
            get => NativeMethods.op_flags_get_face_render();
            set => NativeMethods.op_flags_set_face_render(value);
        }

        public static double FaceRenderThreshold
        {
            get => NativeMethods.op_flags_get_face_render_threshold();
            set => NativeMethods.op_flags_set_face_render_threshold(value);
        }

        public static bool FlirCamera
        {
            get => NativeMethods.op_flags_get_flir_camera();
            set => NativeMethods.op_flags_set_flir_camera(value);
        }

        public static int FlirCameraIndex
        {
            get => NativeMethods.op_flags_get_flir_camera_index();
            set => NativeMethods.op_flags_set_flir_camera_index(value);
        }

        public static ulong FrameFirst
        {
            get => NativeMethods.op_flags_get_frame_first();
            set => NativeMethods.op_flags_set_frame_first(value);
        }

        public static bool FrameFlip
        {
            get => NativeMethods.op_flags_get_frame_flip();
            set => NativeMethods.op_flags_set_frame_flip(value);
        }

        public static bool FrameUndistort
        {
            get => NativeMethods.op_flags_get_frame_undistort();
            set => NativeMethods.op_flags_set_frame_undistort(value);
        }

        public static ulong FrameLast
        {
            get => NativeMethods.op_flags_get_frame_last();
            set => NativeMethods.op_flags_set_frame_last(value);
        }

        public static int FrameRotate
        {
            get => NativeMethods.op_flags_get_frame_rotate();
            set => NativeMethods.op_flags_set_frame_rotate(value);
        }

        public static bool FramesRepeat
        {
            get => NativeMethods.op_flags_get_frames_repeat();
            set => NativeMethods.op_flags_set_frames_repeat(value);
        }

        public static ulong FrameStep
        {
            get => NativeMethods.op_flags_get_frame_step();
            set => NativeMethods.op_flags_set_frame_step(value);
        }

        public static double FpsMax
        {
            get => NativeMethods.op_flags_get_fps_max();
            set => NativeMethods.op_flags_set_fps_max(value);
        }

        public static bool FullScreen
        {
            get => NativeMethods.op_flags_get_fullscreen();
            set => NativeMethods.op_flags_set_fullscreen(value);
        }

        public static double HandAlphaHeatmap
        {
            get => NativeMethods.op_flags_get_hand_alpha_heatmap();
            set => NativeMethods.op_flags_set_hand_alpha_heatmap(value);
        }

        public static double HandAlphaPose
        {
            get => NativeMethods.op_flags_get_hand_alpha_pose();
            set => NativeMethods.op_flags_set_hand_alpha_pose(value);
        }

        public static int HandRender
        {
            get => NativeMethods.op_flags_get_hand_render();
            set => NativeMethods.op_flags_set_hand_render(value);
        }

        public static double HandRenderThreshold
        {
            get => NativeMethods.op_flags_get_hand_render_threshold();
            set => NativeMethods.op_flags_set_hand_render_threshold(value);
        }

        public static int HandScaleNumber
        {
            get => NativeMethods.op_flags_get_hand_scale_number();
            set => NativeMethods.op_flags_set_hand_scale_number(value);
        }

        public static double HandScaleRange
        {
            get => NativeMethods.op_flags_get_hand_scale_range();
            set => NativeMethods.op_flags_set_hand_scale_range(value);
        }

        public static bool Identification
        {
            get => NativeMethods.op_flags_get_identification();
            set => NativeMethods.op_flags_set_identification(value);
        }

        public static int IkThreads
        {
            get => NativeMethods.op_flags_get_ik_threads();
            set => NativeMethods.op_flags_set_ik_threads(value);
        }

        public static bool MaximizePositives
        {
            get => NativeMethods.op_flags_get_maximize_positives();
            set => NativeMethods.op_flags_set_maximize_positives(value);
        }

        public static bool NoGuiVerbose
        {
            get => NativeMethods.op_flags_get_no_gui_verbose();
            set => NativeMethods.op_flags_set_no_gui_verbose(value);
        }

        public static bool PartCandidates
        {
            get => NativeMethods.op_flags_get_part_candidates();
            set => NativeMethods.op_flags_set_part_candidates(value);
        }

        public static bool ProcessRealTime
        {
            get => NativeMethods.op_flags_get_process_real_time();
            set => NativeMethods.op_flags_set_process_real_time(value);
        }

        public static int NumGpu
        {
            get => NativeMethods.op_flags_get_num_gpu();
            set => NativeMethods.op_flags_set_num_gpu(value);
        }

        public static int NumGpuStart
        {
            get => NativeMethods.op_flags_get_num_gpu_start();
            set => NativeMethods.op_flags_set_num_gpu_start(value);
        }

        public static int NumberPeopleMax
        {
            get => NativeMethods.op_flags_get_number_people_max();
            set => NativeMethods.op_flags_set_number_people_max(value);
        }

        public static int PartToShow
        {
            get => NativeMethods.op_flags_get_part_to_show();
            set => NativeMethods.op_flags_set_part_to_show(value);
        }

        public static double RenderThreshold
        {
            get => NativeMethods.op_flags_get_render_threshold();
            set => NativeMethods.op_flags_set_render_threshold(value);
        }

        public static double ScaleGap
        {
            get => NativeMethods.op_flags_get_scale_gap();
            set => NativeMethods.op_flags_set_scale_gap(value);
        }

        public static double WriteVideoFps
        {
            get => NativeMethods.op_flags_get_write_video_fps();
            set => NativeMethods.op_flags_set_write_video_fps(value);
        }

        public static int RenderPose
        {
            get => NativeMethods.op_flags_get_render_pose();
            set => NativeMethods.op_flags_set_render_pose(value);
        }

        public static int ScaleNumber
        {
            get => NativeMethods.op_flags_get_scale_number();
            set => NativeMethods.op_flags_set_scale_number(value);
        }

        public static int Tracking
        {
            get => NativeMethods.op_flags_get_tracking();
            set => NativeMethods.op_flags_set_tracking(value);
        }
        
        public static double UpsamplingRatio
        {
            get => NativeMethods.op_flags_get_upsampling_ratio();
            set => NativeMethods.op_flags_set_upsampling_ratio(value);
        }

        public static int WriteCocoJsonVariant
        {
            get => NativeMethods.op_flags_get_write_coco_json_variant();
            set => NativeMethods.op_flags_set_write_coco_json_variant(value);
        }

        public static int FaceDetector
        {
            get => NativeMethods.op_flags_get_face_detector();
            set => NativeMethods.op_flags_set_face_detector(value);
        }

        public static int HandDetector
        {
            get => NativeMethods.op_flags_get_hand_detector();
            set => NativeMethods.op_flags_set_hand_detector(value);
        }

        public static int HeatmapsScale
        {
            get => NativeMethods.op_flags_get_heatmaps_scale();
            set => NativeMethods.op_flags_set_heatmaps_scale(value);
        }

        public static bool HeatmapsAddParts
        {
            get => NativeMethods.op_flags_get_heatmaps_add_parts();
            set => NativeMethods.op_flags_set_heatmaps_add_parts(value);
        }

        public static bool HeatmapsAddBackground
        {
            get => NativeMethods.op_flags_get_heatmaps_add_bkg();
            set => NativeMethods.op_flags_set_heatmaps_add_bkg(value);
        }

        public static bool HeatmapsAddPAFs
        {
            get => NativeMethods.op_flags_get_heatmaps_add_PAFs();
            set => NativeMethods.op_flags_set_heatmaps_add_PAFs(value);
        }

        public static int KeyPointScale
        {
            get => NativeMethods.op_flags_get_keypoint_scale();
            set => NativeMethods.op_flags_set_keypoint_scale(value);
        }

        public static bool DisableMultiThread
        {
            get => NativeMethods.op_flags_get_disable_multi_thread();
            set => NativeMethods.op_flags_set_disable_multi_thread(value);
        }

        public static int LoggingLevel
        {
            get => NativeMethods.op_flags_get_logging_level();
            set => NativeMethods.op_flags_set_logging_level(value);
        }

        public static string CameraParameterPath
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_camera_parameter_path();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_camera_parameter_path(str);
            }
        }

        public static string CameraResolution
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_camera_resolution();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_camera_resolution(str);
            }
        }

        public static string OutputResolution
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_output_resolution();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_output_resolution(str);
            }
        }

        public static string NetResolution
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_net_resolution();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_net_resolution(str);
            }
        }

        public static string FaceNetResolution
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_face_net_resolution();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_face_net_resolution(str);
            }
        }

        public static string HandNetResolution
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_hand_net_resolution();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_hand_net_resolution(str);
            }
        }

        public static string ImageDir
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_image_dir();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_image_dir(str);
            }
        }

        public static string IpCamera
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_ip_camera();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_ip_camera(str);
            }
        }

        public static string Video
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_video();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_video(str);
            }
        }

        public static string WriteKeyPoint
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_keypoint();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_keypoint(str);
            }
        }

        public static int ProfileSpeed
        {
            get => NativeMethods.op_flags_get_profile_speed();
            set => NativeMethods.op_flags_set_profile_speed(value);
        }

        public static string PrototxtPath
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_prototxt_path();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_prototxt_path(str);
            }
        }

        public static string ModelFolder
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_model_folder();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_model_folder(str);
            }
        }

        public static string ModelPose
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_model_pose();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_model_pose(str);
            }
        }

        public static string UdpHost
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_udp_host();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_udp_host(str);
            }
        }

        public static string UdpPort
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_udp_port();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_udp_port(str);
            }
        }

        public static string WriteBvh
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_bvh();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_bvh(str);
            }
        }

        public static string WriteCocoFootJson
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_coco_foot_json();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_coco_foot_json(str);
            }
        }

        public static string WriteCocoJson
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_coco_json();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_coco_json(str);
            }
        }

        public static string WriteHeatmaps
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_heatmaps();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_heatmaps(str);
            }
        }

        public static string WriteHeatmapsFormat
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_heatmaps_format();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_heatmaps_format(str);
            }
        }

        public static string WriteImages
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_images();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_images(str);
            }
        }

        public static string WriteImagesFormat
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_images_format();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_images_format(str);
            }
        }

        public static string WriteJson
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_json();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_json(str);
            }
        }

        public static string WriteKeyPointFormat
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_keypoint_format();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_keypoint_format(str);
            }
        }

        public static string WriteVideo
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_video();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_video(str);
            }
        }
        
        public static bool WriteVideoWithAudio
        {
            get => NativeMethods.op_flags_get_write_video_with_audio();
            set => NativeMethods.op_flags_set_write_video_with_audio(value);
        }

        public static string WriteVideoAdam
        {
            get
            {
                var stdstr = NativeMethods.op_flags_get_write_video_adam();
                var ret = StringHelper.FromStdString(stdstr, true);
                return ret;
            }
            set
            {
                var str = Encoding.UTF8.GetBytes(value ?? "");
                NativeMethods.op_flags_set_write_video_adam(str);
            }
        }

        #region ExampleOnly

        public static bool NoDisplay
        {
            get;
            set;
        }

        public static bool LatencyIsIrrelevantAndComputerWithLotsOfRam
        {
            get;
            set;
        }

        #endregion

        #endregion

    }

}