using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_3d();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_3d(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_3d_min_views();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_3d_min_views(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_3d_views();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_3d_views(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_alpha_heatmap();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_alpha_heatmap(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_alpha_pose();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_alpha_pose(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_body_disable();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_body_disable(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_caffemodel_path();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_caffemodel_path(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_camera();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_camera(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_cli_verbose();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_cli_verbose(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_disable_blending();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_disable_blending(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_disable_multi_thread();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_disable_multi_thread(bool value);
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_display();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_display(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_face();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_face(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_face_alpha_heatmap();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_face_alpha_heatmap(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_face_alpha_pose();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_face_alpha_pose(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_face_render();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_face_render(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_face_render_threshold();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_face_render_threshold(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_flir_camera();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_flir_camera(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_flir_camera_index();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_flir_camera_index(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_fps_max();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_fps_max(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ulong op_flags_get_frame_first();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_frame_first(ulong value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_frame_flip();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_frame_flip(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_frame_undistort();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_frame_undistort(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ulong op_flags_get_frame_last();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_frame_last(ulong value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_frame_rotate();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_frame_rotate(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_frames_repeat();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_frames_repeat(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ulong op_flags_get_frame_step();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_frame_step(ulong value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_fullscreen();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_fullscreen(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_hand();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_hand(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_hand_alpha_heatmap();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_hand_alpha_heatmap(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_hand_alpha_pose();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_hand_alpha_pose(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_hand_render();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_hand_render(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_hand_render_threshold();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_hand_render_threshold(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_hand_scale_number();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_hand_scale_number(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_hand_scale_range();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_hand_scale_range(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_heatmaps_scale();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_heatmaps_scale(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_face_detector();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_face_detector(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_hand_detector();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_hand_detector(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_heatmaps_add_parts();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_heatmaps_add_parts(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_heatmaps_add_bkg();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_heatmaps_add_bkg(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_heatmaps_add_PAFs();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_heatmaps_add_PAFs(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_keypoint_scale();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_keypoint_scale(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_identification();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_identification(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_ik_threads();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_ik_threads(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_logging_level();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_logging_level(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_maximize_positives();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_maximize_positives(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_no_gui_verbose();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_no_gui_verbose(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_num_gpu();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_num_gpu(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_num_gpu_start();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_num_gpu_start(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_number_people_max();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_number_people_max(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_part_candidates();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_part_candidates(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_part_to_show();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_part_to_show(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_process_real_time();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_process_real_time(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_profile_speed();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_profile_speed(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_render_pose();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_render_pose(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_render_threshold();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_render_threshold(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_scale_gap();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_scale_gap(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_scale_number();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_scale_number(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_tracking();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_tracking(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int op_flags_get_write_coco_json_variant();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_coco_json_variant(int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double op_flags_get_write_video_fps();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_video_fps(double value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_camera_parameter_path();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_camera_parameter_path(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_camera_resolution();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_camera_resolution(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_face_net_resolution();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_face_net_resolution(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_hand_net_resolution();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_hand_net_resolution(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_image_dir();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_image_dir(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_ip_camera();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_ip_camera(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_prototxt_path();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_prototxt_path(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_model_folder();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_model_folder(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_model_pose();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_model_pose(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_net_resolution();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_net_resolution(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_output_resolution();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_output_resolution(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_udp_host();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_udp_host(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_udp_port();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_udp_port(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_bvh();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_bvh(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_coco_foot_json();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_coco_foot_json(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_coco_json();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_coco_json(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_heatmaps();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_heatmaps(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_heatmaps_format();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_heatmaps_format(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_images();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_images(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_images_format();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_images_format(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_json();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_json(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_keypoint();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_keypoint(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_keypoint_format();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_keypoint_format(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_video();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_video(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_write_video_adam();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_video_adam(byte[] value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool op_flags_get_write_video_with_audio();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_write_video_with_audio(bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr op_flags_get_video();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void op_flags_set_video(byte[] value);

    }

}
