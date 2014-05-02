Imports System.Text.RegularExpressions
Imports Ionic.Zip
Imports System.IO


Public Class MainForm
    Dim AppNames As New Dictionary(Of String, String)
    Dim AppIcons As New List(Of String)
    Dim FileToCheck As String = ""
    Function GetProcessText(ByVal process As String, ByVal param As String, ByVal workingDir As String) As String
        Dim p As Process = New Process
        p.StartInfo.FileName = process
        If Not (workingDir = "") Then
            p.StartInfo.WorkingDirectory = workingDir
        End If
        p.StartInfo.Arguments = param
        p.StartInfo.UseShellExecute = False
        p.StartInfo.StandardOutputEncoding = System.Text.UTF8Encoding.UTF8
        p.StartInfo.RedirectStandardOutput = True
        p.Start()
        Dim output As String = p.StandardOutput.ReadToEnd
        p.WaitForExit()
        Return output
    End Function

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If there's a better way, fix it
        Dim AndroidCodeNames As New Dictionary(Of Integer, String)
        Dim PermissionDefinition As New Dictionary(Of String, String)
        PermissionDefinition("ACCESS_CHECKIN_PROPERTIES") = "Allows read/write access to the ""properties"" table in the checkin database, to change values that get uploaded."
        PermissionDefinition("ACCESS_COARSE_LOCATION") = "Allows an app to access approximate location derived from network location sources such as cell towers and Wi-Fi."
        PermissionDefinition("ACCESS_FINE_LOCATION") = "Allows an app to access precise location from location sources such as GPS, cell towers, and Wi-Fi."
        PermissionDefinition("ACCESS_LOCATION_EXTRA_COMMANDS") = "Allows an application to access extra location provider commands"
        PermissionDefinition("ACCESS_MOCK_LOCATION") = "Allows an application to create mock location providers for testing"
        PermissionDefinition("ACCESS_NETWORK_STATE") = "Allows applications to access information about networks"
        PermissionDefinition("ACCESS_SURFACE_FLINGER") = "Allows an application to use SurfaceFlinger's low level features."
        PermissionDefinition("ACCESS_WIFI_STATE") = "Allows applications to access information about Wi-Fi networks"
        PermissionDefinition("ACCOUNT_MANAGER") = "Allows applications to call into AccountAuthenticators."
        PermissionDefinition("ADD_VOICEMAIL") = "Allows an application to add voicemails into the system."
        PermissionDefinition("AUTHENTICATE_ACCOUNTS") = "Allows an application to act as an AccountAuthenticator for the AccountManager"
        PermissionDefinition("BATTERY_STATS") = "Allows an application to collect battery statistics"
        PermissionDefinition("BIND_ACCESSIBILITY_SERVICE") = "Must be required by an AccessibilityService, to ensure that only the system can bind to it."
        PermissionDefinition("BIND_APPWIDGET") = "Allows an application to tell the AppWidget service which application can access AppWidget's data."
        PermissionDefinition("BIND_DEVICE_ADMIN") = "Must be required by device administration receiver, to ensure that only the system can interact with it."
        PermissionDefinition("BIND_INPUT_METHOD") = "Must be required by an InputMethodService, to ensure that only the system can bind to it."
        PermissionDefinition("BIND_NFC_SERVICE") = "Must be required by a HostApduService or OffHostApduService to ensure that only the system can bind to it."
        PermissionDefinition("BIND_NOTIFICATION_LISTENER_SERVICE") = "Must be required by an NotificationListenerService, to ensure that only the system can bind to it."
        PermissionDefinition("BIND_PRINT_SERVICE") = "Must be required by a PrintService, to ensure that only the system can bind to it."
        PermissionDefinition("BIND_REMOTEVIEWS") = "Must be required by a RemoteViewsService, to ensure that only the system can bind to it."
        PermissionDefinition("BIND_TEXT_SERVICE") = "Must be required by a TextService (e.g."
        PermissionDefinition("BIND_VPN_SERVICE") = "Must be required by a VpnService, to ensure that only the system can bind to it."
        PermissionDefinition("BIND_WALLPAPER") = "Must be required by a WallpaperService, to ensure that only the system can bind to it."
        PermissionDefinition("BLUETOOTH") = "Allows applications to connect to paired bluetooth devices"
        PermissionDefinition("BLUETOOTH_ADMIN") = "Allows applications to discover and pair bluetooth devices"
        PermissionDefinition("BLUETOOTH_PRIVILEGED") = "Allows applications to pair bluetooth devices without user interaction."
        PermissionDefinition("BRICK") = "Required to be able to disable the device (very dangerous!)."
        PermissionDefinition("BROADCAST_PACKAGE_REMOVED") = "Allows an application to broadcast a notification that an application package has been removed."
        PermissionDefinition("BROADCAST_SMS") = "Allows an application to broadcast an SMS receipt notification."
        PermissionDefinition("BROADCAST_STICKY") = "Allows an application to broadcast sticky intents."
        PermissionDefinition("BROADCAST_WAP_PUSH") = "Allows an application to broadcast a WAP PUSH receipt notification."
        PermissionDefinition("CALL_PHONE") = "Allows an application to initiate a phone call without going through the Dialer user interface for the user to confirm the call being placed."
        PermissionDefinition("CALL_PRIVILEGED") = "Allows an application to call any phone number, including emergency numbers, without going through the Dialer user interface for the user to confirm the call being placed."
        PermissionDefinition("CAMERA") = "Required to be able to access the camera device."
        PermissionDefinition("CAPTURE_AUDIO_OUTPUT") = "Allows an application to capture audio output."
        PermissionDefinition("CAPTURE_SECURE_VIDEO_OUTPUT") = "Allows an application to capture secure video output."
        PermissionDefinition("CAPTURE_VIDEO_OUTPUT") = "Allows an application to capture video output."
        PermissionDefinition("CHANGE_COMPONENT_ENABLED_STATE") = "Allows an application to change whether an application component (other than its own) is enabled or not."
        PermissionDefinition("CHANGE_CONFIGURATION") = "Allows an application to modify the current configuration, such as locale."
        PermissionDefinition("CHANGE_NETWORK_STATE") = "Allows applications to change network connectivity state"
        PermissionDefinition("CHANGE_WIFI_MULTICAST_STATE") = "Allows applications to enter Wi-Fi Multicast mode"
        PermissionDefinition("CHANGE_WIFI_STATE") = "Allows applications to change Wi-Fi connectivity state"
        PermissionDefinition("CLEAR_APP_CACHE") = "Allows an application to clear the caches of all installed applications on the device."
        PermissionDefinition("CLEAR_APP_USER_DATA") = "Allows an application to clear user data."
        PermissionDefinition("CONTROL_LOCATION_UPDATES") = "Allows enabling/disabling location update notifications from the radio."
        PermissionDefinition("DELETE_CACHE_FILES") = "Allows an application to delete cache files."
        PermissionDefinition("DELETE_PACKAGES") = "Allows an application to delete packages."
        PermissionDefinition("DEVICE_POWER") = "Allows low-level access to power management."
        PermissionDefinition("DIAGNOSTIC") = "Allows applications to RW to diagnostic resources."
        PermissionDefinition("DISABLE_KEYGUARD") = "Allows applications to disable the keyguard"
        PermissionDefinition("DUMP") = "Allows an application to retrieve state dump information from system services."
        PermissionDefinition("EXPAND_STATUS_BAR") = "Allows an application to expand or collapse the status bar."
        PermissionDefinition("FACTORY_TEST") = "Run as a manufacturer test application, running as the root user."
        PermissionDefinition("FLASHLIGHT") = "Allows access to the flashlight"
        PermissionDefinition("FORCE_BACK") = "Allows an application to force a BACK operation on whatever is the top activity."
        PermissionDefinition("GET_ACCOUNTS") = "Allows access to the list of accounts in the Accounts Service"
        PermissionDefinition("GET_PACKAGE_SIZE") = "Allows an application to find out the space used by any package."
        PermissionDefinition("GET_TASKS") = "Allows an application to get information about the currently or recently running tasks."
        PermissionDefinition("GET_TOP_ACTIVITY_INFO") = "Allows an application to retrieve private information about the current top activity, such as any assist context it can provide."
        PermissionDefinition("GLOBAL_SEARCH") = "This permission can be used on content providers to allow the global search system to access their data."
        PermissionDefinition("HARDWARE_TEST") = "Allows access to hardware peripherals."
        PermissionDefinition("INJECT_EVENTS") = "Allows an application to inject user events (keys, touch, trackball) into the event stream and deliver them to ANY window."
        PermissionDefinition("INSTALL_LOCATION_PROVIDER") = "Allows an application to install a location provider into the Location Manager."
        PermissionDefinition("INSTALL_PACKAGES") = "Allows an application to install packages."
        PermissionDefinition("INSTALL_SHORTCUT") = "Allows an application to install a shortcut in Launcher"
        PermissionDefinition("INTERNAL_SYSTEM_WINDOW") = "Allows an application to open windows that are for use by parts of the system user interface."
        PermissionDefinition("INTERNET") = "Allows applications to open network sockets."
        PermissionDefinition("KILL_BACKGROUND_PROCESSES") = "Allows an application to call killBackgroundProcesses(String)."
        PermissionDefinition("LOCATION_HARDWARE") = "Allows an application to use location features in hardware, such as the geofencing api."
        PermissionDefinition("MANAGE_ACCOUNTS") = "Allows an application to manage the list of accounts in the AccountManager"
        PermissionDefinition("MANAGE_APP_TOKENS") = "Allows an application to manage (create, destroy, Z-order) application tokens in the window manager."
        PermissionDefinition("MANAGE_DOCUMENTS") = "Allows an application to manage access to documents, usually as part of a document picker."
        PermissionDefinition("MASTER_CLEAR") = "Not for use by third-party applications."
        PermissionDefinition("MEDIA_CONTENT_CONTROL") = "Allows an application to know what content is playing and control its playback."
        PermissionDefinition("MODIFY_AUDIO_SETTINGS") = "Allows an application to modify global audio settings"
        PermissionDefinition("MODIFY_PHONE_STATE") = "Allows modification of the telephony state - power on, mmi, etc."
        PermissionDefinition("MOUNT_FORMAT_FILESYSTEMS") = "Allows formatting file systems for removable storage."
        PermissionDefinition("MOUNT_UNMOUNT_FILESYSTEMS") = "Allows mounting and unmounting file systems for removable storage."
        PermissionDefinition("NFC") = "Allows applications to perform I/O operations over NFC"
        PermissionDefinition("PERSISTENT_ACTIVITY") = "This constant was deprecated in API level 9. This functionality will be removed in the future; please do not use. Allow an application to make its activities persistent."
        PermissionDefinition("PROCESS_OUTGOING_CALLS") = "Allows an application to see the number being dialed during an outgoing call with the option to redirect the call to a different number or abort the call altogether."
        PermissionDefinition("READ_CALENDAR") = "Allows an application to read the user's calendar data."
        PermissionDefinition("READ_CALL_LOG") = "Allows an application to read the user's call log."
        PermissionDefinition("READ_CONTACTS") = "Allows an application to read the user's contacts data."
        PermissionDefinition("READ_EXTERNAL_STORAGE") = "Allows an application to read from external storage."
        PermissionDefinition("READ_FRAME_BUFFER") = "Allows an application to take screen shots and more generally get access to the frame buffer data."
        PermissionDefinition("READ_HISTORY_BOOKMARKS") = "Allows an application to read (but not write) the user's browsing history and bookmarks."
        PermissionDefinition("READ_INPUT_STATE") = "This constant was deprecated in API level 16. The API that used this permission has been removed."
        PermissionDefinition("READ_LOGS") = "Allows an application to read the low-level system log files."
        PermissionDefinition("READ_PHONE_STATE") = "Allows read only access to phone state."
        PermissionDefinition("READ_PROFILE") = "Allows an application to read the user's personal profile data."
        PermissionDefinition("READ_SMS") = "Allows an application to read SMS messages."
        PermissionDefinition("READ_SOCIAL_STREAM") = "Allows an application to read from the user's social stream."
        PermissionDefinition("READ_SYNC_SETTINGS") = "Allows applications to read the sync settings"
        PermissionDefinition("READ_SYNC_STATS") = "Allows applications to read the sync stats"
        PermissionDefinition("READ_USER_DICTIONARY") = "Allows an application to read the user dictionary."
        PermissionDefinition("REBOOT") = "Required to be able to reboot the device."
        PermissionDefinition("RECEIVE_BOOT_COMPLETED") = "Allows an application to receive the ACTION_BOOT_COMPLETED that is broadcast after the system finishes booting."
        PermissionDefinition("RECEIVE_MMS") = "Allows an application to monitor incoming MMS messages, to record or perform processing on them."
        PermissionDefinition("RECEIVE_SMS") = "Allows an application to monitor incoming SMS messages, to record or perform processing on them."
        PermissionDefinition("RECEIVE_WAP_PUSH") = "Allows an application to monitor incoming WAP push messages."
        PermissionDefinition("RECORD_AUDIO") = "Allows an application to record audio"
        PermissionDefinition("REORDER_TASKS") = "Allows an application to change the Z-order of tasks"
        PermissionDefinition("RESTART_PACKAGES") = "This constant was deprecated in API level 8. The restartPackage(String) API is no longer supported."
        PermissionDefinition("SEND_RESPOND_VIA_MESSAGE") = "Allows an application (Phone) to send a request to other applications to handle the respond-via-message action during incoming calls."
        PermissionDefinition("SEND_SMS") = "Allows an application to send SMS messages."
        PermissionDefinition("SET_ACTIVITY_WATCHER") = "Allows an application to watch and control how activities are started globally in the system."
        PermissionDefinition("SET_ALARM") = "Allows an application to broadcast an Intent to set an alarm for the user."
        PermissionDefinition("SET_ALWAYS_FINISH") = "Allows an application to control whether activities are immediately finished when put in the background."
        PermissionDefinition("SET_ANIMATION_SCALE") = "Modify the global animation scaling factor."
        PermissionDefinition("SET_DEBUG_APP") = "Configure an application for debugging."
        PermissionDefinition("SET_ORIENTATION") = "Allows low-level access to setting the orientation (actually rotation) of the screen."
        PermissionDefinition("SET_POINTER_SPEED") = "Allows low-level access to setting the pointer speed."
        PermissionDefinition("SET_PREFERRED_APPLICATIONS") = "This constant was deprecated in API level 7. No longer useful, see addPackageToPreferred(String)for details."
        PermissionDefinition("SET_PROCESS_LIMIT") = "Allows an application to set the maximum number of (not needed) application processes that can be running."
        PermissionDefinition("SET_TIME") = "Allows applications to set the system time."
        PermissionDefinition("SET_TIME_ZONE") = "Allows applications to set the system time zone"
        PermissionDefinition("SET_WALLPAPER") = "Allows applications to set the wallpaper"
        PermissionDefinition("SET_WALLPAPER_HINTS") = "Allows applications to set the wallpaper hints"
        PermissionDefinition("SIGNAL_PERSISTENT_PROCESSES") = "Allow an application to request that a signal be sent to all persistent processes."
        PermissionDefinition("STATUS_BAR") = "Allows an application to open, close, or disable the status bar and its icons."
        PermissionDefinition("SUBSCRIBED_FEEDS_READ") = "Allows an application to allow access the subscribed feeds ContentProvider."
        PermissionDefinition("SUBSCRIBED_FEEDS_WRITE") = ""
        PermissionDefinition("SYSTEM_ALERT_WINDOW") = "Allows an application to open windows using the type TYPE_SYSTEM_ALERT, shown on top of all other applications."
        PermissionDefinition("TRANSMIT_IR") = "Allows using the device's IR transmitter, if available"
        PermissionDefinition("UNINSTALL_SHORTCUT") = "Allows an application to uninstall a shortcut in Launcher"
        PermissionDefinition("UPDATE_DEVICE_STATS") = "Allows an application to update device statistics."
        PermissionDefinition("USE_CREDENTIALS") = "Allows an application to request authtokens from the AccountManager"
        PermissionDefinition("USE_SIP") = "Allows an application to use SIP service"
        PermissionDefinition("VIBRATE") = "Allows access to the vibrator"
        PermissionDefinition("WAKE_LOCK") = "Allows using PowerManager WakeLocks to keep processor from sleeping or screen from dimming"
        PermissionDefinition("WRITE_APN_SETTINGS") = "Allows applications to write the apn settings."
        PermissionDefinition("WRITE_CALENDAR") = "Allows an application to write (but not read) the user's calendar data."
        PermissionDefinition("WRITE_CALL_LOG") = "Allows an application to write (but not read) the user's contacts data."
        PermissionDefinition("WRITE_CONTACTS") = "Allows an application to write (but not read) the user's contacts data."
        PermissionDefinition("WRITE_EXTERNAL_STORAGE") = "Allows an application to write to external storage."
        PermissionDefinition("WRITE_GSERVICES") = "Allows an application to modify the Google service map."
        PermissionDefinition("WRITE_HISTORY_BOOKMARKS") = "Allows an application to write (but not read) the user's browsing history and bookmarks."
        PermissionDefinition("WRITE_PROFILE") = "Allows an application to write (but not read) the user's personal profile data."
        PermissionDefinition("WRITE_SECURE_SETTINGS") = "Allows an application to read or write the secure system settings."
        PermissionDefinition("WRITE_SETTINGS") = "Allows an application to read or write the system settings."
        PermissionDefinition("WRITE_SMS") = "Allows an application to write SMS messages."
        PermissionDefinition("WRITE_SOCIAL_STREAM") = "Allows an application to write (but not read) the user's social stream data."
        PermissionDefinition("WRITE_SYNC_SETTINGS") = "Allows applications to write the sync settings"
        PermissionDefinition("WRITE_USER_DICTIONARY") = "Allows an application to write to the user dictionary."
        AndroidCodeNames(1) = "1.0"
        AndroidCodeNames(2) = "1.1"
        AndroidCodeNames(3) = "1.5, codename ""Cupcake"""
        AndroidCodeNames(4) = "1.6, codename ""Donut"""
        AndroidCodeNames(5) = "2.0, codename ""Eclair"""
        AndroidCodeNames(6) = "2.0.1, codename ""Eclair"""
        AndroidCodeNames(7) = "2.1, codename ""Eclair"""
        AndroidCodeNames(8) = "2.2.x, codename ""Froyo"""
        AndroidCodeNames(9) = "2.3 - 2.3.2, codename ""Gingerbread"""
        AndroidCodeNames(10) = "2.3.3 - 2.3.7, codename ""Gingerbread"""
        AndroidCodeNames(11) = "3.0, codename ""Honeycomb"""
        AndroidCodeNames(12) = "3.1, codename ""Honeycomb"""
        AndroidCodeNames(13) = "3.2.x, codename ""Honeycomb"""
        AndroidCodeNames(14) = "4.0.1 - 4.0.2, codename ""Ice Cream Sandwich"""
        AndroidCodeNames(15) = "4.0.3 - 4.0.4, codename ""Ice Cream Sandwich"""
        AndroidCodeNames(16) = "4.1.x, codename ""Jelly Bean"""
        AndroidCodeNames(17) = "4.2.x, codename ""Jelly Bean"""
        AndroidCodeNames(18) = "4.3.x, codename ""Jelly Bean"""
        AndroidCodeNames(19) = "4.4 - 4.4.2, codename ""KitKat"""

        Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        For Each arg In CommandLineArgs
            FileToCheck &= arg & " "
        Next
        If FileToCheck = "" Then
            Dim loadWindow As New OpenFileDialog
            loadWindow.Filter = "Android Package file|*.apk"
            loadWindow.Title = "Open APK file"
            loadWindow.ShowDialog()
            FileToCheck = loadWindow.FileName
        End If
        If FileToCheck = "" Then
            End
        End If
        Dim Badging As String = GetProcessText("support\aapt.exe", "dump badging """ & FileToCheck & """", "")
        Dim Badges As String() = Badging.Split(vbLf)
        Dim packageRegex = New Regex("package: name='(.*)' versionCode='(.*)' versionName='(.*)'")
        Dim packageMatch As Match
        Dim AppNameRegex = New Regex("application-label\-*(.*):'(.*)'")
        Dim AppNameMatches As New List(Of Match)
        Dim AppIconRegex = New Regex("application-icon\-*(.*):'(.*)'")
        Dim AppIconMatches As New List(Of Match)
        Dim GenericPropertyRegex = New Regex("(.*):(.*)")
        Dim GenericProperties As New Dictionary(Of String, String)
        Dim Permissions As New List(Of String)
        Dim ImpliedPermissions As New List(Of String)
        Dim Features As New List(Of String)
        Dim ImpliedFeatures As New List(Of String)
        For Each badge In Badges
            If badge.StartsWith("package:") Then
                packageMatch = packageRegex.Match(badge)
            ElseIf badge.StartsWith("application-label") Then
                AppNameMatches.Add(AppNameRegex.Match(badge))
            ElseIf badge.StartsWith("application-icon") Then
                AppIconMatches.Add(AppIconRegex.Match(badge))
            ElseIf badge.StartsWith("uses-permission") Then
                Dim GenericPropertyMatch As Match = GenericPropertyRegex.Match(badge)
                Permissions.Add(GenericPropertyMatch.Groups(2).Value)
            ElseIf badge.StartsWith("uses-feature") Then
                Dim GenericPropertyMatch As Match = GenericPropertyRegex.Match(badge)
                Features.Add(GenericPropertyMatch.Groups(2).Value)
            ElseIf badge.StartsWith("uses-implied-feature") Then
                Dim GenericPropertyMatch As Match = GenericPropertyRegex.Match(badge)
                ImpliedFeatures.Add(GenericPropertyMatch.Groups(2).Value)
            ElseIf badge.StartsWith("uses-implied-permission") Then
                Dim GenericPropertyMatch As Match = GenericPropertyRegex.Match(badge)
                ImpliedPermissions.Add(GenericPropertyMatch.Groups(2).Value)
            Else
                Try
                    Dim GenericPropertyMatch As Match = GenericPropertyRegex.Match(badge)
                    GenericProperties.Add(GenericPropertyMatch.Groups(1).Value, GenericPropertyMatch.Groups(2).Value)
                Catch ex As Exception
                End Try
            End If
        Next
        Dim GenericAppName As String = ""
        For Each AppIcon In AppIconMatches
            AppIcons.Add(AppIcon.Groups(2).Value)
        Next
        labelVersion.Text = "Requires at least Android " & AndroidCodeNames(Integer.Parse(GenericProperties("sdkVersion").Replace("'", "")))
        For Each AppName As Match In AppNameMatches

            'getting the generic name
            If AppName.Groups(1).Value = "" Then
                AppNames.Add("en_US", AppName.Groups(2).Value)
                GenericAppName = AppName.Groups(2).Value
                Dim defaults = New ComboboxItem With {
                                       .Text = System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("en-US").EnglishName,
                                       .Value = "en_US"}
                menuLanguage.Items.Add(defaults)
                menuLanguage.SelectedItem = defaults
            Else
                AppNames.Add(AppName.Groups(1).Value, AppName.Groups(2).Value)
                Try
                    menuLanguage.Items.Add(New ComboboxItem With {
                                           .Text = System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag(AppName.Groups(1).Value.Replace("_", "-")).EnglishName,
                                           .Value = AppName.Groups(1).Value})
                Catch ex As Exception
                    menuLanguage.Items.Add(New ComboboxItem With {
                                          .Text = "Unknown (" & AppName.Groups(1).Value & ")",
                                          .Value = AppName.Groups(1).Value})
                End Try
            End If
        Next
        ListView1.Columns(1).Width = -2
        'get icon
        Dim iss As System.IO.Stream
        iss = New MemoryStream
        Using zip As ZipFile = ZipFile.Read(FileToCheck)
            For Each ex As ZipEntry In zip
                If ex.FileName = AppIcons(AppIcons.Count - 1) Then
                    ex.Extract(iss)
                End If
            Next
        End Using
        PictureBox1.Image = Image.FromStream(iss)
        Dim versionCode = packageMatch.Groups(2).Value
        Dim versionName = packageMatch.Groups(3).Value
        labelAppName.Text = GenericAppName
        Me.Text = "Install " & GenericAppName
        labelAppVersion.Text = String.Format(labelAppVersion.Text, versionName, versionCode)
        For Each Permission In Permissions
            Dim lvi As New ListViewItem
            Dim permnormalized = Permission.Replace("'", "").Replace("android.permission.", "").Trim(vbCr)
            lvi.Text = permnormalized
            Try
                lvi.SubItems.Add(PermissionDefinition(permnormalized))
            Catch ex As Exception
                lvi.SubItems.Add("Unknown")
            End Try
            ListView1.Items.Add(lvi)
        Next
    End Sub

    Private Sub labelVersion_Click(sender As Object, e As EventArgs) Handles labelVersion.Click

    End Sub

    Private Sub menuLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles menuLanguage.SelectedIndexChanged
        labelAppName.Text = AppNames(DirectCast(menuLanguage.SelectedItem, ComboboxItem).Value)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim ai As New AppIcon
        ai.PictureBox1.Image = PictureBox1.Image
        ai.Text = Me.Text.Replace("Install ", "")
        ai.Location = MousePosition
        ai.ShowDialog()

    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ListView1.Columns(1).Width = -2
    End Sub

    Private Sub menuDeviceSelect_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub buttonInstall_Click(sender As Object, e As EventArgs) Handles buttonInstall.Click
        Process.Start("support\adb.exe", "install """ & FileToCheck & "")
        End
    End Sub
End Class
Public Class ComboboxItem
    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set(value As String)
            m_Text = value
        End Set
    End Property
    Private m_Text As String
    Public Property Value() As Object
        Get
            Return m_Value
        End Get
        Set(value As Object)
            m_Value = value
        End Set
    End Property
    Private m_Value As Object

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class