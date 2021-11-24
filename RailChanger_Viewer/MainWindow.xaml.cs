using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using com.mirle.ibg3k0.sc.Data.VO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RailChanger_Viewer
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        SCApplication scApp = null;
        Equipment eqpt = null;

        public MainWindow()
        {
            InitializeComponent();
            scApp = SCApplication.getInstance();

            cbx_RC_Number.SelectionChanged += cbx_RC_Number_SelectedIndexChanged;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RAIL_Sync_Start(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                /*String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_Sync_Start();
                btn_sync_start.Visibility = Visibility.Hidden;
                btn_sync_stop.Visibility = Visibility.Visible;
                EQ_Status.CreateObjectByID(EQ_ID);*/

            }
            catch (Exception ex)
            {

            }
        }

        private void cbx_RC_Number_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            String Number = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            String EQ_ID = "RC" + Number.PadLeft(2, '0'); ;
            EQ_Status.unsetEQAlive();
            EQ_Status.CreateObjectByID(EQ_ID);
        }
        private void RAIL_Sync_Stop(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_Sync_Stop();
            }
            catch (Exception ex)
            {

            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            scApp.stop();
        }

        private bool CheckIsInput()
        {
            if (cbx_RC_Number.Text.Equals(""))
            {
                MessageBox.Show("請選擇換軌機編號！");
                return true;
            }
            else
                return false;
        }

        private void Alarm_Reset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput()) {
                    return;
                }

                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_ALARMRESET();

            }
            catch (Exception ex)
            {

            }
        }

        private void Block_Reset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_RESET_CAREXIST();
            }
            catch (Exception ex)
            {

            }
        }

        private void Block_AllReset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                for (int i = 1; i <= 42; i++) {
                    String EQ_ID = "RC" + i.ToString().PadLeft(2, '0'); ;
                    Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                    RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                    MapAction.RAIL_RESET_CAREXIST();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SideChange_Left_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_RAILSIDESET(SCAppConstants.RC_Side.LEFT);
            }
            catch (Exception ex)
            {

            }
        }

        private void SideChange_Rightt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_RAILSIDESET(SCAppConstants.RC_Side.RIGHT);
            }
            catch (Exception ex)
            {

            }
        }

        private void Mode_Auto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_MODESET(SCAppConstants.RC_Mode.AUTO);
            }
            catch (Exception ex)
            {

            }
        }

        private void Mode_Manual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_MODESET(SCAppConstants.RC_Mode.MANUAL);
            }
            catch (Exception ex)
            {

            }
        }
         
        private void FoceStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_FORCESTOP();
            }
            catch (Exception ex)
            {

            }
        }

        private void AutoChange_Left_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_ISAUTORUN(SCAppConstants.RC_Side.LEFT, SCAppConstants.RC_OnOff.ON, int.Parse(tbx_delay_time.Text));
            }
            catch (Exception ex)
            {

            }

        }
        private void AutoChange_Right_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_ISAUTORUN(SCAppConstants.RC_Side.RIGHT,SCAppConstants.RC_OnOff.ON, int.Parse(tbx_delay_time.Text));
            }
            catch (Exception ex)
            {

            }
        }
        private void AutoChange_Stop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckIsInput())
                {
                    return;
                }
                String EQ_ID = "RC" + cbx_RC_Number.Text.PadLeft(2, '0'); ;
                Equipment eqpt = scApp.getEQObjCacheManager().getEquipmentByEQPTID(EQ_ID);
                RailChangerDefaultValueDefMapAction MapAction = eqpt.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
                MapAction.RAIL_ISAUTORUN(SCAppConstants.RC_Side.LEFT, SCAppConstants.RC_OnOff.OFF, int.Parse(tbx_delay_time.Text));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
