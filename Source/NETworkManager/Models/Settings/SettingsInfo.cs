﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Heijden.DNS;
using Lextm.SharpSnmpLib.Messaging;
using NETworkManager.Models.Export;
using NETworkManager.Models.Network;
using NETworkManager.Utilities;
using static NETworkManager.Models.Network.SNMP;

namespace NETworkManager.Models.Settings
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SettingsInfo : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables
        [XmlIgnore] public bool SettingsChanged { get; set; }

        private string _settingsVersion = "0.0.0.0";
        public string SettingsVersion
        {
            get => _settingsVersion;
            set
            {
                if (value == _settingsVersion)
                    return;

                _settingsVersion = value;
                SettingsChanged = true;
            }
        }

        #region General 
        // General        
        private ApplicationViewManager.Name _general_DefaultApplicationViewName = ApplicationViewManager.Name.NetworkInterface;
        public ApplicationViewManager.Name General_DefaultApplicationViewName
        {
            get => _general_DefaultApplicationViewName;
            set
            {
                if (value == _general_DefaultApplicationViewName)
                    return;

                _general_DefaultApplicationViewName = value;
                SettingsChanged = true;
            }
        }

        private int _general_HistoryListEntries = 5;
        public int General_HistoryListEntries
        {
            get => _general_HistoryListEntries;
            set
            {
                if (value == _general_HistoryListEntries)
                    return;

                _general_HistoryListEntries = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<ApplicationViewInfo> _general_ApplicationList = new ObservableCollection<ApplicationViewInfo>();
        public ObservableCollection<ApplicationViewInfo> General_ApplicationList
        {
            get => _general_ApplicationList;
            set
            {
                if (value == _general_ApplicationList)
                    return;

                _general_ApplicationList = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        // Window
        private bool _window_ConfirmClose;
        public bool Window_ConfirmClose
        {
            get => _window_ConfirmClose;
            set
            {
                if (value == _window_ConfirmClose)
                    return;

                _window_ConfirmClose = value;
                SettingsChanged = true;
            }
        }

        private bool _window_MinimizeInsteadOfTerminating;
        public bool Window_MinimizeInsteadOfTerminating
        {
            get => _window_MinimizeInsteadOfTerminating;
            set
            {
                if (value == _window_MinimizeInsteadOfTerminating)
                    return;

                _window_MinimizeInsteadOfTerminating = value;
                SettingsChanged = true;
            }
        }

        private bool _window_MultipleInstances;
        public bool Window_MultipleInstances
        {
            get => _window_MultipleInstances;
            set
            {
                if (value == _window_MultipleInstances)
                    return;

                _window_MultipleInstances = value;
                SettingsChanged = true;
            }
        }

        private bool _window_MinimizeToTrayInsteadOfTaskbar;
        public bool Window_MinimizeToTrayInsteadOfTaskbar
        {
            get => _window_MinimizeToTrayInsteadOfTaskbar;
            set
            {
                if (value == _window_MinimizeToTrayInsteadOfTaskbar)
                    return;

                _window_MinimizeToTrayInsteadOfTaskbar = value;
                SettingsChanged = true;
            }
        }

        private bool _window_ShowCurrentApplicationTitle;
        public bool Window_ShowCurrentApplicationTitle
        {
            get => _window_ShowCurrentApplicationTitle;
            set
            {
                if (value == _window_ShowCurrentApplicationTitle)
                    return;

                _window_ShowCurrentApplicationTitle = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        // TrayIcon
        private bool _trayIcon_AlwaysShowIcon;
        public bool TrayIcon_AlwaysShowIcon
        {
            get => _trayIcon_AlwaysShowIcon;
            set
            {
                if (value == _trayIcon_AlwaysShowIcon)
                    return;

                _trayIcon_AlwaysShowIcon = value;
                SettingsChanged = true;
            }
        }

        // Appearance
        private string _appearance_AppTheme;
        public string Appearance_AppTheme
        {
            get => _appearance_AppTheme;
            set
            {
                if (value == _appearance_AppTheme)
                    return;

                _appearance_AppTheme = value;
                SettingsChanged = true;
            }
        }

        private string _appearance_Accent;
        public string Appearance_Accent
        {
            get => _appearance_Accent;
            set
            {
                if (value == _appearance_Accent)
                    return;

                _appearance_Accent = value;
                SettingsChanged = true;
            }
        }

        private bool _appearance_EnableTransparency;
        public bool Appearance_EnableTransparency
        {
            get => _appearance_EnableTransparency;
            set
            {
                if (value == _appearance_EnableTransparency)
                    return;

                _appearance_EnableTransparency = value;
                SettingsChanged = true;
            }
        }

        private double _appearance_Opacity = 0.85;
        public double Appearance_Opacity
        {
            get => _appearance_Opacity;
            set
            {
                if (value == _appearance_Opacity)
                    return;

                _appearance_Opacity = value;
                SettingsChanged = true;
            }
        }

        // Localization
        private string _localization_CultureCode;
        public string Localization_CultureCode
        {
            get => _localization_CultureCode;
            set
            {
                if (value == _localization_CultureCode)
                    return;

                _localization_CultureCode = value;
                SettingsChanged = true;
            }
        }

        // Autostart
        private bool _autostart_StartMinimizedInTray;
        public bool Autostart_StartMinimizedInTray
        {
            get => _autostart_StartMinimizedInTray;
            set
            {
                if (value == _autostart_StartMinimizedInTray)
                    return;

                _autostart_StartMinimizedInTray = value;
                SettingsChanged = true;
            }
        }

        // HotKey
        private bool _hotKey_ShowWindowEnabled;
        public bool HotKey_ShowWindowEnabled
        {
            get => _hotKey_ShowWindowEnabled;
            set
            {
                if (value == _hotKey_ShowWindowEnabled)
                    return;

                _hotKey_ShowWindowEnabled = value;
                SettingsChanged = true;
            }
        }

        private int _hotKey_ShowWindowKey = 79;
        public int HotKey_ShowWindowKey
        {
            get => _hotKey_ShowWindowKey;
            set
            {
                if (value == _hotKey_ShowWindowKey)
                    return;

                _hotKey_ShowWindowKey = value;
                SettingsChanged = true;
            }
        }

        private int _hotKey_ShowWindowModifier = 3;
        public int HotKey_ShowWindowModifier
        {
            get => _hotKey_ShowWindowModifier;
            set
            {
                if (value == _hotKey_ShowWindowModifier)
                    return;

                _hotKey_ShowWindowModifier = value;
                SettingsChanged = true;
            }
        }

        // Update
        private bool _update_CheckForUpdatesAtStartup = true;
        public bool Update_CheckForUpdatesAtStartup
        {
            get => _update_CheckForUpdatesAtStartup;
            set
            {
                if (value == _update_CheckForUpdatesAtStartup)
                    return;

                _update_CheckForUpdatesAtStartup = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region Others
        // Application view       
        private bool _expandApplicationView;
        public bool ExpandApplicationView
        {
            get => _expandApplicationView;
            set
            {
                if (value == _expandApplicationView)
                    return;

                _expandApplicationView = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region Network Interface       
        private string _networkInterface_SelectedInterfaceId;
        public string NetworkInterface_SelectedInterfaceId
        {
            get => _networkInterface_SelectedInterfaceId;
            set
            {
                if (value == _networkInterface_SelectedInterfaceId)
                    return;

                _networkInterface_SelectedInterfaceId = value;
                SettingsChanged = true;
            }
        }

        private bool _networkInterface_ExpandProfileView = true;
        public bool NetworkInterface_ExpandProfileView
        {
            get => _networkInterface_ExpandProfileView;
            set
            {
                if (value == _networkInterface_ExpandProfileView)
                    return;

                _networkInterface_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _networkInterface_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double NetworkInterface_ProfileWidth
        {
            get => _networkInterface_ProfileWidth;
            set
            {
                if (value == _networkInterface_ProfileWidth)
                    return;

                _networkInterface_ProfileWidth = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region IPScanner        
        private bool _ipScanner_ShowScanResultForAllIPAddresses;
        public bool IPScanner_ShowScanResultForAllIPAddresses
        {
            get => _ipScanner_ShowScanResultForAllIPAddresses;
            set
            {
                if (value == _ipScanner_ShowScanResultForAllIPAddresses)
                    return;

                _ipScanner_ShowScanResultForAllIPAddresses = value;
                SettingsChanged = true;
            }
        }

        private int _ipScanner_Threads = 256;
        public int IPScanner_Threads
        {
            get => _ipScanner_Threads;
            set
            {
                if (value == _ipScanner_Threads)
                    return;

                _ipScanner_Threads = value;
                SettingsChanged = true;
            }
        }

        private int _ipScanner_ICMPAttempts = 2;
        public int IPScanner_ICMPAttempts
        {
            get => _ipScanner_ICMPAttempts;
            set
            {
                if (value == _ipScanner_ICMPAttempts)
                    return;

                _ipScanner_ICMPAttempts = value;
                SettingsChanged = true;
            }
        }

        private int _ipScanner_ICMPBuffer = 32;
        public int IPScanner_ICMPBuffer
        {
            get => _ipScanner_ICMPBuffer;
            set
            {
                if (value == _ipScanner_ICMPBuffer)
                    return;

                _ipScanner_ICMPBuffer = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _ipScanner_IPRangeHistory = new ObservableCollection<string>();
        public ObservableCollection<string> IPScanner_IPRangeHistory
        {
            get => _ipScanner_IPRangeHistory;
            set
            {
                if (value == _ipScanner_IPRangeHistory)
                    return;

                _ipScanner_IPRangeHistory = value;
                SettingsChanged = true;
            }
        }

        private bool _ipScanner_ResolveHostname = true;
        public bool IPScanner_ResolveHostname
        {
            get => _ipScanner_ResolveHostname;
            set
            {
                if (value == _ipScanner_ResolveHostname)
                    return;

                _ipScanner_ResolveHostname = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private bool _ipScanner_UseCustomDNSServer;
        public bool IPScanner_UseCustomDNSServer
        {
            get => _ipScanner_UseCustomDNSServer;
            set
            {
                if (value == _ipScanner_UseCustomDNSServer)
                    return;

                _ipScanner_UseCustomDNSServer = value;
                SettingsChanged = true;
            }
        }

        private List<string> _ipScanner_CustomDNSServer = new List<string>();
        public List<string> IPScanner_CustomDNSServer
        {
            get => _ipScanner_CustomDNSServer;
            set
            {
                if (value == _ipScanner_CustomDNSServer)
                    return;

                _ipScanner_CustomDNSServer = value;
                SettingsChanged = true;
            }
        }

        private int _ipScanner_DNSPort = 53;
        public int IPScanner_DNSPort
        {
            get => _ipScanner_DNSPort;
            set
            {
                if (value == _ipScanner_DNSPort)
                    return;

                _ipScanner_DNSPort = value;
                SettingsChanged = true;
            }
        }

        private bool _ipScanner_DNSRecursion = true;
        public bool IPScanner_DNSRecursion
        {
            get => _ipScanner_DNSRecursion;
            set
            {
                if (value == _ipScanner_DNSRecursion)
                    return;

                _ipScanner_DNSRecursion = value;
                SettingsChanged = true;
            }
        }

        private bool _ipScanner_DNSUseResolverCache;
        public bool IPScanner_DNSUseResolverCache
        {
            get => _ipScanner_DNSUseResolverCache;
            set
            {
                if (value == _ipScanner_DNSUseResolverCache)
                    return;

                _ipScanner_DNSUseResolverCache = value;
                SettingsChanged = true;
            }
        }

        private TransportType _ipScanner_DNSTransportType = TransportType.Udp;
        public TransportType IPScanner_DNSTransportType
        {
            get => _ipScanner_DNSTransportType;
            set
            {
                if (value == _ipScanner_DNSTransportType)
                    return;

                _ipScanner_DNSTransportType = value;
                SettingsChanged = true;
            }
        }

        private int _ipScanner_DNSAttempts = 2;
        public int IPScanner_DNSAttempts
        {
            get => _ipScanner_DNSAttempts;
            set
            {
                if (value == _ipScanner_DNSAttempts)
                    return;

                _ipScanner_DNSAttempts = value;
                SettingsChanged = true;
            }
        }

        private int _ipScanner_DNSTimeout = 2000;
        public int IPScanner_DNSTimeout
        {
            get => _ipScanner_DNSTimeout;
            set
            {
                if (value == _ipScanner_DNSTimeout)
                    return;

                _ipScanner_DNSTimeout = value;
                SettingsChanged = true;
            }
        }

        private bool _ipScanner_ResolveMACAddress;
        public bool IPScanner_ResolveMACAddress
        {
            get => _ipScanner_ResolveMACAddress;
            set
            {
                if (value == _ipScanner_ResolveMACAddress)
                    return;

                _ipScanner_ResolveMACAddress = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private int _ipScanner_ICMPTimeout = 4000;
        public int IPScanner_ICMPTimeout
        {
            get => _ipScanner_ICMPTimeout;
            set
            {
                if (value == _ipScanner_ICMPTimeout)
                    return;

                _ipScanner_ICMPTimeout = value;
                SettingsChanged = true;
            }
        }

        private bool _ipScanner_ExpandStatistics = true;
        public bool IPScanner_ExpandStatistics
        {
            get => _ipScanner_ExpandStatistics;
            set
            {
                if (value == _ipScanner_ExpandStatistics)
                    return;

                _ipScanner_ExpandStatistics = value;
                SettingsChanged = true;
            }
        }

        private bool _ipScanner_ExpandProfileView = true;
        public bool IPScanner_ExpandProfileView
        {
            get => _ipScanner_ExpandProfileView;
            set
            {
                if (value == _ipScanner_ExpandProfileView)
                    return;

                _ipScanner_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _ipScanner_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double IPScanner_ProfileWidth
        {
            get => _ipScanner_ProfileWidth;
            set
            {
                if (value == _ipScanner_ProfileWidth)
                    return;

                _ipScanner_ProfileWidth = value;
                SettingsChanged = true;
            }
        }

        private bool _ipScanner_ShowStatistics = true;
        public bool IPScanner_ShowStatistics
        {
            get => _ipScanner_ShowStatistics;
            set
            {
                if (value == _ipScanner_ShowStatistics)
                    return;

                _ipScanner_ShowStatistics = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private string _ipScanner_ExportFilePath;
        public string IPScanner_ExportFilePath
        {
            get => _ipScanner_ExportFilePath;
            set
            {
                if (value == _ipScanner_ExportFilePath)
                    return;

                _ipScanner_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _ipScanner_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType IPScanner_ExportFileType
        {
            get => _ipScanner_ExportFileType;
            set
            {
                if(value == _ipScanner_ExportFileType)
                    return;

                _ipScanner_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region Port Scanner
        private ObservableCollection<string> _portScanner_HostHistory = new ObservableCollection<string>();
        public ObservableCollection<string> PortScanner_HostHistory
        {
            get => _portScanner_HostHistory;
            set
            {
                if (value == _portScanner_HostHistory)
                    return;

                _portScanner_HostHistory = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _portScanner_PortHistory = new ObservableCollection<string>();
        public ObservableCollection<string> PortScanner_PortHistory
        {
            get => _portScanner_PortHistory;
            set
            {
                if (value == _portScanner_PortHistory)
                    return;

                _portScanner_PortHistory = value;
                SettingsChanged = true;
            }
        }

        private int _portScanner_Threads = 100;
        public int PortScanner_Threads
        {
            get => _portScanner_Threads;
            set
            {
                if (value == _portScanner_Threads)
                    return;

                _portScanner_Threads = value;
                SettingsChanged = true;
            }
        }

        private bool _portScanner_ShowClosed;
        public bool PortScanner_ShowClosed
        {
            get => _portScanner_ShowClosed;
            set
            {
                if (value == _portScanner_ShowClosed)
                    return;

                _portScanner_ShowClosed = value;
                SettingsChanged = true;
            }
        }

        private int _portScanner_Timeout = 4000;
        public int PortScanner_Timeout
        {
            get => _portScanner_Timeout;
            set
            {
                if (value == _portScanner_Timeout)
                    return;

                _portScanner_Timeout = value;
                SettingsChanged = true;
            }
        }

        private bool _portScanner_ResolveHostnamePreferIPv4 = true;
        public bool PortScanner_ResolveHostnamePreferIPv4
        {
            get => _portScanner_ResolveHostnamePreferIPv4;
            set
            {
                if (value == _portScanner_ResolveHostnamePreferIPv4)
                    return;

                _portScanner_ResolveHostnamePreferIPv4 = value;
                SettingsChanged = true;
            }
        }

        private bool _portScanner_ExpandStatistics = true;
        public bool PortScanner_ExpandStatistics
        {
            get => _portScanner_ExpandStatistics;
            set
            {
                if (value == _portScanner_ExpandStatistics)
                    return;

                _portScanner_ExpandStatistics = value;
                SettingsChanged = true;
            }
        }

        private bool _portScanner_ExpandProfileView = true;
        public bool PortScanner_ExpandProfileView
        {
            get => _portScanner_ExpandProfileView;
            set
            {
                if (value == _portScanner_ExpandProfileView)
                    return;

                _portScanner_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _portScanner_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double PortScanner_ProfileWidth
        {
            get => _portScanner_ProfileWidth;
            set
            {
                if (value == _portScanner_ProfileWidth)
                    return;

                _portScanner_ProfileWidth = value;
                SettingsChanged = true;
            }
        }

        private bool _portScanner_ShowStatistics = true;
        public bool PortScanner_ShowStatistics
        {
            get => _portScanner_ShowStatistics;
            set
            {
                if (value == _portScanner_ShowStatistics)
                    return;

                _portScanner_ShowStatistics = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private string _portScanner_ExportFilePath;
        public string PortScanner_ExportFilePath
        {
            get => _portScanner_ExportFilePath;
            set
            {
                if (value == _portScanner_ExportFilePath)
                    return;

                _portScanner_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _portScanner_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType PortScanner_ExportFileType
        {
            get => _portScanner_ExportFileType;
            set
            {
                if (value == _portScanner_ExportFileType)
                    return;

                _portScanner_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region Ping
        private int _ping_Attempts;
        public int Ping_Attempts
        {
            get => _ping_Attempts;
            set
            {
                if (value == _ping_Attempts)
                    return;

                _ping_Attempts = value;
                SettingsChanged = true;
            }
        }

        private int _ping_Buffer = 32;
        public int Ping_Buffer
        {
            get => _ping_Buffer;
            set
            {
                if (value == _ping_Buffer)
                    return;

                _ping_Buffer = value;
                SettingsChanged = true;
            }
        }

        private bool _ping_DontFragement = true;
        public bool Ping_DontFragment
        {
            get => _ping_DontFragement;
            set
            {
                if (value = _ping_DontFragement)
                    return;

                _ping_DontFragement = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _ping_HostHistory = new ObservableCollection<string>();
        public ObservableCollection<string> Ping_HostHistory
        {
            get => _ping_HostHistory;
            set
            {
                if (value == _ping_HostHistory)
                    return;

                _ping_HostHistory = value;
                SettingsChanged = true;
            }
        }

        private bool _ping_ResolveHostnamePreferIPv4 = true;
        public bool Ping_ResolveHostnamePreferIPv4
        {
            get => _ping_ResolveHostnamePreferIPv4;
            set
            {
                if (value == _ping_ResolveHostnamePreferIPv4)
                    return;

                _ping_ResolveHostnamePreferIPv4 = value;
                SettingsChanged = true;
            }
        }

        private int _ping_Timeout = 4000;
        public int Ping_Timeout
        {
            get => _ping_Timeout;
            set
            {
                if (value == _ping_Timeout)
                    return;

                _ping_Timeout = value;
                SettingsChanged = true;
            }
        }

        private int _ping_TTL = 64;
        public int Ping_TTL
        {
            get => _ping_TTL;
            set
            {
                if (value == _ping_TTL)
                    return;

                _ping_TTL = value;
                SettingsChanged = true;
            }
        }

        private int _ping_WaitTime = 1000;
        public int Ping_WaitTime
        {
            get => _ping_WaitTime;
            set
            {
                if (value == _ping_WaitTime)
                    return;

                _ping_WaitTime = value;
                SettingsChanged = true;
            }
        }

        private int _ping_ExceptionCancelCount = 3;
        public int Ping_ExceptionCancelCount
        {
            get => _ping_ExceptionCancelCount;
            set
            {
                if (value == _ping_ExceptionCancelCount)
                    return;

                _ping_ExceptionCancelCount = value;
                SettingsChanged = true;
            }
        }

        private bool _ping_ExpandStatistics = true;
        public bool Ping_ExpandStatistics
        {
            get => _ping_ExpandStatistics;
            set
            {
                if (value == _ping_ExpandStatistics)
                    return;

                _ping_ExpandStatistics = value;
                SettingsChanged = true;
            }
        }

        private bool _ping_ExpandProfileView = true;
        public bool Ping_ExpandProfileView
        {
            get => _ping_ExpandProfileView;
            set
            {
                if (value == _ping_ExpandProfileView)
                    return;

                _ping_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _ping_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double Ping_ProfileWidth
        {
            get => _ping_ProfileWidth;
            set
            {
                if (value == _ping_ProfileWidth)
                    return;

                _ping_ProfileWidth = value;
                SettingsChanged = true;
            }
        }

        private bool _ping_ShowStatistics = true;
        public bool Ping_ShowStatistics
        {
            get => _ping_ShowStatistics;
            set
            {
                if (value == _ping_ShowStatistics)
                    return;

                _ping_ShowStatistics = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private string _ping_ExportFilePath;
        public string Ping_ExportFilePath
        {
            get => _ping_ExportFilePath;
            set
            {
                if (value == _ping_ExportFilePath)
                    return;

                _ping_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _ping_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType Ping_ExportFileType
        {
            get => _ping_ExportFileType;
            set
            {
                if (value == _ping_ExportFileType)
                    return;

                _ping_ExportFileType = value;
                SettingsChanged = true;
            }
        }

        private bool _ping_HighlightTimeouts = true;
        public bool Ping_HighlightTimeouts
        {
            get => _ping_HighlightTimeouts;
            set
            {
                if(value == _ping_HighlightTimeouts)
                    return;

                _ping_HighlightTimeouts = value;
                
                OnPropertyChanged();

                SettingsChanged = true;
            }
        }
        #endregion

        #region Traceroute
        private ObservableCollection<string> _traceroute_HostHistory = new ObservableCollection<string>();
        public ObservableCollection<string> Traceroute_HostHistory
        {
            get => _traceroute_HostHistory;
            set
            {
                if (value == _traceroute_HostHistory)
                    return;

                _traceroute_HostHistory = value;
                SettingsChanged = true;
            }
        }

        private int _traceroute_MaximumHops = 30;
        public int Traceroute_MaximumHops
        {
            get => _traceroute_MaximumHops;
            set
            {
                if (value == _traceroute_MaximumHops)
                    return;

                _traceroute_MaximumHops = value;
                SettingsChanged = true;
            }
        }

        private int _traceroute_Timeout = 4000;
        public int Traceroute_Timeout
        {
            get => _traceroute_Timeout;
            set
            {
                if (value == _traceroute_Timeout)
                    return;

                _traceroute_Timeout = value;
                SettingsChanged = true;
            }
        }

        private int _traceroute_Buffer = 32;
        public int Traceroute_Buffer
        {
            get => _traceroute_Buffer;
            set
            {
                if (value == _traceroute_Buffer)
                    return;

                _traceroute_Buffer = value;
                SettingsChanged = true;
            }
        }

        private bool _traceroute_ResolveHostname = true;
        public bool Traceroute_ResolveHostname
        {
            get => _traceroute_ResolveHostname;
            set
            {
                if (value == _traceroute_ResolveHostname)
                    return;

                _traceroute_ResolveHostname = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private bool _traceroute_ResolveHostnamePreferIPv4 = true;
        public bool Traceroute_ResolveHostnamePreferIPv4
        {
            get => _traceroute_ResolveHostnamePreferIPv4;
            set
            {
                if (value == _traceroute_ResolveHostnamePreferIPv4)
                    return;

                _traceroute_ResolveHostnamePreferIPv4 = value;
                SettingsChanged = true;
            }
        }

        private bool _traceroute_ExpandStatistics;
        public bool Traceroute_ExpandStatistics
        {
            get => _traceroute_ExpandStatistics;
            set
            {
                if (value == _traceroute_ExpandStatistics)
                    return;

                _traceroute_ExpandStatistics = value;
                SettingsChanged = true;
            }
        }

        private bool _traceroute_ExpandProfileView = true;
        public bool Traceroute_ExpandProfileView
        {
            get => _traceroute_ExpandProfileView;
            set
            {
                if (value == _traceroute_ExpandProfileView)
                    return;

                _traceroute_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _traceroute_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double Traceroute_ProfileWidth
        {
            get => _traceroute_ProfileWidth;
            set
            {
                if (value == _traceroute_ProfileWidth)
                    return;

                _traceroute_ProfileWidth = value;
                SettingsChanged = true;
            }
        }

        private bool _traceroute_ShowStatistics = true;
        public bool Traceroute_ShowStatistics
        {
            get => _traceroute_ShowStatistics;
            set
            {
                if (value == _traceroute_ShowStatistics)
                    return;

                _traceroute_ShowStatistics = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private string _traceroute_ExportFilePath;
        public string Traceroute_ExportFilePath
        {
            get => _traceroute_ExportFilePath;
            set
            {
                if (value == _traceroute_ExportFilePath)
                    return;

                _traceroute_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _traceroute_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType Traceroute_ExportFileType
        {
            get => _traceroute_ExportFileType;
            set
            {
                if (value == _traceroute_ExportFileType)
                    return;

                _traceroute_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region DNS Lookup
        private ObservableCollection<string> _dnsLookup_HostHistory = new ObservableCollection<string>();
        public ObservableCollection<string> DNSLookup_HostHistory
        {
            get => _dnsLookup_HostHistory;
            set
            {
                if (value == _dnsLookup_HostHistory)
                    return;

                _dnsLookup_HostHistory = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<DNSServerInfo> _dnsLookup_DNSServers = new ObservableCollection<DNSServerInfo>();
        public ObservableCollection<DNSServerInfo> DNSLookup_DNSServers
        {
            get => _dnsLookup_DNSServers;
            set
            {
                if (value == _dnsLookup_DNSServers)
                    return;

                _dnsLookup_DNSServers = value;
                SettingsChanged = true;
            }
        }

        private DNSServerInfo _dnsLookup_SelectedDNSServer = new DNSServerInfo();
        public DNSServerInfo DNSLookup_SelectedDNSServer
        {
            get => _dnsLookup_SelectedDNSServer;
            set
            {
                if (value == _dnsLookup_SelectedDNSServer)
                    return;

                _dnsLookup_SelectedDNSServer = value;
                SettingsChanged = true;
            }
        }

        private QClass _dnsLookup_Class = QClass.IN;
        public QClass DNSLookup_Class
        {
            get => _dnsLookup_Class;
            set
            {
                if (value == _dnsLookup_Class)
                    return;

                _dnsLookup_Class = value;
                SettingsChanged = true;
            }
        }

        private bool _dnsLookup_ShowMostCommonQueryTypes = true;
        public bool DNSLookup_ShowMostCommonQueryTypes
        {
            get => _dnsLookup_ShowMostCommonQueryTypes;
            set
            {
                if (value == _dnsLookup_ShowMostCommonQueryTypes)
                    return;

                _dnsLookup_ShowMostCommonQueryTypes = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private QType _dnsLookup_Type = QType.ANY;
        public QType DNSLookup_Type
        {
            get => _dnsLookup_Type;
            set
            {
                if (value == _dnsLookup_Type)
                    return;

                _dnsLookup_Type = value;
                SettingsChanged = true;
            }
        }

        private bool _dnsLookup_AddDNSSuffix = true;
        public bool DNSLookup_AddDNSSuffix
        {
            get => _dnsLookup_AddDNSSuffix;
            set
            {
                if (value == _dnsLookup_AddDNSSuffix)
                    return;

                _dnsLookup_AddDNSSuffix = value;
                SettingsChanged = true;
            }
        }

        private bool _dnsLookup_UseCustomDNSSuffix;
        public bool DNSLookup_UseCustomDNSSuffix
        {
            get => _dnsLookup_UseCustomDNSSuffix;
            set
            {
                if (value == _dnsLookup_UseCustomDNSSuffix)
                    return;

                _dnsLookup_UseCustomDNSSuffix = value;
                SettingsChanged = true;
            }
        }

        private string _dnsLookup_CustomDNSSuffix = string.Empty;
        public string DNSLookup_CustomDNSSuffix
        {
            get => _dnsLookup_CustomDNSSuffix;
            set
            {
                if (value == _dnsLookup_CustomDNSSuffix)
                    return;

                _dnsLookup_CustomDNSSuffix = value;
                SettingsChanged = true;
            }
        }

        private bool _dnsLookup_ResolveCNAME = true;
        public bool DNSLookup_ResolveCNAME
        {
            get => _dnsLookup_ResolveCNAME;
            set
            {
                if (value == _dnsLookup_ResolveCNAME)
                    return;

                _dnsLookup_ResolveCNAME = value;
                SettingsChanged = true;
            }
        }

        private bool _dnsLookup_Recursion = true;
        public bool DNSLookup_Recursion
        {
            get => _dnsLookup_Recursion;
            set
            {
                if (value == _dnsLookup_Recursion)
                    return;

                _dnsLookup_Recursion = value;
                SettingsChanged = true;
            }
        }

        private bool _dnsLookup_UseResolverCache;
        public bool DNSLookup_UseResolverCache
        {
            get => _dnsLookup_UseResolverCache;
            set
            {
                if (value == _dnsLookup_UseResolverCache)
                    return;

                _dnsLookup_UseResolverCache = value;
                SettingsChanged = true;
            }
        }

        private TransportType _dnsLookup_TransportType = TransportType.Udp;
        public TransportType DNSLookup_TransportType
        {
            get => _dnsLookup_TransportType;
            set
            {
                if (value == _dnsLookup_TransportType)
                    return;

                _dnsLookup_TransportType = value;
                SettingsChanged = true;
            }
        }

        private int _dnsLookup_Attempts = 3;
        public int DNSLookup_Attempts
        {
            get => _dnsLookup_Attempts;
            set
            {
                if (value == _dnsLookup_Attempts)
                    return;

                _dnsLookup_Attempts = value;
                SettingsChanged = true;
            }
        }

        private int _dnsLookup_Timeout = 2000;
        public int DNSLookup_Timeout
        {
            get => _dnsLookup_Timeout;
            set
            {
                if (value == _dnsLookup_Timeout)
                    return;

                _dnsLookup_Timeout = value;
                SettingsChanged = true;
            }
        }

        private bool _dnsLookup_ExpandStatistics = true;
        public bool DNSLookup_ExpandStatistics
        {
            get => _dnsLookup_ExpandStatistics;
            set
            {
                if (value == _dnsLookup_ExpandStatistics)
                    return;

                _dnsLookup_ExpandStatistics = value;
                SettingsChanged = true;
            }
        }

        private bool _dnsLookup_ExpandProfileView = true;
        public bool DNSLookup_ExpandProfileView
        {
            get => _dnsLookup_ExpandProfileView;
            set
            {
                if (value == _dnsLookup_ExpandProfileView)
                    return;

                _dnsLookup_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _dnsLookup_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double DNSLookup_ProfileWidth
        {
            get => _dnsLookup_ProfileWidth;
            set
            {
                if (value == _dnsLookup_ProfileWidth)
                    return;

                _dnsLookup_ProfileWidth = value;
                SettingsChanged = true;
            }
        }

        private bool _dnsLookup_ShowStatistics = true;
        public bool DNSLookup_ShowStatistics
        {
            get => _dnsLookup_ShowStatistics;
            set
            {
                if (value == _dnsLookup_ShowStatistics)
                    return;

                _dnsLookup_ShowStatistics = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private string _dnsLookup_ExportFilePath;
        public string DNSLookup_ExportFilePath
        {
            get => _dnsLookup_ExportFilePath;
            set
            {
                if (value == _dnsLookup_ExportFilePath)
                    return;

                _dnsLookup_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _dnsLookup_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType DNSLookup_ExportFileType
        {
            get => _dnsLookup_ExportFileType;
            set
            {
                if (value == _dnsLookup_ExportFileType)
                    return;

                _dnsLookup_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region RemoteDesktop 
        private ObservableCollection<string> _remoteDesktop_HostHistory = new ObservableCollection<string>();
        public ObservableCollection<string> RemoteDesktop_HostHistory
        {
            get => _remoteDesktop_HostHistory;
            set
            {
                if (value == _remoteDesktop_HostHistory)
                    return;

                _remoteDesktop_HostHistory = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_AdjustScreenAutomatically;
        public bool RemoteDesktop_AdjustScreenAutomatically
        {
            get => _remoteDesktop_AdjustScreenAutomatically;
            set
            {
                if (value == _remoteDesktop_AdjustScreenAutomatically)
                    return;

                _remoteDesktop_AdjustScreenAutomatically = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_UseCurrentViewSize;
        public bool RemoteDesktop_UseCurrentViewSize
        {
            get => _remoteDesktop_UseCurrentViewSize;
            set
            {
                if (value == _remoteDesktop_UseCurrentViewSize)
                    return;

                _remoteDesktop_UseCurrentViewSize = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_UseFixedScreenSize = true;
        public bool RemoteDesktop_UseFixedScreenSize
        {
            get => _remoteDesktop_UseFixedScreenSize;
            set
            {
                if (value == _remoteDesktop_UseFixedScreenSize)
                    return;

                _remoteDesktop_UseFixedScreenSize = value;
                SettingsChanged = true;
            }
        }

        private int _remoteDesktop_ScreenWidth = 1280;
        public int RemoteDesktop_ScreenWidth
        {
            get => _remoteDesktop_ScreenWidth;
            set
            {
                if (value == _remoteDesktop_ScreenWidth)
                    return;

                _remoteDesktop_ScreenWidth = value;
                SettingsChanged = true;
            }
        }

        private int _remoteDesktop_ScreenHeight = 768;
        public int RemoteDesktop_ScreenHeight
        {
            get => _remoteDesktop_ScreenHeight;
            set
            {
                if (value == _remoteDesktop_ScreenHeight)
                    return;

                _remoteDesktop_ScreenHeight = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_UseCustomScreenSize;
        public bool RemoteDesktop_UseCustomScreenSize
        {
            get => _remoteDesktop_UseCustomScreenSize;
            set
            {
                if (value == _remoteDesktop_UseCustomScreenSize)
                    return;

                _remoteDesktop_UseCustomScreenSize = value;
                SettingsChanged = true;
            }
        }

        private int _remoteDesktop_CustomScreenWidth;
        public int RemoteDesktop_CustomScreenWidth
        {
            get => _remoteDesktop_CustomScreenWidth;
            set
            {
                if (value == _remoteDesktop_CustomScreenWidth)
                    return;

                _remoteDesktop_CustomScreenWidth = value;
                SettingsChanged = true;
            }
        }

        private int _remoteDesktop_CustomScreenHeight;
        public int RemoteDesktop_CustomScreenHeight
        {
            get => _remoteDesktop_CustomScreenHeight;
            set
            {
                if (value == _remoteDesktop_CustomScreenHeight)
                    return;

                _remoteDesktop_CustomScreenHeight = value;
                SettingsChanged = true;
            }
        }

        private int _remoteDesktop_ColorDepth = 32;
        public int RemoteDesktop_ColorDepth
        {
            get => _remoteDesktop_ColorDepth;
            set
            {
                if (value == _remoteDesktop_ColorDepth)
                    return;

                _remoteDesktop_ColorDepth = value;
                SettingsChanged = true;
            }
        }

        private int _remoteDesktop_Port = 3389;
        public int RemoteDesktop_Port
        {
            get => _remoteDesktop_Port;
            set
            {
                if (value == _remoteDesktop_Port)
                    return;

                _remoteDesktop_Port = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_EnableCredSspSupport = true;
        public bool RemoteDesktop_EnableCredSspSupport
        {
            get => _remoteDesktop_EnableCredSspSupport;
            set
            {
                if (value == _remoteDesktop_EnableCredSspSupport)
                    return;

                _remoteDesktop_EnableCredSspSupport = value;
                SettingsChanged = true;
            }
        }

        private uint _remoteDesktop_AuthenticationLevel = 2;
        public uint RemoteDesktop_AuthenticationLevel
        {
            get => _remoteDesktop_AuthenticationLevel;
            set
            {
                if (value == _remoteDesktop_AuthenticationLevel)
                    return;

                _remoteDesktop_AuthenticationLevel = value;
                SettingsChanged = true;
            }
        }

        private int _remoteDesktop_KeyboardHookMode = 1;
        public int RemoteDesktop_KeyboardHookMode
        {
            get => _remoteDesktop_KeyboardHookMode;
            set
            {
                if (value == _remoteDesktop_KeyboardHookMode)
                    return;

                _remoteDesktop_KeyboardHookMode = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_RedirectClipboard = true;
        public bool RemoteDesktop_RedirectClipboard
        {
            get => _remoteDesktop_RedirectClipboard;
            set
            {
                if (value == _remoteDesktop_RedirectClipboard)
                    return;

                _remoteDesktop_RedirectClipboard = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_RedirectDevices;
        public bool RemoteDesktop_RedirectDevices
        {
            get => _remoteDesktop_RedirectDevices;
            set
            {
                if (value == _remoteDesktop_RedirectDevices)
                    return;

                _remoteDesktop_RedirectDevices = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_RedirectDrives;
        public bool RemoteDesktop_RedirectDrives
        {
            get => _remoteDesktop_RedirectDrives;
            set
            {
                if (value == _remoteDesktop_RedirectDrives)
                    return;

                _remoteDesktop_RedirectDrives = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_RedirectPorts;
        public bool RemoteDesktop_RedirectPorts
        {
            get => _remoteDesktop_RedirectPorts;
            set
            {
                if (value == _remoteDesktop_RedirectPorts)
                    return;

                _remoteDesktop_RedirectPorts = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_RedirectSmartCards;
        public bool RemoteDesktop_RedirectSmartCards
        {
            get => _remoteDesktop_RedirectSmartCards;
            set
            {
                if (value == _remoteDesktop_RedirectSmartCards)
                    return;

                _remoteDesktop_RedirectSmartCards = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_RedirectPrinters;
        public bool RemoteDesktop_RedirectPrinters
        {
            get => _remoteDesktop_RedirectPrinters;
            set
            {
                if (value == _remoteDesktop_RedirectPrinters)
                    return;

                _remoteDesktop_RedirectPrinters = value;
                SettingsChanged = true;
            }
        }

        private bool _remoteDesktop_ExpandProfileView = true;
        public bool RemoteDesktop_ExpandProfileView
        {
            get => _remoteDesktop_ExpandProfileView;
            set
            {
                if (value == _remoteDesktop_ExpandProfileView)
                    return;

                _remoteDesktop_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _remoteDesktop_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double RemoteDesktop_ProfileWidth
        {
            get => _remoteDesktop_ProfileWidth;
            set
            {
                if (value == _remoteDesktop_ProfileWidth)
                    return;

                _remoteDesktop_ProfileWidth = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region PuTTY
        private ObservableCollection<string> _puTTY_HostHistory = new ObservableCollection<string>();
        public ObservableCollection<string> PuTTY_HostHistory
        {
            get => _puTTY_HostHistory;
            set
            {
                if (value == _puTTY_HostHistory)
                    return;

                _puTTY_HostHistory = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _puTTY_SerialLineHistory = new ObservableCollection<string>();
        public ObservableCollection<string> PuTTY_SerialLineHistory
        {
            get => _puTTY_SerialLineHistory;
            set
            {
                if (value == _puTTY_SerialLineHistory)
                    return;

                _puTTY_SerialLineHistory = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _puTTY_PortHistory = new ObservableCollection<string>();
        public ObservableCollection<string> PuTTY_PortHistory
        {
            get => _puTTY_PortHistory;
            set
            {
                if (value == _puTTY_PortHistory)
                    return;

                _puTTY_PortHistory = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _puTTY_BaudHistory = new ObservableCollection<string>();
        public ObservableCollection<string> PuTTY_BaudHistory
        {
            get => _puTTY_BaudHistory;
            set
            {
                if (value == _puTTY_BaudHistory)
                    return;

                _puTTY_BaudHistory = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _puTTY_UsernameHistory = new ObservableCollection<string>();
        public ObservableCollection<string> PuTTY_UsernameHistory
        {
            get => _puTTY_UsernameHistory;
            set
            {
                if (value == _puTTY_UsernameHistory)
                    return;

                _puTTY_UsernameHistory = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _puTTY_ProfileHistory = new ObservableCollection<string>();
        public ObservableCollection<string> PuTTY_ProfileHistory
        {
            get => _puTTY_ProfileHistory;
            set
            {
                if (value == _puTTY_ProfileHistory)
                    return;

                _puTTY_ProfileHistory = value;
                SettingsChanged = true;
            }
        }

        private bool _puTTY_ExpandProfileView = true;
        public bool PuTTY_ExpandProfileView
        {
            get => _puTTY_ExpandProfileView;
            set
            {
                if (value == _puTTY_ExpandProfileView)
                    return;

                _puTTY_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _puTTY_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double PuTTY_ProfileWidth
        {
            get => _puTTY_ProfileWidth;
            set
            {
                if (value == _puTTY_ProfileWidth)
                    return;

                _puTTY_ProfileWidth = value;
                SettingsChanged = true;
            }
        }

        private string _puTTY_PuTTYLocation;
        public string PuTTY_PuTTYLocation
        {
            get => _puTTY_PuTTYLocation;
            set
            {
                if (value == _puTTY_PuTTYLocation)
                    return;

                _puTTY_PuTTYLocation = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private string _puTTY_Profile;
        public string PuTTY_Profile
        {
            get => _puTTY_Profile;
            set
            {
                if (value == _puTTY_Profile)
                    return;

                _puTTY_Profile = value;
                SettingsChanged = true;
            }
        }

        private string _puTTY_SerialLine = "COM1";
        public string PuTTY_SerialLine
        {
            get => _puTTY_SerialLine;
            set
            {
                if (value == _puTTY_SerialLine)
                    return;

                _puTTY_SerialLine = value;
                SettingsChanged = true;
            }
        }

        private int _puTTY_SSHPort = 22;
        public int PuTTY_SSHPort
        {
            get => _puTTY_SSHPort;
            set
            {
                if (value == _puTTY_SSHPort)
                    return;

                _puTTY_SSHPort = value;
                SettingsChanged = true;
            }
        }

        private int _puTTY_TelnetPort = 23;
        public int PuTTY_TelnetPort
        {
            get => _puTTY_TelnetPort;
            set
            {
                if (value == _puTTY_TelnetPort)
                    return;

                _puTTY_TelnetPort = value;
                SettingsChanged = true;
            }
        }

        private int _puTTY_RloginPort = 513;
        public int PuTTY_RloginPort
        {
            get => _puTTY_RloginPort;
            set
            {
                if (value == _puTTY_RloginPort)
                    return;

                _puTTY_RloginPort = value;
                SettingsChanged = true;
            }
        }

        private int _puTTY_BaudRate = 9600;
        public int PuTTY_BaudRate
        {
            get => _puTTY_BaudRate;
            set
            {
                if (value == _puTTY_BaudRate)
                    return;

                _puTTY_BaudRate = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region TightVNC
        private ObservableCollection<string> _tightVNC_HostHistory = new ObservableCollection<string>();
        public ObservableCollection<string> TightVNC_HostHistory
        {
            get => _tightVNC_HostHistory;
            set
            {
                if (value == _tightVNC_HostHistory)
                    return;

                _tightVNC_HostHistory = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<int> _tightVNC_PortHistory = new ObservableCollection<int>();
        public ObservableCollection<int> TightVNC_PortHistory
        {
            get => _tightVNC_PortHistory;
            set
            {
                if (value == _tightVNC_PortHistory)
                    return;

                _tightVNC_PortHistory = value;
                SettingsChanged = true;
            }
        }

        private bool _tightVNC_ExpandProfileView = true;
        public bool TightVNC_ExpandProfileView
        {
            get => _tightVNC_ExpandProfileView;
            set
            {
                if (value == _tightVNC_ExpandProfileView)
                    return;

                _tightVNC_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _tightVNC_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double TightVNC_ProfileWidth
        {
            get => _tightVNC_ProfileWidth;
            set
            {
                if (value == _tightVNC_ProfileWidth)
                    return;

                _tightVNC_ProfileWidth = value;
                SettingsChanged = true;
            }
        }

        private string _tightVNC_TightVNCLocation;
        public string TightVNC_TightVNCLocation
        {
            get => _tightVNC_TightVNCLocation;
            set
            {
                if (value == _tightVNC_TightVNCLocation)
                    return;

                _tightVNC_TightVNCLocation = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private int _tightVNC_VNCPort = 5900;
        public int TightVNC_VNCPort
        {
            get => _tightVNC_VNCPort;
            set
            {
                if (value == _tightVNC_VNCPort)
                    return;

                _tightVNC_VNCPort = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region SNMP
        private WalkMode _snmp_WalkMode = WalkMode.WithinSubtree;
        public WalkMode SNMP_WalkMode
        {
            get => _snmp_WalkMode;
            set
            {
                if (value == _snmp_WalkMode)
                    return;

                _snmp_WalkMode = value;
                SettingsChanged = true;
            }
        }

        private int _snmp_Timeout = 60000;
        public int SNMP_Timeout
        {
            get => _snmp_Timeout;
            set
            {
                if (value == _snmp_Timeout)
                    return;

                _snmp_Timeout = value;
                SettingsChanged = true;
            }
        }

        private int _snmp_port = 161;
        public int SNMP_Port
        {
            get => _snmp_port;
            set
            {
                if (value == _snmp_port)
                    return;

                _snmp_port = value;
                SettingsChanged = true;
            }
        }

        private bool _snmp_ResolveHostnamePreferIPv4 = true;
        public bool SNMP_ResolveHostnamePreferIPv4
        {
            get => _snmp_ResolveHostnamePreferIPv4;
            set
            {
                if (value == _snmp_ResolveHostnamePreferIPv4)
                    return;

                _snmp_ResolveHostnamePreferIPv4 = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _snmp_HostHistory = new ObservableCollection<string>();
        public ObservableCollection<string> SNMP_HostHistory
        {
            get => _snmp_HostHistory;
            set
            {
                if (value == _snmp_HostHistory)
                    return;

                _snmp_HostHistory = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _snmp_OIDHistory = new ObservableCollection<string>();
        public ObservableCollection<string> SNMP_OIDHistory
        {
            get => _snmp_OIDHistory;
            set
            {
                if (value == _snmp_OIDHistory)
                    return;

                _snmp_OIDHistory = value;
                SettingsChanged = true;
            }
        }

        private SNMPMode _snmp_Mode = SNMPMode.Walk;
        public SNMPMode SNMP_Mode
        {
            get => _snmp_Mode;
            set
            {
                if (value == _snmp_Mode)
                    return;

                _snmp_Mode = value;
                SettingsChanged = true;
            }
        }

        private SNMPVersion _snmp_Version = SNMPVersion.V2C;
        public SNMPVersion SNMP_Version
        {
            get => _snmp_Version;
            set
            {
                if (value == _snmp_Version)
                    return;

                _snmp_Version = value;
                SettingsChanged = true;
            }
        }

        private bool _snmp_ExpandStatistics = true;
        public bool SNMP_ExpandStatistics
        {
            get => _snmp_ExpandStatistics;
            set
            {
                if (value == _snmp_ExpandStatistics)
                    return;

                _snmp_ExpandStatistics = value;
                SettingsChanged = true;
            }
        }

        private SNMPV3Security _snmp_Security = SNMPV3Security.AuthPriv;
        public SNMPV3Security SNMP_Security
        {
            get => _snmp_Security;
            set
            {
                if (value == _snmp_Security)
                    return;

                _snmp_Security = value;
                SettingsChanged = true;
            }
        }

        private SNMPV3AuthenticationProvider _snmp_AuthenticationProvider = SNMPV3AuthenticationProvider.SHA1;
        public SNMPV3AuthenticationProvider SNMP_AuthenticationProvider
        {
            get => _snmp_AuthenticationProvider;
            set
            {
                if (value == _snmp_AuthenticationProvider)
                    return;

                _snmp_AuthenticationProvider = value;
                SettingsChanged = true;
            }
        }

        private SNMPV3PrivacyProvider _snmp_PrivacyProvider = SNMPV3PrivacyProvider.AES;
        public SNMPV3PrivacyProvider SNMP_PrivacyProvider
        {
            get => _snmp_PrivacyProvider;
            set
            {
                if (value == _snmp_PrivacyProvider)
                    return;

                _snmp_PrivacyProvider = value;
                SettingsChanged = true;
            }
        }

        private bool _snmp_ShowStatistics = true;
        public bool SNMP_ShowStatistics
        {
            get => _snmp_ShowStatistics;
            set
            {
                if (value == _snmp_ShowStatistics)
                    return;

                _snmp_ShowStatistics = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private string _snmp_ExportFilePath;
        public string SNMP_ExportFilePath
        {
            get => _snmp_ExportFilePath;
            set
            {
                if (value == _snmp_ExportFilePath)
                    return;

                _snmp_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _snmp_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType SNMP_ExportFileType
        {
            get => _snmp_ExportFileType;
            set
            {
                if (value == _snmp_ExportFileType)
                    return;

                _snmp_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region WakeOnLAN
        private int _wakeOnLAN_Port = 7;
        public int WakeOnLAN_Port
        {
            get => _wakeOnLAN_Port;
            set
            {
                if (value == _wakeOnLAN_Port)
                    return;

                _wakeOnLAN_Port = value;
                SettingsChanged = true;
            }
        }

        private bool _wakeOnLAN_ExpandClientView = true;
        public bool WakeOnLAN_ExpandClientView
        {
            get => _wakeOnLAN_ExpandClientView;
            set
            {
                if (value == _wakeOnLAN_ExpandClientView)
                    return;

                _wakeOnLAN_ExpandClientView = value;
                SettingsChanged = true;
            }
        }

        private double _wakeOnLAN_ClientWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double WakeOnLAN_ClientWidth
        {
            get => _wakeOnLAN_ClientWidth;
            set
            {
                if (value == _wakeOnLAN_ClientWidth)
                    return;

                _wakeOnLAN_ClientWidth = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region HTTP Headers
        private ObservableCollection<string> _httpHeaders_WebsiteUriHistory = new ObservableCollection<string>();
        public ObservableCollection<string> HTTPHeaders_WebsiteUriHistory
        {
            get => _httpHeaders_WebsiteUriHistory;
            set
            {
                if (value == _httpHeaders_WebsiteUriHistory)
                    return;

                _httpHeaders_WebsiteUriHistory = value;
                SettingsChanged = true;
            }
        }

        private int _httpHeaders_Timeout = 10000;
        public int HTTPHeaders_Timeout
        {
            get => _httpHeaders_Timeout;
            set
            {
                if (value == _httpHeaders_Timeout)
                    return;

                _httpHeaders_Timeout = value;
                SettingsChanged = true;
            }
        }

        private bool _httpHeaders_ExpandStatistics = true;
        public bool HTTPHeaders_ExpandStatistics
        {
            get => _httpHeaders_ExpandStatistics;
            set
            {
                if (value == _httpHeaders_ExpandStatistics)
                    return;

                _httpHeaders_ExpandStatistics = value;
                SettingsChanged = true;
            }
        }

        private bool _httpHeaders_ExpandProfileView = true;
        public bool HTTPHeaders_ExpandProfileView
        {
            get => _httpHeaders_ExpandProfileView;
            set
            {
                if (value == _httpHeaders_ExpandProfileView)
                    return;

                _httpHeaders_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _httpHeaders_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double HTTPHeaders_ProfileWidth
        {
            get => _httpHeaders_ProfileWidth;
            set
            {
                if (value == _httpHeaders_ProfileWidth)
                    return;

                _httpHeaders_ProfileWidth = value;
                SettingsChanged = true;
            }
        }

        private bool _httpHeaders_ShowStatistics = true;
        public bool HTTPHeaders_ShowStatistics
        {
            get => _httpHeaders_ShowStatistics;
            set
            {
                if (value == _httpHeaders_ShowStatistics)
                    return;

                _httpHeaders_ShowStatistics = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private string _httpHeaders_ExportFilePath;
        public string HTTPHeaders_ExportFilePath
        {
            get => _httpHeaders_ExportFilePath;
            set
            {
                if (value == _httpHeaders_ExportFilePath)
                    return;

                _httpHeaders_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _httpHeaders_ExportFileType = ExportManager.ExportFileType.TXT;
        public ExportManager.ExportFileType HTTPHeaders_ExportFileType
        {
            get => _httpHeaders_ExportFileType;
            set
            {
                if (value == _httpHeaders_ExportFileType)
                    return;

                _httpHeaders_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region Subnet Calculator

        #region Calculator
        private ObservableCollection<string> _subnetCalculator_Calculator_SubnetHistory = new ObservableCollection<string>();
        public ObservableCollection<string> SubnetCalculator_Calculator_SubnetHistory
        {
            get => _subnetCalculator_Calculator_SubnetHistory;
            set
            {
                if (value == _subnetCalculator_Calculator_SubnetHistory)
                    return;

                _subnetCalculator_Calculator_SubnetHistory = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region Subnetting
        private ObservableCollection<string> _subnetCalculator_Subnetting_SubnetHistory = new ObservableCollection<string>();
        public ObservableCollection<string> SubnetCalculator_Subnetting_SubnetHistory
        {
            get => _subnetCalculator_Subnetting_SubnetHistory;
            set
            {
                if (value == _subnetCalculator_Subnetting_SubnetHistory)
                    return;

                _subnetCalculator_Subnetting_SubnetHistory = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _subnetCalculator_Subnetting_NewSubnetmaskOrCIDRHistory = new ObservableCollection<string>();
        public ObservableCollection<string> SubnetCalculator_Subnetting_NewSubnetmaskOrCIDRHistory
        {
            get => _subnetCalculator_Subnetting_NewSubnetmaskOrCIDRHistory;
            set
            {
                if (value == _subnetCalculator_Subnetting_NewSubnetmaskOrCIDRHistory)
                    return;

                _subnetCalculator_Subnetting_NewSubnetmaskOrCIDRHistory = value;
                SettingsChanged = true;
            }
        }

        private string _subnetCalculator_Subnetting_ExportFilePath;
        public string SubnetCalculator_Subnetting_ExportFilePath
        {
            get => _subnetCalculator_Subnetting_ExportFilePath;
            set
            {
                if (value == _subnetCalculator_Subnetting_ExportFilePath)
                    return;

                _subnetCalculator_Subnetting_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _subnetCalculator_Subnetting_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType SubnetCalculator_Subnetting_ExportFileType
        {
            get => _subnetCalculator_Subnetting_ExportFileType;
            set
            {
                if (value == _subnetCalculator_Subnetting_ExportFileType)
                    return;

                _subnetCalculator_Subnetting_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region WideSubnet
        private ObservableCollection<string> _subnetCalculator_WideSubnet_Subnet1 = new ObservableCollection<string>();
        public ObservableCollection<string> SubnetCalculator_WideSubnet_Subnet1
        {
            get => _subnetCalculator_WideSubnet_Subnet1;
            set
            {
                if (value == _subnetCalculator_WideSubnet_Subnet1)
                    return;

                _subnetCalculator_WideSubnet_Subnet1 = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _subnetCalculator_WideSubnet_Subnet2 = new ObservableCollection<string>();
        public ObservableCollection<string> SubnetCalculator_WideSubnet_Subnet2
        {
            get => _subnetCalculator_WideSubnet_Subnet2;
            set
            {
                if (value == _subnetCalculator_WideSubnet_Subnet2)
                    return;

                _subnetCalculator_WideSubnet_Subnet2 = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #endregion

        #region Lookup
        private ObservableCollection<string> _lookup_OUI_MACAddressOrVendorHistory = new ObservableCollection<string>();
        public ObservableCollection<string> Lookup_OUI_MACAddressOrVendorHistory
        {
            get => _lookup_OUI_MACAddressOrVendorHistory;
            set
            {
                if (value == _lookup_OUI_MACAddressOrVendorHistory)
                    return;

                _lookup_OUI_MACAddressOrVendorHistory = value;
                SettingsChanged = true;
            }
        }

        private string _lookup_OUI_ExportFilePath;
        public string Lookup_OUI_ExportFilePath
        {
            get => _lookup_OUI_ExportFilePath;
            set
            {
                if (value == _lookup_OUI_ExportFilePath)
                    return;

                _lookup_OUI_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _lookup_OUI_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType Lookup_OUI_ExportFileType
        {
            get => _lookup_OUI_ExportFileType;
            set
            {
                if (value == _lookup_OUI_ExportFileType)
                    return;

                _lookup_OUI_ExportFileType = value;
                SettingsChanged = true;
            }
        }

        private ObservableCollection<string> _lookup_Port_PortsHistory = new ObservableCollection<string>();
        public ObservableCollection<string> Lookup_Port_PortsHistory
        {
            get => _lookup_Port_PortsHistory;
            set
            {
                if (value == _lookup_Port_PortsHistory)
                    return;

                _lookup_Port_PortsHistory = value;
                SettingsChanged = true;
            }
        }

        private string _lookup_Port_ExportFilePath;
        public string Lookup_Port_ExportFilePath
        {
            get => _lookup_Port_ExportFilePath;
            set
            {
                if (value == _lookup_Port_ExportFilePath)
                    return;

                _lookup_Port_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _lookup_Port_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType Lookup_Port_ExportFileType
        {
            get => _lookup_Port_ExportFileType;
            set
            {
                if (value == _lookup_Port_ExportFileType)
                    return;

                _lookup_Port_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region Whois
        private ObservableCollection<string> _whois_DomainHistory = new ObservableCollection<string>();
        public ObservableCollection<string> Whois_DomainHistory
        {
            get => _whois_DomainHistory;
            set
            {
                if (value == _whois_DomainHistory)
                    return;

                _whois_DomainHistory = value;
                SettingsChanged = true;
            }
        }

        private bool _whois_ExpandStatistics = true;
        public bool Whois_ExpandStatistics
        {
            get => _whois_ExpandStatistics;
            set
            {
                if (value == _whois_ExpandStatistics)
                    return;

                _whois_ExpandStatistics = value;
                SettingsChanged = true;
            }
        }

        private bool _whois_ExpandProfileView = true;
        public bool Whois_ExpandProfileView
        {
            get => _whois_ExpandProfileView;
            set
            {
                if (value == _whois_ExpandProfileView)
                    return;

                _whois_ExpandProfileView = value;
                SettingsChanged = true;
            }
        }

        private double _whois_ProfileWidth = GlobalStaticConfiguration.ProfileDefaultWidthExpanded;
        public double Whois_ProfileWidth
        {
            get => _whois_ProfileWidth;
            set
            {
                if (value == _whois_ProfileWidth)
                    return;

                _whois_ProfileWidth = value;
                SettingsChanged = true;
            }
        }

        private bool _whois_ShowStatistics = true;
        public bool Whois_ShowStatistics
        {
            get => _whois_ShowStatistics;
            set
            {
                if (value == _whois_ShowStatistics)
                    return;

                _whois_ShowStatistics = value;

                OnPropertyChanged();

                SettingsChanged = true;
            }
        }

        private string _whois_ExportFilePath;
        public string Whois_ExportFilePath
        {
            get => _whois_ExportFilePath;
            set
            {
                if (value == _whois_ExportFilePath)
                    return;

                _whois_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _whois_ExportFileType = ExportManager.ExportFileType.TXT;
        public ExportManager.ExportFileType Whois_ExportFileType
        {
            get => _whois_ExportFileType;
            set
            {
                if (value == _whois_ExportFileType)
                    return;

                _whois_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region Connections
        private bool _connections_AutoRefresh;
        public bool Connections_AutoRefresh
        {
            get => _connections_AutoRefresh;
            set
            {
                if (value == _connections_AutoRefresh)
                    return;

                _connections_AutoRefresh = value;
                SettingsChanged = true;
            }
        }

        private AutoRefreshTimeInfo _connections_AutoRefreshTime = AutoRefreshTime.Defaults.First(x => x.Value == 30 && x.TimeUnit == AutoRefreshTime.TimeUnit.Second);
        public AutoRefreshTimeInfo Connections_AutoRefreshTime
        {
            get => _connections_AutoRefreshTime;
            set
            {
                if (value == _connections_AutoRefreshTime)
                    return;

                _connections_AutoRefreshTime = value;
                SettingsChanged = true;
            }
        }
    
        private string _connections_ExportFilePath;
        public string Connections_ExportFilePath
        {
            get => _connections_ExportFilePath;
            set
            {
                if (value == _connections_ExportFilePath)
                    return;

                _connections_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _connections_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType Connections_ExportFileType
        {
            get => _connections_ExportFileType;
            set
            {
                if (value == _connections_ExportFileType)
                    return;

                _connections_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region Listeners
        private bool _listeners_AutoRefresh;
        public bool Listeners_AutoRefresh
        {
            get => _listeners_AutoRefresh;
            set
            {
                if (value == _listeners_AutoRefresh)
                    return;

                _listeners_AutoRefresh = value;
                SettingsChanged = true;
            }
        }

        private AutoRefreshTimeInfo _listeners_AutoRefreshTime = AutoRefreshTime.Defaults.First(x => x.Value == 30 && x.TimeUnit == AutoRefreshTime.TimeUnit.Second);
        public AutoRefreshTimeInfo Listeners_AutoRefreshTime
        {
            get => _listeners_AutoRefreshTime;
            set
            {
                if (value == _listeners_AutoRefreshTime)
                    return;

                _listeners_AutoRefreshTime = value;
                SettingsChanged = true;
            }
        }

        private string _listeners_ExportFilePath;
        public string Listeners_ExportFilePath
        {
            get => _listeners_ExportFilePath;
            set
            {
                if (value == _listeners_ExportFilePath)
                    return;

                _listeners_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _listeners_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType Listeners_ExportFileType
        {
            get => _listeners_ExportFileType;
            set
            {
                if (value == _listeners_ExportFileType)
                    return;

                _listeners_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #region ARPTable
        private bool _arpTable_AutoRefresh;
        public bool ARPTable_AutoRefresh
        {
            get => _arpTable_AutoRefresh;
            set
            {
                if (value == _arpTable_AutoRefresh)
                    return;

                _arpTable_AutoRefresh = value;
                SettingsChanged = true;
            }
        }

        private AutoRefreshTimeInfo _arpTable_AutoRefreshTime = AutoRefreshTime.Defaults.First(x => x.Value == 30 && x.TimeUnit == AutoRefreshTime.TimeUnit.Second);
        public AutoRefreshTimeInfo ARPTable_AutoRefreshTime
        {
            get => _arpTable_AutoRefreshTime;
            set
            {
                if (value == _arpTable_AutoRefreshTime)
                    return;

                _arpTable_AutoRefreshTime = value;
                SettingsChanged = true;
            }
        }

        private string _arpTable_ExportFilePath;
        public string ARPTable_ExportFilePath
        {
            get => _arpTable_ExportFilePath;
            set
            {
                if (value == _arpTable_ExportFilePath)
                    return;

                _arpTable_ExportFilePath = value;
                SettingsChanged = true;
            }
        }

        private ExportManager.ExportFileType _arpTable_ExportFileType = ExportManager.ExportFileType.CSV;
        public ExportManager.ExportFileType ARPTable_ExportFileType
        {
            get => _arpTable_ExportFileType;
            set
            {
                if (value == _arpTable_ExportFileType)
                    return;

                _arpTable_ExportFileType = value;
                SettingsChanged = true;
            }
        }
        #endregion

        #endregion

        #region Constructor
        public SettingsInfo()
        {
            // General
            General_ApplicationList.CollectionChanged += CollectionChanged;

            // IP Scanner
            IPScanner_IPRangeHistory.CollectionChanged += CollectionChanged;

            // Port Scanner
            PortScanner_HostHistory.CollectionChanged += CollectionChanged;
            PortScanner_PortHistory.CollectionChanged += CollectionChanged;

            // Ping
            Ping_HostHistory.CollectionChanged += CollectionChanged;

            // Traceroute
            Traceroute_HostHistory.CollectionChanged += CollectionChanged;

            // DNS Lookup
            DNSLookup_HostHistory.CollectionChanged += CollectionChanged;
            DNSLookup_DNSServers.CollectionChanged += CollectionChanged;

            // Remote Desktop
            RemoteDesktop_HostHistory.CollectionChanged += CollectionChanged;

            // PuTTY
            PuTTY_HostHistory.CollectionChanged += CollectionChanged;
            PuTTY_SerialLineHistory.CollectionChanged += CollectionChanged;
            PuTTY_PortHistory.CollectionChanged += CollectionChanged;
            PuTTY_BaudHistory.CollectionChanged += CollectionChanged;
            PuTTY_UsernameHistory.CollectionChanged += CollectionChanged;
            PuTTY_ProfileHistory.CollectionChanged += CollectionChanged;

            // TightVNC
            TightVNC_HostHistory.CollectionChanged += CollectionChanged;

            // SNMP
            SNMP_HostHistory.CollectionChanged += CollectionChanged;
            SNMP_OIDHistory.CollectionChanged += CollectionChanged;

            // HTTP Header
            HTTPHeaders_WebsiteUriHistory.CollectionChanged += CollectionChanged;

            // Subnet Calculator / Calculator
            SubnetCalculator_Calculator_SubnetHistory.CollectionChanged += CollectionChanged;

            // Subnet Calculator / Subnetting
            SubnetCalculator_Subnetting_SubnetHistory.CollectionChanged += CollectionChanged;
            SubnetCalculator_Subnetting_NewSubnetmaskOrCIDRHistory.CollectionChanged += CollectionChanged;

            // Subnet Calculator / Supernetting
            SubnetCalculator_WideSubnet_Subnet1.CollectionChanged += CollectionChanged;
            SubnetCalculator_WideSubnet_Subnet2.CollectionChanged += CollectionChanged;

            // Lookup / OUI
            Lookup_OUI_MACAddressOrVendorHistory.CollectionChanged += CollectionChanged;

            // Lookup / Port
            Lookup_Port_PortsHistory.CollectionChanged += CollectionChanged;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SettingsChanged = true;
        }
        #endregion
    }
}