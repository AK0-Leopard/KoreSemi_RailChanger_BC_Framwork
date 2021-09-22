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
using com.mirle.ibg3k0.bcf.Common;
using System.Threading;
using NLog;

namespace com.mirle.ibg3k0.bc.winform.UI.AGCComponent_DEMO
{
    public partial class Vehicle : UserControl
    {

        SCApplication scApp = null;
        Unit voUnit = null;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        public event EventHandler CarrerID_Click;

        public Vehicle()
        {
            InitializeComponent();
        }

        //屬性: CST是否存在
        public bool isExitCST
        {
            get
            {
                return CST.Visible;
            }
            set
            {
                CST.Visible = value;
            }
        }

        //屬性: 顯示CARRIER ID
        public string carrierID
        {
            get
            {
                return lab_carrierID.Text;
            }
            set
            {
                lab_carrierID.Text = value;
            }
        }

        //控件啟動
        public void Start(string _unitID)
        {
            try
            {
                //取得SCApplication實例
                scApp = SCApplication.getInstance();

                //取得UNIT物件
                voUnit = scApp.getEQObjCacheManager().getUnitByUnitID(_unitID);

                initialUI(voUnit);

                //新增監聽事件
                addEventHandle(voUnit);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //初始畫面
        private void initialUI(Unit _voUnit)
        {
            try
            {
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setCarrierID(_voUnit.Carrier_ID);
                }), null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //新增監聽事件
        string sHandlerID = string.Empty;
        private void addEventHandle(Unit _voUnit)
        {
            try
            {
                _voUnit.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => _voUnit.Carrier_ID), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setCarrierID(_voUnit.Carrier_ID);
                }), null));
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
                    setInfo(lab_carrierID, "--");
                    CST.Visible = false;
                }
                else
                {
                    setInfo(lab_carrierID, _carrierid);
                    CST.Visible = true;
                }
            }), null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //資訊設定
        private void setInfo(Label setLable, string setData)
        {
            try
            {
                if (setData == null)
                {
                    return;
                }
                else
                {
                    setLable.Text = setData.Trim();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //點選Carrier ID，即更新Port Detail Information於畫面最右側
        private void lab_carrierID_Click(object sender, EventArgs e)
        {
            try
            {
                if (CarrerID_Click != null)
                {
                    CarrerID_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }


    }
}
