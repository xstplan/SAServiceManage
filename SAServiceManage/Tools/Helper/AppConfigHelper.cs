using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace SAServiceManage.Tools.Helper
{
    /// <summary>
    /// ConfigApp配置类
    /// </summary>
    public class AppConfigHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static AppConfigHelper Instance = new Lazy<AppConfigHelper>(() => new AppConfigHelper()).Value;
        private XmlLanguage _lang = XmlLanguage.GetLanguage(GetAppSettings("Langs").ToString());

        public XmlLanguage Lang
        {
            get => _lang;
            set
            {
                if (!_lang.IetfLanguageTag.Equals(value.IetfLanguageTag))
                {
                    _lang = value;
                    OnPropertyChanged(nameof(Lang));
                }
            }
        }
        public void SetLang(string lang)
        {
            Application.Current.Dispatcher.Thread.CurrentUICulture = new CultureInfo(lang);
            Lang = XmlLanguage.GetLanguage(lang);
        }
        /// <summary>
        /// 保存Setting配置文件
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static bool SaveAppSettings(string key, string value)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings[key].Value = value;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// 根据key获取value
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key].ToString();
                return value;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
