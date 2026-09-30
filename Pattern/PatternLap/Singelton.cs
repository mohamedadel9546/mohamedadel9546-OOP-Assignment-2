using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern;

public class AppConfig
{
    private readonly static Lazy<AppConfig> _AppConfig = new Lazy<AppConfig>(() => new AppConfig());
    public static AppConfig Appconfig => _AppConfig.Value;
    public static int LoadCount;
    public string DbConnection { get; set; }
    public string Theme { get; set; }

    private AppConfig(){
        LoadCount++;
        Console.WriteLine($"[AppConfig] Loading settings from disk... (load #{LoadCount})");
        Thread.Sleep(300);
        DbConnection = "Server=localhost;Db=School";
        Theme = "Light";
    }
}

public class DatabaseService
{
    public AppConfig Config { get; } = AppConfig.Appconfig;

    public void Connect() => Console.WriteLine($"Connecting to {Config.DbConnection}");
}

public class UiService
{
    public AppConfig Config { get; } = AppConfig.Appconfig;

    public void Render() => Console.WriteLine($"UI is using theme: {Config.Theme}");
}