using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class XlgLen
    {
        /******************************************************************************************/
        /*                                                                                        */
        /*        System:  LCD Project system                                                     */
        /*                                                                                        */
        /*   FILE   name:  XLGLEN.H                                                               */
        /*                                                                                        */
        /*   Module type:  definition for common macro                                            */
        /*                                                                                        */
        /*          Note:  Length Definition                                                      */
        /*                                                                                        */
        /*   (c) Copyright 2007, International Business Machines-Taiwan Corp                      */
        /*                                                                                        */
        /*  Modification history:                                                                 */
        /*    Date     Ver       Name     Description                                             */
        /* ---------- ----- ------------- ------------------------------------------------------- */
        /* 2007/06/01 A0.00 IBM         Initial release                                           */
        /* 2007/07/10 A0.01 Sabina Fu   Add length define for SPC subsystem                       */
        /* 2007/08/07 A0.02 S.H.Lin     Add length define for PMS subsystem                       */
        /* 2007/11/05 A0.03 Daniel Yuan Add length define for BRM_BOMID                           */
        /* 2007/11/14 A0.04 S.Y.Su      Add length define MTRL_SEQ_NO_LEN                         */
        /* 2007/12/17 A0.05 Cathy Wang  Chg PNL_CHAR_POS to 11                                    */
        /* 2007/12/18 A0.06 Cathy Wang  Add BIN_ID_LEN , JUDGE_RULE_ID_LEN , LOGISTICS_LEN        */
        /*                                  OQC_BATCH_ID_LEN , DEFECT_CODE_LEN                    */
        /* 2007/12/18 A0.07 AdamTsai    Chg BAY_ID_LEN,EQPT_ID_LEN,EQPTG_ID_LEN,ROUTE_ID_LEN      */
        /*                                  TRM_ID_LEN ,BAY_DSC_LEN,RECIPE_ID_LEN,EQPT_DSC_LEN    */
        /*                                  LAYOUT_DSC_LEN,CODE_DSC_LEN,MENU_DSC_LEN,OPE_DSC_LEN  */
        /*                                  PRODUCT_DSC_LEN,ROUTE_DSC_LEN,RWK_DSC_LEN             */
        /* 2007/12/19 A0.08 Cathy Wang  Chg DEFECT_CNT_LEN 3 to 4                                 */
        /*                              Add OQC_BATCH_QTY_LEN , OQC_SMP_CNT_LEN                   */
        /* 2007/12/20 A0.09 Randy Ho    Chg CRR_ID_LEN 25 -> 30 ,LOT_ID_LEN, SHT_ID_LEN to 30     */
        /* 2007/12/26 A0.10 Randy Ho    Add PROC_STEP_LEN                                         */
        /* 2007/12/31 A0.11 Sabina fu   Add length define for BRM_BIN                             */
        /*                              Add JUDGE_CODE_8_LEN                                      */
        /*                              Chg BIN_ID_LEN -> 25, BON_ID_LEN -> 25                    */
        /* 2008/01/02 A0.12 Cathy Wang  Add SGR_ID_11_SIL_POS,SGR_ID_SIL_1_LEN                    */
        /* 2008/01/03 A0.13 Mike Chiu   Add PAK_ID_10_POS, PAK_ID_3_LEN, PAK_ID_LEN               */
        /* 2008/01/04 A0.14 Randy Ho    Chg KEY_ID_LEN 25 --> 30                                  */
        /* 2008/01/07 A0.15 Mike Chi    Add PPBOX_STAT_LEN -> 4                                   */
        /* 2008/01/10 A0.16 Ray  Liu    Add TACT_TIME_LEN  -> 4                                   */
        /* 2008/01/14 A0.17 Eric Su     Chg ROUTE_ID_LEN  -> 16, ADDT_INFO_LEN -> 25              */
        /*																						  */
        /* 2008/02/20 A0.25 Stella      Chg DATA_GROUP_LEN  -> 32                                 */
        /* 2008/04/01 A0.27 Stella      Chg MTRL_CNT_LEN  6 ->  16                                */
        /* 2008/04/07 A0.28 Cathy Wang  Add MTRL_CNT_6_LEN                                        */
        /* 2009/06/19 A0.29 Yvonne Tsai Chg PNL_CHAR_POS --> 12    LINE_ID_LEN-->4                */
        /*                              Add PQM_HOLD_ACTION_LEN, PQM_DESC_128_LEN, PQM_AREA_ID_LEN*/
        /*                                  PQM_REASON_ID_LEN, PQM_ACTION_ID_LEN, PQM_ACTION_DESC_LEN */
        /*                                  PQM_FIXTURE_ID_LEN, PQM_SPEC_RC_LEN ,LIMIT_NUM_LEN    */
        /*                                  ORDERNO_LEN & CIP_PTN_LEN for DCS	                  */
        /*                                  ALRT_CODE_LEN	                                      */
        /*                             	Chg GLASSID_LEN 16-->30                                   */
        /* 2009/06/26 A0.30 Yvonne Tsai Add AMS len define                                        */
        /* 2009/06/26 A0.31 Yvonne Tsai Add PMS len define                                        */
        /* 2009/09/23 A0.32 Yvonne Tsai Add NOTE_LEN                                              */

        /* 2011/06/30 A0.36 S.H.Lin     Chg PASSWORD_LEN from 8 to 20, and sync (w/ xlgext.h):    */
        /*                                DB_NAME_LEN = DB_NAME_CK_LEN = UAS_DB_NAME_LEN = 10     */
        /*                                DB_USER_LEN = DB_USER_CK_LEN = UAS_DB_USER_LEN = 18     */
        /*                                DB_PASSWD_LEN = DB_PASSWD_CK_LEN = UAS_DB_PASSWD_LEN = 18 */
        /* 2011/12/08 A0.37 Shaun Chen Add CERT_ID_LEN                                            */
        /* 2011/12/12 A0.38 Yvonne Tsai  Remove AMS and PMS len define to XlgLenAMS.java and XlgLenPMS.java
        /******************************************************************************************/
        /*----------------------------------------------------------------------------------------*/
        /*  definition Tranzaction                                                                */
        /*----------------------------------------------------------------------------------------*/
        public const int PGM_NAME_LEN = 10; /*                                  */
        public const int QMNAME_LEN = 16; /*                                  */
        public const int QNAME_LEN = 16; /*                                  */
        public const int TQ_NAME_LEN = 20; /*                                  */
        /*                                  */
        //A0.07  #define    TRM_ID_LEN                     8           /*                                  */
        public const int TRM_ID_LEN = 12; /*                                  */ //A0.07
        public const int SYS_SUFFIX_LEN = 3; /*                                  */
        /*     define <CS2CODFN.H>          */
        public const int MAX_COL_CNT = 255; /* Max Column Count of Table        */
        /*                                  */
        public const int MAX_NODE = 20; /* max line of node definition      */
        /*                                  */
        public const int TRX_ID_LEN = 8; /*                                  */
        public const int TRX_TYP_LEN = 1; /*                                  */
        public const int RTN_CODE_LEN = 7; /*                                  */
        public const int RTN_MSG_LEN = 20; /*                                  */
        public const int TRX_MAX_SIZE = 5; /*                                  */
        public const int EVT_INTRX_LEN = 90; /*                                  */
        public const int EVT_OUTTRX_LEN = 90; /*                                  */
        public const int MSG_LOG_LEN = 1024; /* message log buffer len           */
        /*                                  */
        public const int BUFF_64_LEN = 64; /*                                  */
        public const int BUFF_256_LEN = 256; /*                                  */
        public const int BUFF_512_LEN = 512; /*                                  */
        /*                                  */
        public const int TIME_STAMP_LEN = 26; /* Time stamp length                */
        public const int ONCHID_LEN = 50; /* Chart ID Length                  */
        public const int ONCHTYPE_LEN = 6; /* Chart Type Length                */
        public const int MSRTYPE_LEN = 4; /* Measurement Type Length          */
        public const int DETAIL_ACTION_LEN = 6; /* Detail Action Length             */
        public const int SPEC_SEQ_LEN = 40; /* Spec Seq. Length                 */
        public const int CL_SEQ_LEN = 40; /* Control Seq. Length              */
        /*                                  */
        public const int CS2NAME_LEN = 20; /* Using NBRM Library               */
        /*                                  */
        public const int TBLOPE_CODE_LEN = 6; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  common use macro definition in program                                                */
        /*----------------------------------------------------------------------------------------*/
        public const int _FOREVER = 1; /* forever while loop               */
        public const int MAX_RETRY = 5000; /* retry count limitation           */
        public const int WAIT_RECONNECT_DB = 10; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  common use return code macro definition in program                                    */
        /*----------------------------------------------------------------------------------------*/
        public const int _NORMAL = 0; /* normal function return           */
        public const int _ERROR = 1; /* abend  function return           */
        /*                                  */
        public const int _FALSE = 0; /*                                  */
        public const int _TRUE = 1; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  macro definition for sub function                                                     */
        /*----------------------------------------------------------------------------------------*/
        /*-- Transaction function ----------------------------------------------------------------*/
        public const long S_TIMO = 5L; /* send timeout                     */
        public const long R_TIMO = -1L; /* receive time out                 */
        public const long DEF_SEND_TIMO = 30L; /* Default send timeout             */
        public const long DEF_RECV_TIMO = 30L; /* Default receive timeout          */
        public const long RECV_UNLIMITED = -1L; /* Receive time unlimited           */
        public const long RECV_NO_WAIT = 0L; /* Receive no wait                  */
        public const long TIME_OUT_BASE = 9L; /* 90 secs for DCS                  */
        /*                                  */
        /*-- Read Lock ---------------------------------------------------------------------------*/
        public const int MAX_READ_LOCK_CNT = 1; /* Retry Count                      */
        /*                                  */
        /*-- Re Connect --------------------------------------------------------------------------*/
        public const long MAX_RECONNECT_CNT = 1L; /* ReConnect Retry Count            */
        public const long RE_CONNECT_WAIT_TIME = 100L; /* ReConnect Wait Time              */
        /*                                  */
        /*-- send & receive normal disp flag -----------------------------------------------------*/
        public const int M_NOT_MSG = 0; /*                                  */
        public const int M_MSG_DISP = 1; /*                                  */
        /*                                  */
        /*-- SUBFUNC.C function define -----------------------------------------------------------*/
        public const int FEV_LAST_DAY = 28; /*                                  */
        /*                                  */
        public const long MAX_SEC = 60L; /*                                  */
        public const long MAX_MINT = 60L; /*                                  */
        public const long MAX_HOUR = 24L; /*                                  */
        public const long MAX_MONTH = 12L; /*                                  */
        /*                                  */
        public const int OP_YEAR = 1; /*                                  */
        public const int OP_MONTH = 2; /*                                  */
        public const int OP_DAY = 3; /*                                  */
        public const int OP_HOUR = 4; /*                                  */
        public const int OP_MINUTE = 5; /*                                  */
        public const int OP_SECOND = 6; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*                                                                                        */
        /*----------------------------------------------------------------------------------------*/
        public const int VERSION_LEN = 18; /*                                  */
        public const int XFER_RETRY_CNT_LEN = 2; /* Transfer retry count             */
        /*                                  */
        public const int XFER_TYPE_LEN = 1; /*                                  */
        /*                                  */
        //A0.07  #define    BAY_ID_LEN                     8           /*                                  */
        public const int BAY_ID_LEN = 12; /*                                  */ //A0.07
        //A0.07  #define    BAY_DSC_LEN                   24           /*                                  */
        public const int BAY_DSC_LEN = 64; /*                                  */ //A0.07
        public const int BAYNAME_LEN_CELL = 16; /*                                  */
        /*                                  */
        //A0.09  #define    CRR_ID_LEN                    25           /* Carrier ID                       */
        public const int CRR_ID_LEN = 30; /* Carrier ID   A0.09               */
        public const int CRR_ID_SIL_POS = 3; /*                                  */
        public const int CRR_ID_SIL_LEN = 3; /*                                  */
        public const int CRR_TOP_LEN = 2; /* Carrier ID Top                   */
        public const int CRR_ID_DMY_SIL_POS = 2; /*                                  */
        public const int CRR_ID_DMY_SIL_LEN = 8; /*                                  */
        public const int CRR_USE_CNT_LEN = 6; /*                                  */
        public const int XFER_STAT_LEN = 2; /*                                  */
        public const int CMDSTAT_LEN = 1; /*                                  */
        public const int CMD_STAT_DESC_LEN = 14; /* Xfer status                      */
        public const int RUN_CNT_LEN = 6; /*                                  */
        public const int RELEMP_LEN = 4; /* Actual/Empty flag                */
        public const int RSV_FLG_LEN = 2; /*                                  */
        public const int RSV_NO_LEN = 4; /*                                  */
        public const int PRIORITY_LEN = 5; /*                                  */
        public const int PCNNO_LEN = 10; /*                                  */
        public const int CODE_LEN = 4; /*                                  */
        public const int ALRT_CODE_LEN = 6;           /*                                  *///A0.29  
        //A0.07  #define    CODE_DSC_LEN                  24           /*                                  */
        public const int CODE_DSC_LEN = 64; /*                                  */ //A0.07
        public const int CHARGE_CODE_LEN = CODE_LEN; /*                                  */
        public const int CHARGE_DSC_LEN = CODE_DSC_LEN; /*                                  */
        public const int GRADE_CODE_LEN = CODE_LEN; /*                                  */
        public const int CASETCTGL_M_LEN = 2; /* cast CLSSF code(Xfer)            */
        public const int CASETCTGL_DSC_LEN = CODE_DSC_LEN; /*                                  */
        public const int CRR_MKR_ID_LEN = 6; /* carrier maker ID                 */
        public const int CRR_MKR_DSC_LEN = CODE_DSC_LEN; /* cast maker name                  */
        public const int RTCLMKR_LEN = 6; /*reticle maker                     */
        public const int RTCLMKR_DSC_LEN = CODE_DSC_LEN; /*reticle maker name                */
        public const int ZONE_ID_LEN = 3; /* stocker shelf id                 */
        public const int ZONE_TYP_LEN = 1; /* stocker shelf type               */
        public const int ZONE_CNT_LEN = 3; /* stocker shelf set count          */
        public const int PATI_CNT_LEN = 4; /* stocker partition set count      */
        public const int MAX_ZONE_CNT = 20; /* shelf count                      */
        public const int MAX_LRTCLCNT = 10; /* reticl count for lot             */
        public const int MAX_LTSTAT_CNT = 30; /*                                  */
        public const int ZONE_T_CNT_LEN = 3; /* shelf all count                  */
        public const int TFT_SHT_CHAR_POS = 8; /* TFT Out Sourcing Char. Position  */
        /*                                  */
        public const int CASETID_TYP_POS = 1; /* word position in casetid         */
        public const int CASETID_SIL_POS = 3; /* word position in casetid         */
        public const int CASETID_SIL_LEN = 3; /* word length in casetid           */
        /*                                  */
        public const int WAGONID_SIL_POS = 4; /* word position in wagonid         */
        public const int WAGONID_SIL_LEN = 2; /* word length   in wagonid         */
        /*                                  */
        public const int TFT_GROUP_ID_LEN = 10; /* group id (TFT/CF Shop)           */
        public const int GROUP_ID_LEN = 12; /* group id (10->12)                */
        /*                                  */
        public const int CODE_CATE_LEN = 4; /*                                  */
        public const int UNQCODE_LEN = 13; /*                                  */
        public const int EC_CODE_LEN = 2; /*                                  */
        public const int FAMICODE_LEN = 6; /*                                  */
        public const int CHAMB_LEN = 2; /*                                  */
        public const int CHAMB_CNT_SIZE = 2; /*                                  */
        public const int MAX_CHAMB_CNT = 30; /*                                  */
        public const int ZUBAN_LEN = 8; /*                                  */
        public const int HNBAN_LEN = 4; /*                                  */
        public const int FKBAN_LEN = 2; /*                                  */
        public const int MTRL_MKR_ID_LEN = 4; /*                                  */
        public const int MTRL_ID_LEN = 25; /*                                  */
        public const int MTRL_TYP_LEN = 4; /*                                  */
        public const int MTRL_SEQ_NO_LEN = 3; /* A0.04                            */
        public const int PRODUCT_ID_LEN = 25; /*                                  */
        public const int PARTCD_LEN = 10; /*                                  */
        public const int EC_LEN = 6; /*                                  */
        /*                                  */
        public const int PFCD_LEN = PRODUCT_ID_LEN; /*                                  */
        public const int PFCD_DSC_LEN = 24; /*                                  */
        public const int CMB_TYP_LEN = 4; /*                                  */
        public const int HINSH_LEN_CELL = 12; /*                                  */
        public const long HINSH_ROUTE_LEN = HINSH_LEN_CELL; /* HHPTSSS:Route Key                */
        public const int CASKIND_LEN = 3; /*                                  */
        public const int GLMKRID_LEN = 4; /*                                  */
        public const int MTZAI_ID_LEN = 4; /*                                  */
        public const int MTZAI_DSC_LEN = CODE_DSC_LEN; /*                                  */
        public const int MTRL_DSC_LEN = CODE_DSC_LEN; /*                                  */
        public const int MTRL_MKR_DSC_LEN = 24; /*                                  */
        //A0.07  #define    PRODUCT_DSC_LEN               24           /*                                  */
        public const int PRODUCT_DSC_LEN = 64; /*                                  */ //A0.07
        public const int PRODUCT_TYP_LEN = 4; /*                                  */
        //A0.09  #define    LOT_ID_LEN                    12           /*                                  */
        public const int LOT_ID_LEN = 30; /*                                  */
        public const int LOT_ID_HINSH_POS = 0; /*                                  */
        public const int LOTID_HINSH_LEN = EC_LEN; /*                                  */
        public const int LOTID_PREFIX_LCDDMY_LEN = 3; /*                                  */
        public const int LOT_ID_SIL_POS = 5; /*                                  */
        public const int LOT_ID_SIL_LEN = 3; /*                                  */
        public const int LCDDMY_ID_SIL_LEN = 2; /*                                  */
        public const int LOT_ID_CHILD_POS = 9; /*                                  */
        public const int SGR_ID_SIL_LEN = 2; /*                                  */
        public const int SGR_ID_SIL_POS = 5; /*                                  */
        public const int SHT_ID_SIL_LEN = 4; /*                                  */
        public const int SHT_ID_SIL_POS = 7; /*                                  */
        public const int SGR_ID_CHILD_POS = 10; /*                                  */
        public const int SGR_ID_PRDCT_LEN = 10; /*                                  */
        public const int LOTTRNS_LEN = 2; /*                                  */
        public const int LOTSTAT_LEN = 4; /*                                  */
        public const int CRR_STAT_LEN = 4; /*                                  */
        public const int DEPT_CODE_LEN = 4; /*                                  */
        public const int DEPT_DSC_LEN = 24; /*                                  */
        //A0.29	public const int GLASSID_LEN = 16; /*                                  */
        public const int GLASSID_LEN = 30;           /* A0.29                            */
        public const int STBCNT4_LEN = 4; /*                                  */
        public const int STBCNT6_LEN = 6; /*                                  */
        public const int INOUTID_LEN = 2; /*                                  */
        public const int IN_OUT_FLG_LEN = 3; /*                                  */
        public const int DELAYDAY_LEN = 6; /*                                  */
        public const int ORDER_ID_LEN = 12; /*                                  */
        public const int SALES_ORDER_LEN = 12; /*                                  */
        public const int LEADUP_LEN = 3; /*                                  */
        public const int USER_ID_LEN = 20; /*                                  */
        //A0.09  #define    SHT_ID_LEN                    12           /*                                  */
        public const int SHT_ID_LEN = 30; /*                                  */
        public const int LOT_STAT_LEN = 4; /*                                  */
        public const int SHT_STAT_LEN = 4; /*                                  */
        public const int SGR_STAT_LEN = 4; /*                                  */
        /*                                  */
        public const int SLOT_NO_LEN = 3; /*                                  */
        /*                                  */
        public const int MTRL_SLOT_NO_LEN = 3; /*                                  */
        public const int PNL_ID_LEN = 12; /*                                  */
        public const int PNL_SHT_CNT = 100; /* panel cnt in 1board              */
        public const int PNL_SHT_CNT_LEN = 3; /*                                  */
        /*                                  */
        public const int SHT_CHAR_POS = 9; /* Sheet Char. Position             */
        /* A0.29 if ASHEET.unit='LOT' (byLot) case                                 */
        /*       ASHEET.sht_id will be ALOT.lot_id+ALOT.splt_id[0]+ALOT.splt_id[1] */
        /*       and splt_id[0] will be in ASHEET.sht_id[SHT_CHAR_POS] ;           */
        /*       while splt_id[1] will be in ASHEET.sht_id[PNL_CHAR_POS]           */
        //A0.05  #define    PNL_CHAR_POS                  10           /* Panel Char. Position             */
        //A0.29 	public const int PNL_CHAR_POS = 11; /* Panel Char. Position             */ //A0.05
        public const int PNL_CHAR_POS = 12; /* Panel Char. Position             */ //A0.29
        public const int SHT_CHAR_POS_DMY = 8; /* Sheet Char. LCD DMY              */
        public const int DMY_PNL_POS_LEN = 2; /* Sheet Char. LCD DMY              */
        public const int CF_SHT_CHAR_POS = 8; /* CF Out Sourcing Char. Position   */
        /*                                  */
        public const int WRK_ID_LEN = 2; /*                                  */
        public const int POS_ID_LEN = WRK_ID_LEN; /*                                  */
        public const int BOD_CHP_SAME_LEN = 10; /*                                  */
        public const int EXISTFLAG_LEN = 2; /*                                  */
        public const int DISPFLAG_LEN = 2; /*                                  */
        public const int CG_RECNF_POS = 6; /*                                  */
        /*                                  */
        public const int SAMPL_ARY_SIZE = 2; /*                                  */
        public const int MAX_SAMPL_ARY = 99; /*                                  */
        /*                                  */
        public const int LOT_SMP_ID_LEN = 12; /*                                  */
        /*                                  */
        public const int SMPPC_ARY_SIZE = 2; /*                                  */
        public const int MAX_SMPPC_ARY = 99; /*                                  */
        /*                                  */
        public const int LABEL_ARY_SIZE = 2; /*                                  */
        public const int MAX_LABEL_ARY = 30; /*                                  */
        /*                                  */
        public const int SHT_CNT_LEN = 3; /*                                  */
        public const int LOT_CNT_LEN = 3; /*                                  */
        /*                                  */
        public const int PNL_CNT_LEN = 5; /*                                  */
        /*                                  */
        public const int MAX_SHT_ARY = 700; /*                                  */
        public const int MAX_SGR_SHT_ARY = 1000; /*                                  */
        public const int MAX_PBX_SHT_ARY = 400; /*                                  */
        /*                                  */
        public const int MAX_SHT_CNT_ARY = 700; /*                                  */
        /*                                  */
        public const int MAX_SHT_IN_NOTE = 80; /*                                  */
        /*                                  */
        public const int PPID_ARY_SIZE = 3; /*                                  */
        public const int MAX_PPID_ARY = 100; /*                                  */
        /*                                  */
        public const int MAX_PANEL_SCRP = 120; /*                                  */
        public const int MAX_PANEL_SCRN = 100; /*                                  */
        /*                                  */
        public const int MAX_SHT_PNL_CNT = PNL_SHT_CNT; /* panel cnt in 1sheet(100)         */
        public const int PNL_GRADE_LEN = MAX_SHT_PNL_CNT; /*                                  */
        /*                                  */
        public const int BOD_JUD_ARY_SIZE = 1; /* judge array count for board      */
        public const int MAX_BOD_JUD_ARY = 5; /* max judge array count for board  */
        /*                                  */
        public const int PNL_ARY_SIZE = 4; /*                                  */
        public const int MAX_PNL_ARY = (MAX_SHT_ARY * PNL_SHT_CNT); /*                                  */
        /*                                  */
        public const int MASK_ARY_SIZE = 2; /*                                  */
        public const int MAX_MASK_ARY = 10; /*                                  */
        /*                                  */
        public const int MAX_CROUT_ARY = 20; /*                                  */
        public const int MAX_CASET_CNT = 200; /*                                  */
        public const int MAX_CASET_CNT_SIZE = 3; /*                                  */
        /*                                  */
        public const int MAX_WAGON_CNT = 100; /*                                  */
        public const int MAX_WGN_CNT_SIZE = 3; /*                                  */
        /*                                  */
        public const int EQPT_ZLOT_SIZE = 2; /*                                  */
        public const int MAX_ZLOT = 20; /*  material lot array cnt          */
        /*                                  */
        public const int EVT_RSN_CNT_LEN = 2; /*                                  */
        public const int MAX_EVT_RSN_CNT = 5; /*                                  */
        public const int RWK_MAX_CNT = 5; /*                                  */
        /*                                  */
        public const int SERIAL_LEN = 4; /*                                  */
        public const int NSER_LEN = 34; /*                                  */
        public const int LTSTB_LEN = 4; /*                                  */
        public const int SLOTID_LEN = 2; /*                                  */
        //A0.07 #define    ROUTE_ID_LEN                   8           /*                                  */
        //A0.17  #define    ROUTE_ID_LEN                  12           /*                                  */ //A0.07
        public const int ROUTE_ID_LEN = 16; /*                                  */ //A0.17
        public const int ROUTE_CAT_POS = 0; /*                                  */
        public const int ROUTE_KIND_POS = 7; /*                                  */
        //A0.07  #define    ROUTE_DSC_LEN                 24           /*                                  */
        public const int ROUTE_DSC_LEN = 64; /*                                  */ //A0.07
        public const int OPE_NO_LEN = 6; /*                                  */
        public const int LEVEL_LEN = 2; /*                                  */
        public const int ROUTE_VER_LEN = 5; /*                                  */
        //A0.07  #define    OPE_DSC_LEN                   24           /*                                  */
        public const int OPE_DSC_LEN = 64; /*                                  */ //A0.07
        public const int OPE_ID_LEN = 16; /*                                  */
        public const int OPE_VER_LEN = 5; /*                                  */
        public const int RTCLFLAG_LEN = 3; /*                                  */
        public const int PEP_LVL_LEN = 4; /*                                  */
        public const int FDBKFLAG_LEN = 10; /*                                  */
        public const int MANOPETIME_LEN = 5; /*                                  */
        public const int LD_TIME_LEN = 5; /*                                  */
        public const int QUEFLAG_LEN = 2; /*                                  */
        public const int QUELIMIT_LEN = 6; /*                                  */
        public const int OPEFLAG_LEN = 2; /*                                  */
        public const int RWKFLAG_LEN = 2; /*                                  */
        public const int EQPTGCNT_LNE = 4; /*                                  */
        /*                                  */
        public const int RWK_RST_FLG_LEN = 1; /*                                  */
        public const int MODULE_ID_LEN = 16; /*                                  */
        public const int MODULE_VER_LEN = 5; /*                                  */
        /*                                  */
        //A0.07  #define    EQPT_ID_LEN                    8           /*                                  */
        public const int EQPT_ID_LEN = 12; /*                                  */ //A0.07
        //A0.07  #define    EQPT_DSC_LEN                  24           /*                                  */
        public const int EQPT_DSC_LEN = 64; /*                                  */ //A0.07
        //A0.07  #define    EQPTG_ID_LEN                   8           /*                                  */
        public const int EQPTG_ID_LEN = 12; /*                                  */ //A0.07
        //A0.07  #define    EQPTG_DSC_LEN                 24           /*                                  */
        public const int EQPTG_DSC_LEN = 64; /*                                  */ //A0.07
        public const int STOCK_ID_LEN = EQPT_ID_LEN; /*                                  */
        public const int ZONE_DSC_LEN = CODE_DSC_LEN; /*                                  */
        /*                                  */
        public const int PORT_ID_LEN = 4; /*                                  */
        //A0.07  #define    RECIPE_ID_LEN                 32           /*                                  */
        public const int RECIPE_ID_LEN = 64; /*                                  */ //A0.07
        public const int EQPT_STAT_LEN = 4; /*                                  */
        public const int EQPTPOS_LEN = 2; /*                                  */
        public const int MTRL_CATE_LEN = 2; /*                                  */
        public const int RETICLE_CHK_LEN = 2; /*                                  */
        public const int PORT_STAT_LEN = 4; /*                                  */
        public const int EQPT_MODE_LEN = 4; /*                                  */
        public const int ON_OFF_LEN = 4; /*                                  */
        public const int TCS_NODE_LEN = TRM_ID_LEN; /*                                  */
        public const int BCS_NODE_LEN = TRM_ID_LEN; /*                                  */
        public const int CRR_CNT_LEN = 3; /*                                  */
        public const int DCBNAME_LEN = 8; /*                                  */
        public const int TAPNAME_LEN = 8; /*                                  */
        public const int RWKTHHD_LEN = 2; /*                                  */
        public const int RSV_LOT_LEN = 2; /*                                  */
        public const int SPCLCNT_LEN = 10; /*                                  */
        public const int EQPTINT_LEN = 4; /*                                  */
        public const int LOTINT_LEN = 3; /*                                  */
        public const int FAB_ID_LEN = 3; /*                                  */
        //A0.29	public const int LINE_ID_LEN = 3; /*                                  */
        public const int LINE_ID_LEN = 4; /*                                  *///A0.29
        public const int STCKNO_LEN = 2; /* shlf number in eqpt              */
        /* Claim when it changed            */
        /* ( it used in OPEHIS )            */
        public const int RETICLE_SET_LEN = 11; /* reticle set                      */
        public const int NG_CNT_LEN = 3; /* NG_CNT_LEN /DL                   */
        public const int PS_CODE_LEN = 4; /* PS HIGH Code                     */
        public const int INTVL_LEN = 4; /* interval no                      */
        public const int MON_INTERVAL_LEN = 3; /* Monitor interval                 */
        /*                                  */
        public const int WIPNO_LEN = 3; /*                                  */
        /*                                  */
        public const int LOAD_ID_LEN = 2; /*                                  */
        public const int STAGE_ID_LEN = 4; /*                                  */
        public const int SAP_STAGE_ID_LEN = 5; /*                                  */
        /*                                  */
        public const int YEAR_LEN = 4; /*                                  */
        public const int MONTH_LEN = 2; /*                                  */
        public const int DAY_LEN = 2; /*                                  */
        public const int HOUR_LEN = 2; /*                                  */
        public const int MINT_LEN = 2; /*                                  */
        public const int SEC_LEN = 2; /*                                  */
        public const int MSG_ID_LEN = 2; /*                                  */
        public const int MINUT_LEN = 4; /*                                  */
        public const int DATE_LEN = (YEAR_LEN + 1 + MONTH_LEN + 1 + DAY_LEN); /*                          */
        public const int TIME_LEN = (HOUR_LEN + 1 + MINT_LEN + 1 + SEC_LEN); /*                          */
        public const int DATE_TIME_LEN = (DATE_LEN + TIME_LEN); /*                                  */
        public const int MONTH_POS = 5; /*                                  */
        public const int DAY_POS = 8; /*                                  */
        public const int DBDATE_LEN = 10; /* YYYY-MM-DD for UDB               */
        public const int DBTIME_LEN = 8; /* HH.MM.SS   for UDB               */
        public const int T_STAMP_LEN = 26; /*                                  */
        public const int TXSEQ_LEN = 6; /*                                  */
        public const int CPLANT_LEN = 5; /*                                  */
        public const int CTRAN_LEN = 5; /*                                  */
        public const int PART_LEN = 15; /*                                  */
        public const int PART_NAME_LEN = 20; /*                                  */
        public const int PART_CAT_LEN = 8; /*                                  */
        public const int PART_CAT_NAME_LEN = 20; /*                                  */
        public const int PART_CAT_DESC_LEN = 50; /*                                  */
        /*                                  */
        public const int PART_SPC_NAME_LEN = 20; /*                                  */
        public const int PART_SPC_DESC_LEN = 50; /*                                  */
        public const int PART_VOLUME_LEN = 5; /*                                  */
        public const int CUR_STOCK_LEN = 8; /*                                  */
        public const int SAFE_STOCK_LEN = 8; /*                                  */
        public const int VOLUME_LEN = 8; /*                                  */
        public const int QQTY_LEN = 7; /*                                  */
        public const int NTRAN_LEN = 7; /*                                  */
        public const int CREASN_LEN = 6; /*                                  */
        public const int LLOCN_LEN = 7; /*                                  */
        public const int MFGSP_DAY_LEN = 4; /*                                  */
        public const int MFGSP_TIME_LEN = 2; /*                                  */
        public const int MFGSHOP_LEN = (MFGSP_DAY_LEN + MFGSP_TIME_LEN); /*                              */
        public const int HOLI_CODE_LEN = 4; /*                                  */
        public const int MFGMONTH_LEN = 6; /*                                  */
        public const int WEEKDAY_LEN = 3; /*                                  */
        public const int MFGWEEK_LEN = 6; /*                                  */
        public const int MFGQUTR_LEN = 6; /*                                  */
        public const int WS_SHOP_LEN = MFGSP_DAY_LEN; /* Shop DATE of an integer          */
        public const int WS_YMONTH_LEN = 6; /*                                  */
        public const int WS_LOTCNT_LEN = 6; /*                                  */
        public const int WS_CASCNT_LEN = 6; /*                                  */
        public const int WS_CHPCNT_LEN = 6; /*                                  */
        public const int WS_RTIME_LEN = 8; /*                                  */
        public const int WS_YEAR_LEN = YEAR_LEN; /*                                  */
        public const int WS_MONTH_LEN = MONTH_LEN; /*                                  */
        public const int SFT_CNT_SIZE = 1; /*                                  */
        public const int SFT_CNT_ARY = 3; /*                                  */
        public const int SFT_NO_LEN = 2; /*                                  */
        public const int SFTGRP_LEN = 2; /*                                  */
        /*                                  */
        public const int DATATYPE_LEN = 4; /*                                  */
        public const int MES_ID_LEN = 8; /*                                  */
        public const int MESRNAME_LEN = 24; /*                                  */
        public const int DATA_ID_LEN = 8; /*                                  */
        public const int DATA_NAME_LEN = 16; /*                                  */
        public const int DATA_VALUE_LEN = 16; /*                                  */
        public const int ACTNTYPE_LEN = 4; /*                                  */
        public const int SPECVALUE_LEN = 12; /*                                  */
        public const int CALC_LOGIC_LEN = 4; /*                                  */
        /*                                  */
        public const int MESRCNT_LEN = 4; /*                                  */
        public const int DATAUNIT_LEN = 4; /*                                  */
        public const int PROC_STEP_LEN = 2; /* A0.10                            */
        /*                                  */
        /*----------------- SPC use defiine ------------------------------------------------------*/
        public const int DLUDID_LEN = 12; /* A0.01                            */
        public const int ERR_CODE_LEN = RTN_CODE_LEN; /*                                  */
        public const int MSGBODY_LEN = 70; /*                                  */
        public const int OPEMSG_LINE_LEN = 70; /*                                  */
        public const int SHT_OPE_MSG_LEN = 420; /*                                  */
        public const int EVENT_LEN = 16; /*                                  */
        public const int SEQ_NO_LEN = 2; /* sequence number                  */
        public const int MTRL_NO_LEN = 2; /* material number                  */
        //A0.09  #define    USER_DSC_LEN                  24           /*                                  */
        public const int USER_DSC_LEN = 64; /* A0.09 24 -> 64                   */
        public const int EXT_ID_LEN = 10; /*                                  */
        //A0.36	public const int PASSWORD_LEN = 8; /*                                  */
        public const int PASSWORD_LEN = 20; /* A0.36                            */
        public const int OPI_CODE_LEN = 4; /*                                  */
        public const int COMMENT_LEN = 80; /*                                  */
        public const int COMMENT_200_LEN = 200; /*                                  */
        public const int COMMENT_400_LEN = 400; /*                                  */
        public const int ZAHYO_LEN = 3; /*                                  */
        public const int MAST_NAME_LEN = 8; /*                                  */
        public const int EXCCTRL_MODNAME_LEN = 8; /*                                  */
        public const int CRR_SET_CODE_LEN = CODE_LEN; /*                                  */
        public const int CHIP_CNT_SIZE = 3; /*                                  */
        public const int SUBITEM_LEN = 60; /*                                  */
        public const int PPBOX_ID_LEN = 25; /*                                  */
        public const int LAST_EVT_LEN = 4; /*                                  */
        public const int LOCATE_LEN = 10; /*                                  */
        public const int USR_DEF_FLAG_LEN = 4; /*                                  */
        public const int USR_DEF_AREA_LEN = 25; /*                                  */
        public const int ABNORMAL_LEN = 4; /*                                  */
        public const int MAX_ABNORMAL = 4; /*                                  */
        public const int RCY_CNT_SIZE = 2; /*                                  */
        public const int STATUS_LEN = 2; /*                                  */
        public const int CUR_SORT_TYPE_LEN = 50; /*                                  */
        public const int REASONCD_LEN = 5; /*                                  */
        public const int MS_LOT_CNT_LEN = 3; /*                                  */
        public const int MS_CRR_CNT_LEN = 3; /*                                  */
        public const int MS_SHT_CNT_LEN = 4; /*                                  */
        public const int MTRL_MS_SHT_CNT_LEN = 4; /*                                  */
        public const int EVT_CODE_LEN = CODE_LEN; /* (4)                              */
        public const int NBR_EVT_CODE_LEN = 12; /* (4)                              */
        public const int EVT_CODE_DSC_LEN = CODE_DSC_LEN; /* (24)                             */
        public const int PNL_POS_LEN = 3; /*                                  */
        public const int QRS_NO_LEN = 2; /*                                  */
        public const int QRS_TIME_LEN = TIME_LEN; /*                                  */
        public const int QRK_TIME_LEN = TIME_LEN; /*                                  */
        public const int QRS_ID_LEN = 6; /*                                  */
        public const int PARAM_NO_LEN = 2; /*                                  */
        public const int PARAM_LEN = 10; /*                                  */
        //A0.09  #define    PARAM_DSC_LEN                 24           /*                                  */
        public const int PARAM_DSC_LEN = 64; /* A0.09 24 -> 64                   */
        public const int PROC_CNT_LEN = 6; /*                                  */
        //A0.07  #define    RWK_DSC_LEN                   24           /*                                  */
        public const int RWK_DSC_LEN = 64; /*                                  */ //A0.07
        //A0.09  #define    BRN_DSC_LEN                   24           /*                                  */
        public const int BRN_DSC_LEN = 64; /* A0.09 24 -> 64                   */
        public const int MAX_PNL_CNT = MAX_PNL_ARY; /*                                  */
        public const int MAX_PNL_CNT_LEN = 4; /*                                  */
        public const int ABNORMAL_FLG_LEN = 20; /*                                  */
        public const int NTC_COMMENT_LEN = 120; /*                                  */
        public const int NTC_DSC_LEN = 40; /*                                  */
        public const int RPT_DSC_LEN = 40; /*                                  */
        public const int FUNC_ID_LEN = 4; /*                                  */
        public const int PROC_ID_LEN = 6; /*                                  */
        public const int CRT_CRR_CNT_SIZE = 3; /*                                  */
        public const int CRT_LOT_CNT_SIZE = 3; /*                                  */
        public const int CRT_SGR_CNT_SIZE = 2; /*                                  */
        public const int SMP_PRTY_LEN = 4; /*                                  */
        public const int SMP_TIMER_LEN = 4; /*                                  */
        public const int SMP_LAST2_LEN = 2; /*                                  */
        public const int SMP_AEI_LEN = 1; /*                                  */
        public const int NXT_SMP_OPENO_LEN = 16; /*                                  */
        public const int NXT_SMP_OPEVER_LEN = 5; /*                                  */
        public const int NXT_SMP_ROUTE_LEN = 8; /*                                  */
        public const int TEMPLATE_ID_LEN = 12; /*                                  */
        public const int TEMPLATE_DSC_LEN = 24; /*                                  */
        public const int LABEL_DOUBLE_LEN = 16; /*                                  */
        public const int MAX_FTACT_CNT = 60; /*                                  */
        public const int ARG_LEN = 3; /*                                  */
        public const int MAX_SMPTMP_CNT = 200; /*                                  */
        public const int EEN_ID_LEN = 20; /*                                  */
        public const int SPLT_ID_LEN = 2; /*                                  */
        //A0.08  #define    DEFECT_CNT_LEN                 3           /*                                  */
        public const int DEFECT_CNT_LEN = 4; /*                                  */ //A0.08
        public const int PARAM_NAME_LEN = 20; /*                                  */
        public const int PARAM_VAL_LEN = 24; /*                                  */
        //A0.27	public const int MTRL_CNT_LEN = 6; /*                                  */
        public const int MTRL_CNT_LEN = 16;
        public const int MTRL_CNT_6_LEN = 6;	/*           						*/ //A0.28			
        public const int PARAM_NUM_LEN = 6; /*                                  */
        public const int CART_ID_LEN = CRR_ID_LEN; /*                                  */
        public const int MQC_CNT_UP_LEN = 2; /*                                  */
        public const int SUB_CODE_LEN = 10; /*                                  */
        public const int SUBSYS_ID_LEN = 4; /*                                  */
        public const int EVT_SEQ_NO_LEN = 10; /*                                  */
        public const int TBL_CNT_LEN = 3; /*                                  */
        public const int CRR_SEQ_NO_LEN = 4; /*                                  */
        public const int MES_SEQ_NO_LEN = 4; /*                                  */
        public const int PPBODY_LEN = 15; /*                                  */
        public const int RATIO_LEN = 4; /*                                  */
        public const int EQPT_RUN_ID_LEN = 10; /*                                  */
        public const int SHT_HIS_SEQ_LEN = 10; /*                                  */
        public const int MESR_CNT_LEN = 4; /*                                  */
        public const int LOGOF_TX_LEN = 10000; /*                                  */
        public const int CRR_INFO_LEN = 20; /*                                  */
        public const int SYSTEM_ID_LEN = 4; /* subsystem id                     */
        public const int DB_NAME_CK_LEN = 10; /* db name                          */
        //A0.36	public const int DB_USER_CK_LEN = 8; /* db user                          */
        public const int DB_USER_CK_LEN = 18;           /* db user  A0.36                   */
        public const int DB_PASSWD_CK_LEN = 18; /* db password                      */
        public const int MTRL_GRADE_LEN = 2; /*                                  */
        public const int CCODE_LEN = 2; /*                                  */
        public const int GLASS_THK_LEN = 4; /*                                  */
        public const int OWNER_LEN = 10; /*                                  */
        public const int NO_XFER_RSN_LEN = 10; /*                                  */
        public const int PARTITION_ID_LEN = 10; /*                                  */
        public const int ORDER_LEN = 12; /*                                  */
        public const int PM_CONT_LEN = 4; /*                                  */
        public const int LCDTYPE_LEN = 3; /*                                  */
        public const int NO_XFR_REASON_LEN = 1; /*                                  */
        public const int OQC_LOTID_LEN = 31; /*                                  */
        public const int OQC_SIL_POS = 13; /*                                  */
        public const int PROD_TYP_LEN = 2; /*                                  */
        public const int PROD_SIZE_LEN = 2; /*                                  */
        public const int TIME_SCT_LEN = 2; /*                                  */
        public const int PFCD_SIL_POS = 2; /*                                  */
        public const int QTAP_LOTID_LEN = 30; /*                                  */
        public const int LCM_QTAP_LOTID_LEN = 20; /*                                  */
        public const int SHIP_ORDER_LEN = 12; /*                                  */
        public const int MAX_LOT_CNT = 10; /*                                  */
        public const int MAX_PPBOX_CNT = 10; /*                                  */
        public const int PROC_NPO_LEN = 6; /*                                  */
        public const int CART_CNT_LEN = 4; /*                                  */
        public const int OPID_LEN = 16; /*                                  */
        public const int MAX_SLOT_QTY_LEN = 2; /*                                  */
        public const int UNIT_NO_LEN = 4; /*                                  */
        public const int SUSPECT_RSN_LEN = 5; /*                                  */
        public const int MAX_OQC_CRR = 100; /*                                  */
        public const int SHIP_CON_CATE_LEN = 4; /*                                  */
        public const int PAK_PRTY_LEN = 4; /*                                  */
        public const int PAK_FLT_ID_LEN = 16; /*                                  */
        public const int PAK_FLT_DSC_LEN = 24; /*                                  */
        public const int OPE_SEQ_NO_LEN = 6; /*                                  */
        public const int PARAM_BODY_LEN = 4096; /*                                  */
        public const int MAX_PPB_PLT_ARY_SIZE = 2; /*                                  */
        public const int BATCH_CNT_LEN = 4; /*                                  */
        public const int WORK_GRADE_LEN = 2; /*                                  */
        public const int EQPT_QTAP_SIL_POS = 5; /*                                  */
        public const int EQPT_QTAP_TYPE_POS = 7; /*                                  */
        public const int QTAP_EQPT_NUM_LEN = 2; /*                                  */
        public const int CRR_NOTE_LEN = 400; /*                                  */
        public const int XY_DIM_LEN = 4; /*                                  */
        public const int PNL_JUDGE_LEN = 16; /*                                  */
        public const int SHT_24_UP = 24; /* 24Up                             */
        public const int EXT_LEN = 32; /*                                  */
        public const int PPBOX_ID_SIL_LEN = 2; /*                                  */
        public const int PALLET_ID_SIL_LEN = 3; /*                                  */
        public const int FILE_EXT_LEN = 4; /*                                  */
        public const int PAKBATCH_CNT_LEN = 2; /*                                  */
        public const int MAX_PAKBATCH_CNT = 30; /*                                  */
        public const int RMA_NO_LEN = 16; /*                                  */
        public const int PPB_CNT_LEN = 2; /*                                  */
        public const int MAX_PPB_CNT_IN_PLT = 10; /*                                  */
        public const int MAX_UNIT_ARY_CNT = 100; /*                                  */
        public const int QTAP_EQP_ID_LEN = 2; /*                                  */
        public const int RTN_MESG_LEN = 200; /*                                  */
        public const int PLN_BATCH_ID_LEN = 12; /*                                  */
        public const int EQ_LD_SP_LOGIC_LEN = 60; /*                                  */
        public const int LD_SP_CNTL_LEN = 10; /*                                  */
        public const int TIM_SEC_VAL_LEN = 2; /*                                  */
        public const int CHG_PLAN_ID_LEN = 6; /*                                  */
        public const int MTRLMIX_ID_LEN = 2; /*                                  */
        public const int PNL_LENGTH_LEN = 4; /*                                  */
        public const int GRADE_GROUP_LEN = 6; /*                                  */
        public const int GRDGRP_DSC_LEN = 40; /*                                  */
        public const int SEQNO_LEN = 6; /*                                  */
        public const int CLN_CNT_LEN = 3; /*                                  */
        public const int NG_PORT_CRIT_LEN = 100; /*                                  */
        public const int STB_WARN_LEN = 6; /*                                  */
        public const int CURR_STB_CNT_LEN = 6; /*                                  */
        public const int CFM_SHT_CNT = 3; /*                                  */
        public const int CFM_PROD_CNT = 6; /*                                  */
        public const int LEN02_LEN = 2; /*                                  */
        public const int LEN07_LEN = 7; /*                                  */
        public const int RECIPE_NAME_LEN = 32; /*                                  */
        public const int ANALYSIS_FILE_LEN = 64; /*                                  */
        public const int MAX_MTRL_ARY = 999; /*                                  */
        public const int SPACER_USE_CNT_LEN = 3; /*                                  */
        public const int PALLET_STAT_LEN = 4; /*                                  */
        public const int PALLET_SET_CODE_LEN = 4; /*                                  */
        public const int PALLET_OWN_LEN = 3; /*                                  */
        public const int PALLET_CATE_LEN = 4; /*                                  */
        public const int PALLET_SIZE_LEN = 4; /*                                  */
        public const int PALLET_MKR_ID_LEN = 6; /*                                  */
        public const int PALLET_COMMENT_LEN = 20; /*                                  */
        /*                                  */
        /*-- DCARRIGP ----------------------------------------------------------------------------*/
        public const int MAX_CRRG_CNT = 99; /*                                  */
        public const int MAX_CRRG_CNT_SIZE = 2; /*                                  */
        /*                                  */
        /*-- ACARRIST-----------------------------------------------------------------------------*/
        public const int MAX_LOT_SHT_CNT = MAX_SHT_ARY; /*                                  */
        public const int LOT_SHT_CNT_LEN = SHT_CNT_LEN; /*                                  */
        public const int MAX_CRR_HLD_CNT = 5; /*                                  */
        public const int CRR_HLD_CNT_LEN = 1; /*                                  */
        public const int SUBENTITY_LEN = 100; /*                                  */
        public const int CF_SUBENTITY_LEN = 100; /*                                  */
        /*                                  */
        /*-- ASHEET ------------------------------------------------------------------------------*/
        public const int SHT_PNL_CNT_LEN = PNL_SHT_CNT_LEN; /* (3)                              */
        public const int MAX_SHT_NT_CNT = 30; /*                                  */
        public const int SHT_NT_CNT_LEN = 2; /*                                  */
        public const int MAX_SHT_RWK_CNT = 30; /*                                  */
        public const int SHT_RWK_CNT_LEN = 2; /*                                  */
        public const int MAX_SHT_RWCN_CNT = 30; /*                                  */
        public const int SHT_RWCK_CNT_LEN = 2; /*                                  */
        public const int MAX_RT_QRS_CNT = 5; /*                                  */
        public const int MAX_SHT_QRS_CNT = (MAX_RT_QRS_CNT * 2); /*                                  */
        public const int SHT_QRS_CNT_LEN = 1; /*                                  */
        public const int MAX_SHT_RSN_CNT = (5 * MAX_CRR_HLD_CNT); /*                                  */
        public const int SHT_RSN_CNT_LEN = 2; /*                                  */
        public const int MAX_SHT_ABN_CNT = 10; /*                                  */
        public const int MAX_SHIP_ABN_CNT = 20; /*                                  */
        public const int SHT_ABN_CNT_LEN = 2; /*                                  */
        public const int MAX_SHT_PRM_CNT = 50; /*                                  */
        public const int SHT_PRM_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- ASHTDSC -----------------------------------------------------------------------------*/
        public const int PNL_JUD_CNT = (PNL_SHT_CNT * 2); /*                                  */
        /*                                  */
        /*-- AROUTEI -----------------------------------------------------------------------------*/
        public const int MAX_RTI_RT_CNT = 500; /*                                  */
        public const int RTI_RT_CNT_LEN = 3; /*                                  */
        /*                                  */
        /*-- AROUTE ------------------------------------------------------------------------------*/
        public const int MAX_MODULE = 100; /*                                  */
        public const int MAX_OPE_CNT = 500; /*                                  */
        public const int MAX_OPE_LEN = 3; /*                                  */
        public const int MAX_RT_RWK_CNT = 30; /*                                  */
        public const int RT_RWK_CNT_LEN = 2; /*                                  */
        public const int MAX_RT_RWK_QRS_CNT = 10; /*                                  */
        public const int RT_RWK_QRS_CNT_LEN = 2; /*                                  */
        public const int RT_QRS_CNT_LEN = 1; /*                                  */
        public const int MAX_RT_BRN_CNT = 30; /*                                  */
        public const int RT_BRN_CNT_LEN = 2; /*                                  */
        public const int ECYC_CNT_UP_LEN = 2; /*                                  */
        /*                                  */
        /*-- AOPER -------------------------------------------------------------------------------*/
        public const int MAX_OPE_RA_CNT = MAX_SHT_ARY; /*                                  */
        public const int OPE_RA_CNT_LEN = PNL_CNT_LEN; /*                                  */
        /*                                  */
        /*-- AQRS DB -----------------------------------------------------------------------------*/
        public const int MAX_OPE_QRS_CNT = 6; /*                                  */
        /*                                  */
        /*-- AMTRLPRD ----------------------------------------------------------------------------*/
        public const int MAX_MTRLPRD_SR_CNT = 50; /*                                  */
        public const int MTRLPRD_SR_CNT_LEN = 2; /*                                  */
        public const int MAX_MTRLPRD_CT_CNT = 50; /*                                  */
        public const int MTRLPRD_CT_CNT_LEN = 2; /*                                  */
        //A0.17  #define    ADDT_INFO_LEN                 16           /*                                  */
        public const int ADDT_INFO_LEN = 25; /*                                  */	//A0.17
        public const int MTRL_TRNS_CATE_LEN = 4; /*                                  */
        public const int MTRL_MAX_RWK_CNT_LEN = 2; /*                                  */
        public const int MAX_ATT_CNT_LEN = 2; /*                                  */
        public const int CAPACITY_LEN = 4; /*                                  */
        public const int MTRL_QTIM_CATE_LEN = 4; /*                                  */
        /*                                  */
        /*-- APRDCTMT ----------------------------------------------------------------------------*/
        public const int MAX_PRDCTMT_CT_CNT = 50; /*                                  */
        public const int PRDCTMT_CT_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCTMT_MO_CNT = 10; /*                                  */
        public const int PRDCTMT_MO_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCTMT_PF_CNT = 10; /*                                  */
        public const int PRDCTMT_PF_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- APRDCTPL ----------------------------------------------------------------------------*/
        public const int WRK_POS_CNT = 42; /*                                  */
        /*                                  */
        /*-- ABAYAREA ----------------------------------------------------------------------------*/
        public const int MAX_BAY_EQPT_CNT = 100; /*                                  */
        public const int BAY_EQPT_CNT_LEN = 3; /*                                  */
        /*                                  */
        /*-- AEQPTG ------------------------------------------------------------------------------*/
        public const int MAX_EQPTG_GR_CNT = 500; /*                                  */
        public const int EQPTG_GR_CNT_LEN = 3; /*                                  */
        public const int MAX_EQPT_PRM_CNT = 50; /*                                  */
        public const int EQPT_PRM_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- AEQPT -------------------------------------------------------------------------------*/
        public const int MAX_EQPT_GR_CNT = 1000; /*                                  */
        public const int EQPT_GR_CNT_LEN = 4; /*                                  */
        public const int MAX_EQPT_PT_CNT = 30; /*                                  */
        public const int EQPT_PT_CNT_LEN = 2; /*                                  */
        public const int MAX_EQPT_MT_CNT = 20; /*                                  */
        public const int EQPT_MT_CNT_LEN = 2; /*                                  */
        public const int MAX_EQPT_BT_CNT = 10; /*                                  */
        public const int EQPT_BT_CNT_LEN = 2; /*                                  */
        public const int MAX_EQPT_CT_CNT = 2; /*                                  */
        public const int EQPT_CT_CNT_LEN = 1; /*                                  */
        /*                                  */
        /*-- ASTOCKER ----------------------------------------------------------------------------*/
        public const int MAX_STC_PT_CNT = 30; /*                                  */
        public const int STC_PT_CNT_LEN = 2; /*                                  */
        public const int MAX_STC_ZN_CNT = 20; /*                                  */
        public const int STC_ZN_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- ARTICLST ----------------------------------------------------------------------------*/
        public const int MAX_RCLST_RCL_CNT = 30; /*                                  */
        public const int RCLST_RCL_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- ARECIPE  ----------------------------------------------------------------------------*/
        public const int MAX_RECP_PRM_CNT = 10; /*                                  */
        public const int RECP_PRM_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- AMSSGRP  ----------------------------------------------------------------------------*/
        public const int MAX_MSSG_MSS_CNT = 100; /*                                  */
        public const int MSSG_MSS_CNT_LEN = 3; /*                                  */
        /*                                  */
        /*-- AOPIGRP  ----------------------------------------------------------------------------*/
        public const int MAX_OPIG_OPI_CNT = 300; /*                                  */
        public const int OPIG_OPI_CNT_LEN = 3; /*                                  */
        /*                                  */
        /*-- AMQCROT  ----------------------------------------------------------------------------*/
        public const int MAX_MQCRT_OP_CNT = 10; /*                                  */
        public const int MQCRT_OP_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- AMLABEL  ----------------------------------------------------------------------------*/
        public const int MAX_MLBL_ITEM_CNT = 1600; /*                                  */
        public const int MLBL_ITEM_CNT_LEN = 4; /*                                  */
        /*                                  */
        /*-- HAEDCLBL  ---------------------------------------------------------------------------*/
        public const int MAX_HLBL_ITEM_CNT = 600; /*                                  */
        /*                                  */
        /*-- AMLITEM  ----------------------------------------------------------------------------*/
        public const int MAX_MLITM_CHK_CNT = 20; /*                                  */
        public const int MLITM_CHK_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- AMLCHECK ----------------------------------------------------------------------------*/
        public const int MAX_MLCHK_ACT_CNT = 10; /*                                  */
        public const int MLCHK_ACT_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- AMLDELTA ----------------------------------------------------------------------------*/
        public const int MAX_MLDL_DATA_CNT = 1000; /*                                  */
        public const int MLDL_DATA_CNT_LEN = 4; /*                                  */
        /*                                  */
        /*-- AIFTHENLG -----------------------------------------------------------------------------*/
        public const int SETTING_NO_LEN = 10; /*                                  */
        /*                                  */
        /*-- ADCFGNAM ----------------------------------------------------------------------------*/
        public const int CFG_NAME_LEN = 20; /*                                  */
        public const int CFG_NAME_DESC_LEN = 24; /*                                  */
        /*                                  */
        /*-- ADRULSET ----------------------------------------------------------------------------*/
        public const int RULE_SEQ_LEN = 4; /*                                  */
        public const int SORT_SEQ_LEN = 4; /*                                  */
        public const int MAX_SORT_SEQ = 20; /*                                  */
        /*                                  */
        /*-- RULE SETTING ------------------------------------------------------------------------*/
        public const int RULE_NAME_DESC_LEN = 128; /*                                  */
        public const int RULE_TYPE_LEN = 7; /*                                  */
        public const int SOBJ_NAME_LEN = 80; /*                                  */
        public const int SO_FUNC_NAME_LEN = 40; /*                                  */
        public const int RULE_VER_LEN = 5; /*                                  */
        public const int RULE_NAME_LEN = 4; /*                                  */
        /*                                  */
        /*-- AMQCRSLT etc. -----------------------------------------------------------------------*/
        public const int MAX_RSLT_ARY = 20; /*                                  */
        public const int RSLT_ARY_SIZE = 2; /*                                  */
        /*                                  */
        /*-- AGRDRUL -----------------------------------------------------------------------------*/
        public const int MAX_GRL_GRLD_CNT = 50; /*                                  */
        public const int GRL_GRLD_CNT_LEN = 2; /*                                  */
        public const int SRT_OPE_ID_CNT = 50; /*                                  */
        public const int SRT_OPE_ID_LEN = 2; /*                                  */
        /*                                  */
        /*-- CEEN --------------------------------------------------------------------------------*/
        public const int MAX_EEN_EQP_CNT = 50; /*                                  */
        public const int EEN_EQP_CNT_LEN = 2; /*                                  */
        public const int MAX_EEN_SHT_CNT = 50; /*                                  */
        public const int EEN_SHT_CNT_LEN = 2; /*                                  */
        public const int MAX_EEN_OPE_CNT = 50; /*                                  */
        public const int EEN_OPE_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- CCARTDB------------------------------------------------------------------------------*/
        public const int MAX_CART_MT_CNT = 30; /*                                  */
        public const int CART_MT_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- CIFTHEN  ----------------------------------------------------------------------------*/
        public const int MAX_CONDACT_CNT = 10000; /*                                  */
        public const int CONDACT_CNT_LEN = 5; /*                                  */
        public const int MAX_RCP_CNT = 10000; /*                                  */
        /*                                  */
        /*-- CLAYOUT------------------------------------------------------------------------------*/
        public const int MAX_LAY_LC_CNT = PNL_SHT_CNT; /*                                  */
        public const int LAY_LC_CNT_LEN = PNL_SHT_CNT_LEN; /*                                  */
        /*                                  */
        /*-- CPFCD -------------------------------------------------------------------------------*/
        public const int MAX_PFCD_CNT = 50; /*                                  */
        /*                                  */
        /*-- CPIDCOMB ----------------------------------------------------------------------------*/
        public const int PID_LEN = 4; /*                                  */
        /*                                  */
        /*-- CPRDCT ------------------------------------------------------------------------------*/
        public const int MAX_PRDCT_EC_CNT = 20; /*                                  */
        public const int PRDCT_EC_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCT_OPE_CNT = 50; /*                                  */
        public const int PRDCT_OPE_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCT_GRG_CNT = 50; /*                                  */
        public const int PRDCT_GRG_CNT_LEN = 2; /*                                  */
        public const int TOTAL_PIXEL_LEN = 5; /*                                  */
        public const int ONE_PIXEL_LENGTH_LEN = 6; /*                                  */
        /*                                  */
        /*-- CPRDCTGRD ---------------------------------------------------------------------------*/
        public const int MAX_PRDCTGRG_GRD_CNT = 30; /*                                  */
        public const int PRDCTGRG_GRD_CNT_LEN = 2; /*                                  */
        public const int GRADE_LEN = 2; /*                                  */
        public const int GRADE_DSC_LEN = 24; /*                                  */
        /*                                  */
        /*-- CPRDCTEC ----------------------------------------------------------------------------*/
        public const int MAX_PRDCTEC_MT_CNT = 10; /*                                  */
        public const int PRDCTEC_MT_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCTEC_CB_CNT = 10; /*                                  */
        public const int PRDCTEC_CB_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCTEC_TP_CNT = 10; /*                                  */
        public const int PRDCTEC_TP_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCTEC_PP_CNT = 100; /*                                  */
        public const int PRDCTEC_PP_CNT_LEN = 3; /*                                  */
        /*                                  */
        /*-- CPAKFLT -----------------------------------------------------------------------------*/
        public const int CPAKFLT_OWN_ARY = 10; /*                                  */
        public const int CPAKFLT_OWN_LEN = 2; /*                                  */
        public const int CPAKFLT_GRD_ARY = 30; /*                                  */
        public const int CPAKFLT_GRD_LEN = 2; /*                                  */
        /*                                  */
        /*-- AMTRLCON ----------------------------------------------------------------------------*/
        public const int MAX_MTC_DSC_CNT = MAX_SHT_ARY; /*                                  */
        public const int MTC_DSC_CNT_LEN = SHT_CNT_LEN; /*                                  */
        /*                                  */
        /*-- APPBOX ------------------------------------------------------------------------------*/
        public const int MAX_PPB_MT_CNT = 400; /*                                  */
        public const int PPB_MT_CNT_LEN = 3; /*                                  */
        /*                                  */
        /*-- BPRDCT ------------------------------------------------------------------------------*/
        public const int BM_PTT_LEN = 12; /*                                  */
        public const int MAX_RECYC_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- BSHEET ------------------------------------------------------------------------------*/
        public const int RCY_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- HASHTEDC  ---------------------------------------------------------------------------*/
        public const int PS_HIGHT_LEN = 12; /*                                  */
        public const int MAX_EDC_PNL_CNT = 36; /*                                  */
        /*                                  */
        /*-- HAGRPHS   ---------------------------------------------------------------------------*/
        public const int SGR_SE_TYP_LEN = 2; /*                                  */
        public const int SGR_SE_ID_LEN = DATE_TIME_LEN; /*                                  */
        /*                                  */
        /*-- ASGRNOTE  ---------------------------------------------------------------------------*/
        public const int SGR_OPE_MSG_LEN = 420; /*                                  */
        /*                                  */
        /*-- BSHTBATCH ---------------------------------------------------------------------------*/
        public const int LIN_BAT_ID_LEN = 16; /*                                  */
        /*                                  */
        /*-- ASHEET ------------------------------------------------------------------------------*/
        public const int PTT_GRADE_LEN = 2; /*                                  */
        public const int PTT_TYPE_LEN = 2; /*                                  */
        public const int PROJECT_CD_LEN = 10; /*                                  */
        public const int EXPER_NO_LEN = 20; /*                                  */
        //A0.09  #define    SGR_ID_LEN                    20           /*                                  */
        public const int SGR_ID_LEN = 30; /* A0.09 20 -> 30                   */
        /*                                  */
        /*-- ACARRIST ----------------------------------------------------------------------------*/
        public const int PATI_ID_LEN = 10; /*                                  */
        public const int STOCK_STAT_LEN = 4; /*                                  */
        public const int GRADE_ID_LEN = 2; /*                                  */
        public const int ASM_TYPE_LEN = 3; /*                                  */
        public const int CP_PTN_LEN = 6; /*                                  */
        /*                                  */
        /*-- ALOT --------------------------------------------------------------------------------*/
        public const int LOT_ID_YEAR_POS = 2; /*                                  */
        public const int LOT_ID_YEAR_POS_DMY = 3; /*                                  */
        /*                                  */
        /*-- DLOTPLAN ----------------------------------------------------------------------------*/
        public const int LOT_PLAN_SEQ_LEN = 4; /*                                  */
        public const int LOT_PLAN_QTY_LEN = 2; /*                                  */
        public const int MAX_DAY = 31; /*                                  */
        public const int PLNLST_ARY = 20; /*                                  */
        /*                                  */
        /*-- DEQPTPT  ----------------------------------------------------------------------------*/
        public const int MDL_CNT_LEN = 2; /*                                  */
        public const int MAX_MDL = 20; /*                                  */
        public const int NEXTEQPT_CNT_LEN = 2; /*                                  */
        public const int MAX_NEXTEQPT = 10; /*                                  */
        public const int PORT_MASK_LEN = 3; /* Mask flag for CC way             */
        /*                                  */
        /*-- DEQPTST  ----------------------------------------------------------------------------*/
        public const int LDUD_MODE_LEN = 2; /* Loader/Unloader Mode             */
        /*                                  */
        /*-- DEQDPTRT ----------------------------------------------------------------------------*/
        public const int PORT_PRTY_LEN = 2; /* Port Priority                    */
        /*                                  */
        /*-- DRESVLST ----------------------------------------------------------------------------*/
        public const int RESVNO_LEN = 3; /* reserve no line(DRESVLST)        */
        public const int EFCT_EQPT_CNT = 3; /* eqpt cnt for process             */
        public const int EFCT_LOT_CNT = 4; /*                                  */
        public const int STB_CNT_SIZE = 3; /* STB caset cnt Size               */
        public const int MAX_STB_CNT = 50; /*                                  */
        public const int SERIAL_NO_LEN = 10; /* serial No.                       */
        public const int BOARD_MSG_LEN = 120; /*                                  */
        public const int FULL_SELNO_LEN = 6; /* Next Process List number         */
        public const int SUB_SELNO_LEN = 5; /* Process List number              */
        public const int SELPN_CNT_LEN = 4; /* selection cnt                    */
        public const int LOTQTY_SIZE = 4; /*                                  */
        public const int CROUT_ARY_SIZE = 2; /*                                  */
        public const int A_LOTQTY_SIZE = 5; /*                                  */
        public const int APL_ARY_SIZE = 3; /*                                  */
        public const int MAX_APL_ARY = 300; /*                                  */
        public const int MFGMHD_LEN = 10; /* Manufacturing Method             */
        public const int QLTLNK_LEN = 2; /* Quality Lank                     */
        public const int FLWCHT_LEN = 10; /* flow chart                       */
        public const int PACKAGE_LEN = 10; /*                                  */
        public const int CFID_LEN = 10; /*                                  */
        public const int CFPARTNO_LEN = 20; /*                                  */
        public const int PRDCTNO_LEN = 8; /*                                  */
        public const int CNTL_CODE_LEN = 4; /*                                  */
        public const int R_TIME_LEN = 2; /*                                  */
        public const int S_TIME_LEN = 2; /*                                  */
        public const int P_TIME_LEN = 2; /*                                  */
        public const int WAIT_TIME_LEN = 3; /*                                  */
        public const int LDETL_SEQ = 2; /*                                  */
        public const int PROCESS_TIME_LEN = 4; /* Process Time for 1 Board         */
        public const int GROUPID_LEN = 14; /* group number                     */
        public const int MTRL_LOT_ID_LEN = 25; /* glass lot ID                     */
        public const int MTRL_MFDT_LEN = 8; /* glass lot maker date             */
        /*                                  */
        /*-- DSTCKNBN DB -------------------------------------------------------------------------*/
        public const int EC_LEN_2 = 2; /* length for LOT_ID head2          */
        /*                                  */
        /*-- DOPIGRP DMSSGRP ---------------------------------------------------------------------*/
        public const int MENU_GRP_LEN = 6; /*                                  */
        public const int MENU_ID_LEN = 16; /*                                  */
        //A0.07  #define    MENU_DSC_LEN                  24           /*                                  */
        public const int MENU_DSC_LEN = 64; /*                                  */ //A0.07
        public const int MENUGRP_SIZE = 3; /*                                  */
        public const int MAX_MENUGRP = 100; /*                                  */
        public const int MAX_OPIMENUGRP = 300; /*                                  */
        public const int SPC_GROUP_LEN = 12; /* SPC Group ID                     */
        public const int MIN_WAIT_TIME_LEN = 3; /* Minmum Wait Time For EQPT        */
        /*                                  */
        /*-- AMQCROT -----------------------------------------------------------------------------*/
        public const int MQC_CNT_LEN = 2; /*                                  */
        public const int MQC_PURPOSE_LEN = 24; /*                                  */
        public const int MQC_COMMENT_LEN = 10; /*                                  */
        public const int MQC_INTERVAL_LEN = 4; /*                                  */
        public const int MQC_RM_CNT_LEN = 4; /*                                  */
        public const int MQC_PTCL_LVL_LEN = 4; /*                                  */
        public const int MQC_PTCL_CNT_LEN = 6; /*                                  */
        public const int MAX_MQC_PTCL_LVL_CNT = 10; /*                                  */
        public const int MQC_PTCL_LVL_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*-- QCHGHIS -----------------------------------------------------------------------------*/
        public const int CHG_ACT_LEN = 3; /* material_action Length           */
        public const int MATERIAL_ID_LEN = 30; /* material_id Length               */
        public const int USER_DEF_LEN = 25; /* user_def Length                  */
        /*                                  */
        /*-- QXFRREQ -----------------------------------------------------------------------------*/
        public const int PAIR_CTRL_ID_LEN = 10; /* Pair control flag                */
        public const int PAIR_CNT_LEN = 2; /* Pair transfer count              */
        /*                                  */
        /*-- DPROCOND ----------------------------------------------------------------------------*/
        public const int CONDNUM_LEN = 10; /* condition code Length            */
        public const int CMBI_CNT_LEN = 2; /* combination count Length         */
        public const int MAX_CMBI_CNT = 20; /* MAX combination count            */
        /*                                  */
        public const int SRT_TYPE_LEN = 50; /* Sorting Type                     */
        /*                                  */
        /*-- DEQPT DB ----------------------------------------------------------------------------*/
        public const int EQPT_ID_SIL_LEN = 2; /* Eqpt serial number length        */
        public const int EQPT_ID_SIL_POS = (EQPT_ID_LEN - EQPT_ID_SIL_LEN); /*                               */
        /* Eqpt serial number position      */
        /*-- DEQPTG DB ---------------------------------------------------------------------------*/
        public const int EQPT_CAP_LEN = 25; /* Equipment Capability             */
        /*                                  */
        /*-- DEQPTGR DB --------------------------------------------------------------------------*/
        public const int EQPT_PRTY_LEN = 6; /* Equipment Priority               */
        public const int EQPTG_PRTY_LEN = 6; /* Equipment Group Priority         */
        /*                                  */
        /*-- AALERT DB ---------------------------------------------------------------------------*/
        public const int RPT_SOURCE_LEN = 20; /*                                  */
        public const int ALRT_ID_LEN = 8; /*                                  */
        /*                                  */
        /*-- AMLABEL DB --------------------------------------------------------------------------*/
        public const int DATA_PAT_LEN = 2; /*                                  */
        public const int SPEC_CHK_TYP_LEN = 4; /*                                  */
        /*                                  */
        /*-- AMLITEM DB --------------------------------------------------------------------------*/
        public const int LABEL_LEN = 24; /*                                  */
        //	public const int DATA_GROUP_LEN = 14; /*                                  */
        public const int DATA_GROUP_LEN = 32;           /*  A0.25 
	public const int DATA_TYPE_LEN = 12; /*  A0.01                           */
        /*                                  */
        /*-- AMLACTION DB ------------------------------------------------------------------------*/
        public const int ALM_MSG_LEN = 40; /*                                  */
        /*                                  */
        /*-- AEQPT  DB ---------------------------------------------------------------------------*/
        public const int EQPT_TRNS_CATE_LEN = 4; /*                                  */
        /*                                  */
        /*-- AEQPTMT  DB -------------------------------------------------------------------------*/
        public const int MRTL_NO_LEN = 2; /*                                  */
        public const int EQPT_MTG_LEN = DATE_TIME_LEN; /* Eqpt MTG length                  */
        public const int MTRL_STAT_LEN = 4; /*                                  */
        public const int MTRL_WEIGHT_LEN = 6; /*                                  */
        public const int MTRL_QTIME_LEN = 6; /*                                  */
        public const int MOUNT_BAT_ID_LEN = 25; /*                                  */
        /*                                  */
        /*-- AEQPTRM  DB -------------------------------------------------------------------------*/
        public const int MAX_RM = 30; /*                                  */
        public const int MAX_RMPT = 30; /*                                  */
        /*                                  */
        /*-- ARMOPER  DB -------------------------------------------------------------------------*/
        public const int MAX_OPE_RM_CNT = 60; /*                                  */
        /*                                  */
        /*-- ASTOCKST DB -------------------------------------------------------------------------*/
        public const int GARBAGE_TIME_LEN = 6; /*                                  */
        public const int MAX_PULL_CNT_LEN = 3; /*                                  */
        /*                                  */
        /*-- ACODE DB-----------------------------------------------------------------------------*/
        public const int CODE_EXT_LEN = 50; /*                                  */
        public const int CODE_EXT_CNT = 5; /*                                  */
        /*                                  */
        /*-- AGRDRUL DB---------------------------------------------------------------------------*/
        public const int SRT_RULE_ID_LEN = 12; /*                                  */
        public const int SRT_RULE_DSC_LEN = 24; /*                                  */
        public const int SRT_RULE_TYP_LEN = 2; /*                                  */
        /*                                  */
        /*-- AGRDRULD DB--------------------------------------------------------------------------*/
        public const int SRT_GRADE_GRP_LEN = 2; /*                                  */
        /*                                  */
        /*-- AGRDGCOMB DB-------------------------------------------------------------------------*/
        public const int COMB_ID_LEN = 12; /*                                  */
        public const int COMB_DESC_LEN = 50; /*                                  */
        public const int GRD_GRP_LEN = 10; /*                                  */
        /*                                  */
        /*-- CCARRIST DB -------------------------------------------------------------------------*/
        public const int PALLET_ID_LEN = 25; /*                                  */
        /*                                  */
        /*-- CEEN     DB -------------------------------------------------------------------------*/
        public const int EEN_COMMENT_LEN = 120; /*                                  */
        //A0.09  #define    EEN_DSC_LEN                   24           /*                                  */
        public const int EEN_DSC_LEN = 64; /* A0.09 24 -> 64                   */
        public const int EEN_URL_LEN = 120; /*                                  */
        /*                                  */
        /*-- CWORDER  DB -------------------------------------------------------------------------*/
        public const int WORDER_ID_LEN = 16; /*                                  */
        //A0.09  #define    WORDER_DSC_LEN                24           /*                                  */
        public const int WORDER_DSC_LEN = 64; /* A0.09 24 -> 64                   */
        /*                                  */
        /*-- CLAYOUT  DB -------------------------------------------------------------------------*/
        public const int LAYOUT_ID_LEN = 8; /*                                  */
        //A0.07  #define    LAYOUT_DSC_LEN                24           /*                                  */
        public const int LAYOUT_DSC_LEN = 64; /*                                  */ //A0.07
        public const int AXIS_LEN = 2; /*                                  */
        /*                                  */
        /*-- AMESSAGE DB -------------------------------------------------------------------------*/
        public const int MSG_BODY_LEN = 160; /*                                  */
        public const int ACT_MSG_BODY_LEN = 80; /*                                  */
        public const int ACT_MSG_DETAIL_LEN = 512; /*                                  */
        /*                                  */
        /*-- ALERT DB ----------------------------------------------------------------------------*/
        public const int ALRT_DSC_LEN = 80; /*                                  */
        public const int EVT_DSC_LEN = 50; /*                                  */
        /*                                  */
        /*-- SEVNTLG -----------------------------------------------------------------------------*/
        public const int SHOP_CODE_LEN = 3; /*                                  */
        public const int SUBSYS_CODE_LEN = 3; /*                                  */
        public const int EVT_CATE_LEN = 4; /*                                  */
        public const int PROC_TIME_LEN = 8; /*                                  */
        public const int TRX_BODY_LEN = 1048576; /*                                  */
        public const int TRX_SHORT_BODY_LEN = 1024; /*                                  */
        public const int RESULT_MSG_LEN = 40; /*                                  */
        public const int LOG_RTN_CODE_LEN = 7; /*                                  */
        public const int TRX_LEN_LEN = 8; /*                                  */
        /*                                  */
        /*--- DCS --------------------------------------------------------------------------------*/
        public const int DCS_MSG_LEN = 1024; /* DCS Message                      */
        public const int MAX_UID_LENGTH = 18; /*                                  */
        public const int MAX_PWD_LENGTH = 30; /*                                  */
        public const int PRTY_SEQ_LEN = 6; /*                                  */
        public const int DCS_SEQ_LEN = 6; /*                                  */
        public const int PATTERN_ID_LEN = 6; /*                                  */
        public const int XFPLAN_CNT_LEN = 4; /*                                  */
        public const int PRODUCT_CNT_LEN = 3; /*                                  */
        public const int CRR_OWN_LEN = SYS_SUFFIX_LEN; /*                                  */
        /*                                  */
        /*-- CDEFECT DB --------------------------------------------------------------------------*/
        public const int DFT_TYP_LEN = 8; /*                                  */
        public const int PNL_ID_P_LEN = 12; /*                                  */
        public const int AX_LEN = 4; /*                                  */
        /*                                  */
        /*-- CCFDFGRM DB -------------------------------------------------------------------------*/
        public const int DEFECT_DES_LEN = 25; /*                                  */
        /*                                  */
        /*-- AMTRLST DB --------------------------------------------------------------------------*/
        public const int MTRL_VOL_LEN = 4; /*                                  */
        /*                                  */
        /*-- CSHTODF DB --------------------------------------------------------------------------*/
        public const int CF_PS_HEIGHT_LEN = 5; /*                                  */
        public const int RGB_DROP_HEIGHT_LEN = 4; /*                                  */
        public const int ODF_HEIGHT_LEN = 5; /*                                  */
        /*                                  */
        /*-- CODFPRM DB --------------------------------------------------------------------------*/
        public const int ODF_PARAM_LEN = 5; /*                                  */
        /*                                  */
        /*-- CCARRATT DB -------------------------------------------------------------------------*/
        public const int BANK_SHELF_ID_LEN = 30; /*                                  */
        /*                                  */
        /*-- CMTRLCT -----------------------------------------------------------------------------*/
        //	public const int MTRLCT_MAX_WRKID_CNT = (MAX_LAYG_LAY_CNT)*(PNL_SHT_CNT); /*                    */
        /*                                  */
        /*-- CLAYOTG DB --------------------------------------------------------------------------*/
        public const int MAX_LAYG_LAY_CNT = 20; /*                                  */
        /*                                  */
        /*-- CWORDER DB --------------------------------------------------------------------------*/
        public const int MAX_WKO_CRR_CNT = 100; /*                                  */
        public const int MAX_WKO_CRR_CNT_LEN = 3; /*                                  */
        public const int MAX_WKO_LOT_CNT = 50; /*                                  */
        public const int MAX_WKO_LOT_CNT_LEN = 2; /*                                  */
        public const int MAX_WKO_GRP_CNT = 50; /*                                  */
        public const int MAX_WKO_GRP_CNT_LEN = 2; /*                                  */
        public const int MAX_WKO_GRD_CNT = 50; /*                                  */
        public const int MAX_WKO_GRD_CNT_LEN = 2; /*                                  */
        public const int MAX_WKO_CUT_CNT = 100; /*                                  */
        public const int MAX_WKO_CUT_CNT_LEN = 3; /*                                  */
        /*                                  */
        /*-- CMTRLST DB --------------------------------------------------------------------------*/
        public const int SYRINGE_ID_LEN = 25; /*                                  */
        public const int MTRL_BATCH_ID_LEN = DATE_TIME_LEN; /*                                  */
        /*                                  */
        /*-- Shipping DB for LCM ------------------------------------------------------------------*/
        public const int LCM_CRR_ID_LEN = 12; /*                                  */
        public const int LCM_CRR_ID_LEN_8 = 8; /*                                  */
        public const int LCM_RETURN_NO_LEN = 11; /*                                  */
        public const int LCM_ABNORMAL_FLG_LEN = 4; /*                                  */
        public const int LCD_RESERVED_LEN = 4; /*                                  */
        public const int LCM_RESERVED_LEN = 20; /*                                  */
        public const int LCM_PPBOX_ID_LEN = 20; /*                                  */
        public const int LCM_CARTON_ID_LEN = 30; /*                                  */
        public const int LCD_CARTON_ID_LEN = 20; /*                                  */
        public const int ERP_PRODUCT_ID_LEN = 15; /*                                  */
        public const int LCM_BATCH_NO_LEN = 11; /*                                  */
        public const int LCM_SHIP_TYPE = 8; /*                                  */
        public const int LCM_SHIP_DATE = 14; /*                                  */
        public const int LCM_PFCD_LEN = 15; /*                                  */
        public const int LCD_PFCD_LEN = 12; /*                                  */
        public const int LCM_REJECT_LEN = 12; /*                                  */
        public const int LCM_OPE_ID_LEN = 4; /*                                  */
        public const int LCM_DATE_LEN = (YEAR_LEN + MONTH_LEN + DAY_LEN); /*                   */
        public const int MAX_LCM_SHT_CNT = 80; /*                                  */
        public const int LCM_SHT_CNT_LEN = 2; /*                                  */
        public const int MAX_LCM_CRR_CNT = 99; /*                                  */
        public const int LCM_CRR_CNT_LEN = 2; /*                                  */
        public const int LCM_WORDER_ID_LEN = 12; /*                                  */
        public const int LCM_OWNER_ID_LEN = 4; /*                                  */
        public const int LCM_LOT_ID_LEN = 20; /*                                  */
        public const int LCM_PNL_SHT_CNT = 36; /*                                  */
        public const int LCM_TIME_LEN = (HOUR_LEN + MINT_LEN + SEC_LEN); /*                    */
        public const int ODF_PULSE_LEN = 4; /*                                  */
        public const int LCD_REVISION_LEN = 4; /*                                  */
        public const int LCM_RTN_CMT_LEN = 128; /*                                  */
        public const int LCM_RTN_CODE_LEN = 2; /*                                  */
        public const int LCM_FILE_SIZE_LEN = 10; /*                                  */
        public const int LCM_PALLET_ID_LEN = 10; /*                                  */
        public const int LCM_PNL_CNT_LEN = 2; /*                                  */
        public const int LCM_SLOT_NO_LEN = 2; /*                                  */
        public const int LCM_PRODUCT_ID_LEN = 15; /*                                  */
        public const int LCM_LCD_PRODUCT_ID_LEN = 15; /*                                  */
        public const int LCM_WORK_ID_LEN = 10; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /* definition for TCS                                                                     */
        /*----------------------------------------------------------------------------------------*/
        public const int ALM_ID_LEN = 8; /* alarmID                          */
        public const int ALM_CODE_LEN = 3; /* alarm code                       */
        public const int RECIPEPAR_LEN = 10; /* recipe parm                      */
        public const int EQPTMODE_LEN = 4; /* eqpt mode                        */
        public const int EQPTSSTAT_LEN = 4; /* eqpt sub status                  */
        public const int MESSEQNO_LEN = 6; /* measurement seq NO               */
        public const int MESTYPE_LEN = 3; /* measurement type                 */
        public const int QRESTFLAG_LEN = 5; /* que restriction flag             */
        public const int DATANUME_LEN = 12; /* Numerical Value data             */
        public const int DATARAW_LEN = 12; /* RAWdata                          */
        public const int DATACHAR_LEN = 20; /* charactor data                   */
        public const int SYSBYTE_LEN = DATE_TIME_LEN; /* system byte                      */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  macro definition for arry cnt by table                                                */
        /*----------------------------------------------------------------------------------------*/
        public const int SHT_CNT_SIZE = 6; /*                                  */
        public const int SHT_TIME_SIZE = 6; /*                                  */
        public const int BAY_EQPT_SIZE = 3; /*                                  */
        public const int BAY_TCNT = 500; /*                                  */
        public const int EQPT_ARY_SIZE = 2; /*                                  */
        public const int MAX_EQPT_ARY = 10; /*                                  */
        public const int CHMBR_ARY_SIZE = 2; /*                                  */
        public const int MAX_CHMBR_ARY = 10; /*                                  */
        public const int LOTD_RWKOPE_SIZE = 2; /*                                  */
        public const int MAX_DLOTD_RWK = 5; /*                                  */
        public const int MAX_DLTD2_SEN = 5; /*                                  */
        public const int MAX_DLTD2_ZURE = 2; /*                                  */
        public const int SEN_ZURE_LEN = 8; /*                                  */
        public const int FAILCNT_LEN = 3; /*                                  */
        public const int JUDGE_LEN = MAX_SHT_PNL_CNT; /*                                  */
        public const int TST_JUDGE_LEN = 3; /*                                  */
        public const int HANTEI_LEN = 3; /*                                  */
        public const int MESRFLD_FLD_SIZE_EWS = 4; /*                                  */
        public const int MESRFLD_FLD_SIZE = 4; /*                                  */
        public const int MAX_MESR_FLD = 250; /*                                  */
        public const int MAX_SPEC_ARY = 2; /*                                  */
        public const int MAX_SPEC_CNT = 600; /*                                  */
        public const int MAX_SPEC_CNT_EWS = 1250; /*                                  */
        public const int MAX_MESR_CNT = 1000; /*                                  */
        public const int MAX_MESR_CNT_EWS = 2000; /*                                  */
        public const int MAX_NIKON_CNT = 500; /*                                  */
        public const int CDAT_CNT_LEN = 2; /*                                  */
        public const int MAX_CDAT_CNT = 10; /*                                  */
        public const int MAX_CDAT_EWS = 15; /*                                  */
        public const int IDAT_CNT_LEN = 2; /*                                  */
        public const int MAX_IDAT_CNT = 40; /*                                  */
        public const int MAX_IDAT_EWS = 25; /*                                  */
        public const int MAX_SPCFLG_CNT = 75; /*                                  */
        public const int MAX_RSVD = 4; /*                                  */
        public const int MAX_MFCGRP = 60; /*                                  */
        public const int OPISEC_MFC_SIZE = 2; /*                                  */
        public const int MAX_MSTGRP = 20; /*                                  */
        public const int OPISEC_MAS_SIZE = 2; /*                                  */
        public const int MAX_MFGGRP = 30; /*                                  */
        public const int OPISEC_MFG_SIZE = 2; /*                                  */
        public const int PNTBL_HNPRDCT_SIZE = 2; /* halr product parts code array cnt*/
        public const int PNTBL_EC_SIZE = 2; /*                                  */
        public const int PNTBL_GLASS_SIZE = 2; /*                                  */
        public const int MAX_GLASS = 20; /* glass board P/N                  */
        public const int MAX_EC = 10; /* model number code                */
        public const int MAX_HNPRDCT = 20; /* halr product parts code array cnt*/
        public const int MAX_STB_LOT = 500; /* Numberinged lot cnt              */
        public const int MAX_STB_SGR = 500; /* Numberinged Sheet Group cnt      */
        public const int MLOT_STB_LOT_SIZE = 4; /* Numberinged lot cnt size         */
        public const int MAX_CANCELLOT = 200; /* lot cancel cnt                   */
        public const int MLOT_CANCELLOT_SIZE = 4; /* lot cancel cnt size              */
        public const int GLS_CNT_SIZE = 2; /*                                  */
        public const int RGST_ID_LEN = 2; /* registration id                  */
        public const int PEPLVL_ARY_SIZE = 2; /*                                  */
        public const int MAX_PEPLVL = 10; /*                                  */
        public const int RWKMAXCNT_SIZE = 2; /*                                  */
        public const int MAX_RWKID = 20; /* reworkID xxxxx?                  */
        /*        ? - exept M,I,O           */
        public const int RWK_CNT_LEN = 2; /*                                  */
        public const int MAX_RWK_CNT_LEN = 2; /*                                  */
        public const int DSPEC_MAX = 3; /*                                  */
        public const int EQPT_EQPTG_SIZE = 2; /*                                  */
        public const int EQPT_PORT_SIZE = 2; /*                                  */
        public const int KANBAN_SIZE = 3; /*                                  */
        public const int EQPT_RTICL_SIZE = 2; /*                                  */
        public const int MAX_RTICL = 6; /*                                  */
        public const int MAX_RTICL_SIZE = 2; /*                                  */
        public const int MAX_RTICLST = 10; /*                                  */
        public const int MAX_PROBE = 10; /*                                  */
        public const int INTRVAL_LEN = 4; /*                                  */
        public const int QCREC_SIZE = 2; /*                                  */
        public const int MAX_QCREC = 10; /*                                  */
        public const int MAX_EQPT_GROUP = 1000; /*                                  */
        public const int MAX_PORT = 30; /*                                  */
        public const int MAX_PORT_SIZE = 2; /*                                  */
        public const int MAX_BATCH = 30; /*                                  */
        public const int MAX_STOCKER_PORT = 30; /*                                  */
        public const int MAX_STOCKER_ZONE = 20; /*                                  */
        public const int EQPT_CNT_LEN = 2; /*                                  */
        public const int MAX_EQPTCNT = 20; /*                                  */
        public const int UNIT_CNT_SIZE = 3; /*                                  */
        public const int MAX_UNIT_CNT = 100; /*                                  */
        public const int PARTG_PART_SIZE = 2; /*                                  */
        public const int MAX_PARTG = 50; /*                                  */
        public const int EQPT_PART_SIZE = 2; /*                                  */
        public const int MAX_PART = 20; /*                                  */
        public const int EQPTG_EQPT_SIZE = 3; /*                                  */
        public const int MAX_EQPTID = 500; /*                                  */
        public const int MAX_STOCKER_CNT = 500; /*                                  */
        public const int STOCKER_CNT_LEN = 3; /*                                  */
        public const int ALT_STC_CNT = 20; /*                                  */
        public const int DATACNT_SIZE = 2; /*                                  */
        public const int MAX_SLOT = 32; /*                                  */
        public const int WIPDB_IARY_SIZE = 2; /*                                  */
        public const int WIPDB_WARY_SIZE = 4; /*                                  */
        public const int WIPDB_IARY = 80; /*                                  */
        public const int WIPDB_WARY = 50; /*                                  */
        public const int WIPDB1_WARY = 200; /*                                  */
        public const int MAX_WIPDB_WARY = 9999; /*                                  */
        public const int MAX_WIP1_RCD = ((MAX_WIPDB_WARY - WIPDB_WARY) / WIPDB1_WARY + 1); /*  */
        /* (9999-50)/200 + 1 = 9949/200 + 1 = 49+1 = 50 */
        public const int WIPSUMD_LOTARY_SIZE = 4; /*                                  */
        public const int WIPSUMD_LOTARY = 120; /*                                  */
        public const int MAX_WIP_ISHT = WIPDB_IARY * MAX_SHT_ARY; /*                        */
        public const int WIPSUMM_LOTARY_SIZE = 4; /*                                  */
        public const int WIP_CRR_CNT = 3; /*                                  */
        public const int WIP_SHT_CNT = 3; /*                                  */
        public const int CASHIS_LOTARY = 25; /*                                  */
        public const int DAY_ARY_SIZE = 2; /*                                  */
        public const int MAX_DAY_ARY = 40; /*                                  */
        public const int PN_ARY_SIZE = 2; /*                                  */
        public const int MAX_PN_ARY = 20; /*                                  */
        public const int RCPFLG_LEN = 1; /*                                  */
        public const int LOT_RSV_CNT = 10; /* for ASBWHNXT display OPI         */
        public const int MAX_LOT_SIZE = 6; /*                                  */
        public const int MAX_SGR_SIZE = 6; /*                                  */
        /* Regist Model No. cnt by 1eqpt 1process when in model No. select     */
        public const int PNSL_ARY_SIZE = 2; /* Model No. select array count     */
        public const int MAX_PNSL_ARY = 50; /* Model No. select array max cnt   */
        /* model no. assign by port                                                     */
        public const int MAX_KNBN_ARY = 100; /* KANBAN count                     */
        public const int KNBN_CNT_LEN = 3; /* KANBAN size length               */
        public const int SRC_DST_LEN = 3; /* Flag "SRC", "DST"                */
        public const int MQCRT_ROUTE_ARY_SIZE = 3; /*                                  */
        public const int MQCRT_ROUTE_ARY = 100; /*                                  */
        public const int SCH_ARY_SIZE = 3; /*                                  */
        public const int MAX_SCH_ARY = 500; /*                                  */
        public const int SIGMA_LEN = 34; /*                                  */
        public const int SPEC_CHK_ACTION_LEN = 4; /*                                  */
        public const int MESID_LEN = (MES_ID_LEN + MES_ID_LEN); /*                                  */
        public const int MESNAME_LEN = 24; /*                                  */
        public const int VALUE_LEN = 2; /*                                  */
        public const int MSG_80_LEN = 80; /*                                  */
        public const int RULENAME_LEN = 6; /*                                  */
        public const int RULE_CNT_SIZE = 2; /*                                  */
        public const int MAX_RULE_CNT = 20; /*                                  */
        public const int CURRENT_CNT_SIZE = 3; /*                                  */
        public const int CURRENT_LOC_SIZE = 3; /*                                  */
        public const int MAX_CURRENT_CNT = 120; /*                                  */
        public const int LD_SUP_STC_SIZE = 1; /*                                  */
        public const int MAX_LD_SUP_STC = 4; /*                                  */
        public const int UL_SUP_STC_SIZE = 1; /*                                  */
        public const int MAX_UL_SUP_STC = 4; /*                                  */
        public const int RET_STC_SIZE = 1; /*                                  */
        public const int MAX_RET_STC = 4; /*                                  */
        public const int PNTBL_CPROD_SIZE = 2; /*                                  */
        public const int MAX_CPROD = 10; /*                                  */
        public const int KEY_ID_LEN = 30; /*  A0.14 25 --> 30                 */
        public const int RESIST_TYPE_SIZE = 2; /*                                  */
        public const int MAX_RESIST_TYPE = 20; /*                                  */
        public const int UFG_CNT_SIZE = 2; /*                                  */
        public const int MAX_UFG_CNT = 25; /*                                  */
        public const int UAR_CNT_SIZE = 2; /*                                  */
        public const int MAX_UAR_CNT = 25; /*                                  */
        public const int ENG_NAME_LEN = 20; /*                                  */
        public const int PROJECT_CODE_LEN = 10; /*                                  */
        public const int EXP_NO_LEN = 12; /*                                  */
        public const int MAX_DEFECT_ARY = 120; /*                                  */
        public const int MAX_DEFECT_ARY_LEN = 3; /*                                  */
        public const int MAX_JDGCRR_ARY = 50; /*                                  */
        public const int MAX_JDGCRR_ARY_SIZE = 2; /*                                  */
        public const int PPBOX_CNT_LEN = 100; /*                                  */
        public const int PPBOX_CNT_LEN_SIZE = 3; /*                                  */
        public const int MAX_OWNER_CNT = 100; /*                                  */
        public const int SUB_UNIT_CNT = 99; /*                                  */
        /*                                  */
        /*-- SORT LOG MESSAGE LENGTH For QSRTLOG -------------------------------------------------*/
        public const int SRTLOGMSG_LEN = 5000; /*                                  */
        /*                                  */
        /*-- ARY inspection process special eqpt id ----------------------------------------------*/
        public const int DEFECT_ARY = 10; /* defect count array size          */
        public const int DEFECT_ARY_SIZE = 2; /* defect count array size length   */
        /*                                  */
        /*-- Cel for Vryop -----------------------------------------------------------------------*/
        public const int RECIPE_VER_LEN = (YEAR_LEN + MONTH_LEN + DAY_LEN + HOUR_LEN + MINT_LEN + SEC_LEN); /*  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  array count & its size for QREPORT structure                                          */
        /*----------------------------------------------------------------------------------------*/
        public const int REPORT_TRX_CATE = 4; /*                                  */
        /*                                  */
        public const int REPORT_SCRAP_ARY_SIZE = PNL_CNT_LEN; /* board scrap                      */
        public const int REPORT_SCRAP_ARY = MAX_LOT_SHT_CNT; /*                                */
        /*                                  */
        public const int REPORT_SCRAC_ARY_SIZE = 3; /*                                  */
        public const int REPORT_SCRAC_ARY = 60; /*                                  */
        /*                                  */
        public const int REPORT_SCRCR_ARY_SIZE = PNL_CNT_LEN; /* board scrap credit               */
        public const int REPORT_SCRCR_ARY = MAX_LOT_SHT_CNT; /*                                */
        /*                                  */
        public const int REPORT_SCRCQ_ARY_SIZE = 3; /* chip scrap credit                */
        public const int REPORT_SCRCQ_ARY = 80; /*                                  */
        /*                                  */
        public const int REPORT_SPLIT_ARY_SIZE = PNL_CNT_LEN; /*                                  */
        public const int REPORT_SPLIT_ARY = MAX_LOT_SHT_CNT; /*                                */
        /*                                  */
        public const int REPORT_MERGE_ARY_SIZE = PNL_CNT_LEN; /*                                  */
        public const int REPORT_MERGE_ARY = MAX_LOT_SHT_CNT; /*                                */
        /*                                  */
        public const int REPORT_REWRK_ARY_SIZE = PNL_CNT_LEN; /*                                  */
        public const int REPORT_REWRK_ARY = MAX_LOT_SHT_CNT; /*                                */
        /*                                  */
        public const int REPORT_REWRQ_ARY_SIZE = PNL_CNT_LEN; /*                                  */
        public const int REPORT_REWRQ_ARY = MAX_LOT_SHT_CNT; /*                                */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  monitor macro definition                                                              */
        /*----------------------------------------------------------------------------------------*/
        public const int MONSTAT_LEN = 4; /*                                  */
        /*                                  */
        /*-- ARRAY TESTER DB ---------------------------------------------------------------------*/
        public const int RSN_CNT_LEN = 3; /* FOR QATSTCHP                     */
        public const int ERR_CNT_LEN = 3; /* FOR QATSTCHP                     */
        public const int MAX_TSTCHP_ARY = 144; /* for QATSTCHP                     */
        public const int MAX_TSTHIS_ARY = 432; /* for QATSTHIS                     */
        /*                                  */
        /*-- DTLSTCOD DB -------------------------------------------------------------------------*/
        public const int TLST_CAT_LEN = 4; /* category                         */
        public const int CODE_NAME_LEN = 4; /* code name                        */
        public const int CODE_NUM_LEN = 4; /* code number                      */
        public const int CODE_DESC_LEN = 24; /* code description                 */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  report                                                                                */
        /*----------------------------------------------------------------------------------------*/
        public const int MAX_SCRP = 30; /* Scrap Reason Code Max Cnt        */
        public const int MAX_SCRP50 = 50; /* Scrap Reason Code Max Cnt        */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  Array Special Process                                                                 */
        /*----------------------------------------------------------------------------------------*/
        public const int MAX_RETICL_LST = 200; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  OS result process                                                                     */
        /*----------------------------------------------------------------------------------------*/
        public const int THRESHOLD_LEN = 2; /* threshold length                 */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*                                                                                        */
        /*----------------------------------------------------------------------------------------*/
        public const int N2_KANBAN_SIZE = 3; /*                                  */
        public const int N2_WIPCNT_SIZE = 3; /*                                  */
        public const int MAX_WIPLOT_ARY_SIZE = 3; /*                                  */
        public const int MAX_WIPLOT_ARY = 200; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  AMGxxx Definition                                                                     */
        /*----------------------------------------------------------------------------------------*/
        public const int D_VER_LEN = 2; /* version                          */
        public const int MFG_ORDER_LEN = 25; /* mfgorder                         */
        public const int OWNER_ID_LEN = 20; /* owner                            */
        public const int MATERIAL_LEN = 25; /* material                         */
        public const int PANELINFO_LEN = 100; /* Panel information                */
        public const int SHEET_QTY_LEN = 2; /* sheet qty                        */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        public const int DELTA_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        public const int FLOOR_CODE_LEN = 2; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  REPORT Definition                                                                     */
        /*----------------------------------------------------------------------------------------*/
        public const int CLM_CATE_LEN = 4; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  Work Order Definition(04/09)                                                          */
        /*----------------------------------------------------------------------------------------*/
        public const int WO_PNL_CNT_LEN = 8; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  Product Type Length for Numbering(04/12)                                              */
        /*----------------------------------------------------------------------------------------*/
        public const int PRDCT_NUM_LEN = 2; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  Link Sequence No Length for OPEHIS                                                    */
        /*----------------------------------------------------------------------------------------*/
        public const int OPHIS_SEQ_LEN = 10; /*                                  */
        /*                                  */
        /*--- For AMHS ---------------------------------------------------------------------------*/
        public const int AMHS_TICKET_NO_LEN = 7; /*                                  */
        public const int AMHS_CMM_LEN = 8; /*                                  */
        public const int AMHS_LT_LEN = 8; /*                                  */
        public const int AMHS_TSC_LEN = 4; /*                                  */
        public const int AMHS_CLSFCAT_LEN = 1; /*                                  */
        /*                                  */
        /*-- Move from Ary -----------------------------------------------------------------------*/
        public const int PRDCTYP_LEN = 1; /*                                  */
        public const int CHIP_CHAR_POS = 10; /* Chip Char. Position              */
        public const int POSITIONID_LEN = 3; /*                                  */
        public const int RETICLE_ARY_SIZE = 2; /* reticl count for eqpt            */
        public const int MAX_RETICLE_ARY = 50; /* reticl count for eqpt            */
        public const int RETICLE_ID_LEN = 21; /* reticle-id                       */
        public const int PROBE_ID_LEN = 12; /* probe-id                         */
        public const int LOT_OPE_MSG_LEN = 420; /*                                  */
        public const int RETICLE_STAT_LEN = 4; /*                                  */
        public const int PROBE_STAT_LEN = 4; /*                                  */
        public const int PLN_ID_LEN = (YEAR_LEN + MONTH_LEN + DAY_LEN + HOUR_LEN + MINT_LEN + SEC_LEN + MONTH_LEN + DAY_LEN + DAY_LEN);
        public const int AFF_CNT_LEN = 3; /*                                  */
        public const int LABEL_ID_LEN = 24; /*                                  */
        public const int LOT_RUN_ID_LEN = 3; /*                                  */
        public const int MAX_RUN_ID_ARY = 10; /*                                  */
        public const int MAX_LOT_PRM_CNT = 50; /*                                  */
        public const int LOT_PRM_CNT_LEN = 2; /*                                  */
        public const int MAX_PARAM_RCP_CNT = 500; /*                                  */
        public const int PARAM_RCP_CNT_LEN = 3; /*                                  */
        public const int MAX_BOM_ID_CNT = 1; /* A0.03                            */
        public const int BOM_ID_CNT_LEN = 1; /* A0.03                            */
        public const int MAX_BOM_DETAIL_CNT = 50; /* A0.03                            */
        public const int BOM_DETAIL_CNT_LEN = PNL_CNT_LEN; /* A0.03                            */
        public const int MAX_BIN_GRADE_CNT = 30; /* A0.11                            */
        public const int MAX_BIN_JUDGE_CNT = 30; /* A0.11                            */
        public const int MAX_PARAM_SL_CNT = 50; /*                                  */
        public const int PARAM_SL_CNT_LEN = PNL_CNT_LEN; /*                                  */
        public const int MAX_PRDCT_RT_CNT = 20; /*                                  */
        public const int PRDCT_RT_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCT_CP_CNT = 10; /*                                  */
        public const int PRDCT_CP_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCT_MT_CNT = 30; /*                                  */
        public const int PRDCT_MT_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCCMT_MT_CNT = 50; /*                                  */
        public const int PRDCTMT_MT_CNT_LEN = 2; /*                                  */
        public const int MAX_PRDCTMT_GRD_CNT = 10; /*                                  */
        public const int PRDCTMT_GRD_CNT_LEN = 2; /*                                  */
        public const int MAX_MTRLG_MT_CNT = 50; /*                                  */
        public const int MTRLG_MT_CNT_LEN = 2; /*                                  */
        public const int MAX_RCLIF_RCLST_CNT = 30; /*                                  */
        public const int RCLIF_RCLST_CNT_LEN = 2; /*                                  */
        public const int MAX_MQCSHT_OP_CNT = 10; /*                                  */
        public const int MQCSHT_OP_CNT_LEN = 2; /*                                  */
        public const int MAX_PPBOX_MT_CNT = 700; /*                                  */
        public const int PPBOX_MT_CNT_LEN = 3; /*                                  */
        public const int MTRLG_ID_LEN = 10; /*                                  */
        public const int PROC_CODE_LEN = CODE_LEN; /* (4)                              */
        public const int TASK_NAME_LEN = 8; /* Task name                        */
        public const int FUNC_CATE_LEN = 8; /* Function category                */
        public const int SAC_ID_LEN = 4; /* Trx send destination id          */
        public const int MAX_BATCH_CNT = 2; /* Maximum batch carrier qty        */
        public const int TCS_COM_PROG_ID_LEN = 32; /* VTAP TCS I/F user class          */
        public const int EQP_COM_PROG_ID_LEN = 32; /* VTAP EQ  I/F user class          */
        public const int EQP_HOST_LEN = 16; /* EQP host name (HSMS)             */
        public const int EQP_COM_PORT_NUM = 12; /* EQP COM port  (SECS1)            */
        public const int BAUD_RATE_LEN = 12; /* COM Baud rate (SECS1)            */
        public const int TIME_OUT_LEN = 8; /* Time out                         */
        public const int HSMS_MODE_LEN = 2; /* HSMS mode(support SS only)       */
        public const int TAP_LOG_SIZE_LEN = 8; /* VTAP log size                    */
        public const int TAP_LOG_FILE_LEN = 8; /* VTAP log file                    */
        public const int TAP_RETRY_CNT_LEN = 2; /* Retry count                      */
        public const int TAP_PFILE_NAME_LEN = 64; /* VTAP P-File name                 */
        public const int TAP_LOG_PATH_LEN = 64; /* VTAP LOG PATH                    */
        public const int CRR_SUBSTAT_LEN = 3; /* STCS carrier sub status          */
        public const int CRR_TASK_NAME_LEN = 64; /* STCS task name                   */
        public const int CRR_EXCEPTION_NAME_LEN = 64; /* STCS exception task name         */
        public const int STREAM_FUNCTION_LEN = 64; /* Recive Stream Function Name      */
        public const int PFILE_DATA_LEN = 99999; /* VTAP P-File body                 */
        public const int PFILE_LEN = 10; /* VTAP P-File name                 */
        public const int MAX_EEN_LOT_CNT = 50; /*                                  */
        public const int EEN_LOT_CNT_LEN = 2; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For DCS                                                                               */
        /*----------------------------------------------------------------------------------------*/
        public const int DCS_PARAMETER_LEN = 64; /* DCS PARAMETER LEN                */
        public const int AMHS_SHELF_ID_LEN = 10; /* AMHS Shelf ID                    */
        public const int MQ_NAME_LEN = 20; /* MQ Naming Length                 */
        public const int SEL_PRTY_LEN = 2; /* Batch id for TFT/CF              */
        public const int LOOP_CNT_LEN = 2; /* Loop Set Count                   */
        public const int ORDERNO_LEN = 12;           /* Sales Order      A0.29 */
        public const int CIP_PTN_LEN = 6;           /* Chip Pattern     A0.29 */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For DPWHTNXT                                                                          */
        /*----------------------------------------------------------------------------------------*/
        public const int MASK_REASON_LEN = 4; /* Mask Reason Length               */
        public const int SORT_REASON_LEN = 4; /* Sort Reason Length               */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For DPISRTCR                                                                          */
        /*----------------------------------------------------------------------------------------*/
        public const int SRT_TYP_LEN = 100; /* Sorting Criteria                 */
        /*                                  */
        /*-- APARTSPC,CPARTSPC DB ----------------------------------------------------------------*/
        public const int PART_SPEC_ID_LEN = 10; /*                                  */
        /*                                  */
        /*--- For UAC ----------------------------------------------------------------------------*/
        public const int USER_NAME_LEN = 30; /*                                  */
        public const int CHINA_NAME_LEN = 16; /*                                  */
        public const int DEPT_ID_LEN = DEPT_CODE_LEN; /*                                  */
        public const int DEPT_NAME_LEN = 30; /*                                  */
        public const int TITLE_LEN = 20; /*                                  */
        public const int EXT_NO_LEN = 6; /*                                  */
        public const int NOTESID_LEN = 20; /*                                  */
        public const int LAST_ACT_LEN = 16; /*                                  */
        public const int EVT_CD_LEN = 12; /*                                  */
        public const int INWORK_LEN = 12; /*                                  */
        public const int SETUP_STATE_LEN = 18; /*                                  */
        public const int UGROUP_ID_LEN = 10; /*                                  */
        public const int UGROUP_NAME_LEN = 30; /*                                  */
        public const int SYS_SEQ_LEN = 2; /*                                  */
        public const int HEADER_LEN = 1; /*                                  */
        public const int SUBSYSTEM_LEN = 4; /*                                  */
        public const int UFUNCT_LEN = 4; /*                                  */
        public const int UFUNCTNAME_LEN = 50; /*                                  */
        public const int KEY_NAME_LEN = 80; /*                                  */
        public const int TBL_NAME_LEN = 10; /*                                  */
        public const int UAC_POSITION_LEN = 3; /*                                  */
        public const int ERR_KEY_LEN = 256; /*                                  */
        public const int EQPTG_LEN = 8; /*                                  */
        public const int EQPTG_DESC_LEN = 20; /*                                  */
        public const int MAX_USERG_CNT = 20; /*                                  */
        public const int MAX_EQPTG_EQPT_CNT = 20; /*                                  */
        /*                                  */
        /*--- For Recipe -------------------------------------------------------------------------*/
        public const int UNIT_ID_LEN = EQPT_ID_LEN; /*                                  */
        public const int RECIPE_PARAVAL_LEN = 16; /*                                  */
        public const int MAX_RCPPRM_CNT = 500; /*                                  */
        public const int RECIPE_PARA_CNT_PER_ROW = 200; /*                                  */
        public const int RECIPE_BODY_LEN = RECIPE_PARAVAL_LEN * RECIPE_PARA_CNT_PER_ROW; /*              */
        public const int MAX_RECIPE_CNT = 500; /*                                  */
        public const int RECIPE_CNT_SIZE = 4; /*                                  */
        public const int CHK_RSLT_LEN = 1; /*                                  */
        /*                                  */
        /*--- For Eqpt Check ---------------------------------------------------------------------*/
        public const int EQCK_MAX_UNIT_CNT = 32; /*                                  */
        public const int EQCK_PARAM_NAME_LEN = DATA_NAME_LEN; /*                                  */
        public const int EQCK_PARAM_CATE_LEN = DATATYPE_LEN; /*                                  */
        public const int EQCK_PARAM_DESC_LEN = 24; /*                                  */
        public const int EQCK_PARAM_TYPE_LEN = 1; /*                                  */
        public const int EQCK_PARAM_VALUE_LEN = DATA_VALUE_LEN; /*                                  */
        public const int EQCK_TASK_CODE = 1; /*                                  */
        public const int EQCK_INTERVAL_LEN = 5; /*                                  */
        public const int MAX_EQPRM_CNT = 1000; /*                                  */
        public const int EQPRM_CNT_SIZE = 4; /*                                  */
        public const int SCHDL_PARAM_LEN = 16; /*                                  */
        public const int LITE_TIMESTAMP_LEN = 14; /* YYYYMMDDHHMMSS                   */
        public const int TRK_TSTAMP_LEN = 19; /* YYYY-MM-DD-HH.MM.SS              */
        /*                                  */
        /*--- For CFM ----------------------------------------------------------------------------*/
        public const int PRD_WIP_CNT_LEN = 3; /*                                  */
        /*                                  */
        /*--- For PMS ------------------------------------------------------- begin of A0.02 -----*/
        public const int PM_DEPT_ID_LEN = 16; /*                                  */
        public const int PM_ACTION_ID_LEN = 16; /* 64-> 16                          */
        public const int PM_ACTION_DESC_LEN = 64; /*                                  */
        public const int PM_REASON_ID_LEN = 16; /* 64-> 16                          */
        public const int PM_REASON_DESC_LEN = 64; /*                                  */
        public const int PM_CHECK_ID_LEN = 16; /* 64-> 16                          */
        public const int PM_CHECK_VER_LEN = 4; /*                                  */
        public const int PM_CHECK_DESC_LEN = 128; /*                                  */
        public const int PM_TYPE_LEN = 2; /*                                  */
        //double -> DATA_VALUE_LEN                              /*                                  */
        //long ->  3                                            /*                                  */
        public const int PM_LONG_LEN = 3; /*                                  */
        public const int PM_RTYPE_LEN = 20; /*                                  */
        public const int PM_GROUP_NM_LEN = 16; /* 64 -> 16                         */
        public const int PM_ITEM_NO_LEN = 3; /* small -> 3                       */
        public const int PM_ITEM_NM_LEN = 16; /* 256 -> 16                        */
        public const int PM_ITEM_DESC_LEN = 256; /*                                  */
        public const int PM_MEASURE_NM_LEN = 16; /* 64 -> 16                         */
        public const int PM_PURPOSE_LEN = 64; /*                                  */
        public const int PM_VENDOR_ID_LEN = 32; /*                                  */
        public const int PM_VENDOR_MTRL_LEN = 32; /*                                  */
        public const int PM_LOCATION_LEN = 32; /*  63 -> 32                        */
        public const int PM_ID_LEN = 16; /*  64 -> 16                        */
        public const int PM_EQPT_CAT_LEN = 20; /*                                  */
        public const int PM_INTVL_LEN = 16; /*                                  */
        public const int PM_BASED_REF_LEN = 64; /*                                  */
        public const int PM_ACT_LEN = 5; /*                                  */
        public const int PM_MTNO_LEN = 20; /*                                  */
        public const int PM_UN_LEN = 2; /*                                  */
        public const int PM_STK_LEN = 5; /*                                  */
        public const int PM_DAT_LEN = 19; /*                                  */
        public const int PM_SQL_LEN = 2000; /*                                  */
        //  #define    PM_GROUP_LEN                  16           /*                                  */
        public const int PM_GROUP_LEN = 10; /*                                  */
        public const int PM_MESSAGE_LEN = 128; /*                                  */
        public const int PM_UNIT_NM_LEN = 32; /*                                  */
        public const int PM_ADDR_LEN = 128; /*                                  */
        public const int PM_TEL_LEN = 32; /*                                  */
        public const int PM_FAX_LEN = 32; /*                                  */
        public const int PM_ITEM_ATTACH_LEN = 128; /*                                  */
        public const int PM_ENGINEER_LEN = 17; /*                                  */
        public const int UDATA_NAME_LEN = 32; /*                                  */
        public const int UDATA_VALUE_LEN = 254; /*                                  */


        //MINDY


        /*                                  */
        /*------------------------------------------------------------------ end of A0.02 --------*/
        /*----------------------------------------------------------------------------------------*/
        /*  For Reticle                                                                           */
        /*----------------------------------------------------------------------------------------*/
        public const int RETICLE_ZONE_LEN = 1; /* Stock Zone                       */
        public const int RETICLE_ROW_LEN = 2; /* Stock Row                        */
        public const int RETICLE_COLUMN_LEN = 2; /* Stock Column                     */
        /*                                  */
        /*--- Add QMEASURE TO HIS ----------------------------------------------------------------*/
        public const int RECIPEID_LEN = RECIPE_ID_LEN; /*                                  */
        public const int CLDATE_LEN = DATE_LEN; /*                                  */
        public const int CLTIME_LEN = TIME_LEN; /*                                  */
        public const int PV_PROC_ID_LEN = PROC_ID_LEN; /*                                  */
        public const int PEQPT_ID_LEN = EQPT_ID_LEN; /*                                  */
        public const int PSUBENTITY_LEN = SUBENTITY_LEN; /*                                  */
        public const int PRECIPEID_LEN = RECIPE_ID_LEN; /*                                  */
        public const int PCLDATE_LEN = DATE_LEN; /*                                  */
        public const int PCLTIME_LEN = TIME_LEN; /*                                  */
        public const int DAVALU_LEN = 16; /*                                  */
        /*                                  */
        /*-- HAEQPUTL ----------------------------------------------------------------------------*/
        public const int STATUS_TIME_LEN = 12; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*   Variable length define for RMS                                                       */
        /*----------------------------------------------------------------------------------------*/
        public const int RECIPE_READ_REC_COUNT = 5; /* [5]  seq no 1~5                  */
        public const int INTERVAL_LEN = 5; /* [5]  Interval length             */
        public const int PARAM_LEN_RMS = 16; /* [16] Param length                */
        /* for xPCSCHDL xPISCHDL            */
        /*                                  */
        /*-- HAEQPUTL ----------------------------------------------------------------------------*/
        /*                                  */
        /*                                  */
        /******************************************************************************************/
        /*  Declaration for MQ                                                                    */
        /******************************************************************************************/
        public const int MQ_CORREL_ID_LENGTH = 24; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For Data Mart                                                                         */
        /*----------------------------------------------------------------------------------------*/
        public const int DM_QNAME_LEN = 48; /* MQ Naming Length                 */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For CPDLDMSG                                                                          */
        /*----------------------------------------------------------------------------------------*/
        public const int MSG_LEN = 80; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For DCSTRJED                                                                          */
        /*----------------------------------------------------------------------------------------*/
        public const int CSTRJ_CATE_LEN = 1; /*                                  */
        public const int CSTRJ_CODE_LEN = 10; /*                                  */
        public const int CSTRJ_DESC_LEN = 200; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For USL Shipping                                                                      */
        /*----------------------------------------------------------------------------------------*/
        public const int LCM_PS_HEIGHT_LEN = 5 * LCM_PNL_CNT_LEN; /*                              */
        public const int LCM_RGB_DROP_HEIGHT_LEN = 4 * LCM_PNL_CNT_LEN; /*                              */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For CPILOICR                                                                          */
        /*----------------------------------------------------------------------------------------*/
        public const int CST_SPARE_LEN = 12; /*                                  */
        public const int PNL_SPARE_LEN = 12; /*                                  */
        public const int CF_PART_NO_LEN = 25; /*                                  */
        public const int TFT_PART_NO_LEN = 25; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For Archive                                                                           */
        /*----------------------------------------------------------------------------------------*/
        public const int ARH_TBL_NAME_LEN = 20; /*                                  */
        public const int ARH_LAST_KEY_LEN = 20; /*                                  */
        /*                                  */
        /*--- FOR WIPCTRL ------------------------------------------------------------------------*/
        public const int WIPCTRL_LEN = 7; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For RVST Defect Code                                                                  */
        /*----------------------------------------------------------------------------------------*/
        public const int DEFLAYER_ID_LEN = 11; /*                                  */
        public const int DEFTYPE_ID_LEN = 5; /*                                  */
        public const int DEFCODE_ID_LEN = 4; /*                                  */
        public const int DEFSHR_DESC_LEN = 8; /*                                  */
        public const int DEF_DESC_LEN = 30; /*                                  */
        public const int DEFJUDGE_ID_LEN = 1; /*                                  */
        public const int DEFN_ID_LEN = 5; /*                                  */
        public const int DEFL_ID_LEN = 5; /*                                  */
        public const int DEFSHAPE_ID_LEN = 5; /*                                  */
        public const int DEFCOL_ID_LEN = 10; /*                                  */
        public const int DEFSTYPE_ID_LEN = 5; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For RVST Recipe                                                                       */
        /*----------------------------------------------------------------------------------------*/
        public const int LENS_LEN = 3; /*                                  */
        public const int FILTERDEFECT_LEN = 5; /*                                  */
        public const int IMGNUM_X_LEN = 5; /*                                  */
        public const int PATTERNPATH_LEN = 70; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For Auto Feed Back                                                                    */
        /*----------------------------------------------------------------------------------------*/
        public const int AUTO_FEED_BACK_1_LEN = 1; /*                                  */
        public const int AUTO_FEED_BACK_4_LEN = 4; /*                                  */
        public const int AUTO_FEED_BACK_512_LEN = 512; /*                                  */
        public const int FILE_LOCATION_LEN = 80; /*                                  */
        public const int AUTO_FEED_BACK_60_LEN = 60; /*                                  */
        public const int AUTO_FEED_BACK_2_LEN = 2; /*                                  */
        public const int AUTO_FEED_BACK_3_LEN = 4; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*  For TCS                                                                               */
        /*----------------------------------------------------------------------------------------*/
        public const int BENDING_LEN = 3; /*                                  */
        public const int ALRT_CNT_SIZE = 2; /*                                  */
        public const int MAX_ALRT_CNT = 30; /*                                  */
        public const int CHAMB_ID_LEN = CHAMB_LEN; /*                                  */
        public const int CHAMB_STAT_LEN = EQPT_STAT_LEN; /*                                  */
        public const int TCS_RECP_PRM_NAME_LEN = 12; /*                                  */
        public const int TCS_RECP_PRM_VAL_LEN = 12; /*                                  */
        public const int TCS_RECP_PRM_CNT_LEN = 4; /*                                  */
        public const int TCS_SUB_RECP_CNT_LEN = 2; /*                                  */
        public const int MAX_TCS_RECP_PRM_CNT = 200; /*                                  */
        public const int MAX_TCS_SUB_RECP_CNT = 30; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*    For Self Check                                                                      */
        /*----------------------------------------------------------------------------------------*/
        public const int SELF_CHK_TIME_FOR_BTJOB = 10; /* Batch Job                        */
        public const int SELF_CHK_TIME_FOR_CNJOB = (24 * 60 + 1); /* Cron  Job (1day+1min)            */
        public const int TCS_BATCH_ID_LEN = 16; /* TCS BATCH ID LEN                 */
        public const int MS_LOT_CNT_CF4_LEN = 7; /*                                  */
        public const int MS_SHT_CNT_CF4_LEN = 7; /*                                  */
        public const int MS_CRR_CNT_CF4_LEN = 7; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*    For HASHTHS_D                                                                       */
        /*----------------------------------------------------------------------------------------*/
        public const int HST_NAME_LEN = 20; /* Host Name LEN                    */
        public const int CLT_NAME_LEN = 20; /* Client Name Len                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*    List page define                                                                    */
        /*----------------------------------------------------------------------------------------*/
        public const int PAGE_CNT_LEN = 4; /* Date count for one page          */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*   For ng_reson code length                                                             */
        /*----------------------------------------------------------------------------------------*/
        public const int NG_RSN_CODE_LEN = 6; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*   For APCEQPDA.h AEQPDA.h  length                                                      */
        /*----------------------------------------------------------------------------------------*/
        public const int EQPDA_QM_LENGTH = 20; /*                                  */
        public const int EQPDA_EDC_FLG = 3; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*   For arstconn.h                                                                       */
        /*----------------------------------------------------------------------------------------*/
        public const int RESET_TIME_LEN = 20; /*                                  */
        public const int TIME_INTERVAL_LEN = 4; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*                                                                                        */
        /*----------------------------------------------------------------------------------------*/
        public const int VERI_CODE_LEN = 12; /*                                  */
        public const int CUTMER_LEN = 12; /*                                  */
        public const int INIT_SERIAL_NO_LEN = 12; /*                                  */
        public const int JUDGE_CODE_LEN = 2; /*                                  */
        public const int MON_CHAR_LEN = 30; /*                                  */
        public const int SHORT_UNIT_ID_LEN = 2; /*                                  */
        public const int IN_SMP_CODE_LEN = 2; /*                                  */
        public const int OF_ANGLE_LEN = 20; /*                                  */
        public const int SHT_MT_ID_LEN = 20; /*                                  */
        public const int GROUP_SHT_SIZE_LEN = 4; /*                                  */
        public const int STB_SHT_CNT_LEN = 4; /*                                  */
        public const int WORDER_CNT_LEN = 4; /*                                  */
        public const int SHT_JUDGE_CNT_LEN = 4; /*                                  */
        public const int SMP_CNT_LEN = 2; /*                                  */
        public const int CRR_CHAR_LEN = 2; /*                                  */
        public const int DEFECT_REASON_LEN = 8; /*                                  */
        public const int FREQUENCY_LEN = 7; /*                                  */
        public const int DESCRIPTION_LEN = 20; /*                                  */
        public const int PR_PROCESSITEM_LEN = 2; /*                                  */
        public const int MATERIAL_NO_LEN = 18; /*                                  */
        public const int MATERIAL_NAME_LEN = 20; /*                                  */
        public const int PR_ID_LEN = 20; /*                                  */
        public const int WEIGHT_LEN = 12; /*                                  */
        public const int PR_DATETIME_LEN = 14; /*                                  */
        public const int PR_STAT_LEN = 4; /*                                  */
        public const int SORT_METHOD_LEN = 4; /*                                  */
        public const int SUPPORT_TYP_LEN = 4; /*                                  */
        public const int SORT_VER_LEN = 4; /*                                  */
        public const int SORT_SEQNO_LEN = 4; /*                                  */
        public const int SORT_DATA_LEN = 24; /*                                  */
        public const int MAX_WIP_DATA_LEN = 4; /*                                  */
        public const int WDG_INTERVAL_LEN = 4; /*                                  */
        public const int MAX_USE_CNT_LEN = 4; /*                                  */
        public const int MAX_USE_DAY_LEN = 4; /*                                  */
        public const int FORCE_CLN_LEN = 4; /*                                  */
        public const int XF_PRIORITY_LEN = 4; /*                                  */
        public const int SMP_WAIT_LEN = 4; /*                                  */
        public const int INSP_FUNCTION_LEN = 2; /*                                  */
        public const int ACTION_LEN = 4; /*                                  */
        public const int REASON_LEN = 8; /*                                  */
        public const int VCR_SHT_ID_LEN = 25; /*                                  */
        public const int SCP_FLG_LEN = 2; /*                                  */
        public const int CX_CODE_LEN = 3; /*                                  */
        public const int UNIQUE_ID_LEN = 16; /*                                  */
        public const int CHANGE_STAT_LEN = 10; /*                                  */
        public const int SAMP_CNT_LEN = 4; /*                                  */
        public const int SAMP_ITEM_LEN = 2; /*                                  */
        public const int GLASS_SIZE_LEN = 12; /*                                  */
        public const int INSPECTION_RESULT_LEN = 2; /*                                  */
        public const int CHG_AGV_MODE_LEN = 4; /*                                  */
        public const int ISSUE_ID_LEN = 12; /*                                  */
        public const int PAT_CNT_LEN = 2; /*                                  */
        public const int ECS_PROPERTYNO_LEN = 32; /*                                  */
        public const int ECS_STATUS_LEN = 32; /*                                  */
        public const int ECS_MASK_ID_LEN = 50; /*                                  */
        public const int ECS_PRODUCT_DSC_LEN = 32; /*                                  */
        public const int ECS_OPERATION_LEN = 32; /*                                  */
        public const int ECS_STAGE_LEN = 20; /*                                  */
        public const int ECS_COMMENT = 200; /*                                  */
        public const int ECS_USER_LEN = 20; /*                                  */
        public const int ECS_DATE_LEN = 32; /*                                  */
        public const int ECS_REV_LEN = 20; /*                                  */
        public const int ECS_EQPT_LEN = 32; /*                                  */
        public const int ECS_TYPE_LEN = 6; /*                                  */
        public const int ECS_STAUS_LEN = 32; /*                                  */
        public const int ECS_PARTID_LEN = 50; /*                                  */
        public const int ECS_LINE_ID_LEN = 10; /*                                  */
        public const int ECS_EQP_ID_LEN = 10; /*                                  */
        public const int ECS_PRINT_TYPE_LEN = 2; /*                                  */
        public const int WORK_CARD_VER_LEN = 10; /*                                  */
        public const int ECS_CR_LEN = 2; /*                                  */
        public const int USER_CR_LEN = 2; /*                                  */
        public const int NEW_CRR_ID_LEN = 64; /*                                  */
        public const int REASON_CODE_LEN = 4; /*                                  */
        public const int ERROR_DESCRIPTION = 128; /*                                  */
        public const int ALM_CASE_LEN = 4; /*                                  */
        public const int ALM_TYPE_LEN = 30; /*                                  */
        public const int ALM_INTERVAL_LEN = 4; /*                                  */
        public const int ALM_MODULE_LEN = 30; /*                                  */
        public const int E_MAIL_LEN = 50; /*                                  */
        public const int UAS_DB_NAME_LEN = 10; /* db name                          */
        public const int CERT_ID_LEN = 32;
        //A0.36	public const int UAS_DB_USER_LEN = 10; /* db user                          */
        public const int UAS_DB_USER_LEN = 18;           /* db user A0.36                    */
        public const int UAS_DB_PASSWD_LEN = 18;           /* db pwd  A0.36 added              */
        public const int SYSTEM_NAME_LEN = 24; /* subsystem name                   */
        public const int FAB_CODE_LEN = 4; /* Fab Code                         */
        public const int FUNC_CODE_LEN = 60; /* function code                    */
        public const int FUNC_NAME_LEN = 80; /* function name                    */
        public const int URL_LEN = 128; /* Web URL                          */
        public const int QC_NAME_LEN = 10; /* Queue Connection name            */
        public const int QC_HOST_LEN = 32; /* Queue Connection host name       */
        public const int QC_CNL_LEN = 10; /* Queue Connection channel         */
        public const int QC_USER_LEN = 10; /* Queue Connection user            */
        public const int QC_PWD_LEN = 8; /* Queue Connection password        */
        public const int QC_PORT_LEN = 5; /* Queue Connection port            */
        public const int UAS_DEPT_NAME_LEN = CODE_DSC_LEN; /*                                  */
        public const int ERP_UNIT_ID_LEN = 3; /* ERP Unit ID(for OQC)             */
        public const int CRR_NO_LEN = 60; /* ACHISMP                          */
        public const int MAX_PR_MASS_INPUT_CNT = 4; /* Mass Input 0000~9999             */
        public const int MAX_PR_PROCESSITEM_CNT = 1000; /* Max Inpot count 1000             */
        public const int MONTHLY_LEN = 6; /* PR Montly Length                 */
        public const int PR_DAY_LEN = 8; /*                                  */
        public const int PR_USE_LEN = 20; /*                                  */
        public const int PR_MONTH_LEN = 6; /*                                  */
        public const int PR_HOUR_LEN = 8; /*                                  */
        public const int PR_RESULT_LEN = 4; /*                                  */
        public const int SMP_SHT_CNT_LEN = 3; /*                                  */
        public const int SMP_CRR_CNT_LEN = 3; /*                                  */
        public const int JDG_CNT_LEN = 3; /*                                  */
        public const int QC_ID_LEN = 20; /*                                  */
        public const int SORT_VALUE_LEN = 4; /*                                  */
        public const int MAX_PARM_CNT = 1200; /*                                  */
        public const int MAX_PARM_CNT_SIZE = 4; /*                                  */
        public const int CLEAN_ST_LEN = 2; /*                                  */
        public const int INT_CODE_LEN = 5; /*                                  */
        public const int INSP_POS_LEN = 4; /*                                  */
        public const int INSP_AXIS_LEN = 8; /*                                  */
        public const int PARAMETER_LEN = 64; /*                                  */
        public const int AP_PATH_LEN = 64; /*                                  */
        public const int AP_DESC_LEN = 60; /*                                  */
        public const int M_DATE_LEN = 4; /*                                  */
        public const int ITEM_LEN = 2; /*                                  */
        public const int SORT_VER_DESC_LEN = 80; /*                                  */
        public const int PS_HEIGHT_VALUE_LEN = 2; /*                                  */
        public const int WH_DATA_LEN = 10; /*                                  */
        public const int ALM_ITEM_SEQNO_LEN = 30; /*                                  */
        public const int ALM_ITEM_MODULE_LEN = 30; /*                                  */
        public const int ALM_ITEM_TYPE_LEN = 30; /*                                  */
        public const int ALM_ITEM_ALARMTIME_LEN = 30; /*                                  */
        public const int ALM_ITEM_CREATETYPE_LEN = 30; /*                                  */
        public const int ALM_ITEM_ALMSG1_LEN = 4000; /*                                  */
        public const int ALM_ITEM_ALMSG2_LEN = 4000; /*                                  */
        public const int ALM_ITEM_FLAG_LEN = 1; /*                                  */
        public const int ALM_ITEM_USERID_LEN = 30; /*                                  */
        public const int ALM_ITEM_UPDATETIME_LEN = 30; /*                                  */
        public const int FILE_NAME_LEN = 40; /*                                  */
        public const int COM_LONG_LEN = 12; /*                                  */
        public const int REWK_TYP_LEN = 6; /*                                  */
        public const int LOWYIELD_QTY_LEN = 4; /*                                  */
        public const int LOWYIELD_INTERVAL_LEN = 8; /*                                  */
        public const int LOWYIELD_RATE_LEN = 2; /*                                  */
        public const int PLANTNO_LEN = 2; /*                                  */
        public const int UNIT_LEN = 20; /*                                  */
        public const int CHECK_VALUE_LEN = 100; /*                                  */
        public const int QA_QAPAPERNO_LEN = 20; /*                                  */
        public const int QA_LOTOWNER_LEN = 10; /*                                  */
        public const int QA_STATUS_LEN = 15; /*                                  */
        public const int QA_CREATER_LEN = 10; /*                                  */
        public const int QA_CDT_LEN = DATE_LEN; /*                                  */
        public const int QA_REVISER_LEN = 2; /*                                  */
        public const int QA_UDT_LEN = DATE_LEN; /*                                  */
        public const int QA_CHECKER_LEN = 10; /*                                  */
        public const int QA_CHECKDT_LEN = DATE_LEN; /*                                  */
        public const int QA_CROSS_QAPAPERNO_LEN = 100; /*                                  */
        public const int QA_MENO_LEN = 200; /*                                  */
        public const int QA_QCIDDESC_LEN = 150; /*                                  */
        public const int QA_PATCHECKER_LEN = 10; /*                                  */
        public const int QA_PATCHECKDT_LEN = DATE_LEN; /*                                  */
        public const int QA_CUSTOMERNO_LEN = 10; /*                                  */
        public const int QA_CUST_DEPART_LEN = 20; /*                                  */
        public const int QA_CUST_CONTACT_EMP_LEN = 10; /*                                  */
        public const int QA_CUST_CONTACT_TEL_LEN = 10; /*                                  */
        public const int QA_AMTC_DEPART_LEN = 20; /*                                  */
        public const int QA_AMTC_CONTACT_EMPID_LEN = 10; /*                                  */
        public const int QA_AMTC_CONTACT_EMP_LEN = 10; /*                                  */
        public const int QA_AMTC_CONTACT_TEL_LEN = 10; /*                                  */
        public const int IMAGE_FILE_LEN = 100; /*                                  */
        public const int CUTMER_CODE_LEN = 2; /*                                  */
        public const int DEFT_GRADE_LEN = 4; /*                                  */
        public const int REGEN_CNT_LEN = 2; /*                                  */
        public const int USR_DEF_DAY_LEN = 31; /*                                  */
        public const int USR_DEF_SERIAL_LEN = 70; /*                                  */
        public const int SERIAL_INIT_NO_LEN = 2; /*                                  */
        public const int CHARG_LEN = 10; /*                                  */
        public const int BWART_LEN = 3; /*                                  */
        public const int GAMNG_LEN = 12; /*                                  */
        public const int MEINS_LEN = 3; /*                                  */
        public const int ARBPL_LEN = 25; /*                                  */
        public const int AUFNR_LEN = 16; /*                                  */
        public const int TRANDAT_LEN = 8; /*                                  */
        public const int TRANTIM_LEN = 6; /*                                  */
        public const int PODAT_LEN = 8; /*                                  */
        public const int POTIM_LEN = 6; /*                                  */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*           For pqcspcck.h(SPC)                                                          */
        /*----------------------------------------------------------------------------------------*/
        /*------ Common --------------------------------------------------------------------------*/
        public const int AIX_PID_LEN = 10; /* R6 AIX PID                       */
        public const int PQM_MAX_ITEM_CNT = MAX_MESR_CNT; /*                                  */
        public const int PQM_MAX_ITEM_LEN = 4; /*                                  */
        public const int PQM_MAX_CHAMBERU_LEN = 9; /*                                  */
        public const int PQM_RESRV_AREA_LEN = 20; /*                                  */
        public const int PQM_CHECK_PRE_CNT = 15; /*                                  */
        public const int PQM_MAXPOINT_LEN = 4; /*                                  */
        public const int PQM_MAXCHART_LEN = 2; /*                                  */
        public const int PQM_CHART_CATE_LEN = 2; /*                                  */
        public const int PQM_ELEMENT_SEQ_LEN = 2; /*                                  */
        public const int PQM_FONTTYPE_LEN = 32; /*                                  */
        public const int PQM_LINETYPE_LEN = 32; /*                                  */
        public const int PQM_CTRLPLN_LEN = 32; /*                                  */
        public const int PQM_NUM_LEN = 6; /*                                  */
        public const int PQM_VERSION_LEN = 5; /*                                  */
        public const int PQM_TYPE_LEN = 2; /*                                  */
        public const int PQM_TYPE_STR_LEN = 16; /*                                  */
        public const int PQM_TYPE_SET_LEN = 16; /*                                  */
        public const int PQM_ARY_LEN = 4; /*                                  */
        public const int PQM_OPTION_LEN = 32; /*                                  */
        public const int PQM_NAME_LEN = 16; /*                                  */
        public const int PQM_GNAME_LEN = 10; /*                                  */
        public const int PQM_HOLD_ACTION_LEN = 20;           /*                           A0.29  */
        public const int PQM_DESC_128_LEN = 128;           /*                           A0.29  */
        public const int PQM_AREA_ID_LEN = 64;           /*                           A0.29  */
        public const int PQM_REASON_ID_LEN = 64;           /*                           A0.29  */
        public const int PQM_ACTION_ID_LEN = 64;           /*                           A0.29  */
        public const int PQM_ACTION_DESC_LEN = 64;           /*                           A0.29  */
        public const int PQM_FIXTURE_ID_LEN = 64;           /* Fixture id                A0.29  */
        public const int PQM_SPEC_RC_LEN = 2;           /*                           A0.29  */
        public const int PQM_MSG_128_LEN = 128;           /*                           A0.29  */
        public const int PQM_CNAME_LEN = 8; /*                                  */
        public const int PQM_DESC_LEN = 64; /*                                  */
        public const int PQM_TITLE_LEN = 64; /*                                  */
        public const int PQM_LOG_LEN = 128; /*                                  */
        public const int PQM_MEMO_LEN = 254; /*                                  */
        public const int PQM_COM_LEN = 80; /*                                  */
        public const int PQM_MSG_LEN = 64; /*                                  */
        public const int PQM_MC_SUB_INFO_LEN = 699; /*                                  */
        public const int PQM_MAIL_ADDR_LEN = 64; /*                                  */
        public const int PQM_RULE_LEN = 30; /*                                  */
        public const int PQM_RULE1_LEN = 10; /*                                  */
        public const int PQM_RULE2_LEN = 20; /*                                  */
        public const int PQM_RULE_RESULT_LEN = 20; /*                                  */
        public const int PQM_ACTION_LEN = 5; /*                                  */
        public const int PQM_SPEC_ACTION_LEN = 2; /*                                  */
        public const int PQM_ALARM_NODE_LEN = 8; /*                                  */
        public const int PQM_RULE_MOD_LEN = 3; /*                                  */
        public const int PQM_ITEM_SEQ_LEN = 2; /*                                  */
        public const int PQM_FIELD_NAME_LEN = 32; /*                                  */
        public const int PQM_FIELD_VALUE_LEN = 32; /*                                  */
        public const int PQM_RPT_SEQ_LEN = 2; /*                                  */
        public const int PQM_TX_SEQ_LEN = 4; /*                                  */
        public const int PQM_CHECK_GROUP_LEN = 2; /*                                  */
        public const int PQM_OCAP_ID_LEN = 12; /*                                  */
        public const int PQM_OCAP_DESC_LEN = 64; /*                                  */
        public const int PQM_OCAP_NM_LEN = 16; /*                                  */
        public const int PQM_IQCNUN_LEN = 10; /*                                  */
        public const int PQM_IQCINFO_LEN = 16; /*                                  */
        public const int PQM_IQCITEM_SEQ_LEN = 2; /*                                  */
        public const int PQM_IQCNAME_LEN = 16; /*                                  */
        public const int PQM_MATERIAL_ID_LEN = 32; /*                                  */
        public const int PQM_IQCPLAN_LEN = 4; /*                                  */
        public const int PQM_BILLNO_LEN = 16; /*                                  */
        public const int PQM_QCRESULT_LEN = 16; /*                                  */
        public const int PQM_IQCINSP_LEN = 3; /*                                  */
        public const int PQM_FUNGRP_LEN = 12; /*                                  */
        public const int PQM_FUNCTION_LEN = 8; /*                                  */
        public const int PQM_USERNAME_LEN = 16; /*                                  */
        public const int PQM_PASSWORD_LEN = 12; /*                                  */
        public const int PQM_UNIT_LEN = 16; /*                                  */
        public const int PQM_CAUSEID_LEN = 16; /*                                  */
        public const int PQM_ACTIONID_LEN = 16; /*                                  */
        public const int PQM_DEFECTID_LEN = 16; /*                                  */
        public const int PQM_DEFITEM_LEN = 16; /*                                  */
        public const int PQM_LEVELID_LEN = 16; /*                                  */
        public const int PQM_LEVITEM_LEN = 16; /*                                  */
        public const int PQM_PNLGRP_LEN = 16; /*                                  */
        public const int PQM_PNLGRP_NM_LEN = 32; /*                                  */
        public const int PQM_CUST_LEN = 16; /*                                  */
        public const int PQM_CUST_NM_LEN = 32; /*                                  */
        public const int PQM_MC_NAME_LEN = 16; /*                                  */
        public const int PQM_MYFAVOR_NM_LEN = 32; /*                                  */
        public const int PQM_AREA_DESC_LEN = 64; /* Area Description                 */
        public const int PQM_REASON_DESC_LEN = 64; /* Reason Description               */
        public const int PQM_REVS_1_LEN = 40; /* Reserved Filed 1                 */
        public const int PQM_REVS_2_LEN = 40; /* Reserved Filed 2                 */
        public const int PQM_SHEET_NO_LEN = 100; /* Sheet No                         */
        public const int PQM_FQRULE_ID_LEN = 16; /*                                  */
        public const int PQM_FQSCORE_LEN = 4; /*                                  */
        public const int PQM_FQINSP_ITEM_LEN = 4; /*                                  */
        public const int PQM_EH_CNT_LEN = 3; /*                                  */
        public const int PQM_FQINSP_NM_LEN = 32; /*                                  */
        public const int PQM_FQINSP_ABRE_LEN = 8; /*                                  */
        public const int PQM_FQITEM_NO_LEN = 3; /*                                  */
        public const int PQM_FQITEM_NM_LEN = 64; /*                                  */
        //A0.11  #define    BIN_ID_LEN                     8           /*                            A0.06 */
        public const int BIN_ID_LEN = 25; /*                            A0.11 */
        public const int JUDGE_RULE_ID_LEN = 8; /*                            A0.06 */
        public const int LOGISTICS_LEN = 20; /*                            A0.06 */
        public const int OQC_BATCH_ID_LEN = 26; /*                            A0.06 */
        public const int DEFECT_CODE_LEN = 8; /*                            A0.06 */
        public const int OQC_BATCH_QTY_LEN = 5; /*                            A0.08 */
        public const int OQC_SMP_CNT_LEN = 3; /*                            A0.08 */
        public const int JUDGE_CODE_8_LEN = 8; /*                            A0.11 */
        public const int SGR_ID_11_SIL_POS = 11; /*                            A0.12 */
        public const int SGR_ID_SIL_1_LEN = 1; /*                            A0.12 */
        public const int PAK_ID_10_POS = 10; /*                            A0.13 */
        public const int PAK_ID_3_LEN = 3; /*                            A0.13 */
        public const int PAK_ID_LEN = 13; /*                            A0.13 */
        /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*                                                                                        */
        /*----------------------------------------------------------------------------------------*/
        //A0.11  #define    BOM_ID_LEN                     8           /*                                  */
        public const int BOM_ID_LEN = 25; /*                            A0.11 */
        public const int BOM_DSC_LEN = CODE_DSC_LEN; /*                                  */
        /*----------------------------------------------------------------------------------------*/
        /*                                                                                        */
        /*----------------------------------------------------------------------------------------*/
        public const int AQL_SEQ_NO_LEN = 4; /*                                  */
        public const int PNL_QTY_LEN = 5; /*                                  */
        public const int SMP_QTY_LEN = 5; /*                                  */
        public const int ACCEPT_QTY_LEN = 5; /*                                  */
        public const int AQL_LVL_LEN = 5; /*                                  */
        public const int PPBOX_STAT_LEN = 4; /*                            A0.15 */
        public const int TACT_TIME_LEN = 4; /*                            A0.16 */
        public const int NOTE_LEN = 500;   /*                 A0.32*/


        /******************************************************************************************/
        /*   End of File                                                                          */
        /******************************************************************************************/

    }
}
