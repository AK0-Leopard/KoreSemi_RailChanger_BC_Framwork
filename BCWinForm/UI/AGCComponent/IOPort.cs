using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using com.mirle.ibg3k0.bcf.Common;
using System.Threading;

namespace com.mirle.ibg3k0.bc.winform.UI.AGCComponent_DEMO
{
    public partial class IOPort : UserControl
    {
        Port ioport = null;
        SCApplication scApp = null;
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public IOPort()
        {
            InitializeComponent();
        }

        public bool isExitCST
        {
            get
            {
                return ExitCST.Visible;
            }
            set
            {
                ExitCST.Visible = value;
            }
        }

        //控件啟動
        public void Start(string _LocationID)
        {
            try
            {
                //取得SCApplication實例
                scApp = SCApplication.getInstance();

                //取得UNIT物件
                //ioport = scApp.getEQObjCacheManager().getPortByPortID(_LocationID);

                if (ioport != null)
                {
                    //初始畫面
                    initialUI(ioport);

                    //新增監聽事件
                    addEventHandle(ioport);
                }
                else
                {
                    ExitCST.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //初始畫面
        private void initialUI(Port _ioPort)
        {
            try
            {
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    //setCarrierID(_ioPort.IO_Crr_ID);
                }), null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //新增監聽事件
        string sHandlerID = string.Empty;
        private void addEventHandle(Port _ioPort)
        {
            try
            {
                //_ioPort.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => _ioPort.IO_Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCarrierID(_ioPort.IO_Crr_ID);
                //}), null));
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //設定Carrier ID
        private void setCarrierID(string _carrierid)
        {
            try
            {
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    if (_carrierid == null || _carrierid == "")
                    {
                        ExitCST.Visible = false;
                    }
                    else
                    {
                        ExitCST.Visible = true;
                    }
                }), null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

    }
}
