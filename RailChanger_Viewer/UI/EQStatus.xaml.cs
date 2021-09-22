using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RailChanger_Viewer.UI
{
    /// <summary>
    /// EQStatus.xaml 的互動邏輯
    /// </summary>
    public partial class EQStatus : UserControl
    {
        SCApplication scApp = null;
        Equipment voEQ = null;
        public EQStatus()
        {
            InitializeComponent();
        }

        public void CreateObjectByID(string _eqid)
        {
            try
            {
                scApp = SCApplication.getInstance();

                voEQ = scApp.getEQObjCacheManager().getEquipmentByEQPTID(_eqid);
                if (voEQ != null)
                {
                    initialUI(voEQ);
                    addEventHandle(voEQ);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void initialUI(Equipment voEQ)
        {
            try
            {
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    EQID.Text = voEQ.Eqpt_ID.Trim();
                    setEQAlive(voEQ.Is_EqAlive);
                    setMode(voEQ.Oper_Mode);
                    setRC_Side(voEQ.RC_Side);
                    setRC_BlockStatus(voEQ.Block_Status);
                    setRC_AutoOnOff(voEQ.Mode_Onoff);
                    setRC_DefaultSide(voEQ.Default_Side);
                    setRC_ChangeCount(voEQ.Change_Count);
                    setRC_ErrorReport(voEQ.Error_Report);
                    setRC_Version(voEQ.RC_Version);
                }), null);
            }
            catch (Exception ex)
            {

            }
        }

        string sHandlerID = string.Empty;
        private void addEventHandle(Equipment voEQ)
        {
            try
            {
                voEQ.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => voEQ.Is_EqAlive), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setEQAlive(voEQ.Is_EqAlive);
                }), null));

                voEQ.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => voEQ.Oper_Mode), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setMode(voEQ.Oper_Mode);
                }), null));

                voEQ.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => voEQ.RC_Side), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setRC_Side(voEQ.RC_Side);
                }), null));

                voEQ.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => voEQ.Block_Status), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setRC_BlockStatus(voEQ.Block_Status);
                }), null));

                voEQ.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => voEQ.Mode_Onoff), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setRC_AutoOnOff(voEQ.Mode_Onoff);
                }), null));

                voEQ.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => voEQ.Default_Side), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setRC_DefaultSide(voEQ.Default_Side);
                }), null));

                voEQ.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => voEQ.Change_Count), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setRC_ChangeCount(voEQ.Change_Count);
                }), null));

                voEQ.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => voEQ.Error_Report), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setRC_ErrorReport(voEQ.Error_Report);
                }), null));

                voEQ.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => voEQ.RC_Version), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setRC_Version(voEQ.RC_Version);
                }), null));

            }
            catch (Exception ex) { 

            }
        }
        /// <summary>
        /// 解除EQ監聽
        /// </summary>
        public void unsetEQAlive()
        {
            try
            {
                if(voEQ != null)
                    voEQ.RemoveAllEvents();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 更新EQ Alive
        /// </summary>
        private void setEQAlive(bool isAlive)
        {
            try
            {
                if (isAlive)
                {
                    EQAliveValue.Text = "ON";
                    EQAliveValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
                }
                else
                {
                    EQAliveValue.Text = "OFF";
                    EQAliveValue.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 更新EQ 運作功能狀態
        /// </summary>
        private void setMode(int mode)
        {
            try
            {
                switch (mode) {
                    case 0:
                        RailStatusValue.Text = "未初始化";
                        RailStatusValue.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        break;
                    case 1:
                        RailStatusValue.Text = "手動";
                        RailStatusValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
                        break;
                    case 2:
                        RailStatusValue.Text = "自動";
                        RailStatusValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
                        break;
                    case 3:
                        RailStatusValue.Text = "ERROR";
                        RailStatusValue.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 更新EQ 軌道狀態
        /// </summary>
        private void setRC_Side(int mode)
        {
            try
            {
                switch (mode)
                {
                    case 1:
                        RailSideValue.Text = "直軌";
                        RailSideValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
                        break;
                    case 2:
                        RailSideValue.Text = "彎軌";
                        RailSideValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 更新EQ 管轄軌道內有/無車
        /// </summary>
        private void setRC_BlockStatus(int status)
        {
            try
            {
                switch (status)
                {
                    case 0:
                        RailBlockStatusValue.Text = "未初始化";
                        RailBlockStatusValue.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        break;
                    case 1:
                        RailBlockStatusValue.Text = "有車";
                        RailBlockStatusValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
                        break;
                    case 2:
                        RailBlockStatusValue.Text = "無車";
                        RailBlockStatusValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 更新EQ 自動切換軌道狀態
        /// </summary>
        private void setRC_AutoOnOff(int OnOff)
        {
            try
            {
                switch (OnOff)
                {
                    case 0:
                        RailModeValue.Text = "Off";
                        RailModeValue.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        break;
                    case 1:
                        RailModeValue.Text = "On";
                        RailModeValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 更新EQ 自動切換軌道預測方向
        /// </summary>
        private void setRC_DefaultSide(int side)
        {
            try
            {
                switch (side)
                {
                    case 1:
                        RailDefaultSideValue.Text = "直軌";
                        RailDefaultSideValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
                        break;
                    case 2:
                        RailDefaultSideValue.Text = "彎軌";
                        RailDefaultSideValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 更新EQ 軌道切換次數
        /// </summary>
        private void setRC_ChangeCount(int count)
        {
            try
            {
                RailChangeAmout.Text = count.ToString();
                RailDefaultSideValue.Foreground = new SolidColorBrush(Color.FromRgb(7, 0, 34));
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 更新EQ ErrorReport
        /// </summary>
        private void setRC_ErrorReport(int error)
        {
            try
            {
                RailAlarmCode.Text = error.ToString();
                RailAlarmCode.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 更新EQ Version
        /// </summary>
        private void setRC_Version(int version)
        {
            try
            {
                RailVersion.Text = version.ToString();
                RailVersion.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
