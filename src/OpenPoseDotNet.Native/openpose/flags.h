#ifndef _CPP_OP_FLAGS_H_
#define _CPP_OP_FLAGS_H_

#include "shared.h"
#include <openpose/flags.hpp>

#pragma region template

#define MAKE_FUNC(__NAME__, __TYPE__)\
DLLEXPORT __TYPE__ op_flags_get_##__NAME__##()\
{\
    return FLAGS_##__NAME__;\
}\
\
DLLEXPORT void op_flags_set_##__NAME__##(const __TYPE__ value)\
{\
    FLAGS_##__NAME__ = value;\
}\

#define MAKE_FUNC_STRING(__NAME__)\
DLLEXPORT std::string* op_flags_get_##__NAME__##()\
{\
    return new std::string(FLAGS_##__NAME__);\
}\
\
DLLEXPORT void op_flags_set_##__NAME__##(const char* value)\
{\
    std::string str(value);\
    FLAGS_##__NAME__ = str;\
}\

#pragma endregion template

MAKE_FUNC(3d, bool)
MAKE_FUNC(3d_min_views, int32_t)
MAKE_FUNC(3d_views, int32_t)
MAKE_FUNC(alpha_heatmap, double)
MAKE_FUNC(alpha_pose, double)
MAKE_FUNC(body_disable, bool)
MAKE_FUNC(camera, int32_t)
MAKE_FUNC(cli_verbose, double)
MAKE_FUNC(disable_blending, bool)
MAKE_FUNC(disable_multi_thread, bool)
MAKE_FUNC(display, int32_t)
MAKE_FUNC(face, bool)
MAKE_FUNC(face_alpha_heatmap, double)
MAKE_FUNC(face_alpha_pose, double)
MAKE_FUNC(face_render, int32_t)
MAKE_FUNC(face_render_threshold, double)
MAKE_FUNC(flir_camera, bool)
MAKE_FUNC(flir_camera_index, int32_t)
MAKE_FUNC(fps_max, double)
MAKE_FUNC(frame_first, uint64_t)
MAKE_FUNC(frame_flip, bool)
MAKE_FUNC(frame_keep_distortion, bool)
MAKE_FUNC(frame_last, uint64_t)
MAKE_FUNC(frame_rotate, int32_t)
MAKE_FUNC(frames_repeat, bool)
MAKE_FUNC(frame_step, uint64_t)
MAKE_FUNC(fullscreen, bool)
MAKE_FUNC(hand, bool)
MAKE_FUNC(hand_alpha_heatmap, double)
MAKE_FUNC(hand_alpha_pose, double)
MAKE_FUNC(hand_render, int32_t)
MAKE_FUNC(hand_render_threshold, double)
MAKE_FUNC(hand_scale_number, int32_t)
MAKE_FUNC(hand_scale_range, double)
MAKE_FUNC(hand_tracking, bool)
MAKE_FUNC(heatmaps_add_bkg, bool)
MAKE_FUNC(heatmaps_add_PAFs, bool)
MAKE_FUNC(heatmaps_add_parts, bool)
MAKE_FUNC(heatmaps_scale, int32_t)
MAKE_FUNC(identification, bool)
MAKE_FUNC(ik_threads, int32_t)
MAKE_FUNC(logging_level, int32_t)
MAKE_FUNC(keypoint_scale, int32_t)
MAKE_FUNC(maximize_positives, bool)
MAKE_FUNC(no_gui_verbose, bool)
MAKE_FUNC(num_gpu, int32_t)
MAKE_FUNC(num_gpu_start, int32_t)
MAKE_FUNC(number_people_max, int32_t)
MAKE_FUNC(part_candidates, bool)
MAKE_FUNC(part_to_show, int32_t)
MAKE_FUNC(process_real_time, bool)
MAKE_FUNC(profile_speed, int32_t)
MAKE_FUNC(render_pose, int32_t)
MAKE_FUNC(render_threshold, double)
MAKE_FUNC(scale_gap, double)
MAKE_FUNC(scale_number, int32_t)
MAKE_FUNC(tracking, int32_t)
MAKE_FUNC(write_coco_json_variant, int32_t)
MAKE_FUNC(write_video_fps, double)

MAKE_FUNC_STRING(camera_resolution)
MAKE_FUNC_STRING(camera_parameter_folder)
MAKE_FUNC_STRING(face_net_resolution)
MAKE_FUNC_STRING(hand_net_resolution)
MAKE_FUNC_STRING(image_dir)
MAKE_FUNC_STRING(ip_camera)
MAKE_FUNC_STRING(model_folder)
MAKE_FUNC_STRING(model_pose)
MAKE_FUNC_STRING(net_resolution)
MAKE_FUNC_STRING(output_resolution)
MAKE_FUNC_STRING(udp_host)
MAKE_FUNC_STRING(udp_port)
MAKE_FUNC_STRING(write_bvh)
MAKE_FUNC_STRING(write_coco_foot_json)
MAKE_FUNC_STRING(write_coco_json)
MAKE_FUNC_STRING(write_heatmaps)
MAKE_FUNC_STRING(write_heatmaps_format)
MAKE_FUNC_STRING(write_images)
MAKE_FUNC_STRING(write_images_format)
MAKE_FUNC_STRING(write_json)
MAKE_FUNC_STRING(write_keypoint)
MAKE_FUNC_STRING(write_keypoint_format)
MAKE_FUNC_STRING(write_video)
MAKE_FUNC_STRING(write_video_adam)
MAKE_FUNC_STRING(video)

#endif