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
$ExamplesRoot = $PSScriptRoot
$OpenPoseDotNetRoot = Split-Path $ExamplesRoot -Parent
$SrcRoot = Join-Path $OpenPoseDotNetRoot src
$OpenPoseRoot = Join-Path $SrcRoot openpose
$OpenPoseDotNetNativeRoot = Join-Path $SrcRoot OpenPoseDotNet.Native
$BuildDir = Join-Path $OpenPoseDotNetNativeRoot $Directory
$OpenPoseDotNetNativeBuildDir = Join-Path $BuildDir $Configuration
$OpenPoseBuildDir = Join-Path $BuildDir openpose |
                    Join-Path -child x64 |
                    Join-Path -child $Configuration

$projects = Get-ChildItem ${ExamplesRoot} -Recurse -Filter *.csproj
foreach ($SrcPath in $projects)
{
   $SrcPath = Split-Path -Parent $SrcPath   
   Write-Host "Project: ${SrcPath}" -ForegroundColor Blue
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
   )

   $binaries = Get-ChildItem ${OpenPoseDotNetNativeBuildDir} -Filter *.dll
   foreach ($binary in $binaries)
   {
      $OpenPoseDependenciesLibraries += (Split-Path -Leaf $binary)
   }

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
}