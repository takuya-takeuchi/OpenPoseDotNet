#***************************************
#Arguments
#%1: Build Configuration (Release/Debug)
#%2: Build Directory (build_win_desktop_<cpu/cuda>_x64)
#***************************************
Param
(
   [Parameter(
   Mandatory=$True,
   Position = 1
   )][string]
   $Configuration,

   [Parameter(
   Mandatory=$True,
   Position = 2
   )][string]
   $Directory
)

# build path
$SrcPath = $PSScriptRoot
$TutorialAddModuleRoot = Split-Path $SrcPath -Parent
$ExamplesRoot = Split-Path $TutorialAddModuleRoot -Parent
$OpenPoseDotNetRoot = Split-Path $ExamplesRoot -Parent
$SrcRoot = Join-Path $OpenPoseDotNetRoot src
$OpenPoseRoot = Join-Path $SrcRoot openpose
$OpenPoseDotNetNativeRoot = Join-Path $SrcRoot OpenPoseDotNet.Native
$BuildDir = Join-Path $OpenPoseDotNetNativeRoot $Directory
$OpenPoseDotNetNativeBuildDir = Join-Path $BuildDir $Configuration
$OpenPoseBuildDir = Join-Path $BuildDir openpose |
                    Join-Path -child x64 |
                    Join-Path -child $Configuration

$AppDir = Join-Path $SrcPath bin |
          Join-Path -child $Configuration |
          Join-Path -child netcoreapp2.0
New-Item $AppDir -Force -ItemType Directory | Out-Null

# check path
if (!(Test-Path $OpenPoseDotNetNativeBuildDir))
{
   Write-Host "[Error] '$OpenPoseDotNetNativeBuildDir' does not exist" -ForegroundColor Red
   exit
}
if (!(Test-Path $OpenPoseBuildDir))
{
   Write-Host "[Error] '$OpenPoseBuildDir' does not exist" -ForegroundColor Red
   exit
}

# create symlink
$TestDataDriectories =
@(
   "models",
   "examples"
)
$OpenPoseLibraries =
@(
   "openpose.dll"
)
$OpenPoseDotNetNativeLibraries =
@(
   "OpenPoseDotNetNative.dll"
)
$OpenPoseDependenciesLibraries =
@(
   "boost_filesystem-vc141-mt-x64-1_69.dll",
   "boost_filesystem-vc141-mt-gd-x64-1_69.dll",
   "boost_thread-vc141-mt-gd-x64-1_69.dll",
   "boost_thread-vc141-mt-x64-1_69.dll",
   "caffe.dll",
   "caffehdf5.dll",
   "caffehdf5_hl.dll",
   "caffezlib1.dll",
   "cublas64_100.dll",
   "cudart64_100.dll",
   "cudnn64_7.dll",
   "curand64_100.dll",
   "gflags.dll",
   "gflagsd.dll",
   "glog.dll",
   "glogd.dll",
   "libgcc_s_seh-1.dll",
   "libgfortran-3.dll",
   "libopenblas.dll",
   "libquadmath-0.dll",
   "opencv_videoio_ffmpeg420_64.dll",
   "opencv_world420.dll",
   "opencv_world420d.dll",
   "VCRUNTIME140.dll"
)

# create symlink
function create-symlink($Targets, $SrcDir, $DstDir)
{
   foreach ($Target in $Targets)
   {
      $src = Join-Path $SrcDir $Target
      $dst = Join-Path $DstDir $Target

      if (!(Test-Path $src))
      {
         Write-Host "[Error] '$src' does not exist" -ForegroundColor Red
         exit
      }

      if (Test-Path $dst)
      {
         Remove-Item $dst
      }

      New-Item -Path "${DstDir}" -Value "${src}" -Name "${Target}" -ItemType SymbolicLink | Out-Null
   }
}

create-symlink $TestDataDriectories           $OpenPoseRoot                 $SrcPath
create-symlink $OpenPoseLibraries             $OpenPoseBuildDir             $AppDir
create-symlink $OpenPoseDotNetNativeLibraries $OpenPoseDotNetNativeBuildDir $AppDir
create-symlink $OpenPoseDependenciesLibraries $OpenPoseDotNetNativeBuildDir $AppDir