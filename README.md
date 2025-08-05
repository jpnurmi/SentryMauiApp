# SentryMauiApp

First, find the device id with:
```sh
xcrun xctrace list devices
```

Then, do a clean build, and run the app with `Sentry.Maui` pinned at version `[5.5.1]`:
```sh
dotnet clean -c Release
dotnet build -c Release --framework net9.0-ios18.0 /t:Run /p:RuntimeIdentifier=iossimulator-arm64 /p:_DeviceName=:v2:udid=<DeviceId>
[...]
[Sentry] [debug] [SentrySDK:209] Starting SDK...
[...]
```

Check Sentry Cocoa bundle version (expected 8.39.0):
```sh
plutil -convert xml1 -o - obj/Release/net9.0-ios18.0/iossimulator-arm64/Sentry.Bindings.Cocoa.resources.zip/Sentry-Dynamic.xcframework/ios-arm64_x86_64-simulator/Sentry.framework/Info.plist | grep CFBundleVersion -A1

        <key>CFBundleVersion</key>
        <string>8.39.0</string>
```

Next, upgrade `Sentry.Maui` to `[5.6.0]`:
```sh
$ dotnet add package Sentry.Maui --version "[5.6.0]"
```

Finally, try building and running the app _without cleaning_ the intermediate output directory:
```sh
$ dotnet build -c Release --framework net9.0-ios18.0 /t:Run /p:RuntimeIdentifier=iossimulator-arm64 /p:_DeviceName=:v2:udid=<DeviceId>
[...]
  SentryMauiApp net9.0-ios18.0 failed with 1 error(s) (652.1s) → bin/Release/net9.0-ios18.0/iossimulator-arm64/SentryMauiApp.dll
    /usr/local/share/dotnet/packs/Microsoft.iOS.Sdk.net9.0_18.0/18.0.9617/targets/Xamarin.Shared.Sdk.targets(1663,3): error :
      clang++ exited with code 1:
      Undefined symbols for architecture arm64:
        "_OBJC_CLASS_$_SentryEventDecodable", referenced from:
            <initial-undefines>
        "_OBJC_CLASS_$__TtC6Sentry14SentryFeedback", referenced from:
            <initial-undefines>
      ld: symbol(s) not found for architecture arm64
      clang++: error: linker command failed with exit code 1 (use -v to see invocation)

Build failed with 1 error(s) in 652.2s
```

Also, check Sentry Cocoa bundle version (expected 8.46.0):
```sh
$ plutil -convert xml1 -o - obj/Release/net9.0-ios18.0/iossimulator-arm64/Sentry.Bindings.Cocoa.resources.zip/Sentry-Dynamic.xcframework/ios-arm64_x86_64-simulator/Sentry.framework/Info.plist | grep CFBundleVersion -A1

        <key>CFBundleVersion</key>
        <string>8.39.0</string>
```
