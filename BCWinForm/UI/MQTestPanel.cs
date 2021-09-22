using com.mirle.ibg3k0.mqc.tx;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.JSON;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.mirle.ibg3k0.bc.winform.UI
{
    public partial class MQTestPanel : Form
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        BCMainForm mainForm = null;
        private Line line = null;
        SCApplication scApp = null;
        HostDefaultValueDefMapAction hostDefaultMapAction = null;

        public MQTestPanel(BCMainForm _mainForm)
        {
            InitializeComponent();
            scApp = SCApplication.getInstance();
            line = scApp.getEQObjCacheManager().getLine();
            mainForm = _mainForm;

            hostDefaultMapAction = scApp.getEQObjCacheManager().getLine().getMapActionByIdentityKey(
                            typeof(HostDefaultValueDefMapAction).Name) as HostDefaultValueDefMapAction;
        }
        private void MQTestPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.removeForm("MQTestPanel");
        }

    }
}
