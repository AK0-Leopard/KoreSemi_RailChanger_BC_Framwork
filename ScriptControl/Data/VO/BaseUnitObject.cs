//*********************************************************************************
//      BaseUnitObject.cs
//*********************************************************************************
// File Name: BaseUnitObject.cs
// Description: BaseUnitObject類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2014/02/19    Hayes Chen     N/A            N/A     Initial Release
// 2014/03/28    Hayes Chen     N/A            A0.01   Add Sheet List
// 2014/04/23    Hayes Chen     N/A            A0.02   目前不必詳細紀錄到玻璃在哪一個Unit
// 2014/04/24    Miles Chen     N/A            A0.03   Change AlarmHisQueue to AlarmHisList
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Data.VO;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public abstract class BaseUnitObject : BaseEQObject, IAlarmHisList //A0.02, ISheetList //A0.03
    {
        //private AlarmHisQueue alarmHisQueue = new AlarmHisQueue(); //A0.03
        //public virtual AlarmHisQueue AlarmHisQueue { get { return alarmHisQueue; } } //A0.03

        private AlarmHisList alarmHisList = new AlarmHisList();
        public virtual AlarmHisList AlarmHisList { get { return alarmHisList; } }

//A0.02        private SheetList sheetList = new SheetList();                      //A0.01       
//A0.02        public virtual SheetList SheetList { get { return sheetList; } }    //A0.01

        /// <summary>
        /// 放入Alarm至Queue中
        /// </summary>
        /// <param name="alarm"></param>
        /*public virtual void putAlarmHis(Alarm alarm) //A0.03
        {
            alarmHisQueue.putAlarmHis(alarm);
        }*/
        public virtual void resetAlarmHis(List<Alarm> AlarmHisList)
        {
            alarmHisList.resetAlarmHis(AlarmHisList);
        }
        
//A0.02 Begin        public virtual void clearAllSheet()
        //{
        //    sheetList.clearAllSheet();
        //}

        //public virtual void addSheet(Sheet sheet)
        //{
        //    sheetList.addSheet(sheet);
        //}

        //public virtual void addSheets(List<Sheet> sheets) 
        //{
        //    sheetList.addSheets(sheets);
        //}

        //public virtual bool removeSheetByID(string sheet_id)
        //{
        //    return sheetList.removeSheetByID(sheet_id);
//A0.02 End        }
    }
}
