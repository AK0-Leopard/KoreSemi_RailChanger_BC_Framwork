//*********************************************************************************
//      CassetteLoader.cs
//*********************************************************************************
// File Name: CassetteLoader.cs
// Description: Cassette Loader類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/23    Steven Hong    N/A            A0.01   移除Cassette，將Cassette資料儲存於Carrier中
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class CassetteLoader : PropertyChangedVO
    {
        //A0.01 Start
        //private Cassette cassetteItem = new Cassette();
        //public virtual Cassette CassetteItem 
        //{
        //    get { return cassetteItem; }
        //}

        //public void loadCassette(Cassette cassette) 
        //{
        //    BCFUtility.setValueToPropety(ref cassette, ref cassetteItem);
        //    OnPropertyChanged(BCFUtility.getPropertyName(() => this.CassetteItem));
        //}
        //A0.01 End

        public void unloadCassette() 
        {

        }





    }

    public interface ICassetteLoader
    {
        //A0.01 void loadCassette(Cassette cassette);
        void unloadCassette();
    }

}
