//*********************************************************************************
//      AGC_Mainform.cs
//*********************************************************************************
// File Name: AGC_Mainform.cs
// Description: AGC Line系統主監控畫面
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************

using com.mirle.ibg3k0.bc.winform.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace com.mirle.ibg3k0.bc.winform.UI
{
    public partial class AGC_Mainform : Form
    {
        #region 公用參數設定
        Line line = null;
        BCApplication bcApp;
        BCMainForm mainForm;
        List<string> sEQList = new List<string>();
        List<Equipment> EQList = new List<Equipment>();
        SCApplication scApp = SCApplication.getInstance();
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        Dictionary<String, Form> openForms = new Dictionary<string, Form>();
        List<ConsoleMsg> systemConsole = new List<ConsoleMsg>();
        List<Cmd_Com> _cmdCom = new List<Cmd_Com>();
        Unit RGV1 = null;
        Unit RGV2_1 = null;
        Unit RGV2_2 = null;
        Unit RGV3_1 = null;
        Unit RGV3_2 = null;
        Unit RGV4 = null;
        Unit STK1_1 = null;
        Unit STK1_2 = null;
        Unit STK1_3 = null;
        Unit STK2_1 = null;
        Unit STK2_2 = null;
        Unit STK2_3 = null;
        Unit STK2_4 = null;

        Port STK111 = null;
        Port STK112 = null;
        Port STK121 = null;
        Port STK122 = null;
        Port STK131 = null;
        Port STK2111 = null;
        Port STK2112 = null;
        Port STK2211 = null;
        Port STK2212 = null;
        Port STK2221 = null;
        Port STK2222 = null;
        Port STK2311 = null;
        Port STK2312 = null;
        Port STK2321 = null;
        Port STK2322 = null;
        Port STK2411 = null;
        Port STK2412 = null;

        Port IO11 = null;
        Port IO12 = null;
        Port IO13 = null;
        Port IO14 = null;

        Port IO21 = null;
        Port IO22 = null;
        Port IO23 = null;
        Port IO24 = null;
        Port IO25 = null;
        Port IO26 = null;

        Port IO31 = null;
        Port IO32 = null;
        Port IO33 = null;
        Port IO34 = null;
        Port IO35 = null;
        Port IO36 = null;

        Port RGIO111 = null;
        Port RGIO112 = null;
        Port RGIO211 = null;
        Port RGIO212 = null;
        Port RGIO221 = null;
        Port RGIO222 = null;
        Port RGIO321 = null;
        Port RGIO322 = null;
        Port RGIO331 = null;
        Port RGIO332 = null;
        Port RGIO431 = null;
        Port RGIO432 = null;
        #endregion 公用參數設定

        #region 建構子
        public AGC_Mainform(BCMainForm _mainForm)
        {
            try
            {
                InitializeComponent();

                mainForm = _mainForm;

                bcApp = mainForm.BCApp;

                line = scApp.getEQObjCacheManager().getLine();

                dgv_CmdChk.AutoGenerateColumns = false;

                RGV1 = scApp.getEQObjCacheManager().getUnitByUnitID("RGV1_1");
                RGV2_1 = scApp.getEQObjCacheManager().getUnitByUnitID("RGV2_1");
                RGV2_2 = scApp.getEQObjCacheManager().getUnitByUnitID("RGV2_2");
                RGV3_1 = scApp.getEQObjCacheManager().getUnitByUnitID("RGV3_1");
                RGV3_2 = scApp.getEQObjCacheManager().getUnitByUnitID("RGV3_2");
                RGV4 = scApp.getEQObjCacheManager().getUnitByUnitID("RGV4_1");
                STK1_1 = scApp.getEQObjCacheManager().getUnitByUnitID("STK11_1");
                STK1_2 = scApp.getEQObjCacheManager().getUnitByUnitID("STK12_1");
                STK1_3 = scApp.getEQObjCacheManager().getUnitByUnitID("STK13_1");
                STK2_1 = scApp.getEQObjCacheManager().getUnitByUnitID("STK21_1");
                STK2_2 = scApp.getEQObjCacheManager().getUnitByUnitID("STK22_1");
                STK2_3 = scApp.getEQObjCacheManager().getUnitByUnitID("STK23_1");
                STK2_4 = scApp.getEQObjCacheManager().getUnitByUnitID("STK24_1");

                STK111 = scApp.getEQObjCacheManager().getPortByPortID("1103");
                STK112 = scApp.getEQObjCacheManager().getPortByPortID("1102");
                STK121 = scApp.getEQObjCacheManager().getPortByPortID("1203");
                STK122 = scApp.getEQObjCacheManager().getPortByPortID("1202");
                STK131 = scApp.getEQObjCacheManager().getPortByPortID("1303");
                STK2111 = scApp.getEQObjCacheManager().getPortByPortID("2101");
                STK2112 = scApp.getEQObjCacheManager().getPortByPortID("2103");
                STK2211 = scApp.getEQObjCacheManager().getPortByPortID("2206");
                STK2212 = scApp.getEQObjCacheManager().getPortByPortID("2204");
                STK2221 = scApp.getEQObjCacheManager().getPortByPortID("2201");
                STK2222 = scApp.getEQObjCacheManager().getPortByPortID("2203");
                STK2311 = scApp.getEQObjCacheManager().getPortByPortID("2306");
                STK2312 = scApp.getEQObjCacheManager().getPortByPortID("2304");
                STK2321 = scApp.getEQObjCacheManager().getPortByPortID("2301");
                STK2322 = scApp.getEQObjCacheManager().getPortByPortID("2303");
                STK2411 = scApp.getEQObjCacheManager().getPortByPortID("2407");
                STK2412 = scApp.getEQObjCacheManager().getPortByPortID("2405");

                IO11 = scApp.getEQObjCacheManager().getPortByPortID("5101");
                IO12 = scApp.getEQObjCacheManager().getPortByPortID("5102");
                IO13 = scApp.getEQObjCacheManager().getPortByPortID("5103");
                IO14 = scApp.getEQObjCacheManager().getPortByPortID("5104");

                IO21 = scApp.getEQObjCacheManager().getPortByPortID("5201");
                IO22 = scApp.getEQObjCacheManager().getPortByPortID("5202");
                IO23 = scApp.getEQObjCacheManager().getPortByPortID("5203");
                IO24 = scApp.getEQObjCacheManager().getPortByPortID("5204");
                IO25 = scApp.getEQObjCacheManager().getPortByPortID("5205");
                IO26 = scApp.getEQObjCacheManager().getPortByPortID("5206");

                IO31 = scApp.getEQObjCacheManager().getPortByPortID("5301");
                IO32 = scApp.getEQObjCacheManager().getPortByPortID("5302");
                IO33 = scApp.getEQObjCacheManager().getPortByPortID("5303");
                IO34 = scApp.getEQObjCacheManager().getPortByPortID("5304");
                IO35 = scApp.getEQObjCacheManager().getPortByPortID("5305");
                IO36 = scApp.getEQObjCacheManager().getPortByPortID("5306");

                RGIO111 = scApp.getEQObjCacheManager().getPortByPortID("3110");
                RGIO112 = scApp.getEQObjCacheManager().getPortByPortID("4101");
                RGIO211 = scApp.getEQObjCacheManager().getPortByPortID("3201");
                RGIO212 = scApp.getEQObjCacheManager().getPortByPortID("4106");
                RGIO221 = scApp.getEQObjCacheManager().getPortByPortID("3207");
                RGIO222 = scApp.getEQObjCacheManager().getPortByPortID("4208");
                RGIO321 = scApp.getEQObjCacheManager().getPortByPortID("3315");
                RGIO322 = scApp.getEQObjCacheManager().getPortByPortID("4201");
                RGIO331 = scApp.getEQObjCacheManager().getPortByPortID("3314");
                RGIO332 = scApp.getEQObjCacheManager().getPortByPortID("4301");
                RGIO431 = scApp.getEQObjCacheManager().getPortByPortID("3413");
                RGIO432 = scApp.getEQObjCacheManager().getPortByPortID("4308");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }
        #endregion 建構子

        #region 介面載入
        private void B_Line_Mainform_Load(object sender, EventArgs e)
        {
            try
            {
                //註冊Port組件
                registPort();

                //註冊Vehicle組件
                registVehicle();

                //註冊IO Port組件
                registIOPort();

                //註冊Command Check
                registCmdCheck();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }
        #endregion 介面載入

        #region 註冊Port組件
        private void registPort()
        {
            try
            {
                #region SMP-R1
                P191.Start("0191");
                P191.CST_Click += P191_CST_Click;
                #endregion SMP-R1

                #region ZF1
                P411.Start("0411");
                P412.Start("0412");
                P413.Start("0413");
                P414.Start("0414");
                P411.CST_Click += P411_CST_Click;
                P412.CST_Click += P412_CST_Click;
                P413.CST_Click += P413_CST_Click;
                P414.CST_Click += P414_CST_Click;
                #endregion ZF1

                #region ZF2
                P421.Start("0421");
                P422.Start("0422");
                P423.Start("0423");
                P424.Start("0424");
                P421.CST_Click += P421_CST_Click;
                P422.CST_Click += P422_CST_Click;
                P423.CST_Click += P423_CST_Click;
                P424.CST_Click += P424_CST_Click;
                #endregion ZF2

                #region ZF3
                P431.Start("0431");
                P432.Start("0432");
                P433.Start("0433");
                P434.Start("0434");
                P431.CST_Click += P431_CST_Click;
                P432.CST_Click += P432_CST_Click;
                P433.CST_Click += P433_CST_Click;
                P434.CST_Click += P434_CST_Click;
                #endregion ZF3

                #region ZP6
                P261.Start("0261");
                P262.Start("0262");
                P263.Start("0263");
                P264.Start("0264");
                P261.CST_Click += P261_CST_Click;
                P262.CST_Click += P262_CST_Click;
                P263.CST_Click += P263_CST_Click;
                P264.CST_Click += P264_CST_Click;
                #endregion ZP6

                #region ZP5
                P251.Start("0251");
                P252.Start("0252");
                P253.Start("0253");
                P254.Start("0254");
                P251.CST_Click += P251_CST_Click;
                P252.CST_Click += P252_CST_Click;
                P253.CST_Click += P253_CST_Click;
                P254.CST_Click += P254_CST_Click;
                #endregion ZP5

                #region ZP4
                P241.Start("0241");
                P242.Start("0242");
                P243.Start("0243");
                P244.Start("0244");
                P241.CST_Click += P241_CST_Click;
                P242.CST_Click += P242_CST_Click;
                P243.CST_Click += P243_CST_Click;
                P244.CST_Click += P244_CST_Click;
                #endregion ZP4

                #region ZP3
                P231.Start("0231");
                P232.Start("0232");
                P233.Start("0233");
                P234.Start("0234");
                P231.CST_Click += P231_CST_Click;
                P232.CST_Click += P232_CST_Click;
                P233.CST_Click += P233_CST_Click;
                P234.CST_Click += P234_CST_Click;
                #endregion ZP3

                #region ZP2
                P221.Start("0221");
                P222.Start("0222");
                P223.Start("0223");
                P224.Start("0224");
                P221.CST_Click += P221_CST_Click;
                P222.CST_Click += P222_CST_Click;
                P223.CST_Click += P223_CST_Click;
                P224.CST_Click += P224_CST_Click;
                #endregion ZP2

                #region ZP1
                P211.Start("0211");
                P212.Start("0212");
                P213.Start("0213");
                P214.Start("0214");
                P211.CST_Click += P211_CST_Click;
                P212.CST_Click += P212_CST_Click;
                P213.CST_Click += P213_CST_Click;
                P214.CST_Click += P214_CST_Click;
                #endregion ZP1

                #region SMP-R2-1
                P291.Start("0291");
                P291.CST_Click += P291_CST_Click;
                #endregion SMP-R2-1

                #region ZAW
                P101.Start("0101");
                P101.CST_Click += P101_CST_Click;
                #endregion ZAW

                #region SWM
                P202.Start("0202");
                P202.CST_Click += P202_CST_Click;
                #endregion SWM

                #region APW
                P203.Start("0203");
                P203.CST_Click += P203_CST_Click;
                #endregion APW

                #region INS
                P441.Start("0441");
                P442.Start("0442");
                P443.Start("0443");
                P444.Start("0444");
                P441.CST_Click += P441_CST_Click;
                P442.CST_Click += P442_CST_Click;
                P443.CST_Click += P443_CST_Click;
                P444.CST_Click += P444_CST_Click;
                #endregion INS

                #region ZFW
                P341.Start("0341");
                P401.Start("0401");
                P341.CST_Click += P341_CST_Click;
                P401.CST_Click += P401_CST_Click;
                #endregion ZFW

                #region ZR1
                P331.Start("0331");
                P332.Start("0332");
                P333.Start("0333");
                P334.Start("0334");
                P331.CST_Click += P331_CST_Click;
                P332.CST_Click += P332_CST_Click;
                P333.CST_Click += P333_CST_Click;
                P334.CST_Click += P334_CST_Click;
                #endregion ZR1

                #region ZN2
                P321.Start("0321");
                P322.Start("0322");
                P323.Start("0323");
                P324.Start("0324");
                P321.CST_Click += P321_CST_Click;
                P322.CST_Click += P322_CST_Click;
                P323.CST_Click += P323_CST_Click;
                P324.CST_Click += P324_CST_Click;
                #endregion ZN2

                #region ZN1
                P311.Start("0311");
                P312.Start("0312");
                P313.Start("0313");
                P314.Start("0314");
                P311.CST_Click += P311_CST_Click;
                P312.CST_Click += P312_CST_Click;
                P313.CST_Click += P313_CST_Click;
                P314.CST_Click += P314_CST_Click;
                #endregion ZN1

                #region ZRW
                P271.Start("0271");
                P301.Start("0301");
                P271.CST_Click += P271_CST_Click;
                P301.CST_Click += P301_CST_Click;
                #endregion ZRW

                #region SMP02-2
                P921.Start("0921");
                P921.CST_Click += P921_CST_Click;
                #endregion SMP02-2

                #region SMP02-1
                P922.Start("0922");
                P922.CST_Click += P922_CST_Click;
                #endregion SMP02-1

                #region SMP-R2-2 
                P292.Start("0292");
                P292.CST_Click += P292_CST_Click;
                #endregion SMP-R2-2 

                #region SMP01-1
                P911.Start("0911");
                P911.CST_Click += P911_CST_Click;
                #endregion SMP01-1

                #region SMP01-2
                P912.Start("0912");
                P912.CST_Click += P912_CST_Click;
                #endregion SMP01-2

                #region ZA1
                P111.Start("0111");
                P112.Start("0112");
                P113.Start("0113");
                P114.Start("0114");
                P115.Start("0115");
                P116.Start("0116");
                P111.CST_Click += P111_CST_Click;
                P112.CST_Click += P112_CST_Click;
                P113.CST_Click += P113_CST_Click;
                P114.CST_Click += P114_CST_Click;
                P115.CST_Click += P115_CST_Click;
                P116.CST_Click += P116_CST_Click;
                #endregion ZA1

                #region ZPW
                P121.Start("0121");
                P201.Start("0201");
                P121.CST_Click += P121_CST_Click;
                P201.CST_Click += P201_CST_Click;
                #endregion ZPW
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }
        #endregion 註冊Port組件

        #region SMP-R1 Click Event(P191)
        private void P191_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0191");
            PortDetail.Visible = true;
        }
        #endregion SMP-R1 Click Event(P191)

        #region ZPW Click Event(P121、P201)
        private void P121_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0121");
            PortDetail.Visible = true;
        }

        private void P201_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("201");
            PortDetail.Visible = true;
        }
        #endregion ZPW Click Event(P121、P201)

        #region ZA1 Click Evnet(P111、P112、P113、P114、P115、P116)
        private void P111_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0111");
            PortDetail.Visible = true;
        }

        private void P112_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0112");
            PortDetail.Visible = true;
        }
        private void P113_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0113");
            PortDetail.Visible = true;
        }
        private void P114_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0114");
            PortDetail.Visible = true;
        }
        private void P115_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0115");
            PortDetail.Visible = true;
        }
        private void P116_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0116");
            PortDetail.Visible = true;
        }
        #endregion ZA1 Click Evnet(P111、P112、P113、P114、P115、P116)

        #region SMP01-1 Click Evnet(P911)
        private void P911_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0911");
            PortDetail.Visible = true;
        }
        #endregion SMP01-1 Click Evnet(P911)

        #region SMP01-2 Click Evnet(P912)
        private void P912_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0912");
            PortDetail.Visible = true;
        }
        #endregion SMP01-2 Click Evnet(P912)

        #region SMP-R2-2 Click Event(P292)
        private void P292_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0292");
            PortDetail.Visible = true;
        }
        #endregion SMP-R2-2 Click Event(P292)

        #region SMP02-2 Click Evnet(P921)
        private void P921_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0921");
            PortDetail.Visible = true;
        }
        #endregion SMP02-2 Click Evnet(P921)

        #region SMP02-1 Click Evnet(P922)
        private void P922_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0922");
            PortDetail.Visible = true;
        }
        #endregion SMP02-1 Click Evnet(P922)

        #region ZRW Click Event(P271、P301)
        private void P271_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0271");
            PortDetail.Visible = true;
        }

        private void P301_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0301");
            PortDetail.Visible = true;
        }
        #endregion ZRW Click Event(P271、P301)

        #region ZN1 Click Event(P311、P312、P313、P314)
        private void P311_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0311");
            PortDetail.Visible = true;
        }

        private void P312_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0312");
            PortDetail.Visible = true;
        }

        private void P313_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0313");
            PortDetail.Visible = true;
        }

        private void P314_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0314");
            PortDetail.Visible = true;
        }
        #endregion ZN1 Click Event(P311、P312、P313、P314)

        #region ZN2 Click Event(P321、P322、P323、P324)
        private void P321_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0321");
            PortDetail.Visible = true;
        }

        private void P322_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0322");
            PortDetail.Visible = true;
        }

        private void P323_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0323");
            PortDetail.Visible = true;
        }

        private void P324_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0324");
            PortDetail.Visible = true;
        }
        #endregion ZN2 Click Event(P321、P322、P323、P324)

        #region ZR1 Click Event(P331、P332、P333、P334)
        private void P331_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0331");
            PortDetail.Visible = true;
        }

        private void P332_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0332");
            PortDetail.Visible = true;
        }

        private void P333_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0333");
            PortDetail.Visible = true;
        }

        private void P334_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0334");
            PortDetail.Visible = true;
        }
        #endregion ZR1 Click Event(P331、P332、P333、P334)

        #region ZFW Click Event(P341、P401)
        private void P341_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0341");
            PortDetail.Visible = true;
        }

        private void P401_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0401");
            PortDetail.Visible = true;
        }
        #endregion ZFW Click Event(P341、P401)

        #region INS Click Event(P441、P442、P443、P444)
        private void P441_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0441");
            PortDetail.Visible = true;
        }

        private void P442_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0442");
            PortDetail.Visible = true;
        }

        private void P443_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0443");
            PortDetail.Visible = true;
        }

        private void P444_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0444");
            PortDetail.Visible = true;
        }
        #endregion INS Click Event(P441、P442、P443、P444)

        #region ZAW Click Evnet(P101)
        private void P101_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0101");
            PortDetail.Visible = true;
        }
        #endregion ZAW Click Evnet(P101)

        #region SWM Click Evnet(P202)
        private void P202_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0202");
            PortDetail.Visible = true;
        }
        #endregion SWM Click Evnet(P202)

        #region APW Click Evnet(P203)
        private void P203_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0203");
            PortDetail.Visible = true;
        }
        #endregion APW Click Evnet(P203)

        #region SMP-R2-1 Click Event(P291)
        private void P291_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0291");
            PortDetail.Visible = true;
        }
        #endregion SMP-R2-1 Click Event(P291)

        #region ZP1 Click Event(P211、P212、P213、P214)
        private void P211_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0211");
            PortDetail.Visible = true;
        }

        private void P212_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0212");
            PortDetail.Visible = true;
        }

        private void P213_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0213");
            PortDetail.Visible = true;
        }

        private void P214_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("214");
            PortDetail.Visible = true;
        }
        #endregion ZP1 Click Event(P211、P212、P213、P214)

        #region ZP2 Click Event(P221、P222、P223、P224)
        private void P221_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0221");
            PortDetail.Visible = true;
        }

        private void P222_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0222");
            PortDetail.Visible = true;
        }

        private void P223_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0223");
            PortDetail.Visible = true;
        }

        private void P224_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0224");
            PortDetail.Visible = true;
        }
        #endregion ZP2 Click Event(P221、P222、P223、P224)

        #region ZP3 Click Event(P231、P232、P233、P234)
        private void P231_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0231");
            PortDetail.Visible = true;
        }

        private void P232_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0232");
            PortDetail.Visible = true;
        }

        private void P233_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0233");
            PortDetail.Visible = true;
        }

        private void P234_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0234");
            PortDetail.Visible = true;
        }
        #endregion ZP3 Click Event(P231、P232、P233、P234)

        #region ZP4 Click Event (P241、P242、P243、P244)
        private void P241_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0241");
            PortDetail.Visible = true;
        }

        private void P242_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0242");
            PortDetail.Visible = true;
        }

        private void P243_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0243");
            PortDetail.Visible = true;
        }

        private void P244_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0244");
            PortDetail.Visible = true;
        }
        #endregion ZP4 Click Event (P241、P242、P243、P244)

        #region ZP5 Click Event (P251、P252、P253、P254)
        private void P251_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0251");
            PortDetail.Visible = true;
        }

        private void P252_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0252");
            PortDetail.Visible = true;
        }

        private void P253_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0253");
            PortDetail.Visible = true;
        }

        private void P254_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0254");
            PortDetail.Visible = true;
        }
        #endregion ZP5 Click Event (P251、P252、P253、P254)

        #region ZP6 Click Event (P261、P262、P263、P264)
        private void P261_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0261");
            PortDetail.Visible = true;
        }

        private void P262_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0262");
            PortDetail.Visible = true;
        }

        private void P263_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0263");
            PortDetail.Visible = true;
        }

        private void P264_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0264");
            PortDetail.Visible = true;
        }
        #endregion ZP6 Click Event (P261、P262、P263、P264)

        #region ZF1 Click Event (P411、P412、P413、P414)
        private void P411_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0411");
            PortDetail.Visible = true;
        }
        private void P412_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0412");
            PortDetail.Visible = true;
        }
        private void P413_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0413");
            PortDetail.Visible = true;
        }
        private void P414_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0414");
            PortDetail.Visible = true;
        }
        #endregion ZF1 Click Event (P411、P412、P413、P414)

        #region ZF2 Click Event (P421、P422、P423、P424)
        private void P421_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0421");
            PortDetail.Visible = true;
        }
        private void P422_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0422");
            PortDetail.Visible = true;
        }
        private void P423_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0423");
            PortDetail.Visible = true;
        }
        private void P424_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0424");
            PortDetail.Visible = true;
        }
        #endregion ZF2 Click Event (P421、P422、P423、P424)

        #region ZF3 Click Event (P431、P432、P433、P434)
        private void P431_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0431");
            PortDetail.Visible = true;
        }
        private void P432_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0432");
            PortDetail.Visible = true;
        }
        private void P433_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0433");
            PortDetail.Visible = true;
        }
        private void P434_CST_Click(object sender, EventArgs e)
        {
            hidePortAndCarrierDetail();
            PortDetail.updatePortDetail("0434");
            PortDetail.Visible = true;
        }
        #endregion ZF3 Click Event (P431、P432、P433、P434)


        private void hidePortAndCarrierDetail()
        {
            PortDetail.Visible = false;
            CarrierDetail.Visible = false;
        }

        string sHandlerID = "MainForm";
        #region 註冊Vehicle組件
        private void registVehicle()
        {
            try
            {
                //RGV1.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGV1.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(RGV1, RGV1_CST);
                //}), null));


                //RGV2_1.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGV2_1.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(RGV2_1, RGV2_1_CST);
                //}), null));

                //RGV2_2.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGV2_2.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(RGV2_2, RGV2_2_CST);
                //}), null));

                //RGV3_1.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGV3_1.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(RGV3_1, RGV3_1_CST);
                //}), null));

                //RGV3_2.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGV3_2.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(RGV3_2, RGV3_2_CST);
                //}), null));

                //RGV4.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGV4.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(RGV4, RGV4_CST);
                //}), null));

                //STK1_1.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK1_1.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(STK1_1, STK1_1_CST);
                //}), null));

                //STK1_2.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK1_2.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(STK1_2, STK1_2_CST);
                //}), null));

                //STK1_3.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK1_3.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(STK1_3, STK1_3_CST);
                //}), null));

                //STK2_1.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2_1.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(STK2_1, STK2_1_CST);
                //}), null));

                //STK2_2.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2_2.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(STK2_2, STK2_2_CST);
                //}), null));

                //STK2_3.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2_3.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(STK2_3, STK2_3_CST);
                //}), null));

                //STK2_4.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2_4.Carrier_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnRGV(STK2_4, STK2_4_CST);
                //}), null));
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }
        #endregion 註冊Vehicle組件

        private void setCSTOnRGV(Unit _unit, PictureBox _picBox)
        {
            try
            {
                if (_unit == null)
                {
                    _picBox.Visible = false;
                }
                else if (_unit.Carrier_ID.Trim() == "")
                {
                    _picBox.Visible = false;
                }
                else
                {
                    _picBox.Visible = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        #region 註冊IO Port組件
        private void registIOPort()
        {
            try
            {
                //STK111.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK111.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK111, STK111_CST);
                //}), null));

                //STK112.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK112.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK112, STK112_CST);
                //}), null));

                //STK121.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK121.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK121, STK121_CST);
                //}), null));

                //STK122.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK122.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK122, STK122_CST);
                //}), null));

                //STK131.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK131.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK131, STK131_CST);
                //}), null));

                //STK2111.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2111.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2111, STK2111_CST);
                //}), null));

                //STK2112.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2112.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2112, STK2112_CST);
                //}), null));

                //STK2211.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2211.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2211, STK2211_CST);
                //}), null));

                //STK2212.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2212.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2212, STK2212_CST);
                //}), null));

                //STK2221.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2221.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2221, STK2221_CST);
                //}), null));

                //STK2222.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2222.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2222, STK2222_CST);
                //}), null));

                //STK2311.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2311.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2311, STK2311_CST);
                //}), null));

                //STK2312.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2312.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2312, STK2312_CST);
                //}), null));

                //STK2321.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2321.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2321, STK2321_CST);
                //}), null));

                //STK2322.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2322.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2322, STK2322_CST);
                //}), null));

                //STK2411.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2411.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2411, STK2411_CST);
                //}), null));

                //STK2412.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => STK2412.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(STK2412, STK2412_CST);
                //}), null));

                //IO11.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO11.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO11, IO11_CST);
                //}), null));

                //IO12.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO12.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO12, IO12_CST);
                //}), null));

                //IO13.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO13.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO13, IO13_CST);
                //}), null));

                //IO14.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO14.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO14, IO14_CST);
                //}), null));

                //IO21.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO21.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO21, IO21_CST);
                //}), null));

                //IO22.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO22.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO22, IO22_CST);
                //}), null));

                //IO23.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO23.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO23, IO23_CST);
                //}), null));

                //IO24.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO24.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO24, IO24_CST);
                //}), null));

                //IO25.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO25.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO25, IO25_CST);
                //}), null));

                //IO26.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO26.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO26, IO26_CST);
                //}), null));

                //IO31.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO31.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO31, IO31_CST);
                //}), null));

                //IO32.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO32.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO32, IO32_CST);
                //}), null));

                //IO33.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO33.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO33, IO33_CST);
                //}), null));

                //IO34.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO34.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO34, IO34_CST);
                //}), null));

                //IO35.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO35.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO35, IO35_CST);
                //}), null));

                //IO36.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => IO36.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(IO36, IO36_CST);
                //}), null));

                //RGIO111.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO111.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO111, RGIO11_CST);
                //}), null));

                //RGIO112.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO112.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO112, RGIO11_CST);
                //}), null));

                //RGIO211.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO211.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO211, RGIO21_CST);
                //}), null));

                //RGIO212.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO212.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO212, RGIO21_CST);
                //}), null));

                //RGIO221.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO221.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO221, RGIO22_CST);
                //}), null));

                //RGIO222.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO222.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO222, RGIO22_CST);
                //}), null));

                //RGIO321.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO321.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO321, RGIO32_CST);
                //}), null));

                //RGIO322.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO322.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO322, RGIO32_CST);
                //}), null));

                //RGIO331.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO331.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO331, RGIO33_CST);
                //}), null));

                //RGIO332.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO332.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO332, RGIO33_CST);
                //}), null));

                //RGIO431.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO431.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO431, RGIO43_CST);
                //}), null));

                //RGIO432.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => RGIO432.Crr_ID), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setCSTOnPort(RGIO432, RGIO43_CST);
                //}), null));
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }
        #endregion 註冊IO Port組件

        private void setCSTOnPort(Port port, PictureBox picBox)
        {
            try
            {
                if (port == null)
                {
                    picBox.Visible = false;
                }
                else if (port.Crr_ID.Trim() == "")
                {
                    picBox.Visible = false;
                }
                else
                {
                    picBox.Visible = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        #region 註冊Command List組件
        private void registCmdCheck()
        {
            try
            {
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }
        #endregion

        #region Command Check
        private void updateCmdChk()
        {
            try
            {
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        private void updateCmdChkLcs()
        {
            try
            {
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        #endregion Command Check

        #region 加速開啟畫面
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        #endregion 加速開啟畫面
    }
}
