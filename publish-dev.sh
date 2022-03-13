#!/usr/bin/env bash

rm -rf ./*/bin ./*/obj ./build

VERSION=$(cat VERSION)-$(date +%s)

dotnet.exe publish BarLauncher.Volume.Wox/BarLauncher.Volume.Wox.csproj -c Debug -p:Version=${VERSION}
(cd build/BarLauncher.Volume.Wox/bin/Debug/net48/publish; zip -r ../../../../../../../BarLauncher-Volume-${VERSION}.wox .)

dotnet.exe publish BarLauncher.Volume.Flow.Launcher/BarLauncher.Volume.Flow.Launcher.csproj -c Debug -p:Version=${VERSION}
(cd build/BarLauncher.Volume.Flow.Launcher/bin/Debug/net5.0-windows/publish; zip -r ../../../../../../../BarLauncher-Volume-${VERSION}.zip .)
