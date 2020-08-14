class Config
{

   $ConfigurationArray =
   @(
      "Debug",
      "Release"
   )

   $TargetArray =
   @(
      "cpu",
      "cuda"
   )

   $PlatformArray =
   @(
      "desktop"
   )

   $ArchitectureArray =
   @(
      32,
      64
   )

   $CudaVersionArray =
   @(
      90,
      91,
      92,
      100,
      101
   )

   $CudaVersionHash =
   @{
      90 = "CUDA_PATH_V9_0";
      91 = "CUDA_PATH_V9_1";
      92 = "CUDA_PATH_V9_2";
      100 = "CUDA_PATH_V10_0";
      101 = "CUDA_PATH_V10_1"
   }

   $VisualStudioHash =
   @{
      2015 = "Visual Studio 14 2015";
      2017 = "Visual Studio 15 2017";
      2019 = "Visual Studio 16 2019"
   }
   
   static $BuildLibraryWindowsHash = 
   @{
      "OpenPoseDotNet.Native"     = "OpenPoseDotNetNative.dll";
   }
   
   static $BuildLibraryLinuxHash = 
   @{
      "OpenPoseDotNet.Native"     = "libOpenPoseDotNetNative.so";
   }
   
   static $BuildLibraryOSXHash = 
   @{
      "OpenPoseDotNet.Native"     = "libOpenPoseDotNetNative.dylib";
   }

   [string]   $_Root
   [string]   $_Configuration
   [int]      $_Architecture
   [string]   $_Target
   [string]   $_Platform
   [int]      $_CudaVersion
   [int]      $_VisualStudioVersion

   #***************************************
   # Arguments
   #  %1: Root directory of OpenPoseDotNet
   #  %2: Build Configuration (Release/Debug)
   #  %3: Target (cpu/cuda)
   #  %4: Architecture (32/64)
   #  %5: Platform (desktop)
   #  %6: Optional Argument
   #    Reserved
   #  %7: Optional Argument
   #    Reserved
   #***************************************
   Config(  [string]$Root,
            [string]$Configuration,
            [string]$Target,
            [int]   $Architecture,
            [string]$Platform,
            [string]$Option1,
            [string]$Option2
         )
   {
      if ($this.ConfigurationArray.Contains($Configuration) -eq $False)
      {
         $candidate = $this.ConfigurationArray -join "/"
         Write-Host "Error: Specify build configuration [${candidate}]" -ForegroundColor Red
         exit -1
      }

      if ($this.TargetArray.Contains($Target) -eq $False)
      {
         $candidate = $this.TargetArray -join "/"
         Write-Host "Error: Specify Target [${candidate}]" -ForegroundColor Red
         exit -1
      }

      if ($this.ArchitectureArray.Contains($Architecture) -eq $False)
      {
         $candidate = $this.ArchitectureArray -join "/"
         Write-Host "Error: Specify Architecture [${candidate}]" -ForegroundColor Red
         exit -1
      }

      if ($this.PlatformArray.Contains($Platform) -eq $False)
      {
         $candidate = $this.PlatformArray -join "/"
         Write-Host "Error: Specify Platform [${candidate}]" -ForegroundColor Red
         exit -1
      }

      if ($global:IsWindows)
      {
         switch ($Platform)
         {
            "desktop"
            {
               $this._VisualStudioVersion = [int]$Option1
               if ($this.VisualStudioHash.Contains($this._VisualStudioVersion) -ne $True)
               {
                  $candidate = $this.VisualStudioHash.Keys -join "/"
                  Write-Host "Error: Specify Visual Studio version [${candidate}]" -ForegroundColor Red
                  exit -1
               }
            }
         }
      }

      switch ($Target)
      {
         "cuda"
         {
            $this._CudaVersion = [int]$Option2
            if ($this.CudaVersionArray.Contains($this._CudaVersion) -ne $True)
            {
               $candidate = $this.CudaVersionArray -join "/"
               Write-Host "Error: Specify CUDA version [${candidate}]" -ForegroundColor Red
               exit -1
            }
         }
      }

      $this._Root = $Root
      $this._Configuration = $Configuration
      $this._Architecture = $Architecture
      $this._Target = $Target
      $this._Platform = $Platform
   }

   static [string] Base64Encode([string]$text)
   {
      $byte = ([System.Text.Encoding]::Default).GetBytes($text)
      return [Convert]::ToBase64String($byte)
   }

   static [string] Base64Decode([string]$base64)
   {
      $byte = [System.Convert]::FromBase64String($base64)
      return [System.Text.Encoding]::Default.GetString($byte)
   }

   static [hashtable] GetBinaryLibraryWindowsHash()
   {
      return [Config]::BuildLibraryWindowsHash
   }

   static [hashtable] GetBinaryLibraryOSXHash()
   {
      return [Config]::BuildLibraryOSXHash
   }

   static [hashtable] GetBinaryLibraryLinuxHash()
   {
      return [Config]::BuildLibraryLinuxHash
   }

   static [hashtable] GetBinaryLibraryIOSHash()
   {
      return [Config]::BuildLibraryIOSHash
   }

   [string] GetRootDir()
   {
      return $this._Root
   }

   [string] GetOpenPoseRootDir()
   {
      return   Join-Path $this.GetRootDir() src |
               Join-Path -ChildPath openpose
   }

   [string] GetNugetDir()
   {
      return   Join-Path $this.GetRootDir() nuget
   }

   [int] GetArchitecture()
   {
      return $this._Architecture
   }

   [string] GetConfigurationName()
   {
      return $this._Configuration
   }

   [string] GetArtifactDirectoryName()
   {
      $target = $this._Target
      $platform = $this._Platform
      $name = ""

      switch ($platform)
      {
         "desktop"
         {
            if ($target -eq "cuda")
            {
               $cudaVersion = $this._CudaVersion
               $name = "${target}-${cudaVersion}"
            }
            else
            {
               $name = $target
            }
         }
      }

      return $name
   }

   [string] GetOSName()
   {
      $os = ""

      if ($global:IsWindows)
      {
         $os = "win"
      }
      elseif ($global:IsMacOS)
      {
         $os = "osx"
      }
      elseif ($global:IsLinux)
      {
         $os = "linux"
      }
      else
      {
         Write-Host "Error: This plaform is not support" -ForegroundColor Red
         exit -1
      }

      return $os
   }

   [string] GetArchitectureName()
   {
      $arch = ""
      $target = $this._Target
      $architecture = $this._Architecture

      if ($target -eq "arm")
      {
         if ($architecture -eq 32)
         {
            $arch = "arm"
         }
         elseif ($architecture -eq 64)
         {
            $arch = "arm64"
         }
      }
      else
      {
         if ($architecture -eq 32)
         {
            $arch = "x86"
         }
         elseif ($architecture -eq 64)
         {
            $arch = "x64"
         }
      }

      return $arch
   }

   [string] GetTarget()
   {
      return $this._Target
   }

   [string] GetPlatform()
   {
      return $this._Platform
   }

   [string] GetBuildDirectoryName([string]$os="")
   {
      if (![string]::IsNullOrEmpty($os))
      {
         $osname = $os
      }
      elseif (![string]::IsNullOrEmpty($env:TARGETRID))
      {
         $osname = $env:TARGETRID
      }
      else
      {
         $osname = $this.GetOSName()
      }
      
      $target = $this._Target
      $platform = $this._Platform
      $architecture = $this.GetArchitectureName()

      switch ($platform)
      {
         "android"
         {
            $architecture = $this._AndroidABI
         }
      }

      if ($this._Configuration -eq "Debug")
      {
         return "build_${osname}_${platform}_${target}_${architecture}_d"
      }
      else
      {
         return "build_${osname}_${platform}_${target}_${architecture}"
      }
   }

   [string] GetVisualStudio()
   {
      return $this.VisualStudioHash[$this._VisualStudioVersion]
   }

   [string] GetVisualStudioArchitecture()
   {
      $architecture = $this._Architecture
      $target = $this._Target
      
      if ($target -eq "arm")
      {
         if ($architecture -eq 32)
         {
            return "ARM"
         }
         elseif ($architecture -eq 64)
         {
            return "ARM64"
         }
      }
      else
      {
         if ($architecture -eq 32)
         {
            return "Win32"
         }
         elseif ($architecture -eq 64)
         {
            return "x64"
         }
      }

      Write-Host "${architecture} and ${target} do not support" -ForegroundColor Red
      exit -1
   }

   [string] GetCUDAPath()
   {
      # CUDA_PATH_V10_0=C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v10.0
      # CUDA_PATH_V10_1=C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v10.1
      # CUDA_PATH_V9_0=C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v9.0
      # CUDA_PATH_V9_1=C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v9.1
      # CUDA_PATH_V9_2=C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v9.2
      $version = $this.CudaVersionHash[$this._CudaVersion]      
      return [environment]::GetEnvironmentVariable($version, 'Machine')
   }

   [string] GetAVXINSTRUCTIONS()
   {
      return "ON"
   }

   [string] GetSSE4INSTRUCTIONS()
   {
      return "ON"
   }

   [string] GetSSE2INSTRUCTIONS()
   {
      return "OFF"
   }

}

class ThirdPartyBuilder
{

   [Config]   $_Config

   ThirdPartyBuilder( [Config]$Config )
   {
      $this._Config = $Config
   }

   [string] BuildOpenPose([string]$useCuda)
   {
      $ret = ""
      $current = Get-Location

      try
      {         
         $Platform = $this._Config.GetPlatform()
         $Configuration = $this._Config.GetConfigurationName()

         switch ($Platform)
         {
            "desktop"
            {
               Write-Host "Start Build openpose" -ForegroundColor Green

               if ($useCuda -eq "ON")
               {
                  $cudaPath = $this._Config.GetCUDAPath()
                  if (!(Test-Path $cudaPath))
                  {
                     Write-Host "Error: '${cudaPath}' does not found" -ForegroundColor Red
                     exit -1
                  }

                  $env:CUDA_PATH="${cudaPath}"
                  $env:PATH="$env:CUDA_PATH\bin;$env:CUDA_PATH\libnvvp;$ENV:PATH"
                  Write-Host "Info: CUDA_PATH: ${env:CUDA_PATH}" -ForegroundColor Green
               }

               $openposeDir = $this._Config.GetOpenPoseRootDir()
               $openposeTarget = Join-Path $current openpose
               New-Item $openposeTarget -Force -ItemType Directory
               Set-Location $openposeTarget
               $current2 = Get-Location
               $installDir = Join-Path $current2 install
               $ret = $installDir

               if ($global:IsWindows)
               {
                  $vs = $this._Config.GetVisualStudio()
                  $vsarc = $this._Config.GetVisualStudioArchitecture()

                  Write-Host "   cmake -G $vs -A $vsarc -D CMAKE_BUILD_TYPE=$Configuration `
         -D USE_CUDA:BOOL=$useCuda `
         $openposeDir" -ForegroundColor Yellow
                  cmake -G $vs -A $vsarc -T host=x64 `
                        -D USE_CUDA:BOOL=$useCuda `
                        $openposeDir
                  Write-Host "   cmake --build . --config $Configuration" -ForegroundColor Yellow
                  cmake --build . --config $Configuration
               }
               elseif ($global:IsMacOS)
               {
                  # $env:vecLib_INCLUDE_DIR="/Applications/Xcode.app/Contents/Developer/Platforms/MacOSX.platform/Developer/SDKs/MacOSX.sdk/System/Library/Frameworks/Accelerate.framework/Versions/Current/Frameworks/vecLib.framework/Headers/"
                  Write-Host "   cmake -D CMAKE_BUILD_TYPE=$Configuration `
         -D USE_CUDA:BOOL=$useCuda `
         $openposeDir" -ForegroundColor Yellow
                  cmake -D CMAKE_BUILD_TYPE=$Configuration `
                        -D USE_CUDA:BOOL=$useCuda `
                        $openposeDir
                  Write-Host "   cmake --build . --config $Configuration" -ForegroundColor Yellow
                  cmake --build . --config $Configuration
               }  
               else
               {
                  Write-Host "   cmake -D CMAKE_BUILD_TYPE=$Configuration `
         -D USE_CUDA:BOOL=$useCuda `
         $openposeDir" -ForegroundColor Yellow
                  cmake -D CMAKE_BUILD_TYPE=$Configuration `
                        -D USE_CUDA:BOOL=$useCuda `
                        $openposeDir
                  Write-Host "   cmake --build . --config $Configuration" -ForegroundColor Yellow
                  cmake --build . --config $Configuration
               }               
            }
         }         
      }
      finally
      {
         Set-Location $current
         Write-Host "End Build openpose" -ForegroundColor Green
      }

      return $ret
   }
}

function ConfigCPU([Config]$Config)
{
   $Builder = [ThirdPartyBuilder]::new($Config)
   
   # Build openpose
   $installOpenPoseDir = $Builder.BuildOpenPose("OFF")

   $openposeDir = $Config.GetOpenPoseRootDir()

   # Build OpenPoseDotNet.Native
   Write-Host "Start Build OpenPoseDotNet.Native" -ForegroundColor Green
   if ($IsWindows)
   {
      $vs = $Config.GetVisualStudio()
      $vsarc = $Config.GetVisualStudioArchitecture()

      Write-Host "   cmake -G "$vs" -A $vsarc -T host=x64 `
         -D BUILD_SHARED_LIBS=ON `
         .." -ForegroundColor Yellow
      cmake -G "$vs" -A $vsarc -T host=x64 `
            ..
   }
   else
   {
      $env:OpenCV_DIR = $installOpenCVDir
      Write-Host "   cmake -D BUILD_SHARED_LIBS=ON `
         .." -ForegroundColor Yellow
      cmake -D BUILD_SHARED_LIBS=ON `
            ..
   }
}

function ConfigCUDA([Config]$Config)
{
   $Builder = [ThirdPartyBuilder]::new($Config)
   
   # Build openpose
   $installOpenPoseDir = $Builder.BuildOpenPose("ON")

   $openposeDir = $Config.GetOpenPoseRootDir()

   # Build OpenPoseDotNet.Native
   Write-Host "Start Build OpenPoseDotNet.Native" -ForegroundColor Green
   if ($IsWindows)
   {
      $vs = $Config.GetVisualStudio()
      $vsarc = $Config.GetVisualStudioArchitecture()

      $env:CUDA_PATH="${cudaPath}"
      $env:PATH="$env:CUDA_PATH\bin;$env:CUDA_PATH\libnvvp;$ENV:PATH"
      Write-Host "Info: CUDA_PATH: ${env:CUDA_PATH}" -ForegroundColor Green

      Write-Host "   cmake -G "$vs" -A $vsarc -T host=x64 `
         -D BUILD_SHARED_LIBS=ON `
         .." -ForegroundColor Yellow
      cmake -G "$vs" -A $vsarc -T host=x64 `
            -D BUILD_SHARED_LIBS=ON `
            ..
   }
   else
   {
      $env:OpenCV_DIR = $installOpenCVDir
      Write-Host "   cmake -D BUILD_SHARED_LIBS=ON `
         .." -ForegroundColor Yellow
      cmake -D BUILD_SHARED_LIBS=ON `
            ..
   }
}

function Build([Config]$Config)
{
   $Current = Get-Location

   $Output = $Config.GetBuildDirectoryName("")
   if ((Test-Path $Output) -eq $False)
   {
      New-Item $Output -ItemType Directory
   }

   Set-Location -Path $Output

   $Target = $Config.GetTarget()
   $Platform = $Config.GetPlatform()

   switch ($Platform)
   {
      "desktop"
      {
         switch ($Target)
         {
            "cpu"
            {
               ConfigCPU $Config
            }
            "cuda"
            {
               ConfigCUDA $Config
            }
         }
      }
   }

   cmake --build . --config $Config.GetConfigurationName()

   # Copy prebuild binaries
   if ($IsWindows)
   {
      $outputDirectory = Get-Location

      $Configuration = $Config.GetConfigurationName()
      $dst = Join-Path ${outputDirectory} ${Configuration}

      $bin = Join-Path ${outputDirectory} openpose | `
             Join-Path -ChildPath bin | `
             Join-Path -ChildPath "*"
      $openpose = Join-Path ${outputDirectory} openpose | `
                  Join-Path -ChildPath x64 | `
                  Join-Path -ChildPath ${Configuration} | `
                  Join-Path -ChildPath openpose*.dll

      Write-Host "Copy PreBuild openpose binaries" -ForegroundColor Green
      Copy-Item ${bin} ${dst}

      Write-Host "Copy openpose binary" -ForegroundColor Green
      Copy-Item ${openpose} ${dst}
   }

   # Move to Root directory
   Set-Location -Path $Current
}

function CopyToArtifact()
{
   Param([string]$srcDir, [string]$build, [string]$libraryName, [string]$dstDir, [string]$rid, [string]$configuration="")

   if ($configuration)
   {
      $binary = Join-Path ${srcDir} ${build}  | `
               Join-Path -ChildPath ${configuration} | `
               Join-Path -ChildPath ${libraryName}
   }
   else
   {
      $binary = Join-Path ${srcDir} ${build}  | `
               Join-Path -ChildPath ${libraryName}
   }

   $output = Join-Path $dstDir runtimes | `
            Join-Path -ChildPath ${rid} | `
            Join-Path -ChildPath native

   if (!(Test-Path $output))
   {
      Write-Host "Destination: ${output} is not found" -ForegroundColor Red
      exit -1
   }

   $output = Join-Path $output $libraryName

   Write-Host "Copy ${libraryName} to ${output}" -ForegroundColor Green
   Copy-Item ${binary} ${output}
}

function CopyDependenciesToArtifact()
{
   Param([string]$srcDir, [string]$build, [string]$libraryName, [string]$dstDir, [string]$rid, [string]$configuration="")

   if ($configuration)
   {
      $baseDir = Join-Path ${srcDir} ${build} | `
                 Join-Path -ChildPath ${configuration}
   }
   else
   {
      $baseDir = Join-Path ${srcDir} ${build}
   }

   $output = Join-Path $dstDir runtimes | `
             Join-Path -ChildPath ${rid} | `
             Join-Path -ChildPath native

   if (!(Test-Path $output))
   {
      Write-Host "Destination: ${output} is not found" -ForegroundColor Red
      exit -1
   }

   if ($global:IsWindows)
   {
      $os = "win"
   }
   elseif ($global:IsMacOS)
   {
      $targetDirectories =
      @(
         "openpose/caffe/lib",
         "openpose/src/openpose"
      )

      foreach ($target in $targetDirectories)
      {
         $libs = Join-Path $baseDir $target | `
                 Join-Path -ChildPath "*.dylib"

         Write-Host "Copy ${libs} to ${output}" -ForegroundColor Green
         Copy-Item ${libs} ${output}
      }
   }
   elseif ($global:IsLinux)
   {
   }
}