using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;

namespace gemoDream
{
    /// <summary>
    /// Library of functions for ClarityForm, ColorForm and MeasureForm
    /// </summary>
    public class GraderLib
    {
        // Code format
        //private static int[] CODE_FORMAT = new int[3] {5,5,3};
        private static int[] CODE_FORMAT = new int[3] { 5, 3, 2 };
        private static int[] NEW_CODE_FORMAT = new int[3] { 6, 3, 2 };
		//private static int[] 12_DIGIT_FORMAT = new int[3] { 7, 3, 2 };
		// first dot position in the code
		private static int DOT1 = CODE_FORMAT[0];
        private static int NEW_DOT1 = NEW_CODE_FORMAT[0];
        // second dot position in the code
        private static int DOT2 = CODE_FORMAT[0] + CODE_FORMAT[1];
        private static int NEW_DOT2 = NEW_CODE_FORMAT[0] + NEW_CODE_FORMAT[1];
        // third dot position in the code
        private static int DOT3 = CODE_FORMAT[0] + CODE_FORMAT[1] + CODE_FORMAT[2];
        private static int NEW_DOT3 = NEW_CODE_FORMAT[0] + NEW_CODE_FORMAT[1] + NEW_CODE_FORMAT[2];

        // Batch code length
        //public const int BATCH_CODE = 15;
        public const int BATCH_CODE = 8;
        public const int NEW_BATCH_CODE = 9;

        // Item code length
        //public const int ITEM_CODE = 18;
        public const int ITEM_CODE = 10;
        public const int NEW_ITEM_CODE = 11;
		public const int CID_CODE = 7;

        // characteristic type info

        private const int DOC_ITEM_CODE = 11;
        private static int[] DOC_ITEM_CODE_FORMAT = { 1, 5, 3, 2 };
        private static int ITEM_DOT1 = DOC_ITEM_CODE_FORMAT[0];
        private static int ITEM_DOT2 = DOC_ITEM_CODE_FORMAT[0] + DOC_ITEM_CODE_FORMAT[1];
        private static int ITEM_DOT3 = DOC_ITEM_CODE_FORMAT[0] + DOC_ITEM_CODE_FORMAT[1] + DOC_ITEM_CODE_FORMAT[2];
        private const int DOC_BATCH_CODE = 9;
        private static int[] DOC_BATCH_CODE_FORMAT = { 1, 5, 3 };
        private static int BATCH_DOT1 = DOC_BATCH_CODE_FORMAT[0];
        private static int BATCH_DOT2 = DOC_BATCH_CODE_FORMAT[0] + DOC_BATCH_CODE_FORMAT[1];
        private const int DOC_ORDER_CODE = 6;
        private static int[] DOC_ORDER_CODE_FORMAT = { 1, 5 };
        private static int ORDER_DOT1 = DOC_ORDER_CODE_FORMAT[0];

        private static int[] ITEM_CODE_FORMAT = { 5, 5, 3, 2 };
        private static int[] NEW_ITEM_CODE_FORMAT = { 6, 6, 3, 2 };

        public struct TypeInfo
        {
            public int iCharCode;
            public string sCharType;
            public int iMinDotDigits;
            public int iMaxDotDigits;
        }//;

        public struct Sp
        {
            public const string BatchesStruct = "BatchByCodeTypeEx";
            public const string BatchEventsStruct = "BatchEventsTypeEx";
            public const string BatchEventUpdate = "BatchEvents";
            public const string Batches = "BatchByCode";
            public const string ItemsStruct = "ItemByCodeTypeEx";
            //public const string Items = "ItemByCode";
            public const string Items = "ItemCPPictureByCode";
            public const string PartsStruct = "ItemTypeTypeEx";
            public const string Parts = "PartsByItemType";
            //public const string PartsStruct = "PartsByItemTypeAndBatchTypeOf";
            //public const string Parts = "PartsByItemTypeAndBatch";
            public const string MeasuresStruct = "ItemMeasuresByViewAccessAndCPTypeEx"; //ItemMeasuresByViewAccess&CPTypeEx
            public const string Measures = "ItemMeasuresByViewAccessAndCP"; //ItemMeasuresByViewAccess 
            public const string FullMeasuresStruct = "ItemMeasuresByViewAccessTypeEx";
            public const string FullMeasures = "ItemMeasuresByViewAccessNoCP"; //ItemMeasuresByViewAccess  
            public const string CurrentRecheckStruct = "CurrentRecheckSessionTypeEx";
            public const string CurrentRecheck = "CurrentRecheckSession";
            public const string PartValuesStruct = "PartValueCCMTypeEx";
            public const string UpdatePartValuesStruct = "PartValueTypeOf";
            public const string PartValues = "PartValueCCM";
            public const string PartValuesFull = "PartValueByViewAccessCode";
            public const string MeasureValues = "MeasureValues";
        }

        public struct Codes
        {
            public const int Color = 5;
            public const int Clarity = 4;
            public const int Measure = 6;
            public const int Itemizing = 2;
            public const int AccRep = 8;
            public const int LaserInscription = 67;
            public const int Shape = 8;
        }
        public struct ItemState
        {
            public const int Invalid = 3;
            public const int Valid = 2;
            public const int Closed = 1;
        }
        public enum OrderTreeSet
        {
            OrderBatchIemDoc,
            OrderMemoBatchItemDoc
        };

        public struct BatchEvents
        {
            public const int Opened = 1;
            public const int Updated = 2;
            public const int Touched = 3;
            public const int Closed = 4;
            public const int Created = 5;
            public const int EndSession = 6;
            public const int Billed = 7;
            public const int TakeOut = 8;
            public const int ShipOut = 9;
            public const int AddReport = 10;
            public const int Printed = 11;
            public const int ReadyForDelivery = 19;
            public const int CreatedFromOldNumbers = 20;
        }

        public enum WorkMode
        {
            ChoosingMode, NextEnteringCode, NextNotEnteringCode, GradeEnteringCharacteristic,
            GradeEnteringStringValue, GradeEnteringIntegerValue, GradeEnteringEnumValue,
            Comment, LaserInscription
        };
        public const string Grade = "grade";
        public const string Comment = "comment";
        public const string LaserInscription = "li";
        public const string NextItem = "next";

        /// <summary>
        /// Checks wether part from the current item is worked up
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="sPartName">part name</param>
        /// <returns>true if part is worked up and false otherwise</returns>
        public static bool IsPartWorkedUp(DataSet dsBatchSet,
                                            int iOrderCode,
                                            int iEntryBatchCode,
                                            int iBatchCode,
                                            int iItemCode,
                                            int iPartId,
                                            bool bIsManual)
        {
            int iCharId, iCharCode;
            //bool bIsAllEmpty = true;
            //bool bIsAllFull = true;

            //DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);
            DataView dvVals = new DataView(dsBatchSet.Tables["tblValues"]);

            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartName='"+sPartName+"'";
            //foreach(DataRowView drPartRow in dvParts)
            //{
            //	iPartId = Convert.ToInt32(drPartRow["PartId"]);
            dvChars.RowFilter = "PartId=" + iPartId + " and ItemCode=" + iItemCode;
            foreach (DataRowView drCharRow in dvChars)
            {
                if (Convert.ToInt32(drCharRow["IsEdit"]) == 0)
                    continue;

                iCharId = Convert.ToInt32(drCharRow["CharId"]);
                iCharCode = Convert.ToInt32(drCharRow["CharCode"]);
                dvVals.RowFilter = "MeasureID=" + iCharId + " and PartId=" + iPartId + " and ItemCode=" + iItemCode;
                foreach (DataRowView drValsRow in dvVals)
                {
                    if (Convert.IsDBNull(drValsRow["ValueId"]) && Convert.IsDBNull(drValsRow["Value"]) &&
                        Convert.IsDBNull(drValsRow["StringValue"]) && iCharCode != Codes.LaserInscription)
                    {
                        //bIsAllFull = false;

                        //if(bIsManual)
                        //	continue;

                        return false;
                    }
                    //if(iCharCode != Codes.LaserInscription)
                    //	bIsAllEmpty = false;
                }
            }
            //}
            return true;
        }

        /// <summary>
        /// Checks wether item from the batch is worked up
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <returns>true if item is worked up and false otherwise</returns>
        public static bool IsItemWorkedUp(DataSet dsBatchSet,
                                            int iOrderCode,
                                            int iEntryBatchCode,
                                            int iBatchCode,
                                            int iItemCode,
                                            bool bIsManual)
        {
            if (dsBatchSet == null)
                return false;

            int iPartId;
            //string sPartName;
            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            dvParts.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iItemCode;
            if (dvParts.Count == 0)
                return false;

            //if(IsItemBlocked(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode))
            //	return true;

            foreach (DataRowView drvPart in dvParts)
            {
                //sPartName = Convert.ToString(drvPart["PartName"]);
                iPartId = Convert.ToInt32(drvPart["PartId"]);
                if (!IsPartWorkedUp(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, iPartId, bIsManual))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks wether batch is worked up
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <returns>true if batch is worked up and false otherwise</returns>
        public static bool IsBatchWorkedUp(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, bool bIsManual)
        {
            if (dsBatchSet == null)
                return false;

            bool bIsItemWorkedUp, bIsItemBlocked;
            int iItemCode;
            DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
            dvItems.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode =" + iEntryBatchCode + " and BatchCode=" + iBatchCode;
            foreach (DataRowView drvItem in dvItems)
            {
                iItemCode = Convert.ToInt32(drvItem["ItemCode"]);
                bIsItemWorkedUp = IsItemWorkedUp(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, bIsManual);
                bIsItemBlocked = IsItemBlocked(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode);
                if (!bIsItemWorkedUp && bIsItemBlocked)
                    continue;
                if (!bIsItemWorkedUp)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks wether entered code is current batch code
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entry batch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="rbNextItem">rbNextItem rdio button</param>
        /// <param name="iUser">form user</param>
        /// <returns>true if item belongs to the batch and false otherwise</returns>
        public static bool IsCurrentBatch(ref DataSet dsBatchSet,
                                            int iOrderCode,
                                            int iEntryBatchCode,
                                            int iBatchCode,
                                            int iItemCode,
                                            ref RadioButton rbNextItem,
                                            int iUser,
                                            int iFormType)
        {
            //foreach(DataRow drRow in dsBatchSet.Tables["tblItems"].Rows)
            DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
            dvItems.RowFilter = "OrderCode=" + iOrderCode + " and BatchCode=" + iBatchCode + " and ItemCode =" + iItemCode;

            if (dvItems.Count > 0) return true;

            /* Old Part
            if(dsBatchSet.Tables["tblItems"].Rows.Count > 0)
            {
                if(Convert.ToInt32(dsBatchSet.Tables["tblItems"].Rows[0]["BatchCode"]) == iBatchCode
                    && Convert.ToInt32(dsBatchSet.Tables["tblItems"].Rows[0]["OrderCode"]) == iOrderCode)
                    return true;
            }
            //End Of Old Part
            */

            if (iUser == Client.Grader)
            {
                rbNextItem.Checked = true;
                throw new Exception("You entered wrong batch code. Enter another, please");
            }

            if (iFormType == Codes.Color)
                Service.UpdateColorBatchInfo(dsBatchSet);
            if (iFormType == Codes.Clarity)
                Service.UpdateClarityBatchInfo(dsBatchSet);
            if (iFormType == Codes.Measure)
                Service.UpdateMeasureBatchInfo(dsBatchSet);

            dsBatchSet = null;

            return false;
        }

        /// <summary>
        /// Checks wether entered item belongs to the batch
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="rbNextItem">rbNextItem rdio button</param>
        /// <param name="iUser">form user</param>
        /// <returns>true if item belongs to the batch and false otherwise</returns>
        public static bool IsBatchItem(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, ref RadioButton rbNextItem, int iUser)
        {
            if (dsBatchSet != null)
            {
                DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                //DataView dvOldItems = new DataView(dsBatchSet.Tables["tblItems"]);
                dvItems.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iItemCode;
                //dvOldItems.RowFilter = "PrevGroupCode="+iOrderCode+" and PrevBatchCode="+iBatchCode+" and PrevItemCode="+iItemCode;

                if (dvItems.Count > 0) return true;

                //			foreach(DataRow drRow in dsBatchSet.Tables["tblItems"].Rows)
                //					if(Convert.ToInt32(drRow["ItemCode"]) == iItemCode)
                //					return true;

                //if(dvOldItems.Count > 0)  return true;
            }
            rbNextItem.Checked = true;
            throw new Exception("There is no item in the batch with entered code. Enter another item code, please");
        }

        /// <summary>
        /// Checks wether item from the batch is blocked
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="rbNextItem">rbNextItem radio button</param>
        /// <returns>true if item is blocked and false otherwise</returns>
        public static bool IsItemBlocked(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, ref RadioButton rbNextItem)
        {
            DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
            dvItems.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iItemCode;

            if (Convert.ToInt32(dvItems[0]["IsBlock"]) == ItemState.Invalid)
            {
                rbNextItem.Checked = true;
                throw new Exception("This item is blocked. Enter another item code, please");
            }

            return false;

            //return true;
            //rbNextItem.Checked = true;
            //throw new Exception("This item is blocked. Enter another item code, please");
        }

        /// <summary>
        /// Checks wether item from the batch is blocked
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <returns>true if item is blocked and false otherwise</returns>
        public static bool IsItemBlocked(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode)
        {
            DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
            dvItems.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iItemCode;

            if (Convert.ToInt32(dvItems[0]["IsBlock"]) == 1)
                return true;

            return false;

            //return true;
        }

        /// <summary>
        /// Finds out wether entered key is end or not
        /// </summary>
        /// <param name="cPressedKeys">entered chars</param>
        /// <param name="sFileName">file name</param>
        /// <returns>true if entered key is end and false otherwise</returns>
        public static bool IsEndKey(char[] cPressedKeys, string sFileName)
        {
            try
            {
                int i;
                string sXPath = "/keyboard/map/itemtype/";

                for (i = 0; i < cPressedKeys.Length - 1; i++)
                    sXPath += cPressedKeys[i] + "/nextavailable/";
                sXPath += cPressedKeys[i];

                XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);

                if (xnlNodeList[0].Attributes.GetNamedItem("end").Value == "yes")
                    return true;
                else
                    return false;
            }
            catch (Exception eEx)
            {
                throw new Exception("Couldn't get characteristic value code\r\n" + eEx.Message);
            }
        }

        /// <summary>
        /// Finds out wether entered keys is available and end
        /// </summary>
        /// <param name="cPressedKeys">entered keys</param>
        /// <param name="sFileName">file name</param>
        /// <returns>true if end and false otherwise</returns>
        public static bool IsAvailableEndModeKey(char[] cPressedKeys, string sFileName)
        {
            string sXPath = CreateModeXPath(cPressedKeys, false, "key");
            XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);
            bool bEndKey = IsEndModeKey(cPressedKeys, sFileName);
            if (!bEndKey && xnlNodeList.Count == 0)
                throw new Exception("'" + cPressedKeys[cPressedKeys.Length - 1] + "' is not available.\nTry to enter another character to choose mode");

            return bEndKey;
        }

        /// <summary>
        /// Finds out wether entered keys is available for current part
        /// </summary>
        /// <param name="cPressedKeys">entered keys</param>
        /// <param name="iPartCharCodes">part characteristic codes</param>
        /// <param name="sFileName">file name</param>
        /// <param name="bIsFinish">indicates wether pressed key is end</param>
        /// <param name="bIsValue">indicates wether pressed key is value</param>
        /// <returns>true if available and false otherwise</returns>
        public static bool IsAvailableEndKey(char[] cPressedKeys, int[] iPartCharCodes, string sFileName, bool bIsValue)
        {
            string sXPath = CreateFilteredCharXPath(cPressedKeys, iPartCharCodes, false, bIsValue, "key");

            XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);
            bool bEndKey = IsEndCharKey(cPressedKeys, iPartCharCodes, sFileName, bIsValue);
            if (!bEndKey && xnlNodeList.Count == 0)
                throw new Exception("'" + cPressedKeys[cPressedKeys.Length - 1] + "' is not available for current part characteristic");

            return bEndKey;
        }

        /// <summary>
        /// Finds out wether entered key is end for characteristic or not
        /// </summary>
        /// <param name="cPressedKeys">entered chars</param>
        /// <param name="iPartCharCodes">part characteristic codes</param>
        /// <param name="sFileName">file name</param>
        /// <param name="bIsValue">indicates wether entered char is value</param>
        /// <returns>true if entered key is end and false otherwise</returns>
        public static bool IsEndCharKey(char[] cPressedKeys, int[] iPartCharCodes, string sFileName, bool bIsValue)
        {
            string sXPath = CreateFilteredCharXPath(cPressedKeys, iPartCharCodes, true, bIsValue, "key");
            XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);
            if (xnlNodeList.Count > 0)
                if (!xnlNodeList[0].HasChildNodes)
                    return true;

            return false;
        }
        /// <summary>
        /// Finds out wether entered key is end for characteristic or not
        /// </summary>
        /// <param name="cPressedKeys">entered chars</param>
        /// <param name="iPartCharCodes">part characteristic codes</param>
        /// <param name="sFileName">file name</param>
        /// <param name="bIsValue">indicates wether entered char is value</param>
        /// <returns>true if entered key is end and false otherwise</returns>
        public static bool IsEndModeKey(char[] cPressedKeys, string sFileName)
        {
            string sXPath = CreateModeXPath(cPressedKeys, true, "key");
            XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);
            if (xnlNodeList.Count > 0)
                if (!xnlNodeList[0].HasChildNodes)
                    return true;

            return false;
        }

        /// <summary>
        /// Finds out wether pressed key is char
        /// </summary>
        /// <param name="iKeyCode">key code</param>
        /// <returns>true if pressed key is char and false otherwise</returns>
        public static bool IsChar(int iKeyCode)
        {
            if (iKeyCode == 13)// enter
                return false;
            if (iKeyCode == 27)// escape
                return false;

            return true;
        }


        /// <summary>
        /// Parses entered code
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param> 
        /// <returns>full entered code</returns>
        public static void ParseCode(DataSet dsBatchSet, /*TextBox*/string sNextItem, ref int iOrderCode, ref int iEntryBatchCode, ref int iBatchCode, ref int iItemCode, ref string sOldNumber)
        {
			//{
			//    sNextItem = Service.GetItemNumberBy7digit(sNextItem);
			//}

			switch (sNextItem.Length)
            {
                /*case ITEM_CODE:
                    iOrderCode = Convert.ToInt32(sNextItem.Substring(0,5));
                    iEntryBatchCode = Convert.ToInt32(sNextItem.Substring(6,5));
                    iBatchCode = Convert.ToInt32(sNextItem.Substring(12,3));
                    iItemCode = Convert.ToInt32(sNextItem.Substring(16,2));
                    if(sNextItem.Substring(DOT1,1)!="." || sNextItem.Substring(DOT2,1)!="." || sNextItem.Substring(DOT3,1)!=".")
                        throw new Exception("Incorrect separators. Enter another item code, please");
                    return;*/

                case ITEM_CODE:
                    iOrderCode = Convert.ToInt32(sNextItem.Substring(0, DOT1));
                    iEntryBatchCode = Convert.ToInt32(sNextItem.Substring(0, DOT1));
                    iBatchCode = Convert.ToInt32(sNextItem.Substring(DOT1, DOT2 - DOT1));
                    iItemCode = Convert.ToInt32(sNextItem.Substring(DOT2, DOT3 - DOT2));
                    //if(sNextItem.Substring(DOT1,1)!="." || sNextItem.Substring(DOT2,1)!="." || sNextItem.Substring(DOT3,1)!=".")
                    //	throw new Exception("Incorrect separators. Enter another item code, please");
                    break;
                case NEW_ITEM_CODE:
                    iOrderCode = Convert.ToInt32(sNextItem.Substring(0, NEW_DOT1));
                    iEntryBatchCode = Convert.ToInt32(sNextItem.Substring(0, NEW_DOT1));
                    iBatchCode = Convert.ToInt32(sNextItem.Substring(NEW_DOT1, NEW_DOT2 - NEW_DOT1));
                    iItemCode = Convert.ToInt32(sNextItem.Substring(NEW_DOT2, NEW_DOT3 - NEW_DOT2));
                    break;
			        /*case BATCH_CODE:
                    iOrderCode = Convert.ToInt32(tbNextItem.Text.Substring(0,5));
                    iEntryBatchCode = Convert.ToInt32(tbNextItem.Text.Substring(6,5));
                    iBatchCode = Convert.ToInt32(tbNextItem.Text.Substring(12,3));
                    if(tbNextItem.Text.Substring(DOT1,1)!= "." || tbNextItem.Text.Substring(DOT2,1)!= ".")
                        throw new Exception("Incorrect separators. Enter another item code, please");
                    return;*/
                default:
					throw new Exception("Code length is incorrect. Enter another item code, please");
            }
            if (dsBatchSet != null)
            {
                DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                DataView dvOldItems = new DataView(dsBatchSet.Tables["tblItems"]);
                dvItems.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iItemCode;

                if (dvItems.Count > 0)
                {
                    foreach (DataRowView drv in dvItems)
                    {
                        iOrderCode = Convert.ToInt32(drv["OrderCode"]);
                        iEntryBatchCode = Convert.ToInt32(drv["EntryBatchCode"]);
                        iBatchCode = Convert.ToInt32(drv["BatchCode"]);
                        iItemCode = Convert.ToInt32(drv["ItemCode"]);

                        sOldNumber = Service.FillToFiveChars(drv["PrevGroupCode"].ToString()) +
                                     Service.FillToThreeChars(drv["PrevBatchCode"].ToString()) +
                                     Service.FillToTwoChars(drv["PrevItemCode"].ToString());
                        return;
                    }
                }

                dvOldItems.RowFilter = "PrevGroupCode=" + iOrderCode + " and PrevBatchCode=" + iBatchCode + " and PrevItemCode=" + iItemCode;

                if (dvOldItems.Count > 0)
                {
                    foreach (DataRowView drv in dvOldItems)
                    {
                        iOrderCode = Convert.ToInt32(drv["OrderCode"]);
                        iEntryBatchCode = Convert.ToInt32(drv["EntryBatchCode"]);
                        iBatchCode = Convert.ToInt32(drv["BatchCode"]);
                        iItemCode = Convert.ToInt32(drv["ItemCode"]);

                        sOldNumber = Service.FillToFiveChars(drv["PrevGroupCode"].ToString()) +
                                        Service.FillToThreeChars(drv["PrevBatchCode"].ToString()) +
                                        Service.FillToTwoChars(drv["PrevItemCode"].ToString());
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Corrects the item code (it must be two digits)
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iItemCode">item code</param>
        /// <returns>correct item code</returns>
        public static string CorrectItemCode(DataSet dsBatchSet, int iItemCode)
        {
            if (iItemCode < 10)
                return 0.ToString() + iItemCode.ToString();
            else
                return iItemCode.ToString();
        }


        /// <summary>
        /// Gets all parts of the sprscified item
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param> 
        /// <returns>parts of the sprscified item</returns>
        public static DataTable GetItemParts(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode)
        {
            DataTable dtItemParts = new DataTable();
            dtItemParts.Columns.Add("PartId");
            dtItemParts.Columns.Add("PartName");

            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            dvParts.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iItemCode;

            //DataView dvParts = new DataView(dsBatchSet.Tables["tblChars"]);

            foreach (DataRowView drvPart in dvParts)
            {
                dtItemParts.Rows.Add(new object[] { drvPart["PartId"], drvPart["PartName"] });
            }

            return dtItemParts;
        }

        /// <summary>
        /// Gets all characteristic values of the current part
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param> 
        /// <param name="sPartName">part name</param>
        /// <returns>characteristic values</returns>
        public static DataSet GetPartCharValues(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, /*string sPartName*/int iPartId)
        {
            int iCharId, iValueId;
            string sCharName, sValue;

            DataSet dsCharValues = new DataSet();
            DataTable dtCharValues = dsCharValues.Tables.Add();
            dtCharValues.Columns.Add();


            //DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);
            DataView dvVals = new DataView(dsBatchSet.Tables["tblValues0"]);//tblValues
            DataView dvVC = new DataView(dsBatchSet.Tables["tblValueCodes"]);

            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartName='"+sPartName+"'";
            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartId="+iPartId;
            //foreach(DataRowView drPartRow in dvParts)
            //{
            //	iPartId = Convert.ToInt32(drPartRow["PartId"]);
            dvChars.RowFilter = "PartId=" + iPartId + " and ItemCode=" + iItemCode;
            foreach (DataRowView drCharRow in dvChars)
            {
                iCharId = Convert.ToInt32(drCharRow["CharId"]);
                sCharName = Convert.ToString(drCharRow["CharName"]);
                ///dvVals.RowFilter = "CharId="+iCharId+" and PartId="+iPartId;
                dvVals.RowFilter = "MeasureID='" + iCharId + "' and PartId='" + iPartId + "' and ItemCode='" + iItemCode + "'";
                foreach (DataRowView drValsRow in dvVals)
                {
                    if (!Convert.IsDBNull(drValsRow["ValueId"]))
                    {
                        iValueId = Convert.ToInt32(drValsRow["ValueId"]);
                        dvVC.RowFilter = "ValueId='" + iValueId + "'";
                        if (dvVC.Count != 0)
                        {
                            //dtCharValues.Rows.Add(new object[] {sCharName+"="+dvVC[0]["ValueName"]});
                            dtCharValues.Rows.Add(new object[] { dvVC[0]["ValueName"] });
                            continue;
                        }
                        //sCharName = Convert.ToString(drCharRow["CharName"]); Commented at (07/15/08) 
                        //dtCharValues.Rows.Add(new object[] {sCharName+"="+iValueId});
                        dtCharValues.Rows.Add(new object[] { iValueId });
                        continue;
                    }
                    if (!Convert.IsDBNull(drValsRow["Value"]))
                    {
                        sValue = Convert.ToString(drValsRow["Value"]);
                        //sCharName = Convert.ToString(drCharRow["CharName"]);  Commented at (07/15/08) 
                        //dtCharValues.Rows.Add(new object[] {sCharName+"="+sValue});
                        dtCharValues.Rows.Add(new object[] { sValue });
                        //dtCharValues.Rows.Add(new object[] {sValue});
                        continue;
                    }
                    if (!Convert.IsDBNull(drValsRow["StringValue"]) && Convert.ToInt32(drCharRow["CharCode"]) != GraderLib.Codes.LaserInscription)
                    {
                        sValue = Convert.ToString(drValsRow["StringValue"]);
                        //sCharName = Convert.ToString(drCharRow["CharName"]); Commented at (07/15/08) 
                        //dtCharValues.Rows.Add(new object[] {sCharName+"="+sValue});
                        dtCharValues.Rows.Add(new object[] { sValue });
                        //dtCharValues.Rows.Add(new object[] {sValue});
                        continue;
                    }
                    dtCharValues.Rows.Add(new object[] { "" });
                }
            }
            //}

            /*string[] sCharValues = new string[dtCharValues.Rows.Count];
            for(int i=0; i<dtCharValues.Rows.Count; i++)
                sCharValues[i] = Convert.ToInt32(dtCharValues.Rows[i][0]);*/

            return dsCharValues;
        }

        /// <summary>
        /// Gets all characteristic values of the current item
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param> 
        /// <returns>characteristic values</returns>
        public static DataSet GetItemCharValues(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode)
        {
            DataSet dsCharValues = new DataSet();
            DataTable dtCharValues = dsCharValues.Tables.Add();
            dtCharValues.Columns.Add();

            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            dvParts.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iItemCode;
            DataSet dsPartCharValues;
            foreach (DataRowView drvPart in dvParts)
            {
                //sPartName = drvPart["PartName"].ToString();
                int iPartId = Convert.ToInt32(drvPart["PartId"]);
                dsPartCharValues = GetPartCharValues(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, iPartId);
                foreach (DataRow drPartCharValue in dsPartCharValues.Tables[0].Rows)
                    dtCharValues.Rows.Add(new object[] { drPartCharValue[0].ToString() });
            }

            return dsCharValues;
        }

        /// <summary>
        /// Gets clarity values of the current item
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="sPartName">part name</param>
        /// <param name="sHistoryTbl1">name of the first table which contains old item characteristic values</param>
        /// <param name="sHistoryTbl2">name of the second table which contains old item characteristic values</param>
        /// <param name="sHistoryTbl3">name of the third table which contains old item characteristic values</param>
        /// <returns>coloumn with clarity values</returns>
        public static DataSet GetHistoryPartCharValues(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, /*string sPartName*/int iPartId, string sHistoryTbl1, string sHistoryTbl2, string sHistoryTbl3)
        {
            int iCharId,
                iValueId;

            DataSet dsClarityValues = new DataSet();
            DataTable dtHistory1Values = dsClarityValues.Tables.Add(sHistoryTbl1);
            DataTable dtHistory2Values = dsClarityValues.Tables.Add(sHistoryTbl2);
            DataTable dtHistory3Values = dsClarityValues.Tables.Add(sHistoryTbl3);
            dtHistory1Values.Columns.Add();
            dtHistory2Values.Columns.Add();
            dtHistory3Values.Columns.Add();

            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);
            DataView dvHistory1Vals = new DataView(dsBatchSet.Tables[sHistoryTbl1]);
            DataView dvHistory2Vals = new DataView(dsBatchSet.Tables[sHistoryTbl2]);
            DataView dvHistory3Vals = new DataView(dsBatchSet.Tables[sHistoryTbl3]);
            DataView dvVC = new DataView(dsBatchSet.Tables["tblValueCodes"]);

            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartName='"+sPartName+"'";
            //foreach(DataRowView drPartRow in dvParts)
            //{
            //	iPartId = Convert.ToInt32(drPartRow["PartId"]);
            ///dvChars.RowFilter = "PartId="+iPartId;
            dvChars.RowFilter = "PartId=" + iPartId + " and ItemCode=" + iItemCode;
            foreach (DataRowView drCharRow in dvChars)
            {
                iCharId = Convert.ToInt32(drCharRow["CharId"]);
                dvHistory1Vals.RowFilter = "MeasureID=" + iCharId + " and ItemCode=" + iItemCode + " and PartId=" + iPartId;
                foreach (DataRowView drHistory1Val in dvHistory1Vals)
                {
                    if (!Convert.IsDBNull(drHistory1Val["ValueId"]))
                    {
                        iValueId = Convert.ToInt32(drHistory1Val["ValueId"]);
                        dvVC.RowFilter = "ValueId=" + iValueId;
                        if (dvVC.Count > 0)
                            dtHistory1Values.Rows.Add(new object[] { dvVC[0]["ValueName"] });
                        else
                            dtHistory1Values.Rows.Add(new object[] { iValueId });
                    }
                }
                dvHistory2Vals.RowFilter = "MeasureID=" + iCharId + " and ItemCode=" + iItemCode + " and PartId=" + iPartId;
                foreach (DataRowView drHistory2Val in dvHistory2Vals)
                {
                    if (!Convert.IsDBNull(drHistory2Val["ValueId"]))
                    {
                        iValueId = Convert.ToInt32(drHistory2Val["ValueId"]);
                        dvVC.RowFilter = "ValueId=" + iValueId;
                        //
                        if (dvVC.Count > 0)
                            dtHistory2Values.Rows.Add(new object[] { dvVC[0]["ValueName"] });
                        else
                            dtHistory2Values.Rows.Add(new object[] { iValueId });
                    }
                }
                dvHistory3Vals.RowFilter = "MeasureID=" + iCharId + " and ItemCode=" + iItemCode + " and PartId=" + iPartId;
                foreach (DataRowView drHistory3Val in dvHistory3Vals)
                {
                    if (!Convert.IsDBNull(drHistory3Val["ValueId"]))
                    {
                        iValueId = Convert.ToInt32(drHistory3Val["ValueId"]);
                        dvVC.RowFilter = "ValueId=" + iValueId;
                        if (dvVC.Count > 0)
                            dtHistory3Values.Rows.Add(new object[] { dvVC[0]["ValueName"] });
                        else
                            dtHistory3Values.Rows.Add(new object[] { iValueId });
                    }
                }
            }
            //}

            return dsClarityValues;
        }

        /// <summary>
        /// Gets current part codes
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="sPartName">part name</param>
        /// <returns>part codes</returns>
        public static int[] GetPartValueCodes(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, int iPartId, int ViewAccessCode)
        {
            /*DataSet dsPosVals = Service.GetPartPossibleEnumValues(iPartId, ViewAccessCode);
            int[] iPartCodes = new int[dsPosVals.Tables[0].Rows.Count];
            for(int i = 0; i<dsPosVals.Tables[0].Rows.Count; i++)
                iPartCodes[i] = Convert.ToInt32(dsPosVals.Tables[0].Rows[i]["ValueCode"]);
            return iPartCodes;*/
            /**
             * Changed by 3ter on 2006.03.17. Speed up
             * */

            /**/
            int iCharId, iValueCode;

            DataSet dsPartCodes = new DataSet();
            DataTable dtPartCodes = dsPartCodes.Tables.Add();
            dtPartCodes.Columns.Add();

            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);
            DataView dvVC = new DataView(dsBatchSet.Tables["tblValueCodes"]);

            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartName='"+sPartName+"'";
            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartId="+iPartId;
            //foreach(DataRowView drPartRow in dvParts)
            //{
            //iPartId = Convert.ToInt32(drPartRow["PartId"]);
			string sRowFilter = "";
			switch (ViewAccessCode)
			{
				case 5:
				case 4:
					{
						sRowFilter = "PartId = " + iPartId + " and ItemCode = " + iItemCode + " and CharID <> " + 8;
						break;
					}
				//case 6:
				//    {
				//        sRowFilter = "PartId = " + iPartId + " and ItemCode = " + iItemCode + " and CharID <> " + 32 + " and CharID <> " + 27 + " and CharID <> " + 29;
				//        break;
				//    }
				default:
					{
						sRowFilter = "PartId =" + iPartId + " and ItemCode = " + iItemCode;
						break;
					}
			}
			dvChars.RowFilter = sRowFilter;

#if DEBUG
			int nRowsChars = dvChars.Count;
			int nRowsVC = dvVC.Count;
#endif
            foreach (DataRowView drCharRow in dvChars)
            {
#if DEBUG				
				string sCharName = drCharRow["CharName"].ToString();
#endif
				iCharId = Convert.ToInt32(drCharRow["CharId"]);
                dvVC.RowFilter = "CharId=" + iCharId;

                foreach (DataRowView drValCode in dvVC)
                {
						iValueCode = Convert.ToInt32(drValCode["ValueCode"]);
						string sValueName = drValCode["ValueName"].ToString();
						dtPartCodes.Rows.Add(new object[] { iValueCode });
                }
            }
  
            int[] iPartCodes = new int[dtPartCodes.Rows.Count];
            for (int i = 0; i < dtPartCodes.Rows.Count; i++)
                iPartCodes[i] = Convert.ToInt32(dtPartCodes.Rows[i][0]);

            return iPartCodes;
  }

        public static int[] GetPartValueCodes(
                                              DataSet dsBatchSet, 
                                              int iOrderCode, 
                                              int iEntryBatchCode, 
                                              int iBatchCode, 
                                              int iItemCode, 
                                              int iPartId, 
                                              int ViewAccessCode, 
                                              TypeInfo charCode
                                              )
        {
            /*DataSet dsPosVals = Service.GetPartPossibleEnumValues(iPartId, ViewAccessCode);
            int[] iPartCodes = new int[dsPosVals.Tables[0].Rows.Count];
            for(int i = 0; i<dsPosVals.Tables[0].Rows.Count; i++)
                iPartCodes[i] = Convert.ToInt32(dsPosVals.Tables[0].Rows[i]["ValueCode"]);
            return iPartCodes;*/
            /**
             * Changed by 3ter on 2006.03.17. Speed up
             * */

            /**/
            int iCharId, iValueCode;

            DataSet dsPartCodes = new DataSet();
            DataTable dtPartCodes = dsPartCodes.Tables.Add();
            dtPartCodes.Columns.Add();

            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);
            DataView dvVC = new DataView(dsBatchSet.Tables["tblValueCodes"]);

            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartName='"+sPartName+"'";
            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartId="+iPartId;
            //foreach(DataRowView drPartRow in dvParts)
            //{
            //iPartId = Convert.ToInt32(drPartRow["PartId"]);
            string sRowFilter = "";
            switch (ViewAccessCode)
            {
                case 5:
                case 4:
                    {
                        sRowFilter = "PartId = " + iPartId + " and ItemCode = " + iItemCode + " and CharID <> " + 8;
                        break;
                    }
                //case 6:
                //    {
                //        sRowFilter = "PartId = " + iPartId + " and ItemCode = " + iItemCode + " and CharID <> " + 32 + " and CharID <> " + 27 + " and CharID <> " + 29;
                //        break;
                //    }
                default:
                    {
                        sRowFilter = "PartId =" + iPartId + " and ItemCode = " + iItemCode;
                        break;
                    }
            }
            if (charCode.sCharType != null && charCode.sCharType.ToUpper() == "ENUM")
                sRowFilter = "PartId = " + iPartId + " and ItemCode = " + iItemCode + " and CharID = " + charCode.iCharCode;
            dvChars.RowFilter = sRowFilter;

#if DEBUG
            int nRowsChars = dvChars.Count;
            int nRowsVC = dvVC.Count;
#endif
            foreach (DataRowView drCharRow in dvChars)
            {
#if DEBUG
                string sCharName = drCharRow["CharName"].ToString();
#endif
                iCharId = Convert.ToInt32(drCharRow["CharId"]);
                dvVC.RowFilter = "CharId=" + iCharId;

                foreach (DataRowView drValCode in dvVC)
                {
                    iValueCode = Convert.ToInt32(drValCode["ValueCode"]);
                    string sValueName = drValCode["ValueName"].ToString();
                    dtPartCodes.Rows.Add(new object[] { iValueCode });
                }
            }

            int[] iPartCodes = new int[dtPartCodes.Rows.Count];
            for (int i = 0; i < dtPartCodes.Rows.Count; i++)
                iPartCodes[i] = Convert.ToInt32(dtPartCodes.Rows[i][0]);

            return iPartCodes;
        }

        /// <summary>
        /// Gets current part characteristic codes
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="sPartName">part name</param>
        /// <returns>part characteristic codes</returns>
        public static int[] GetPartCharCodes(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, int iPartId)
        {
            int iCharCode;

            DataSet dsPartCharCodes = new DataSet();
            DataTable dtPartCharCodes = dsPartCharCodes.Tables.Add();
            dtPartCharCodes.Columns.Add();

            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);

            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartName='"+sPartName+"'";
            //foreach(DataRowView drPartRow in dvParts)
            //{
            //	iPartId = Convert.ToInt32(drPartRow["PartId"]);

            dvChars.RowFilter = "PartId=" + iPartId + " and ItemCode=" + iItemCode;
            foreach (DataRowView drCharRow in dvChars)
            {
                iCharCode = Convert.ToInt32(drCharRow["CharCode"]);
                dtPartCharCodes.Rows.Add(new object[] { iCharCode });
            }
            //}

            int[] iPartCharCodes = new int[dtPartCharCodes.Rows.Count];
            for (int i = 0; i < dtPartCharCodes.Rows.Count; i++)
                iPartCharCodes[i] = Convert.ToInt32(dtPartCharCodes.Rows[i][0]);

            return iPartCharCodes;
        }

        /*/// <summary>
        /// Gets next available key to press in current mode
        /// </summary>
        /// <param name="cPressedKeys">already pressed keys</param>
        /// <param name="iPartCodes">available codes for the current item part</param>
        /// <returns>available chars to press next</returns>
        public static char[] GetNextAvailableKeys(char[] cPressedKeys, int[] iPartCodes, string sFileName)
        {
            //try
            //{
            string sXPath = CreateFilteredXPath(cPressedKeys, iPartCodes);

            XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);
            char[] cAvailableChars = new char[xnlNodeList.Count];
            for(int i=0; i<xnlNodeList.Count; i++)
                cAvailableChars[i] = xnlNodeList[i].Name[0];

            if(cAvailableChars.Length == 0)
                throw new Exception("There is no available next keys");

            return cAvailableChars;

            //}
            //catch(Exception eEx)
            //{
            //	throw new Exception("Couldn't get available keys to press next\r\n"+eEx.Message);
            //}
        }*/

        /// <summary>
        /// Gets next available keys to press for the current part characteristic
        /// </summary>
        /// <param name="cPressedKeys">already pressed keys</param>
        /// <param name="iPartCharCodes">available codes for the current item part</param>
        /// <param name="sFileName">file name</param>
        /// <param name="bIsValue">indicates wether entered char is value</param>
        /// <returns>available chars to press next</returns>
        public static char[] GetNextAvailableCharKeys(char[] cPressedKeys, int[] iPartCharCodes, string sFileName, bool bIsValue)
        {
            string sXPath = CreateFilteredCharXPath(cPressedKeys, iPartCharCodes, false, bIsValue, "key");

            XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);
            if (xnlNodeList.Count == 0)
                throw new Exception("There is no available next keys");

            char[] cAvailableChars = new char[xnlNodeList.Count];
            for (int i = 0; i < xnlNodeList.Count; i++)
                cAvailableChars[i] = xnlNodeList[i].Name[3];

            return cAvailableChars;
        }

        /// <summary>
        /// Gets valuecode of entered value
        /// </summary>
        /// <param name="cPressedKeys">entered value</param>
        /// <param name="sFileName">file name</param>
        /// <param name="iPartValueCodes">current part value codes</param>
        /// <returns>valuecode</returns>
        public static int GetCharValueCode(char[] cPressedKeys, int[] iPartValueCodes, string sFileName)
        {
            string sXPath = CreateFilteredCharXPath(cPressedKeys, iPartValueCodes, true, true, "key");
            XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);

            /*int i;
            string sXPath = "/keyboard/map/itemtype/";

            for(i=0; i<cPressedKeys.Length-1; i++)
                sXPath += cPressedKeys[i]+"/nextavailable/";
            sXPath += cPressedKeys[i]+"/valuecode";

            XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);*/

            return Convert.ToInt32(xnlNodeList[0].Attributes.GetNamedItem("code").Value);
        }

        /// <summary>
        /// Gets entered characteristic type info
        /// </summary>
        /// <param name="cPressedKeys">pressed keys</param>
        /// <param name="iPartCharCodes">character codes</param>
        /// <param name="sFileName">file name</param>
        /// <returns>characteristic type info</returns>
        public static TypeInfo GetCharInfo(char[] cPressedKeys, int[] iPartCharCodes, string sFileName)
        {
            TypeInfo tiChar;

            string sXPath = CreateFilteredCharXPath(cPressedKeys, iPartCharCodes, true, false, "key");
            XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);

            tiChar.iCharCode = Convert.ToInt32(xnlNodeList[0].Attributes.GetNamedItem("code").Value);
            tiChar.sCharType = Convert.ToString(xnlNodeList[0].Attributes.GetNamedItem("type").Value);

            tiChar.iMinDotDigits = -1;
            tiChar.iMaxDotDigits = -1;
            if (tiChar.sCharType == "integer")
            {
                tiChar.iMinDotDigits = Convert.ToInt32(xnlNodeList[0].Attributes.GetNamedItem("mindotdigits").Value);
                tiChar.iMaxDotDigits = Convert.ToInt32(xnlNodeList[0].Attributes.GetNamedItem("maxdotdigits").Value);
            }
            return tiChar;
        }

        /// <summary>
        /// Gets current part characteristic identifiers
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="sPartName">part name</param>
        /// <returns>part characteristic identifiers</returns>
        public static int[] GetPartCharIds(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, int iPartId)
        {
            int iCharId;

            DataSet dsPartCharIds = new DataSet();
            DataTable dtPartCharIds = dsPartCharIds.Tables.Add();
            dtPartCharIds.Columns.Add();

            //DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);

            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartName='"+sPartName+"'";
            //foreach(DataRowView drPartRow in dvParts)
            //{
            //	iPartId = Convert.ToInt32(drPartRow["PartId"]);
            dvChars.RowFilter = "PartId=" + iPartId + " and ItemCode=" + iItemCode;
            foreach (DataRowView drCharRow in dvChars)
            {
                iCharId = Convert.ToInt32(drCharRow["CharId"]);
                //iCharId = Convert.ToInt32(drCharRow["CharCode"]);
                dtPartCharIds.Rows.Add(new object[] { iCharId });
            }
            //}

            int[] iPartCharIds = new int[dtPartCharIds.Rows.Count];
            for (int i = 0; i < dtPartCharIds.Rows.Count; i++)
                iPartCharIds[i] = Convert.ToInt32(dtPartCharIds.Rows[i][0]);

            return iPartCharIds;
        }

        /// <summary>
        /// Gets current part characteristic identifiers
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="sPartName">part name</param>
        /// <returns>part characteristic identifiers</returns>		
        public static DataTable GetPartCharIds(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, string sPartName, int iPartId, bool b)
        {
            int iCharId;

            DataTable dtPartCharIds = new DataTable();
            dtPartCharIds.Columns.Add("PartId");
            dtPartCharIds.Columns.Add("PartName");
            dtPartCharIds.Columns.Add("CharId");
            dtPartCharIds.Columns.Add("ItemCode");

            //DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);

            //dvParts.RowFilter = "OrderCode="+iOrderCode+" and EntryBatchCode="+iEntryBatchCode+" and BatchCode="+iBatchCode+" and ItemCode="+iItemCode+" and PartName='"+sPartName+"'";
            //foreach(DataRowView drPartRow in dvParts)
            //{
            //	iPartId = Convert.ToInt32(drPartRow["PartId"]);
            //	sPartName = Convert.ToString(drPartRow["PartName"]);
            dvChars.RowFilter = "PartId=" + iPartId + " and ItemCode=" + iItemCode;
            foreach (DataRowView drCharRow in dvChars)
            {
                iCharId = Convert.ToInt32(drCharRow["CharId"]);
                dtPartCharIds.Rows.Add(new object[] { iPartId, sPartName, iCharId, iItemCode });
            }
            //}

            return dtPartCharIds;
        }

        /// <summary>
        /// Gets current item characteristic identifiers
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <returns>item characteristic identifiers</returns>
        public static int[] GetItemCharIds(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode)
        {
            int iPartId;
            int[] iPartCharIds;

            DataSet dsItemCharIds = new DataSet();
            DataTable dtItemCharIds = dsItemCharIds.Tables.Add();
            dtItemCharIds.Columns.Add();

            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            dvParts.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iItemCode;
            foreach (DataRowView drPartRow in dvParts)
            {
                //sPartName = Convert.ToString(drPartRow["PartName"]);
                iPartId = Convert.ToInt32(drPartRow["PartId"]);
                iPartCharIds = GetPartCharIds(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, iPartId);
                foreach (int iPartCharId in iPartCharIds)
                    dtItemCharIds.Rows.Add(new object[] { iPartCharId });
            }

            int[] iItemCharIds = new int[dtItemCharIds.Rows.Count];
            for (int i = 0; i < dtItemCharIds.Rows.Count; i++)
                iItemCharIds[i] = Convert.ToInt32(dtItemCharIds.Rows[i][0]);

            return iItemCharIds;
        }

        /// <summary>
        /// Gets current item characteristic identifiers
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <returns>item characteristic identifiers</returns>
        public static DataSet GetItemCharIds(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, bool b)
        {
            int iPartId;
            string sPartName;

            DataTable dtPartCharIds;
            DataSet dsItemCharIds = new DataSet();
            //DataTable dtItemCharIds = new DataTable();
            /*dtItemCharIds.Columns.Add("PartId");
            dtItemCharIds.Columns.Add("PartName");
            dtItemCharIds.Columns.Add("CharId");*/
            //dsItemCharIds.Tables.Add()

            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            dvParts.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iItemCode;
            foreach (DataRowView drPartRow in dvParts)
            {
                sPartName = Convert.ToString(drPartRow["PartName"]);
                iPartId = Convert.ToInt32(drPartRow["PartId"]);
                dtPartCharIds = GetPartCharIds(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, sPartName, iPartId, true);
                if (dtPartCharIds.Rows.Count > 0)
                    dsItemCharIds.Tables.Add(dtPartCharIds.Copy());

                //foreach(DataRow drPartCharId in dtPartCharIds.Rows)
                //	dtItemCharIds.Rows.Add(drPartCharId);
            }

            return dsItemCharIds;
        }

        /// <summary>
        /// Gets correct full code string
        /// </summary>
        /// <returns>full code string</returns>
        /// 
        public static string GetCorrectOrderBatchItemString(int iOrderCode, int iBatchCode, int iItemCode)
        {
            string sCode = "";
            if (iOrderCode > 0)
                sCode += Service.FillToFiveChars(iOrderCode.ToString()); //GetCorrectCodeString(iOrderCode, DOC_ITEM_CODE_FORMAT[1]);
            if (iBatchCode > 0)
                sCode += "." + Service.FillToThreeChars(iBatchCode.ToString()); //GetCorrectCodeString(iBatchCode, D.OC_ITEM_CODE_FORMAT[2]);
            if (iItemCode > 0)
                sCode += "." + Service.FillToTwoChars(iItemCode.ToString()); //GetCorrectCodeString(iItemCode, DOC_ITEM_CODE_FORMAT[3]);
            return sCode;
        }

        public static string GetCorrectFullCodeString(int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode)
        {

            string sCode = "";

            if (iOrderCode > 0)
                sCode += Service.FillToFiveChars(iOrderCode.ToString()); //GetCorrectCodeString(iOrderCode, DOC_ITEM_CODE_FORMAT[1]);
            if (iEntryBatchCode > 0)
                sCode += "." + Service.FillToFiveChars(iOrderCode.ToString());
            //				sCode += "."+GetCorrectCodeString(iEntryBatchCode, DOC_ITEM_CODE_FORMAT[1]);
            if (iBatchCode > 0)
                sCode += "." + Service.FillToThreeChars(iBatchCode.ToString()); //GetCorrectCodeString(iBatchCode, D.OC_ITEM_CODE_FORMAT[2]);
            if (iItemCode > 0)
                sCode += "." + Service.FillToTwoChars(iItemCode.ToString()); //GetCorrectCodeString(iItemCode, DOC_ITEM_CODE_FORMAT[3]);
            //            sCode = Service.FillToFiveChars(iOrderCode.ToString()) + "." + 
            //                    Service.FillToFiveChars(iEntryBatchCode.ToString()) + "." + 
            //                    Service.FillToThreeChars(iBatchCode.ToString()) + "." + 
            //                    Service.FillToTwoChars(iItemCode.ToString());

            return sCode;
        }

        public static string GetCorrectOrderBatchItemCodeStringNoDots(int iOrderCode, int iBatchCode, int iItemCode)
        {
            string sCode = "";

            if (iOrderCode > 0)
                sCode += Service.FillToFiveChars(iOrderCode.ToString()); //GetCorrectCodeString(iOrderCode, DOC_ITEM_CODE_FORMAT[1]);
            if (iBatchCode > 0)
                sCode += Service.FillToThreeChars(iBatchCode.ToString()); //GetCorrectCodeString(iBatchCode, DOC_ITEM_CODE_FORMAT[2]);
            if (iItemCode > 0)
                sCode += Service.FillToTwoChars(iItemCode.ToString()); //GetCorrectCodeString(iItemCode, DOC_ITEM_CODE_FORMAT[3]);

            //            sCode = Service.FillToFiveChars(iOrderCode.ToString()) + 
            //                    Service.FillToThreeChars(iBatchCode.ToString()) + 
            //                    Service.FillToTwoChars(iItemCode.ToString());

            return sCode;
        }

        /// <summary>
        /// Gets correct full code string
        /// </summary>
        /// <param name="sCode">code</param>
        /// <returns>correct full code string</returns>
        /// 
        public static string GetFullCodeStringWithDots(string sCode)
        {
            sCode = sCode.Replace(".", "");
            Regex re10 = new Regex(@"^\d{5}\.\d{5}\.\d{3}\.\d{2}$");
            Regex re11 = new Regex(@"^\d{6}\.\d{6}\.\d{3}\.\d{2}$");
            string sText = "";
            if (sCode.Trim().Length == 10)
            {
                sText = sCode.Trim().Substring(0, 5);
                sText += ".";
                sText += sCode.Trim().Substring(0, 5);
                sText += ".";
                sText += sCode.Trim().Substring(5, 3);
                sText += ".";
                sText += sCode.Trim().Substring(8, 2);

                if (!re10.IsMatch(sText))
                {
                    throw new Exception("Please type again. Acceptable formats: 12345.12345.123.12 or 1234567890");
                }
            }
            if (sCode.Trim().Length == 11)
            {
                sText = sCode.Trim().Substring(0, 6);
                sText += ".";
                sText += sCode.Trim().Substring(0, 6);
                sText += ".";
                sText += sCode.Trim().Substring(6, 3);
                sText += ".";
                sText += sCode.Trim().Substring(9, 2);

                if (!re11.IsMatch(sText))
                {
                    throw new Exception("Please type again. Acceptable formats: 123456.123456.123.12 or 12345678910");
                }
            }
            return sText;
        }

        public static string GetCorrectFullCodeString(string sCode)
        {
            string sCorrectCode = "";

            string[] sCodes = sCode.Split('.');

            try
            {
                Convert.ToInt32(sCode.Substring(0, 1));
            }
            catch
            {
                sCorrectCode += sCodes[0].Substring(0, 1);
                sCodes[0] = sCodes[0].Substring(1, sCodes[0].Length - 1);
            }
            finally
            {
                if (sCodes[0].Length < 6)
                {
                    for (int i = 0; i < sCodes.Length; i++)
                        sCorrectCode += GetCorrectCodeString(Convert.ToInt32(sCodes[i]), ITEM_CODE_FORMAT[i]) + ".";
                }
                else
                {
                    for (int i = 0; i < sCodes.Length; i++)
                        sCorrectCode += GetCorrectCodeString(Convert.ToInt32(sCodes[i]), NEW_ITEM_CODE_FORMAT[i]) + ".";
                }
            }

            return sCorrectCode.Substring(0, sCorrectCode.Length - 1);
        }

        /// <summary>
        /// Gets Correct code string
        /// </summary>
        /// <param name="iCode">code</param>
        /// <param name="iCodeLength">need code length</param>
        /// <returns></returns>
        public static string GetCorrectCodeString(int iCode, int iCodeLength)
        {
            return GetCorrectCodeString(iCode.ToString(), iCodeLength);
        }

        /// <summary>
        /// Gets Correct code string
        /// </summary>
        /// <param name="sCode">code</param>
        /// <param name="iCodeLength">need code length</param>
        /// <returns></returns>
        public static string GetCorrectCodeString(string sCode, int iCodeLength)
        {
            while (sCode.Length < iCodeLength)
                sCode = "0" + sCode;

            return sCode;
        }
        /// <summary>
        /// Gets mode from the keymap
        /// </summary>
        /// <param name="cPressedKeys">pressed keys</param>
        /// <param name="sFileName">file name</param>
        /// <param name="iModeCode">mode code</param>
        /// <returns>mode</returns>
        public static string GetMode(char[] cPressedKeys, string sFileName, out int iModeCode)
        {
            string sXPath = CreateModeXPath(cPressedKeys, true, "key");
            XmlNodeList xnlNodeList = Client.GetXmlNodesByXPath(sXPath, sFileName);

            try
            {
                iModeCode = Convert.ToInt32(xnlNodeList[0].Attributes.GetNamedItem("code").Value);
            }
            catch
            {
                iModeCode = -1;
            }

            return xnlNodeList[0].Attributes.GetNamedItem("mode").Value;
        }


        /// <summary>
        /// Sets part name of the current item
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="sPartName">part name</param>
        /// <returns>part name</returns>
        public static void NextPartName(DataSet dsBatchSet,
                                        int iOrderCode,
                                        int iEntryBatchCode,
                                        int iBatchCode,
                                        int iItemCode,
                                        ref string sPartName,
                                        ref int iPartId)
        {
            int iCurPartId = iPartId;

            DataView dvPartNames = new DataView(dsBatchSet.Tables["tblParts"]);
            dvPartNames.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iItemCode;

            /*if(iPartId == 0 && dvPartNames.Count>0)
            {
                iPartId = Convert.ToInt32(dvPartNames[0]["PartId"]);
                sPartName = Convert.ToString(dvPartNames[0]["PartName"]);
                return;
            }*/

            bool bIsPassed = true;
            if (iCurPartId != 0)
                bIsPassed = false;

            for (int i = 0; i < dvPartNames.Count; i++)
            {
                iPartId = Convert.ToInt32(dvPartNames[i]["PartId"]);
                sPartName = Convert.ToString(dvPartNames[i]["PartName"]);

                DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);
                dvChars.RowFilter = "PartId=" + iPartId + " and ItemCode=" + iItemCode/*+" and IsEdit="+0*/;
                if (dvChars.Count == 0)
                    continue;

                if (bIsPassed)
                    return;

                if (iCurPartId == iPartId)// && i!=dvPartNames.Count-1
                    bIsPassed = true;
                //{
                //bIsPassed = true;
                //iPartId = Convert.ToInt32(dvPartNames[i+1]["PartId"]);
                //sPartName = Convert.ToString(dvPartNames[i+1]["PartName"]);
                //return;
                //}
                //if(!IsPartWorkedUp(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, iPartId, bIsManual))
                //	return;

                //bool bIsWorked = IsPartWorkedUp(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, sPartName);
                /*if(dvPartNames[i]["PartName"].ToString()==sPartName && i!=dvPartNames.Count-1)
                {
                    sPartName = dvPartNames[i+1]["PartName"].ToString();
                    return;
                }*/
            }

            sPartName = "";
            iPartId = 0;
            //throw new Exception("");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dsBatchSet"></param>
        /// <param name="iOrderCode"></param>
        /// <param name="iEntryBatchCode"></param>
        /// <param name="iBatchCode"></param>
        /// <param name="iItemCode"></param>
        /// <param name="tbItemsDone"></param>
        public static void DeleteItemFromDoneBox(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, ref TextBox tbItemsDone)
        {
            //tbItemsDone.Text = "";

            /*int iIterItem;
            //string sCorrectItemCode;
            //DataSet dsCharValues;
            foreach(DataRow drRow in dsBatchSet.Tables["tblItems"].Rows)
            {
                iIterItem = Convert.ToInt32(drRow["ItemCode"]);
                //sCorrectItemCode = CorrectItemCode(dsBatchSet, iIterItem);
                if(IsItemWorkedUp(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iIterItem, false))
                    PutItemInDoneBox(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iIterItem, ref tbItemsDone);
                else
                    PutItemInNotDoneBox(iOrderCode, iEntryBatchCode, iBatchCode, iIterItem, ref tbItemsNotDone);*/
            //tbItemsNotDone.Text += "item "+iOrderCode+"."+iEntryBatchCode+"."+iBatchCode+"."+sCorrectItemCode+"\r\n";
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dsBatchSet"></param>
        /// <param name="iOrderCode"></param>
        /// <param name="iEntryBatchCode"></param>
        /// <param name="iBatchCode"></param>
        /// <param name="iItemCode"></param>
        /// <param name="tbItemsNotDone"></param>
        public static void DeleteItemFromNotDoneBox(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, ref TextBox tbItemsNotDone)
        { }

        /// <summary>
        /// Puts specified item into Textbox with done items
        /// </summary>
        /// <param name="dsBatchSet">full batch info</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entry batch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="tbItemsDone">tbItemsDone textbox</param>
        public static void PutItemInDoneBox(DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, ref TextBox tbItemsDone)
        {
            tbItemsDone.Text += GetCorrectFullCodeString(iOrderCode, iEntryBatchCode, iBatchCode, iItemCode);
            DataSet dsCharValues = GetItemCharValues(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode);
            foreach (DataRow drCharValue in dsCharValues.Tables[0].Rows)
                tbItemsDone.Text += ", " + drCharValue[0].ToString();
            tbItemsDone.Text += "\r\n";
        }

        /// <summary>
        /// Puts specified item into Textbox with notdone items
        /// </summary>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entry batch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="tbItemsDone">tbItemsDone textbox</param>
        public static void PutItemInNotDoneBox(int iOrderCode, int iEntryBatchCode, int iBatchCode, int iIterItem, ref TextBox tbItemsNotDone)
        {
            tbItemsNotDone.Text += GetCorrectFullCodeString(iOrderCode, iEntryBatchCode, iBatchCode, iIterItem) + "\r\n";
        }


        /// <summary>
        /// Fills Done and not done items text boxes
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="tbItemsNotDone">tbItemsNotDone textbox</param>
        /// <param name="tbItemsDone">tbItemsDone textbox</param>
        public static void UpdateDoneNotDoneItemBoxes(DataSet dsBatchSet,
                                                        int iOrderCode,
                                                        int iEntryBatchCode,
                                                        int iBatchCode,
                                                        ref TextBox tbItemsNotDone,
                                                        ref TextBox tbItemsDone)
        {
            tbItemsNotDone.Text = "";
            tbItemsDone.Text = "";

            int iIterItem;
            //string sCorrectItemCode;
            //DataSet dsCharValues;
            foreach (DataRow drRow in dsBatchSet.Tables["tblItems"].Rows)
            {
                iIterItem = Convert.ToInt32(drRow["ItemCode"]);

                DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                dvItems.RowFilter = "OrderCode=" + iOrderCode + " and EntryBatchCode=" + iEntryBatchCode + " and BatchCode=" + iBatchCode + " and ItemCode=" + iIterItem;
                if (dvItems.Count == 1)
                {
                    if (Convert.ToInt32(dvItems[0]["IsDone"]) == 0)
                        PutItemInNotDoneBox(iOrderCode, iEntryBatchCode, iBatchCode, iIterItem, ref tbItemsNotDone);
                    else
                        PutItemInDoneBox(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iIterItem, ref tbItemsDone);//;
                }

                //sCorrectItemCode = CorrectItemCode(dsBatchSet, iIterItem);
                /*if(IsItemWorkedUp(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iIterItem, false))
                    PutItemInDoneBox(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iIterItem, ref tbItemsDone);
                else
                    PutItemInNotDoneBox(iOrderCode, iEntryBatchCode, iBatchCode, iIterItem, ref tbItemsNotDone);*/
                //tbItemsNotDone.Text += "item "+iOrderCode+"."+iEntryBatchCode+"."+iBatchCode+"."+sCorrectItemCode+"\r\n";
            }
        }

        /// <summary>
        /// Updates current part characteristics values in the boxes
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="sPartName">part name</param>
        /// <param name="sHistoryTbl1">name of the first table which contains old item characteristic values</param>
        /// <param name="sHistoryTbl2">name of the second table which contains old item characteristic values</param>
        /// <param name="sHistoryTbl3">name of the third table which contains old item characteristic values</param>
        /// <param name="lPart">lPart label</param>
        /// <param name="lCurrent">lCurrent label</param>
        /// <param name="lHistory1">lHistory1 label</param>
        /// <param name="lHistory2">lHistory2 label</param>
        /// <param name="lHistory3">lHistory3 label</param>
        public static void UpdateCurrentPartInfo(DataSet dsBatchSet,
                                                    int iOrderCode,
                                                    int iEntryBatchCode,
                                                    int iBatchCode,
                                                    int iItemCode,
                                                    string sPartName,
                                                    int iPartId,
                                                    string sHistoryTbl1,
                                                    string sHistoryTbl2,
                                                    string sHistoryTbl3,
                                                    ref Label lPart,
                                                    ref Label lCurrent,
                                                    ref Label lHistory1,
                                                    ref Label lHistory2,
                                                    ref Label lHistory3,
                                                    ref PictureBox pbShape,
                                                    ref PictureBox pbItemPicture,
                                                    ref Label lMeasures)
        {
            lPart.Text = sPartName;

            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);
            dvChars.RowFilter = "ItemCode='" + iItemCode + "' and PartId='" + iPartId + "'";
            lMeasures.Text = "";
            foreach (DataRowView drvChar in dvChars)
                lMeasures.Text += drvChar["CharName"] + " \n\r";
            if (lMeasures.Text.Length > 0)
            {
                lMeasures.Text = lMeasures.Text.Trim();
                lMeasures.Text = lMeasures.Text.Substring(0, lMeasures.Text.Length);
            }

            lCurrent.Text = "";
            string sCurrent = "";
            DataSet dsCurPartCharValues = GetPartCharValues(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, iPartId);
            if (dsCurPartCharValues.Tables[0].Rows.Count > 0)
            {
                //lCurrent.Text = dsCurPartCharValues.Tables[0].Rows[0][0].ToString();
                for (int i = 0; i < dsCurPartCharValues.Tables[0].Rows.Count; i++)
                {
                    sCurrent += dsCurPartCharValues.Tables[0].Rows[i][0].ToString() + ",\n\r";
                    //lCurrent.Text += dsCurPartCharValues.Tables[0].Rows[i][0].ToString() + ",\n\r";
                }
                lCurrent.Text = sCurrent;
            }

            lHistory1.Text = "";
            DataSet dsHistoryCharValues = GetHistoryPartCharValues(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, iPartId, sHistoryTbl1, sHistoryTbl2, sHistoryTbl3);
            if (dsHistoryCharValues.Tables[sHistoryTbl1].Rows.Count > 0)
            {
                lHistory1.Text = dsHistoryCharValues.Tables[sHistoryTbl1].Rows[0][0].ToString();
                for (int i = 1; i < dsHistoryCharValues.Tables[sHistoryTbl1].Rows.Count; i++)
                    lHistory1.Text += ", " + dsHistoryCharValues.Tables[sHistoryTbl1].Rows[i][0];
            }
            lHistory2.Text = "";
            if (dsHistoryCharValues.Tables[sHistoryTbl2].Rows.Count > 0)
            {
                lHistory2.Text = dsHistoryCharValues.Tables[sHistoryTbl2].Rows[0][0].ToString();
                for (int i = 1; i < dsHistoryCharValues.Tables[sHistoryTbl2].Rows.Count; i++)
                    lHistory2.Text += ", " + dsHistoryCharValues.Tables[sHistoryTbl2].Rows[i][0];
            }
            lHistory3.Text = "";
            if (dsHistoryCharValues.Tables[sHistoryTbl3].Rows.Count > 0)
            {
                lHistory3.Text = dsHistoryCharValues.Tables[sHistoryTbl3].Rows[0][0].ToString();
                for (int i = 1; i < dsHistoryCharValues.Tables[sHistoryTbl3].Rows.Count; i++)
                    lHistory3.Text += ", " + dsHistoryCharValues.Tables[sHistoryTbl3].Rows[i][0];
            }

            pbItemPicture.Image = null;
            pbShape.Image = null;
            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);
            dvParts.RowFilter = "ItemCode=" + iItemCode + " and PartId=" + iPartId;
            if (dvParts.Count > 0)
            {
                dvChars.RowFilter = "ItemCode='" + iItemCode + "' and PartId='" + iPartId + "' and CharId='" + Codes.Shape + "'";
                //if(!Convert.IsDBNull(dvParts[0]["ShapePicture"]) && dvChars.Count!=0) //old  version
                if (!Convert.IsDBNull(dvParts[0]["ShapePath"]) && dvChars.Count != 0) //new  version - 03/31/08
                {
                    //pbShape.Image = (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["ShapePicture"].ToString(), dvParts[0]["ShapePath"].ToString());
                    string pathToShape = Client.GetOfficeDirPath("iconDir") + dvParts[0]["ShapePath"].ToString();
                    if (File.Exists(pathToShape))
                    {
                        System.Drawing.Image imgShape = System.Drawing.Image.FromFile(pathToShape); //  (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["ShapePicture"].ToString(), dvParts[0]["ShapePath"].ToString()); old part
                        Service.DrawAdjustShapeImage(pbShape, imgShape);
                    }
                }
                //if(!Convert.IsDBNull(dvParts[0]["PicturePicture"])) old part
                if (!Convert.IsDBNull(dvParts[0]["PicturePath"]))
                {
                    //pbItemPicture.Image = (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["PicturePicture"].ToString(), dvParts[0]["PicturePath"].ToString());
                    //new part
                    string pathToPicture = Client.GetOfficeDirPath("iconDir") + dvParts[0]["PicturePath"].ToString();
                    if (File.Exists(pathToPicture))
                    {
                        System.Drawing.Image imgShape = System.Drawing.Image.FromFile(pathToPicture);//  (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["ShapePicture"].ToString(), dvParts[0]["ShapePath"].ToString()); old part
                        Service.DrawAdjustShapeImage(pbItemPicture, imgShape);
                    }
                    // old part
                    //System.Drawing.Image imgItem = (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["PicturePicture"].ToString(), dvParts[0]["PicturePath"].ToString());
                    //Service.DrawAdjustShapeImage(pbItemPicture, imgItem);
                    // end of old part
                }
            }

            //if(lPart.Text != "")
            //	throw new Exception("");
        }

        /// <summary>
        /// Updates current part characteristics values in the boxes
        /// </summary>
        /// <param name="dsBatchSet">full information about item</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entrybatch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="sHistoryTbl1">name of the first table which contains old item characteristic values</param>
        /// <param name="sHistoryTbl2">name of the second table which contains old item characteristic values</param>
        /// <param name="sHistoryTbl3">name of the third table which contains old item characteristic values</param>
        /// <param name="lPart">lPart label</param>
        /// <param name="lCurrent">lCurrent label</param>
        /// <param name="tbComment">tbComment text box</param>
        /// <param name="tbLaserInscription">tbLaserInscription text box</param>
        /// <param name="iInscriptionCode">inscription code</param>
        /// <param name="iPartId">part identifier</param>
        /// <param name="lHistory1">lHistory1 label</param>
        /// <param name="lHistory2">lHistory2 label</param>
        /// <param name="lHistory3">lHistory3 label</param>
        public static void UpdateCurrentPartInfo(DataSet dsBatchSet,
                                                    int iOrderCode,
                                                    int iEntryBatchCode,
                                                    int iBatchCode,
                                                    int iItemCode,
                                                    string sPartName,
                                                    int iPartId,
                                                    int iInscriptionCode,
                                                    string sHistoryTbl1,
                                                    string sHistoryTbl2,
                                                    string sHistoryTbl3,
                                                    ref Label lPart,
                                                    ref Label lCurrent,
                                                    ref TextBox tbComment,
                                                    ref TextBox tbLaserInscription,
                                                    ref Label lHistory1,
                                                    ref Label lHistory2,
                                                    ref Label lHistory3,
                                                    ref PictureBox pbShape,
                                                    ref PictureBox pbItemPicture,
                                                    ref Label lMeasures,
                                                    System.Boolean isNewItem)
        {

            lPart.Text = sPartName;
            DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
            DataView dvValues0 = new DataView(dsBatchSet.Tables["tblValues0"]);
            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);
            if (iPartId != 0)
            {
                dvItems.RowFilter = "ItemCode=" + iItemCode;
                //dvValues0.RowFilter = "ItemCode="+iItemCode+" and PartId="+iPartId+" and MeasureID="+iInscriptionCode;
                dvChars.RowFilter = "ItemCode=" + iItemCode + " and PartId=" + iPartId;

                lMeasures.Text = "";
                foreach (DataRowView drvChar in dvChars)
                    lMeasures.Text += drvChar["CharName"] + "\n\r";
                if (lMeasures.Text.Length > 0)
                {
                    lMeasures.Text = lMeasures.Text.Trim();
                    lMeasures.Text = lMeasures.Text.Substring(0, lMeasures.Text.Length);
                }

                tbLaserInscription.Text = "";
                tbComment.Text = "";
                dvValues0.RowFilter = "ItemCode=" + iItemCode + " and PartId=" + iPartId + " and MeasureID= 26"; //  +iInscriptionCode;
                if (dvValues0.Count > 0)
                    tbComment.Text = dvValues0[0]["StringValue"].ToString();

                //Modified by Vetal.

                //String sSelect = "OrderCode = " + iOrderCode + " and BatchCode = " + iBatchCode;
                //Modified 08/29/07
                //DataRow[] adrBatchNfo = dsBatchSet.Tables["tblItems"].Select(sSelect);
                //DataRow[] adrComms = dsBatchSet.Tables["tblParts"].Select("PartTypeID = '15'");
                //sSelect = "OrderCode = " + iOrderCode + " and BatchCode = " + iBatchCode;// + " and ItemCode = " + iItemCode;
                /*
								
                DataRow[] adrComms2 = dsBatchSet.Tables["tblItems"].Select(sSelect);
                DataRow[] adrComms1;//[];// = new DataRow();
                DataTable dtIC = new DataTable("tblBatchList");
                foreach (DataRow dRow in adrComms2)
                {
                    if (dRow["ItemCode"].ToString() == iItemCode.ToString())
                    {
                        dtIC = Service.GetPartValueCCM(dRow["NewBatchID"].ToString(), dRow["NewItemCode"].ToString());
                        adrComms1 = dtIC.Select("PartID = " + iPartId + " and MeasureCode = 26");
                        if(adrComms1.Length > 0)		
                            tbComment.Text = adrComms1[0]["StringValue"].ToString();
                        else 
                            tbComment.Text = "";
                        break;
                    }
                }
                //DataTable dtIC = Service.GetPartValueCCM(adrComms2[0]["NewBatchID"].ToString(), adrComms2[0]["NewItemCode"].ToString());
                //DataTable dtIC = Service.GetPartValueCCM(adrBatchNfo[0]["NewBatchID"].ToString(), adrBatchNfo[0]["NewItemCode"].ToString());
                //adrComms1 = dtIC.Select("PartID = " + adrComms[0]["PartID"] + " and MeasureCode = 26");
                */
            }
            //if (isNewItem)
            {
                /* sd 27.12.2006
                    DataTable dtIC = Service.GetPartValueCCM(adrBatchNfo[0]["BatchID"].ToString(), iItemCode.ToString());
                */
                dvValues0.RowFilter = "ItemCode=" + iItemCode + " and PartId=" + iPartId + " and MeasureID=" + iInscriptionCode;
                if (dvValues0.Count > 0)
                    tbLaserInscription.Text = dvValues0[0]["StringValue"].ToString();
            }

            lCurrent.Text = "";


            DataSet dsCurPartCharValues = GetPartCharValues(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, iPartId);
            if (dsCurPartCharValues.Tables[0].Rows.Count > 0)
            {
                lCurrent.Text = dsCurPartCharValues.Tables[0].Rows[0][0].ToString();
                for (int i = 1; i < dsCurPartCharValues.Tables[0].Rows.Count; i++)
                    lCurrent.Text += ",\n\r" + dsCurPartCharValues.Tables[0].Rows[i][0];
            }

            lHistory1.Text = "";
            DataSet dsHistoryCharValues = GetHistoryPartCharValues(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode,
                                                                    iItemCode, iPartId, sHistoryTbl1, sHistoryTbl2, sHistoryTbl3);
            if (dsHistoryCharValues.Tables[sHistoryTbl1].Rows.Count > 0)
            {
                lHistory1.Text = dsHistoryCharValues.Tables[sHistoryTbl1].Rows[0][0].ToString();
                for (int i = 1; i < dsHistoryCharValues.Tables[sHistoryTbl1].Rows.Count; i++)
                    lHistory1.Text += ", " + dsHistoryCharValues.Tables[sHistoryTbl1].Rows[i][0];
            }

            lHistory2.Text = "";
            if (dsHistoryCharValues.Tables[sHistoryTbl2].Rows.Count > 0)
            {
                lHistory2.Text = dsHistoryCharValues.Tables[sHistoryTbl2].Rows[0][0].ToString();
                for (int i = 1; i < dsHistoryCharValues.Tables[sHistoryTbl2].Rows.Count; i++)
                    lHistory2.Text += ", " + dsHistoryCharValues.Tables[sHistoryTbl2].Rows[i][0];
            }

            lHistory3.Text = "";
            if (dsHistoryCharValues.Tables[sHistoryTbl3].Rows.Count > 0)
            {
                lHistory3.Text = dsHistoryCharValues.Tables[sHistoryTbl3].Rows[0][0].ToString();
                for (int i = 1; i < dsHistoryCharValues.Tables[sHistoryTbl3].Rows.Count; i++)
                    lHistory3.Text += ", " + dsHistoryCharValues.Tables[sHistoryTbl3].Rows[i][0];
            }
            pbShape.Image = null;
            pbItemPicture.Image = null;

            DataView dvParts = new DataView(dsBatchSet.Tables["tblParts"]);

            dvParts.RowFilter = "ItemCode=" + iItemCode + " and PartId = " + iPartId;
            if (dvParts.Count > 0)
            {
                dvChars.RowFilter = "ItemCode=" + iItemCode + " and PartId=" + iPartId + " and CharId=" + Codes.Shape;
                //if(!Convert.IsDBNull(dvParts[0]["ShapePicture"]) && dvChars.Count!=0) //old  version
                if (!Convert.IsDBNull(dvParts[0]["ShapePath"]) && dvChars.Count != 0) //new  version - 03/31/08
                {
                    //pbShape.Image = (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["ShapePicture"].ToString(), dvParts[0]["ShapePath"].ToString());
                    string pathToShape = Client.GetOfficeDirPath("iconDir") + dvParts[0]["ShapePath"].ToString();
                    if (File.Exists(pathToShape))
                    {
                        System.Drawing.Image imgShape = System.Drawing.Image.FromFile(pathToShape);//  (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["ShapePicture"].ToString(), dvParts[0]["ShapePath"].ToString()); old part
                        Service.DrawAdjustShapeImage(pbShape, imgShape);
                    }
                }
                //if(!Convert.IsDBNull(dvParts[0]["PicturePicture"])) old part
                if (!Convert.IsDBNull(dvParts[0]["PicturePath"]))
                {
                    //pbItemPicture.Image = (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["PicturePicture"].ToString(), dvParts[0]["PicturePath"].ToString());
                    //new part
                    string pathToPicture = Client.GetOfficeDirPath("iconDir") + dvParts[0]["PicturePath"].ToString();
                    if (File.Exists(pathToPicture))
                    {
                        System.Drawing.Image imgShape = System.Drawing.Image.FromFile(pathToPicture);//  (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["ShapePicture"].ToString(), dvParts[0]["ShapePath"].ToString()); old part
                        Service.DrawAdjustShapeImage(pbItemPicture, imgShape);
                    }
                    // old part
                    //System.Drawing.Image imgItem = (System.Drawing.Image)Service.ExtractImageFromString(dvParts[0]["PicturePicture"].ToString(), dvParts[0]["PicturePath"].ToString());
                    //Service.DrawAdjustShapeImage(pbItemPicture, imgItem);
                    // end of old part
                }
            }
        }

        /// <summary>
        /// Updates item value
        /// </summary>
        /// <param name="dsBatchSet">full batch information</param>
        /// <param name="iOrderCode">order code</param>
        /// <param name="iEntryBatchCode">entry batch code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        public static void UpdateItemValue(ref DataSet dsBatchSet, int iOrderCode, int iEntryBatchCode, int iBatchCode, int iItemCode, bool bNotInvert)
        {
            //int[] iItemCharIds = GetItemCharIds(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode);
            DataSet dsItemChars = GetItemCharIds(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode, true);
            //DataTable dtItemParts = GraderLib.GetItemParts(dsBatchSet, iOrderCode, iEntryBatchCode, iBatchCode, iItemCode);

            DataTable dtValues = dsBatchSet.Tables["tblValues"];
            DataTable dtValues0 = dsBatchSet.Tables["tblValues0"];

            foreach (DataTable dtItemChars in dsItemChars.Tables)
            {
                foreach (DataRow drItemChar in dtItemChars.Rows)
                {
                    DataView dvValues = new DataView(dtValues);
                    DataView dvValues0 = new DataView(dtValues0);

                    dvValues.RowFilter = "MeasureID=" + drItemChar["CharId"] + " and PartId=" + drItemChar["PartId"] + " and ItemCode=" + drItemChar["ItemCode"];
                    dvValues0.RowFilter = "MeasureID=" + drItemChar["CharId"] + " and PartId=" + drItemChar["PartId"] + " and ItemCode=" + drItemChar["ItemCode"];

                    if (bNotInvert)
                    {
                        for (int i = 0; i < dvValues.Count; i++)
                        {
                            //dvValues0[i]["ValueId"] = dvValues[i]["ValueId"];
                            //dvValues0[i]["Value"] = dvValues[i]["Value"];
                            //dvValues0[i]["StringValue"] = dvValues[i]["StringValue"];
                            dvValues[i]["ValueId"] = DBNull.Value;
                            dvValues[i]["Value"] = DBNull.Value;
                            dvValues[i]["StringValue"] = DBNull.Value;
                        }
                        continue;
                    }

                    for (int i = 0; i < dvValues.Count; i++)
                    {
                        dvValues[i]["ValueId"] = dvValues0[i]["ValueId"];
                        dvValues[i]["Value"] = dvValues0[i]["Value"];
                        dvValues[i]["StringValue"] = dvValues0[i]["StringValue"];
                    }
                }
            }
        }

        /// <summary>
        /// Updates shape picture
        /// </summary>
        /// <param name="iValueId">value identifier</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="iPartId">part identifier</param>
        /// <param name="dsBatch">batch information</param>
        public static void UpdateShapePicture(int iValueId, int iGroupCode, int iBatchCode, int iItemCode, int iPartId, ref DataSet dsBatch, int iFormType)
        {
            /*DataTable dtParts = dsBatch.Tables["tblParts"];
			
            int iValueCode = 0;
            DataView dvVCView = new DataView(dsBatch.Tables["tblValueCodes"]);
            dvVCView.RowFilter = "ValueId="+iValueId+" and CharId="+GraderLib.Codes.Shape;
            if(dvVCView.Count > 0)
                iValueCode = Convert.ToInt32(dvVCView[0]["ValueCode"]);

            string sPartName = "";
            DataSet dsPrmss = Service.GetShapeByCode(iValueCode);
            DataTable dtPrmss = dsPrmss.Tables[0];
            if(dtPrmss.Rows.Count > 0)
            {
                DataView dvPartss = new DataView(dtParts);
                dvPartss.RowFilter = "ItemCode="+iItemCode+" and PartId="+iPartId;
                if(dvPartss.Count > 0)
                {
                    dvPartss[0]["ShapePath"] = dtPrmss.Rows[0]["Path2Drawing"];//ShapePath
                    dvPartss[0]["ShapePicture"] = dtPrmss.Rows[0]["Image_Path2Drawing"];//ShapePicture
                    sPartName = dvPartss[0]["PartName"].ToString();
                }
            }

            if(iFormType == GraderLib.Codes.Measure)
                PrintShape(iGroupCode, iBatchCode, iItemCode, iValueCode, sPartName);*/
        }

        /// <summary>
        /// Prints shape after changing it in clarity
        /// </summary>
        /// <param name="iGroupCode">group code</param>
        /// <param name="iBatchCode">batch code</param>
        /// <param name="iItemCode">item code</param>
        /// <param name="iShapeCode">shape code</param>
        private static void PrintShape(int iGroupCode, int iBatchCode, int iItemCode, int iShapeCode, string sPartName)
        {
            string sRepPath = Client.GetOfficeDirPath("repDir");
            CrystalReportCl.CrystalReport crRpt = new CrystalReportCl.CrystalReport(sRepPath);
            int iCodeLength;
            if (iGroupCode.ToString().Length <= 5) iCodeLength = 5;
            else iCodeLength = 6;
            string sGroupCode = GetCorrectCodeString(iGroupCode, iCodeLength);
            string sBatchCode = GetCorrectCodeString(iBatchCode, 3);
            string sItemCode = GetCorrectCodeString(iItemCode, 2);
            string sShapeCode = iShapeCode.ToString();

            crRpt.Customer_Program(sBatchCode, sItemCode, sShapeCode, sGroupCode, sPartName);
            crRpt.Print();
        }

        /// <summary>
        /// Stretches image to correct 
        /// </summary>
        /// <param name="pbPicture"></param>
        public static void ShowCorrectPicture(ref PictureBox pbPicture)
        {
            if (pbPicture.Image == null)
                return;
            if (pbPicture.Image.Size.Height > pbPicture.Size.Height || pbPicture.Image.Size.Width > pbPicture.Size.Width)
                Service.DrawAdjustShapeImage(pbPicture, pbPicture.Image, -1, 0, 0, 0);
            //pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pbPicture.SizeMode = PictureBoxSizeMode.CenterImage;

        }


        /*
        /// <summary>
        /// Creates XPath string
        /// </summary>
        /// <param name="cPressedKeys">already pressed keys</param>
        /// <param name="iPartCodes">available codes for the current item part</param>
        /// <returns>XPath string</returns>
        private static string CreateFilteredXPath(char[] cPressedKeys, int[] iPartCodes)
        {
            if(iPartCodes.Length==0)
                return "";

            string sXPath = "/keyboard/map/itemtype/";

            int i;
            if(cPressedKeys.Length == 1)
                sXPath += cPressedKeys[0]+"/*/
        /*[";
else
{
for(i=0; i<cPressedKeys.Length-1; i++)
sXPath += cPressedKeys[i]+"/nextavailable/";
sXPath += cPressedKeys[i]+"[";
}
			
for(i=0; i<iPartCodes.Length-1; i++)
sXPath += "(valuecode="+iPartCodes[i]+") or ";
sXPath += "(valuecode="+iPartCodes[i]+")]";

return sXPath;
}*/

        /// <summary>
        /// Creates filtered xPath string for current part characteristic
        /// </summary>
        /// <param name="cPressedKeys">pressed keys</param>
        /// <param name="iPartCharCodes">current part characteristic codes</param>
        /// <param name="bIsFinish">indicates wether xPath string is searching end element</param>
        /// <param name="bIsValue">indicates wether pressed key is value</param>
        /// <returns>xPath string</returns>
        private static string CreateFilteredCharXPath(char[] cPressedKeys, int[] iPartCharCodes, bool bIsFinish, bool bIsValue, string sTagBegin)
        {
            if (iPartCharCodes.Length == 0)
                return "";

            string sXPath;
            if (bIsValue) sXPath = "/keymap/charvalue";
            else sXPath = "/keymap/characteristic";

            foreach (char cPressedKey in cPressedKeys)
                sXPath += "/" + sTagBegin + cPressedKey;

            if (bIsFinish) return sXPath;

            sXPath += "/*[";
            int i;
            for (i = 0; i < iPartCharCodes.Length - 1; i++)
                sXPath += "(.//@code=" + iPartCharCodes[i] + ") or ";
            sXPath += "(.//@code=" + iPartCharCodes[i] + ")]";

            return sXPath;
        }

        /// <summary>
        /// Creates xPath string for mode selecting
        /// </summary>
        /// <param name="cPressedKeys">pressed keys</param>
        /// <returns>xpath string</returns>
        private static string CreateModeXPath(char[] cPressedKeys, bool bIsEnd, string sTagBegin)
        {
            string sXPath = "/keymap/controls";
            foreach (char cPressedKey in cPressedKeys)
                sXPath += "/" + sTagBegin + cPressedKey;

            if (!bIsEnd) sXPath += "/*";

            return sXPath;
        }

    }



    /// <summary>
    /// Class contains commonly used functions in Clarity, Color and Measure forms
    /// </summary>
    public class GraderWork
    {
        /// <summary>
        /// Key press event handler for choosing mode
        /// </summary>
        /// 
        /*
        private static int[] CODE_FORMAT = new int[3] {5,3,2};
        // first dot position in the code
        private static int DOT1 = CODE_FORMAT[0];
        // second dot position in the code
        private static int DOT2 = CODE_FORMAT[0]+CODE_FORMAT[1];
        // third dot position in the code
        private static int DOT3 = CODE_FORMAT[0]+CODE_FORMAT[1]+CODE_FORMAT[2];
        */

        public static void ModeKeyPress(KeyPressEventArgs e,
                                        string sFileName,
                                        ref string sMode,
                                        ref RadioButton rbNextItem,
                                        ref RadioButton rbGrade,
                                        ref RadioButton rbComment,
                                        ref RadioButton rbLaserInscription,
                                        ref Label lWarnings,
                                        ref int CommentCode,
                                        ref int InscriptionCode,
                                        ref DataSet dsBatchSet,
                                        int curOrderCode,
                                        int curEntryBatchCode,
                                        int curBatchCode,
                                        int curItemCode,
                                        ref TextBox tbItemsNotDone,
                                        ref TextBox tbItemsDone)
        {
            try
            {


                if (e.KeyChar == 27)//escape value
                    throw new Exception("");

                sMode += e.KeyChar.ToString();
                char[] cEnteredChars = sMode.ToCharArray();
                if (GraderLib.IsAvailableEndModeKey(cEnteredChars, sFileName))
                {
                    int iModeCode;
                    string ssMode = GraderLib.GetMode(cEnteredChars, sFileName, out iModeCode);
                    switch (ssMode.ToLower().Trim())
                    {
                        case GraderLib.NextItem:
                            DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                            dvItems.RowFilter = "OrderCode=" + curOrderCode + " and EntryBatchCode=" + curEntryBatchCode + " and BatchCode=" + curBatchCode + " and ItemCode=" + curItemCode;
                            if (dvItems.Count == 1)
                                dvItems[0]["IsDone"] = 1;
                            GraderLib.UpdateDoneNotDoneItemBoxes(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, ref tbItemsNotDone, ref tbItemsDone);
                            rbNextItem.Checked = false;
                            rbNextItem.Checked = true;
                            lWarnings.Text = "Enter next item code or press 'Esc' and then 'Enter' to close current batch, please";
                            //throw new Exception("Enter next item code or press 'Esc' and then 'Enter' to close current batch, please");
                            break;

                        case GraderLib.Grade:
                            rbGrade.Checked = false;
                            rbGrade.Checked = true;
                            break;

                        case GraderLib.Comment:
                            CommentCode = iModeCode;
                            rbComment.Checked = false;
                            rbComment.Checked = true;
                            break;

                        case GraderLib.LaserInscription:
                            InscriptionCode = iModeCode;
                            rbLaserInscription.Checked = false;
                            rbLaserInscription.Checked = true;
                            break;

                        default:
                            throw new Exception("There is no such mode available on this program.\nTry to enter another character to choose mode and edit mode characters in the keymap");
                    }
                }
            }
            catch (Exception eEx)
            {
                sMode = "";
                e.Handled = true;
                lWarnings.Text = eEx.Message;
            }
        }

        /// <summary>
        /// Key press event handler for choosing mode
        /// </summary>
        public static void ModeKeyPress(KeyPressEventArgs e,
                                        string sFileName,
                                        ref string sMode,
                                        ref RadioButton rbNextItem,
                                        ref RadioButton rbGrade,
                                        ref Label lWarnings,
                                        ref DataSet dsBatchSet,
                                        int curOrderCode,
                                        int curEntryBatchCode,
                                        int curBatchCode,
                                        int curItemCode,
                                        ref TextBox tbItemsNotDone,
                                        ref TextBox tbItemsDone)
        {
            try
            {
                if (e.KeyChar == 27)//escape value
                    throw new Exception("");

                sMode += e.KeyChar.ToString();
                char[] cEnteredChars = sMode.ToCharArray();
                if (GraderLib.IsAvailableEndModeKey(cEnteredChars, sFileName))
                {
                    int iModeCode;
                    string ssMode = GraderLib.GetMode(cEnteredChars, sFileName, out iModeCode);
                    switch (ssMode.ToLower().Trim())
                    {
                        case GraderLib.NextItem:
                            DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                            dvItems.RowFilter = "OrderCode=" + curOrderCode + " and EntryBatchCode=" + curEntryBatchCode + " and BatchCode=" + curBatchCode + " and ItemCode=" + curItemCode;
                            if (dvItems.Count == 1)
                                dvItems[0]["IsDone"] = 1;
                            GraderLib.UpdateDoneNotDoneItemBoxes(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, ref tbItemsNotDone, ref tbItemsDone);
                            rbNextItem.Checked = false;
                            rbNextItem.Checked = true;
                            //throw new Exception("Enter next item code or press 'Esc' and then 'Enter' to close current batch, please");
                            lWarnings.Text = "Enter next item code or press 'Esc' and then 'Enter' to close current batch, please";
                            break;

                        case GraderLib.Grade:
                            rbGrade.Checked = false;
                            rbGrade.Checked = true;
                            break;

                        default:
                            throw new Exception("There is no such mode available on this program.\nTry to enter another character to choose mode and edit mode characters in the keymap");
                    }
                }
            }
            catch (Exception eEx)
            {
                sMode = "";
                e.Handled = true;
                lWarnings.Text = eEx.Message;
            }
        }

        /// <summary>
        /// Key press event handler for choosing grade
        /// </summary>
        public static void GradeKeyPress(KeyPressEventArgs e,
                                            ref GraderLib.WorkMode wmMode,
                                            string sFileName,
                                            ref DataSet dsBatchSet,
                                            ref int curOrderCode,
                                            ref int curEntryBatchCode,
                                            ref int curBatchCode,
                                            ref int curItemCode,
                                            ref int curPartId,
                                            ref string curPartName,
                                            ref bool bJustEntered,
                                            ref string sGrade,
                                            ref StatusBar sbStatus,
                                            ref Label lWarnings,
                                            ref Label lCurrent,
                                            ref Label lHistory1,
                                            ref Label lHistory2,
                                            ref Label lHistory3,
                                            ref Label lPart,
                                            ref TextBox tbItemsDone,
                                            ref TextBox tbItemsNotDone,
                                            ref RadioButton rbNextItem,
                                            ref GraderLib.TypeInfo tiChar,
                                            ref PictureBox pbShape,
                                            ref PictureBox pbItemPicture,
                                            int FormType,
                                            ref TextBox tbComment,
                                            ref TextBox tbLaserInscription,
                                            int InscriptionCode,
                                            ref Label lMeasures)
        {
            try
            {
                //lWarnings.Text = "";
                if (!GraderLib.IsChar(e.KeyChar))
                    return;

                sGrade += e.KeyChar.ToString();
                sbStatus.Text = sGrade;
                char[] cEnteredChars = sGrade.ToCharArray();

                #region EnteringIntegerValue
                if (wmMode == GraderLib.WorkMode.GradeEnteringIntegerValue)
                {
                }
                #endregion

                #region EnteringStringValue mode
                if (wmMode == GraderLib.WorkMode.GradeEnteringStringValue)
                {
                }
                #endregion

                #region EnteringEnumValue mode
                if (wmMode == GraderLib.WorkMode.GradeEnteringEnumValue)
                {
                    int[] iPartValueCodes = GraderLib.GetPartValueCodes(dsBatchSet,
                                                                        curOrderCode,
                                                                        curEntryBatchCode,
                                                                        curBatchCode,
                                                                        curItemCode,
                                                                        curPartId,
                                                                        FormType,
                                                                        tiChar);
                    if (GraderLib.IsAvailableEndKey(cEnteredChars, iPartValueCodes, sFileName, true))
                    {
                        SubmitValueId(cEnteredChars,
                                        iPartValueCodes,
                                        sFileName,
                                        curOrderCode,
                                        curEntryBatchCode,
                                        curBatchCode,
                                        curItemCode,
                                        curPartId,
                                        ref dsBatchSet,
                                        FormType);

                        if (FormType == GraderLib.Codes.Measure)
                            wmMode = GraderLib.WorkMode.GradeEnteringCharacteristic;
                        else
                            wmMode = GraderLib.WorkMode.GradeEnteringEnumValue;

                        if (FormType != GraderLib.Codes.Clarity)
                        {
                            UpdateSubmit(ref dsBatchSet,
                                            ref curOrderCode,
                                            ref curEntryBatchCode,
                                            ref curBatchCode,
                                            ref curItemCode,
                                            ref curPartName,
                                            ref curPartId,
                                            ref lPart,
                                            ref lCurrent,
                                            ref lHistory1,
                                            ref lHistory2,
                                            ref lHistory3,
                                            ref tbItemsDone,
                                            ref tbItemsNotDone,
                                            ref rbNextItem,
                                            ref pbShape,
                                            ref pbItemPicture,
                                            ref lMeasures);
                        }
                        else
                        {
                            UpdateSubmit(ref dsBatchSet,
                                            ref curOrderCode,
                                            ref curEntryBatchCode,
                                            ref curBatchCode,
                                            ref curItemCode,
                                            ref curPartName,
                                            ref curPartId,
                                            ref lPart,
                                            ref lCurrent,
                                            ref lHistory1,
                                            ref lHistory2,
                                            ref lHistory3,
                                            ref tbItemsDone,
                                            ref tbItemsNotDone,
                                            ref rbNextItem,
                                            ref pbShape,
                                            ref pbItemPicture,
                                            ref tbComment,
                                            ref tbLaserInscription,
                                            InscriptionCode,
                                            ref lMeasures);
                        }
                    }

                    char[] cAvailableKeys = GraderLib.GetNextAvailableCharKeys(cEnteredChars, iPartValueCodes, sFileName, true);
                    lWarnings.Text = "Available keys to press next: ";
                    foreach (char cKey in cAvailableKeys)
                        lWarnings.Text += cKey + " ";
                }
                #endregion

                #region EnteringCharacteristic mode
                if (wmMode == GraderLib.WorkMode.GradeEnteringCharacteristic)
                {
                    /*if(bJustEntered)
                    {
                        bJustEntered = false;
                        throw new Exception("Enter characteristic of the current part");
                    }*/

                    int[] iPartCharCodes = GraderLib.GetPartCharCodes(dsBatchSet,
                                                                        curOrderCode,
                                                                        curEntryBatchCode,
                                                                        curBatchCode,
                                                                        curItemCode,
                                                                        curPartId);
                    if (GraderLib.IsAvailableEndKey(cEnteredChars, iPartCharCodes, sFileName, false))
                    {
                        tiChar = GraderLib.GetCharInfo(cEnteredChars, iPartCharCodes, sFileName);
                        if (tiChar.sCharType == "string")
                        {
                            wmMode = GraderLib.WorkMode.GradeEnteringStringValue;
                            throw new Exception("Enter string characteristic value and press enter when finished");
                        }
                        if (tiChar.sCharType == "enum")
                        {
                            wmMode = GraderLib.WorkMode.GradeEnteringEnumValue;
                            throw new Exception("Enter next symbol");
                        }
                        if (tiChar.sCharType == "integer")
                        {
                            wmMode = GraderLib.WorkMode.GradeEnteringIntegerValue;
                            throw new Exception("Enter integer characteristic value and press enter when finished");
                        }
                    }

                    char[] cAvailableKeys = GraderLib.GetNextAvailableCharKeys(cEnteredChars, iPartCharCodes, sFileName, false);
                    lWarnings.Text = "Available keys to press next: ";
                    foreach (char cKey in cAvailableKeys)
                        lWarnings.Text += cKey + " ";
                }
                #endregion
            }
            catch (Exception eEx)
            {
                sGrade = "";
                sbStatus.Text = "";
                e.Handled = true;
                //mmMode = Measuremode.GradeEnteringCharacteristic;
                lWarnings.Text = eEx.Message;
            }
        }

        /// <summary>
        /// Key press event handler for entering next item
        /// </summary>
        public static void NextKeyPress(KeyPressEventArgs e,
                                        ref Timer timer,
                                        ref bool bJustEntered,
                                        ref GraderLib.WorkMode wmMode,
                                        ref string sNext,
                                        ref Label lPart,
                                        ref Label lCurrent,
                                        ref Label lBatchCode,
                                        ref Label lItemCode,
                                        ref Label lWarnings,
                                        ref Label lHistory1,
                                        ref Label lHistory2,
                                        ref Label lHistory3)
        {
            if (!GraderLib.IsChar(e.KeyChar))
                return;

            /*if(bJustEntered)
            {
                bJustEntered = false;
                return;
            }*/

            timer.Stop();
            timer.Interval = 1000;
            timer.Start();

            if (wmMode != GraderLib.WorkMode.NextEnteringCode)
            {
                lPart.Text = "";
                lCurrent.Text = "";
                lHistory1.Text = "";
                lHistory2.Text = "";
                lHistory3.Text = "";
                lWarnings.Text = "";
                lBatchCode.Text = "";
                lItemCode.Text = "";
                wmMode = GraderLib.WorkMode.NextEnteringCode;
            }

            sNext += e.KeyChar.ToString();
            //			if(lBatchCode.Text.Length < GraderLib.BATCH_CODE)
            //				lBatchCode.Text += e.KeyChar.ToString();
            //			if(lItemCode.Text.Length < GraderLib.ITEM_CODE)
            lItemCode.Text += e.KeyChar.ToString();
        }

        /// <summary>
        /// Checks digit value for correct format before submiting
        /// </summary>
        public static void CheckSubmitValue(string sGrade, GraderLib.TypeInfo tiChar)
        {
            string spr = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

            int iMinDigits = tiChar.iMinDotDigits;
            int iMaxDigits = tiChar.iMaxDotDigits;

            if (iMinDigits < 0)
                throw new Exception("xml-parameter 'mindotdigits' must be positive for entered measure.");
            if (iMaxDigits < 0)
                throw new Exception("xml-parameter 'maxdotdigits' must be positive for entered measure.");
            if (iMaxDigits < iMinDigits)
                throw new Exception("xml-parameter 'maxdotdigits' must be greater then 'mindotdigits' for entered measure.");

            string[] sValues = sGrade.Trim().Split(spr.ToCharArray());
            if (sValues.Length > 2)
                throw new Exception("Input string was not in a correct format.\nIt must have minimum " + iMinDigits + " and maximum " + iMaxDigits + " after separator digits.\nTry to re-enter value.");

            int iValue1 = Convert.ToInt32(sValues[0]);
            if (sValues.Length == 2)
            {
                int iValue2 = Convert.ToInt32(sValues[1]);
                if (sValues[1].Length > iMaxDigits || sValues[1].Length < iMinDigits)
                    throw new Exception("Input string was not in a correct format.\nIt must have minimum " + iMinDigits + " and maximum " + iMaxDigits + " after separator digits.\nTry to re-enter value.");
            }
        }

        /// <summary>
        /// Submits digit or string value
        /// </summary>
        public static void SubmitValue(string sValueColumnName, string sGrade, int curPartId, int curItemCode, ref DataSet dsBatchSet, GraderLib.TypeInfo tiChar)
        {
            string sCurOrderCode;
            string sCurBatchCode;
            string item = "";
            bool isWeight = false;

            DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);
            DataView dvVals = new DataView(dsBatchSet.Tables["tblValues"]);
            DataView dvVals0 = new DataView(dsBatchSet.Tables["tblValues0"]);
            dvChars.RowFilter = "CharCode = '" + tiChar.iCharCode + "' and PartId ='" + curPartId + "' and ItemCode ='" + curItemCode + "'";

            string sPartName = dvChars[0]["PartName"].ToString();
            string sMeasureName = dvChars[0]["CharName"].ToString();

            DataRow[] dItem = dsBatchSet.Tables["tblItems"].Select("ItemCode = '" + curItemCode.ToString() + "'");
            if (dItem.Length != 0)
            {
                sCurOrderCode = dItem[0]["OrderCode"].ToString();
                sCurBatchCode = dItem[0]["BatchCode"].ToString();
                item = Service.FillToFiveChars(sCurOrderCode) + "." + Service.FillToFiveChars(sCurOrderCode) + "." + Service.FillToThreeChars(sCurBatchCode) + "." + Service.FillToTwoChars(curItemCode.ToString());
            }
            if (tiChar.iCharCode == 2 || tiChar.iCharCode == 4 || tiChar.iCharCode == 5 || tiChar.iCharCode == 7)
            {
                isWeight = true;
                if (Convert.ToDouble(sGrade) > 9.9999)
                {
                    if (MessageBox.Show(sMeasureName + " " + sGrade + " for Item " + item + " looks incorrect. \nDo you want to save " + sMeasureName + " " + sGrade + "?", sMeasureName + " is too big", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                        return;
                }
            }

            string sarinWeight = "";
            if (sPartName.ToUpper().IndexOf("DIAMOND") > -1 && isWeight)
            {
                DataRow[] dRS = dsBatchSet.Tables["tblValues"].Select("MeasureID = '6' and ItemCode = '" + curItemCode.ToString() + "' and PartID = '" + curPartId.ToString() + "'");
                if (dRS.Length != 0 && sGrade.Length != 0)
                {
                    sarinWeight = dRS[0]["Value"].ToString();
                    if (sarinWeight != "" && sGrade != "")
                    {
                        if (System.Math.Abs(System.Convert.ToDouble(sarinWeight) - System.Convert.ToDouble(sGrade)) > 0.02)
                        {
                            if (MessageBox.Show(sMeasureName + " - Sarin Weight for Item " + item + " looks incorrect.\nDo you want to save current values?", "Weights comparison failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                return;
                        }
                    }
                }
            }

            int iCharId;

            //dvVView.RowFilter = "MeasureID='"+iCharId+"' and ItemCode='"+curItemCode+"' and PartId='"+curPartId+"'";

            foreach (DataRowView drCharRow in dvChars)
            {
                iCharId = Convert.ToInt32(drCharRow["CharId"]);
                sPartName = drCharRow["PartName"].ToString();
                dvVals.RowFilter = "MeasureID= '" + iCharId + "' and ItemCode = '" + curItemCode + "' and PartId = '" + curPartId + "'";
                dvVals0.RowFilter = "MeasureID= '" + iCharId + "' and ItemCode = '" + curItemCode + "' and PartId = '" + curPartId + "'";
                //dvVals.RowFilter = "MeasureID= " + iCharId + " and PartId="+curPartId+" and ItemCode="+curItemCode;
                //dvVals0.RowFilter = "MeasureID="+iCharId+" and PartId="+curPartId+" and ItemCode="+curItemCode;
                dvVals[0][sValueColumnName] = sGrade;
                dvVals0[0][sValueColumnName] = sGrade;
                dvVals[0]["IsDone"] = 1;
                dvVals0[0]["IsDone"] = 1;
            }
        }

        /// <summary>
        /// Submits enum value
        /// </summary>
        public static void SubmitValueId(char[] cEnteredChars, int[] iPartValueCodes, string sFileName, int curOrderCode, int curEntryBatchCode, int curBatchCode, int curItemCode, int curPartId, ref DataSet dsBatchSet, int iFormType)
        {
            int iCode = GraderLib.GetCharValueCode(cEnteredChars, iPartValueCodes, sFileName);
            int[] iCharIds = GraderLib.GetPartCharIds(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, curPartId);
            int iValueId;

            foreach (int iCharId in iCharIds)
            {
                DataView dvVCView = new DataView(dsBatchSet.Tables["tblValueCodes"]);
                dvVCView.RowFilter = "ValueCode='" + iCode + "' and CharId='" + iCharId + "'";
                if (dvVCView.Count > 0)
                {
                    iValueId = Convert.ToInt32(dvVCView[0]["ValueId"]);
                    DataView dvVView = new DataView(dsBatchSet.Tables["tblValues"]);
                    DataView dvVView0 = new DataView(dsBatchSet.Tables["tblValues0"]);
                    dvVView.RowFilter = "MeasureID='" + iCharId + "' and ItemCode='" + curItemCode + "' and PartId='" + curPartId + "'";
                    dvVView0.RowFilter = "MeasureID='" + iCharId + "' and ItemCode='" + curItemCode + "' and PartId='" + curPartId + "'";
                    dvVView[0]["ValueId"] = iValueId;
                    dvVView0[0]["ValueId"] = iValueId;
                    dvVView[0]["IsDone"] = 1;
                    dvVView0[0]["IsDone"] = 1;

                    if (iCharId == GraderLib.Codes.Shape)
                        GraderLib.UpdateShapePicture(iValueId, curOrderCode, curBatchCode, curItemCode, curPartId, ref dsBatchSet, iFormType);
                }
            }
        }

        /// <summary>
        /// Updates part after submit value
        /// </summary>
        public static void UpdateSubmit(ref DataSet dsBatchSet,
                                            ref int curOrderCode,
                                            ref int curEntryBatchCode,
                                            ref int curBatchCode,
                                            ref int curItemCode,
                                            ref string curPartName,
                                            ref int curPartId,
                                            ref Label lPart,
                                            ref Label lCurrent,
                                            ref Label lHistory1,
                                            ref Label lHistory2,
                                            ref Label lHistory3,
                                            ref TextBox tbItemsDone,
                                            ref TextBox tbItemsNotDone,
                                            ref RadioButton rbNextItem,
                                            ref PictureBox pbShape,
                                            ref PictureBox pbItemPicture,
                                            ref Label lMeasures)
        {
            GraderLib.UpdateCurrentPartInfo(dsBatchSet,
                                            curOrderCode,
                                            curEntryBatchCode,
                                            curBatchCode,
                                            curItemCode,
                                            curPartName,
                                            curPartId,
                                            "tblHistory1",
                                            "tblHistory2",
                                            "tblHistory3",
                                            ref lPart,
                                            ref lCurrent,
                                            ref lHistory1,
                                            ref lHistory2,
                                            ref lHistory3,
                                            ref pbShape,
                                            ref pbItemPicture,
                                            ref lMeasures);
            //if(!GraderLib.IsPartWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, curPartId, false))
            //	throw new Exception("Enter another characteristic of the current part, please");

            throw new Exception("Press 'Esc' and then 'Enter' to choose next part, or enter another characteristic of the current part, please");
            #region old code
            /*//GraderLib.NextPartName(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref curPartName, ref curPartId);
			//GraderLib.UpdateCurrentPartInfo(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, curPartName, curPartId, "tblHistory1", "tblHistory2", "tblHistory3", ref lPart, ref lCurrent, ref lHistory1, ref lHistory2, ref lHistory3, ref pbShape, ref pbItemPicture);

			if(!GraderLib.IsItemWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode))
				throw new Exception("Part was worked up. Enter characteristic of the next part, please");

			//GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, false);
			GraderLib.UpdateDoneNotDoneItemBoxes(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, ref tbItemsNotDone, ref tbItemsDone);
			//GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, true);

			if(!GraderLib.IsBatchWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode))
			{
				rbNextItem.Checked = true;
				throw new Exception("Item was worked up. Enter next item code, please");
			}
						
			Service.UpdateMeasureBatchInfo(dsBatchSet);
			tbItemsDone.Text = "";
			tbItemsNotDone.Text = "";
			lHistory1.Text = "";
			lHistory2.Text = "";
			lHistory3.Text = "";
			lPart.Text = "";
			lCurrent.Text = "";
			rbNextItem.Checked = true;
			dsBatchSet = null;
			throw new Exception("Batch was worked up. Enter next batch item code, please");*/
            #endregion
        }
        /// <summary>
        /// Updates part after submit value
        /// </summary>
        public static void UpdateSubmit(ref DataSet dsBatchSet,
                                        ref int curOrderCode,
                                        ref int curEntryBatchCode,
                                        ref int curBatchCode,
                                        ref int curItemCode,
                                        ref string curPartName,
                                        ref int curPartId,
                                        ref Label lPart,
                                        ref Label lCurrent,
                                        ref Label lHistory1,
                                        ref Label lHistory2,
                                        ref Label lHistory3,
                                        ref TextBox tbItemsDone,
                                        ref TextBox tbItemsNotDone,
                                        ref RadioButton rbNextItem,
                                        ref PictureBox pbShape,
                                        ref PictureBox pbItemPicture,
                                        ref TextBox tbComment,
                                        ref TextBox tbLaserInscription,
                                        int InscriptionCode,
                                        ref Label lMeasures)
        {
            GraderLib.UpdateCurrentPartInfo(dsBatchSet,
                                            curOrderCode,
                                            curEntryBatchCode,
                                            curBatchCode,
                                            curItemCode,
                                            curPartName,
                                            curPartId,
                                            InscriptionCode,
                                            "tblHistory1",
                                            "tblHistory2",
                                            "tblHistory3",
                                            ref lPart,
                                            ref lCurrent,
                                            ref tbComment,
                                            ref tbLaserInscription,
                                            ref lHistory1,
                                            ref lHistory2,
                                            ref lHistory3,
                                            ref pbShape,
                                            ref pbItemPicture,
                                            ref lMeasures,
                                            false);
            //if(!GraderLib.IsPartWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, curPartId, false))
            //	throw new Exception("Enter another characteristic of the current part, please");

            throw new Exception("Press 'Esc' and then 'Enter' to choose next part, or enter another characteristic of the current part, please");
        }
        /// <summary>
        /// Selects next part when all measures are submited
        /// </summary>
        public static void SelectNextPart(ref DataSet dsBatchSet,
                                            ref int curOrderCode,
                                            ref int curEntryBatchCode,
                                            ref int curBatchCode,
                                            ref int curItemCode,
                                            ref string curPartName,
                                            ref int curPartId,
                                            ref Label lPart,
                                            ref Label lCurrent,
                                            ref Label lHistory1,
                                            ref Label lHistory2,
                                            ref Label lHistory3,
                                            ref TextBox tbItemsDone,
                                            ref TextBox tbItemsNotDone,
                                            ref RadioButton rbNextItem,
                                            ref PictureBox pbShape,
                                            ref PictureBox pbItemPicture,
                                            int FormType,
                                            bool bIsManual,
                                            ref Label lMeasures)
        {

            /**
             * by vetal_242 
             * 03.21.2006
             * */
            if (curPartName.ToLower().IndexOf("diamond") != -1)
            {
                string item = Service.FillToFiveChars(curOrderCode.ToString()) + "." + Service.FillToFiveChars(curOrderCode.ToString()) + "." + Service.FillToThreeChars(curBatchCode.ToString()) + "." + Service.FillToTwoChars(curItemCode.ToString());
                DataRow[] dRS = dsBatchSet.Tables["tblValues"].Select("MeasureID = '6' and ItemCode = '" + curItemCode.ToString() + "' and PartID = '" + curPartId.ToString() + "'");
                DataRow[] drMeasureWeight = dsBatchSet.Tables["tblValues"].Select("MeasureID = '4' and ItemCode = '" + curItemCode.ToString() + "' and PartID = '" + curPartId.ToString() + "'");
                if (dRS.Length != 0 && drMeasureWeight.Length != 0)
                {
                    string sarinWeight = dRS[0]["Value"].ToString();
                    string measureWeight = drMeasureWeight[0]["Value"].ToString();
                    //if sarinWeight is empty - mountedDiamond				
                    if (sarinWeight != "" && measureWeight != "")
                    {
                        string shape;
                        string shapeID;
                        DataRow[] drShapeID = dsBatchSet.Tables["tblValues"].Select("MeasureID = '8' and ItemCode = '" + curItemCode.ToString() + "'");
                        if (drShapeID.Length != 0)
                        {
                            shapeID = drShapeID[0]["ValueID"].ToString();
                        }
                        else
                        {
                            shapeID = "";
                        }
                        DataRow[] drShape = dsBatchSet.Tables["tblValueCodes"].Select("ValueId = '" + shapeID + "'");
                        if (drShape.Length != 0)
                        {
                            shape = drShape[0]["ValueName"].ToString();
                        }
                        else
                        {
                            shape = "";
                        }
                        if (shape.ToLower().IndexOf("round") != -1)
                        {
                            if (System.Math.Abs(System.Convert.ToDouble(sarinWeight) - System.Convert.ToDouble(measureWeight)) > 0.01)
                            {
                                if (MessageBox.Show("Measured Weight - Sarin Weight for Item " + item + " looks incorrect. You can re-enter Measured Weight or proceed with current values.\nDo you want to save current values?", "Weights comparison failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                {
                                    MessageBox.Show("Please, enter correct weights", "Re-enter values", MessageBoxButtons.OK);
                                    return;
                                }
                                else
                                {
                                    DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                                    dvItems.RowFilter = "ItemCode = '" + curItemCode + "'";
                                    dvItems[0]["IsBlock"] = "3";
                                }
                            }
                        }
                        else
                        {
                            if (System.Math.Abs(System.Convert.ToDouble(sarinWeight) - System.Convert.ToDouble(measureWeight)) > 0.02)
                            {
                                if (MessageBox.Show("Measured Weight - Sarin Weight for Item " + item + " looks incorrect. You can re-enter Measured Weight or proceed with current values.\nDo you want to save current values?", "Weights campare failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                {
                                    MessageBox.Show("Please, enter correct weights", "Re-enter values", MessageBoxButtons.OK);
                                    return;
                                }
                                else
                                {
                                    DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                                    dvItems.RowFilter = "ItemCode = '" + curItemCode + "'";
                                    dvItems[0]["IsBlock"] = "3";
                                }
                            }
                        }

                        DataRow[] cWR = dsBatchSet.Tables["tblValues"].Select("MeasureID = '7' and ItemCode = '" + curItemCode.ToString() + "'");
                        if (cWR.Length != 0)
                        {
                            string customerWeight = cWR[0]["Value"].ToString();
                            if (customerWeight != "")
                            {
                                if (System.Math.Abs(System.Convert.ToDouble(customerWeight) - System.Convert.ToDouble(measureWeight)) > 0.02)
                                {
                                    if (MessageBox.Show("Measured Weight - Customer Weight for Item " + item + " looks incorrect. You can re-enter Measured Weight or proceed with current values.\nDo you want to save current values?", "Measure Weight failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                    {
                                        MessageBox.Show("Please, enter correct weights", "Re-enter values", MessageBoxButtons.OK);
                                        return;
                                    }
                                    else
                                    {
                                        DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                                        dvItems.RowFilter = "ItemCode = '" + curItemCode + "'";
                                        dvItems[0]["IsBlock"] = "3";
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    DataRow[] drCustomerWeight = dsBatchSet.Tables["tblValues"].Select("MeasureID = '7' and ItemCode = '" + curItemCode.ToString() + "'");
                    DataRow[] drCalculatedWeight = dsBatchSet.Tables["tblValues"].Select("MeasureID = '5' and ItemCode = '" + curItemCode.ToString() + "'");

                    if (drCalculatedWeight.Length != 0 && drCustomerWeight.Length != 0)
                    {
                        string customerWeight = drCustomerWeight[0]["Value"].ToString();
                        string calculatedWeight = drCalculatedWeight[0]["Value"].ToString();
                        if (customerWeight != "" && calculatedWeight != "")
                        {
                            if (System.Math.Abs(System.Convert.ToDouble(customerWeight) - System.Convert.ToDouble(calculatedWeight)) > 0.02)
                            {
                                if (MessageBox.Show("Calculated Weight - Customer Weight for Item " + item + " looks incorrect. You can re-enter Measured Weight or proceed with current values.\nDo you want to save current values?", "Measure Weight failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {
                                    DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                                    dvItems.RowFilter = "ItemCode = '" + curItemCode + "'";
                                    dvItems[0]["IsBlock"] = "3";
                                }
                            }
                        }
                    }
                }
            }
            //end by vetal_242

            GraderLib.NextPartName(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref curPartName, ref curPartId);
            GraderLib.UpdateCurrentPartInfo(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, curPartName, curPartId, "tblHistory1", "tblHistory2", "tblHistory3", ref lPart, ref lCurrent, ref lHistory1, ref lHistory2, ref lHistory3, ref pbShape, ref pbItemPicture, ref lMeasures);

            if (curPartId == 0)
            {
                //if(!GraderLib.IsItemWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, false))
                //	throw new Exception("Part was worked up. Enter characteristic of the next part, please");

                //GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, false);
                DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                dvItems.RowFilter = "OrderCode=" + curOrderCode + " and EntryBatchCode=" + curEntryBatchCode + " and BatchCode=" + curBatchCode + " and ItemCode=" + curItemCode;
                if (dvItems.Count == 1)
                    dvItems[0]["IsDone"] = 1;

                GraderLib.UpdateDoneNotDoneItemBoxes(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, ref tbItemsNotDone, ref tbItemsDone);
                //GraderLib.PutItemInDoneBox(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref tbItemsDone);
                //GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, true);

                //if(!GraderLib.IsBatchWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, false))
                //{
                rbNextItem.Checked = true;
                //throw new Exception("Item was worked up. Enter next item code, please");
                throw new Exception("Enter next item code or press 'Esc' and then 'Enter' to close current batch, please");
                //}

                //TextBox tbLaserInscription = new TextBox();
                //TextBox tbComment = new TextBox();
                //UpdateDbBatch(ref dsBatchSet, ref lPart, ref lCurrent, ref lHistory1, ref lHistory2, ref lHistory3, ref tbItemsDone, ref tbItemsNotDone, ref rbNextItem, ref pbShape, ref pbItemPicture, FormType, ref tbComment, ref tbLaserInscription);
            }
        }
        /// <summary>
        /// Selects next part when all measures are submited
        /// </summary>
        public static void SelectNextPart(ref DataSet dsBatchSet, ref int curOrderCode, ref int curEntryBatchCode, ref int curBatchCode, ref int curItemCode, ref string curPartName, ref int curPartId, ref Label lPart, ref Label lCurrent, ref Label lHistory1, ref Label lHistory2, ref Label lHistory3, ref TextBox tbItemsDone, ref TextBox tbItemsNotDone, ref RadioButton rbNextItem, ref PictureBox pbShape, ref PictureBox pbItemPicture, int FormType, ref TextBox tbComment, ref TextBox tbLaserInscription, int InscriptionCode, bool bIsManual, ref Label lMeasures)
        {
            //GraderLib.UpdateCurrentPartInfo(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, curPartName, curPartId, InscriptionCode, "tblHistory1", "tblHistory2", "tblHistory3", ref lPart, ref lCurrent, ref tbComment, ref tbLaserInscription, ref lHistory1, ref lHistory2, ref lHistory3, ref pbShape, ref pbItemPicture);

            //if(!GraderLib.IsPartWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, curPartId, true))
            //	throw new Exception("Enter another characteristic of the current part, please");


            GraderLib.NextPartName(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref curPartName, ref curPartId);
            GraderLib.UpdateCurrentPartInfo(dsBatchSet,
                                            curOrderCode,
                                            curEntryBatchCode,
                                            curBatchCode,
                                            curItemCode,
                                            curPartName,
                                            curPartId,
                                            InscriptionCode,
                                            "tblHistory1",
                                            "tblHistory2",
                                            "tblHistory3",
                                            ref lPart,
                                            ref lCurrent,
                                            ref tbComment,
                                            ref tbLaserInscription,
                                            ref lHistory1,
                                            ref lHistory2,
                                            ref lHistory3,
                                            ref pbShape,
                                            ref pbItemPicture,
                                            ref lMeasures,
                                            false);

            if (curPartId == 0)
            {
                //if(!GraderLib.IsItemWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, false))
                //	throw new Exception("Part was worked up. Enter characteristic of the next part, please");

                DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                dvItems.RowFilter = "OrderCode=" + curOrderCode + " and EntryBatchCode=" + curEntryBatchCode + " and BatchCode=" + curBatchCode + " and ItemCode=" + curItemCode;
                if (dvItems.Count == 1)
                    dvItems[0]["IsDone"] = 1;

                //GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, false);
                GraderLib.UpdateDoneNotDoneItemBoxes(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, ref tbItemsNotDone, ref tbItemsDone);
                //GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, true);

                //if(!GraderLib.IsBatchWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, false))
                //{
                rbNextItem.Checked = true;
                throw new Exception("Enter next item code or press 'Esc' and then 'Enter' to close current batch, please");
                //}

                //UpdateDbBatch(ref dsBatchSet, ref lPart, ref lCurrent, ref lHistory1, ref lHistory2, ref lHistory3, ref tbItemsDone, ref tbItemsNotDone, ref rbNextItem, ref pbShape, ref pbItemPicture, FormType, ref tbComment, ref tbLaserInscription);
            }
        }

        /// <summary>
        /// Checks for need data in the db. If it's not there calls console utility
        /// </summary>
        public static bool CheckForData(DataSet dsBatchSet, int FormType, int iOrderCode, int iBatchCode, int iItemCode, int iPartId, bool loadItem)
        {
            return false;
            //int[] iArray = {8, 6, 11, 12, 14, 75, 15, 16, 22, 76, 24, 17, 84, 83, 77, 78, 79, 80, 81, 82};
            int[] iArray = { 12 };
            //string sPartID="";
            string sBatchID = "";
            string sNewBatchID = "";
            string sNewItemCode = "";
            string rid;

            string siItemCode = iItemCode.ToString();
            if (FormType == GraderLib.Codes.Clarity || FormType == GraderLib.Codes.Measure)
            {
                foreach (int i in iArray)
                {
                    DataView dvChars = new DataView(dsBatchSet.Tables["tblChars"]);
                    dvChars.RowFilter = "CharCode=" + i;
                    if (dvChars.Count > 0)
                    {
                        int iCharId = Convert.ToInt32(dvChars[0]["CharId"]);
                        int iiPartId = Convert.ToInt32(dvChars[0]["PartId"]);
                        DataView dvValues0 = new DataView(dsBatchSet.Tables["tblValues0"]);
                        dvValues0.RowFilter = "MeasureID = '" + iCharId + "' and ItemCode='" + iItemCode + "'";//+" and PartId="+iiPartId;
                        if (dvValues0.Count > 0)
                        {
                            dvValues0.RowFilter = "MeasureCode='" + 110 + "' or MeasureCode='" + 112 + "'";
                            if (dvValues0.Count > 0 || loadItem)
                            //if((Convert.IsDBNull(dvValues0[0]["ValueId"]) && Convert.IsDBNull(dvValues0[0]["Value"]) && Convert.IsDBNull(dvValues0[0]["StringValue"])) || loadItem)
                            {
                                bool bIsAdd = false;
                                DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
                                dvItems.RowFilter = "OrderCode = '" + iOrderCode + "' and BatchCode = '" + iBatchCode + "' and ItemCode = '" + iItemCode + "'";
                                //foreach(DataRow drItem in dsBatchSet.Tables["tblItems"].Rows)
                                int iCodeLength;
                                foreach (DataRowView drItem in dvItems)
                                {
                                    sBatchID = drItem["BatchID"].ToString();

                                    sNewBatchID = drItem["NewBatchID"].ToString();
                                    sNewItemCode = drItem["NewItemCode"].ToString();
                                    if (drItem["OrderCode"].ToString().Length <= 5) iCodeLength = 5;
                                    else iCodeLength = 6;
                                    string sOrderCode = GraderLib.GetCorrectCodeString(drItem["OrderCode"].ToString(), iCodeLength);
                                    string sBatchCode = GraderLib.GetCorrectCodeString(drItem["BatchCode"].ToString(), 3);
                                    string sItemCode = GraderLib.GetCorrectCodeString(drItem["ItemCode"].ToString(), 2);
                                    //string sFileName = Service.GetServiceCfgParameter("graderDir")+sOrderCode+sBatchCode+sItemCode+".ou1";
                                    string sFileName1 = Client.GetOfficeDirPath("graderDir") + sOrderCode + sBatchCode + sItemCode + ".ou1";
                                    //-------------------
                                    //sd 10.28.2006
                                    string sFileName = sFileName1;
                                    if (!loadItem)
                                    {
                                        //------------------------
                                        string sGNumber = "";
                                        string sPrefix = "";
                                        string sSuffix = "";
                                        string sLightReturnMessage = "";

                                        DataView dvVals = new DataView(dsBatchSet.Tables["tblValues0"]);//tblValues +PartID
                                        dvVals.RowFilter = "ItemCode='" + iItemCode + "'";
                                        DataView dvVC = new DataView(dsBatchSet.Tables["tblValueCodes"]);
                                        DataView dvGNumbers = new DataView(dsBatchSet.Tables["tblValues0"]);
                                        dvGNumbers.RowFilter = "MeasureCode='110' and ItemCode = '" + iItemCode + "'";
                                        //dvVals.RowFilter="(MeasureCode='"+110+"' or MeasureCode='"+112+"') and ItemCode = '"+iItemCode+"'";
                                        Hashtable hsParts = new Hashtable();
                                        foreach (DataRowView drValsRow in dvVals)
                                        {
                                            hsParts[drValsRow["PartID"].ToString()] = null;
                                        }

                                        foreach (String PartID in hsParts.Keys)
                                        {
                                            sGNumber = "";
                                            sPrefix = "";
                                            sSuffix = "";
                                            sLightReturnMessage = "";
                                            sFileName = sFileName1;
                                            dvVals.RowFilter = "MeasureCode = '112' and ItemCode = '" + iItemCode + "' and PartID = '" + PartID + "'"; //Prefix
                                            if (dvVals.Count > 0)
                                            {
                                                sPrefix = dvVals[0]["StringValue"].ToString();

                                                //											if(!Convert.IsDBNull(dvVals[0]["ValueId"]))//111
                                                //											{
                                                //												int iValueId = Convert.ToInt32(dvVals[0]["ValueId"]);
                                                //												dvVC.RowFilter = "ValueId='" + iValueId + "'";
                                                //												if(dvVC.Count != 0)
                                                //												{
                                                //													sPrefix=dvVC[0]["StringValue"].ToString();
                                                //												}
                                                //											}
                                                if (sPrefix.Trim() != "")
                                                    sLightReturnMessage = Service.SetLightReturnData(sOrderCode, sBatchCode, sItemCode, sPrefix, PartID);
                                            }

                                            dvVals.RowFilter = "MeasureCode = '110' and ItemCode = '" + iItemCode + "' and PartID = '" + PartID + "'"; //GNumber
                                            if (dvVals.Count > 0)
                                            {
                                                if (!Convert.IsDBNull(dvVals[0]["Value"]))//110
                                                {
                                                    sGNumber = dvVals[0]["Value"].ToString();
                                                    if (sGNumber.IndexOf(".") > 0)
                                                        sGNumber = sGNumber.Substring(0, sGNumber.IndexOf("."));
                                                }

                                                if (sGNumber == "")
                                                {
                                                    if (!Convert.IsDBNull(dvVals[0]["StringValue"]))//110
                                                    {
                                                        sGNumber = dvVals[0]["StringValue"].ToString();
                                                        if (sGNumber.IndexOf(".") > 0)
                                                            sGNumber = sGNumber.Substring(0, sGNumber.IndexOf("."));
                                                    }
                                                }
                                            }
                                            dvVals.RowFilter = "MeasureCode = '122' and ItemCode = '" + iItemCode + "' and PartID = '" + PartID + "'";

                                            if (dvVals.Count > 0)
                                            {
                                                sSuffix = dvVals[0]["StringValue"].ToString();

                                                //if(!Convert.IsDBNull(dvVals[0]["ValueId"]))//111
                                                //{
                                                //	int iValueId = Convert.ToInt32(dvVals[0]["ValueId"]);
                                                //	dvVC.RowFilter = "ValueId='" + iValueId + "'";
                                                //	if(dvVC.Count != 0)
                                                //	{
                                                //		sPrefix=dvVC[0]["StringValue"].ToString();
                                                //	}
                                                //}
                                            }
                                            //Added 02.14.08
                                            string sFileName2 = Client.GetOfficeDirPath("graderDir") + sPrefix.Trim() + sGNumber.Trim() + sSuffix.Trim() + ".ou1";
                                            if (File.Exists(sFileName2))
                                            {
                                                sFileName = sFileName2 + ";" + sFileName1;
                                                Service.AddGraderData(sFileName, PartID, out rid);
                                                if (rid == "")
                                                    bIsAdd = true;
                                                SetMeasurements(sNewBatchID, sNewItemCode, PartID);
                                            }
                                            //Commented 02.14.08
                                            //										if(sGNumber.Trim()!="" && dvGNumbers.Count > 1)
                                            //										{
                                            //											string myPrefix = (sPrefix.Trim() == ""?"" : sPrefix + "-");
                                            //											string mySuffix = (sSuffix.Trim() == ""?"" : "-" + sSuffix);
                                            //											sGNumber = sGNumber.Trim();
                                            //											if (sGNumber.Length == 9)
                                            //											{
                                            //												sGNumber = "0" + sGNumber;
                                            //											}
                                            //											string sFileName2 =Service.GetServiceCfgParameter("graderDir") + myPrefix + sGNumber + mySuffix + ".ou1";
                                            //								
                                            //											if (File.Exists(sFileName2))
                                            //											{
                                            //												sFileName = sFileName2 + ";" + sFileName1;			
                                            //											}
                                            //											else
                                            //											{
                                            //												sFileName =sFileName1;
                                            //											}
                                            //											
                                            //											Service.AddGraderData(sFileName,PartID, out rid);
                                            //											if(rid=="")
                                            //											bIsAdd = true;
                                            //											SetMeasurements(sNewBatchID, sNewItemCode, PartID);
                                            //										}
                                            //Service.log.Write(@"Entering 'Service.AddGraderData'");

                                            //Service.log.Write(@"Done 'Service.AddGraderData'");

                                            //SetMeasurements(sBatchID, sItemCode, PartID);
                                            //sd 22.12.2006
                                        }
                                    }
                                    //----------------
                                    if (!bIsAdd)
                                    {
                                        DataRow[] drDiamond = dsBatchSet.Tables["tblParts"].Select("PartTypeID in (1,2,3,10,11,12)");
                                        //Service.log.Write(@"Entering 'Service.AddGraderData'");
                                        //Service.AddGraderData(sFileName1,drDiamond[0]["PartID"].ToString(), out rid);
                                        if (File.Exists(sFileName1))
                                        {
                                            Service.AddGraderData(sFileName1, null, out rid);
                                            if (rid == "")
                                                bIsAdd = true;
                                            //Service.log.Write(@"Done 'Service.AddGraderData'");

                                            //SetMeasurements(sBatchID, sItemCode, drDiamond[0]["PartID"].ToString());
                                            //sd 22.12.2006
                                            SetMeasurements(sNewBatchID, sNewItemCode, drDiamond[0]["PartID"].ToString());
                                        }
                                    }
                                }

                                if (bIsAdd)
                                    return true;
                                #region
                                /*if(FormType == GraderLib.Codes.Clarity)
								{
									if(rid=="")
										return true;

									// call spSetItemState
									//Service.SetItemStateByCode(iOrderCode, iBatchCode, iItemCode, 3);

									//DataView dvItems = new DataView(dsBatchSet.Tables["tblItems"]);
									//dvItems.RowFilter = "ItemCode=" + iItemCode;
									//if(dvItems.Count > 0)
									//	dvItems[0]["IsBlock"] = GraderLib.ItemState.Invalid;

									return false;
								}
								if(FormType == GraderLib.Codes.Measure)
								{
									return true;
								}*/
                                #endregion
                            }
                        }
                    }
                }
            }

            //return true;
            return false;
        }
        //		public static void SetLightReturnData(string sOrderCode, string sBatchCode, string sItemCode, string sPrefix, string sPartID)
        //		{
        //			DataSet dsData=new DataSet();
        //			DataTable table=new DataTable("LightReturn");
        //			table.Columns.Add("GroupCode");
        //			table.Columns.Add("BatchCode");
        //			table.Columns.Add("ItemCode");
        //			table.Columns.Add("Prefix");
        //			table.Columns.Add("PartID");
        //			table.Rows.Add(table.NewRow());
        //			table.Rows[0]["GroupCode"] = sOrderCode;
        //			table.Rows[0]["BatchCode"] = sBatchCode;
        //			table.Rows[0]["ItemCode"]=sItemCode;
        //			table.Rows[0]["Prefix"]=sPrefix;
        //			table.Rows[0]["PartID"]=sPartID;
        //			dsData.Tables.Add(table);
        //			Service.ProxyGenericSet(dsData,"Set");
        //		}

        public static void SetMeasurements(string BatchID, string ItemCode, string PartID)
        {
            string rId;
            //@ItemCode,@BatchID,@PartID, @CurrentOfficeID,@AuthorID, @AuthorOfficeID
            DataSet dsData = new DataSet();
            DataTable table = new DataTable("Measurements");
            table.Columns.Add("BatchID");
            table.Columns.Add("ItemCode");
            table.Columns.Add("PartID");
            table.Rows.Add(table.NewRow());
            table.Rows[0]["BatchID"] = BatchID;
            table.Rows[0]["ItemCode"] = ItemCode;
            table.Rows[0]["PartID"] = PartID;
            dsData.Tables.Add(table);
            Service.ProxyGenericSet(dsData, "Set"); //Procedure dbo.spSetMeasurements

            //@rId varchar(150) output,@BatchID,@ItemCode,
            //@CurrentOfficeID,@AuthorID,@AuthorOfficeID
            dsData = new DataSet();
            table = new DataTable("CalcGirdCutCol");
            table.Columns.Add("BatchID");
            table.Columns.Add("ItemCode");
            table.Rows.Add(table.NewRow());
            table.Rows[0]["BatchID"] = BatchID;
            table.Rows[0]["ItemCode"] = ItemCode;
            dsData.Tables.Add(table);
            Service.ProxyGenericSet(dsData, ""); //Procedure dbo.spCalcGirdCutCol
        }

        /**
         * Change item measure from ou1 by pres SARIN button on the ReMeasure form
         * by vetal_242
         * 17.01.2006
        */
        public static bool ChangeDataFromOU1(string iOrderCode, string iBatchCode)
        {
            string sItemCode;
            string sOrderCode = iOrderCode;//.ToString();
            string sBatchCode = iBatchCode;//.ToString();
            int iCodeLength = sOrderCode.Length;
            if (iCodeLength <= 5) iCodeLength = 5;
            else iCodeLength = 6;
            DataTable table = Service.GetItemListByCode(sOrderCode, sBatchCode);

            bool bIsAdd = false;
            foreach (DataRow drItem in table.Rows)
            {
                sOrderCode = GraderLib.GetCorrectCodeString(drItem["OrderCode"].ToString(), iCodeLength);
                sBatchCode = GraderLib.GetCorrectCodeString(drItem["BatchCode"].ToString(), 3);
                sItemCode = GraderLib.GetCorrectCodeString(drItem["ItemCode"].ToString(), 2);

                string sFileName = Client.GetOfficeDirPath("graderDir") + sOrderCode + sBatchCode + sItemCode + ".ou1";

                string rid;
                string sPartID = "";
                //Service.log.Write(@"Entering 'Service.AddGraderData'");

                Service.AddGraderData(sFileName, sPartID, out rid);
                bIsAdd = true;

                //Service.log.Write(@"Done 'Service.AddGraderData'");
            }
            if (bIsAdd)
                return true;
            return false;
        }

        public static bool ChangeDataFromOU11(DataTable dtItems)
        {
            bool bIsAdd = false;
            foreach (DataRow drItem in dtItems.Rows)
            {
                string sOrderCode = Service.FillToFiveChars(drItem["OrderCode"].ToString());
                string sBatchCode = Service.FillToThreeChars(drItem["BatchCode"].ToString());
                string sItemCode = Service.FillToTwoChars(drItem["ItemCode"].ToString());

                string sPrevOrderCode = Service.FillToFiveChars(drItem["PrevOrderCode"].ToString());
                string sPrevBatchCode = Service.FillToThreeChars(drItem["PrevBatchCode"].ToString());
                string sPrevItemCode = Service.FillToTwoChars(drItem["PrevItemCode"].ToString());

                string sPrefix = drItem["Prefix"].ToString().Trim();
                string sGNumber = drItem["GNumber"].ToString().Trim();
				string sSarinID = drItem["SarinID"].ToString().Trim();
                if (sGNumber == "0") sGNumber = "";
                string sPartID = (drItem["PartID"].ToString() == "" ? null : drItem["PartID"].ToString());
                string sSuffix = drItem["Suffix"].ToString();
                string sFileName1 = Client.GetOfficeDirPath("graderDir") + sOrderCode + sBatchCode + sItemCode + ".ou1";
//#if DEBUG
//                sFileName1 = "C:/graderfiles/" + sOrderCode + sBatchCode + sItemCode + ".ou1";
//#endif
                string sFileName = sFileName1;
                //if(sGNumber!="" && sPrefix!="")
                //Changed 02.14.08
                if (sGNumber.Trim() != "")
                {
                    //string myPrefix = (sPrefix == ""?"" : sPrefix + "-");
                    //string mySuffix = (sSuffix == ""?"" : "-" + sSuffix);
                    sGNumber = sGNumber.Trim();
                    if (sGNumber.Length == 9)
                    {
                        sGNumber = "0" + sGNumber;
                    }
                }
				string sFileName2 = "";
				if (sSarinID.Trim().Length > 5)
				{
					sFileName2 = Client.GetOfficeDirPath("graderDir") + sSarinID.Trim() + ".ou1";

					//#if DEBUG
					//                sFileName2 = "C:/graderfiles/" + sPrefix + sGNumber + sSuffix + ".ou1";
					//#endif
					if (File.Exists(sFileName2) && sFileName2.Trim().Length > 8)
					{
						sFileName = sFileName2 + ";" + sFileName1;
					}
					else
					{
						sFileName = sFileName1;
					}
				}
				else
					if (sPrefix.Trim().Length > 5)
					{
						sFileName2 = Client.GetOfficeDirPath("graderDir") + sPrefix.Trim() + ".ou1";
						if (File.Exists(sFileName2) && sFileName2.Trim().Length > 8)
						{
							sFileName = sFileName2 + ";" + sFileName1;
						}
						else
						{
							sFileName = sFileName1;
						}					
					
					}
				else
					if (sSuffix.Trim().Length > 5)
					{
							sFileName2 = Client.GetOfficeDirPath("graderDir") + sSuffix.Trim() + ".ou1";
							if (File.Exists(sFileName2) && sFileName2.Trim().Length > 8)
							{
								sFileName = sFileName2 + ";" + sFileName1;
							}
							else
							{
								sFileName = sFileName1;
							}
					}
				else
					if (sGNumber.Trim().Length > 4)
					{
								sFileName2 = Client.GetOfficeDirPath("graderDir") + sGNumber.Trim() + ".ou1";
								if (File.Exists(sFileName2) && sFileName2.Trim().Length > 8)
								{
									sFileName = sFileName2 + ";" + sFileName1;
								}
								else
								{
									sFileName = sFileName1;
								}							
		
					}
			
                string rid;

                //Service.log.Write(@"Entering 'Service.AddGraderData'");
                Service.AddGraderData(sFileName, sPartID, out rid);
                //Service.log.Write(@"Done 'Service.AddGraderData'");
                if (rid == "")
                    bIsAdd = true;
                else
                {
                    if ((sOrderCode + sBatchCode + sItemCode) !=
                        (sPrevOrderCode + sPrevBatchCode + sPrevItemCode))
                    {
                        sFileName = Client.GetOfficeDirPath("graderDir") + sPrevOrderCode + sPrevBatchCode + sPrevItemCode + ".ou1";
                        rid = "";
                        //Service.log.Write(@"Entering 'Service.AddGraderData'");
                        Service.AddGraderData(sFileName, sPartID, out rid);
                        //Service.log.Write(@"Done 'Service.AddGraderData'");
                        if (rid == "") bIsAdd = true;
                    }

                }


            }
            if (bIsAdd)
                return true;
            return false;
        }

        /// <summary>
        /// Gets Entered item when item code is entered (from forms "Measurement", "Color")
        /// </summary>
        public static void GetEnteredItem(ref string sNext,
                                            ref DataSet dsBatchSet,
                                            ref int curOrderCode,
                                            ref int curEntryBatchCode,
                                            ref int curBatchCode,
                                            ref int curItemCode,
                                            ref string curPartName,
                                            ref int curPartId,
                                            ref int accessCode,
                                            ref Label lPart,
                                            ref Label lCurrent,
                                            ref Label lHistory1,
                                            ref Label lHistory2,
                                            ref Label lHistory3,
                                            ref RadioButton rbNextItem,
                                            ref Label lBatchCode,
                                            ref Label lNewBatchCode,
                                            ref	Label lOldBatchCode,
                                            ref Label lItemCode,
                                            ref Label lNewItemCode,
                                            ref Label lOldItemCode,
                                            ref Label lWarnings,
                                            ref RadioButton rbGrade,
                                            ref TextBox tbItemsDone,
                                            ref TextBox tbItemsNotDone,
                                            int FormType,
                                            ref PictureBox pbShape,
                                            ref PictureBox pbItemPicture,
                                            ref Label lMeasures,
                                            int iFormType,
                                            ref bool bFullAccess)
        {
            try
            {
                //Service.log.Write("Entering GraderLib.ParseCode");
                string sOldNumber = "";
				sNext = Service.GetItemNumberBy7digit(sNext);
                GraderLib.ParseCode(dsBatchSet, sNext, ref curOrderCode, ref curEntryBatchCode, ref curBatchCode, ref curItemCode, ref sOldNumber);
                //Service.log.Write("Done GraderLib.ParseCode");

                //Service.log.Write("OrderCode="+curOrderCode);
                //Service.log.Write("BatchCode="+curBatchCode);
                //Service.log.Write("ItemCode="+curItemCode);

                if (dsBatchSet != null)
                {

                    //					if(FormType == GraderLib.Codes.Measure) //Add 2.08.08
                    //					{
                    //						bool sarinImport = false;
                    //						sarinImport = CheckForData(dsBatchSet, FormType, curOrderCode, curBatchCode, curItemCode, curPartId, true); //Add 2.08.08
                    //					}
                    //Service.log.Write(@"dsBatchSet!=null");
                    //Service.log.Write("Entering 'GraderLib.IsCurrentBatch'");
                    GraderLib.IsCurrentBatch(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref rbNextItem, accessCode, iFormType);
                    //Service.log.Write("Done 'GraderLib.IsCurrentBatch'");

                }

                if (dsBatchSet == null) //GraderLib.IsBatchWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, false)*/)
                {
                    //Service.log.Write(@"dsBatchSet==null");

                    if (FormType == GraderLib.Codes.Measure)
                    {
                        //Service.log.Write(@"FormType == GraderLib.Codes.Measure");
                        //Service.log.Write(@"Entering 'Service.GetMeasureBatchInfo'");
                        dsBatchSet = Service.GetMeasureBatchInfo(curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, bFullAccess);
                        //Service.log.Write(@"Done 'Service.GetMeasureBatchInfo'");
                        //bool bIsImport = false;
                        //Service.log.Write(@"Entering 'CheckForData'");//sd 10.29.06
                        //bool loadItem = true; //Add 02.08.08
                        //bIsImport = CheckForData(dsBatchSet, FormType, curOrderCode, curBatchCode, curItemCode, curPartId, loadItem);
                        //Service.log.Write(@"Done 'CheckForData'");
                        //Service.log.Write(@"bIsImport="+bIsImport.ToString());
                        //Commented by Sasha  02.08.08
                        //						if(bIsImport)
                        //						{
                        //							//Service.log.Write(@"Entering 'Service.GetMeasureInfo'");
                        //							//Next line was commented for debugging purposes 01/23/08
                        //							//dsBatchSet = Service.GetMeasureBatchInfo(curOrderCode, curEntryBatchCode, curBatchCode);
                        //							//Service.log.Write(@"Done 'Service.GetMeasureInfo'");
                        //                		}
                    }
                    if (FormType == GraderLib.Codes.Color)
                        dsBatchSet = Service.GetColorBatchInfo(curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, bFullAccess);
                    /*if(FormType == GraderLib.Codes.Clarity)
                    {
                        dsBatchSet = Service.GetClarityBatchInfo(curOrderCode, curEntryBatchCode, curBatchCode);
                        bool bIsImport = false;
                        bIsImport = CheckForData(dsBatchSet, FormType, curOrderCode, curBatchCode, curItemCode, curPartId);
                        if(bIsImport)
                            dsBatchSet = Service.GetClarityBatchInfo(curOrderCode, curEntryBatchCode, curBatchCode);
                    }*/
                }
                GraderLib.ParseCode(dsBatchSet, sNext, ref curOrderCode, ref curEntryBatchCode, ref curBatchCode, ref curItemCode, ref sOldNumber);

                if (FormType == GraderLib.Codes.Measure)
                {
                    bool bIsImport = true; //Add 02.08.08
                    bIsImport = CheckForData(dsBatchSet, FormType, curOrderCode, curBatchCode, curItemCode, curPartId, true);
                }
                //if(!CheckForData(dsBatchSet, FormType, curOrderCode, curBatchCode, curItemCode, curPartId))
                //	throw new Exception("There is no measure values in the db for entered item");

                //CheckForData(dsBatchSet, FormType, curOrderCode, curBatchCode, curItemCode, curPartId);

                //GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, true);

                GraderLib.UpdateDoneNotDoneItemBoxes(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, ref tbItemsNotDone, ref tbItemsDone);
                //GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, true);

                GraderLib.IsBatchItem(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref rbNextItem, accessCode);
                GraderLib.IsItemBlocked(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref rbNextItem);

                //GraderLib.UpdateItemHistory(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode);
                //GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, true);

                GraderLib.NextPartName(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref curPartName, ref curPartId);
                GraderLib.UpdateCurrentPartInfo(dsBatchSet,
                                                curOrderCode,
                                                curEntryBatchCode,
                                                curBatchCode,
                                                curItemCode,
                                                curPartName,
                                                curPartId,
                                                "tblHistory1",
                                                "tblHistory2",
                                                "tblHistory3",
                                                ref lPart,
                                                ref lCurrent,
                                                ref lHistory1,
                                                ref lHistory2,
                                                ref lHistory3,
                                                ref pbShape,
                                                ref pbItemPicture,
                                                ref lMeasures);
                rbGrade.Checked = true;

                string sItemCode = GraderLib.GetCorrectFullCodeString(curOrderCode, curEntryBatchCode, curBatchCode, curItemCode);
                //string[] sCode = sItemCode.Split('.');
                //string sCurrentCode = sCode[0] + sCode[2] + sCode[3];
                lNewItemCode.Text = sItemCode;
                lNewBatchCode.Text = lNewItemCode.Text.Substring(0, lNewItemCode.Text.Length - 3);

                lItemCode.Text = GraderLib.GetFullCodeStringWithDots(sNext);
                lBatchCode.Text = lItemCode.Text.Substring(0, lItemCode.Text.Length - 3);

                lOldItemCode.Text = GraderLib.GetFullCodeStringWithDots(sOldNumber);
                lOldBatchCode.Text = lOldItemCode.Text.Substring(0, lOldItemCode.Text.Length - 3);
            }
            catch (Exception eEx)
            {
                lBatchCode.Text = "Order#.Batch#";
                lItemCode.Text = "Order#.Batch#.Item#";
                lNewBatchCode.Text = "";
                lNewItemCode.Text = "";
                lOldItemCode.Text = "";
                lOldBatchCode.Text = "";

                curOrderCode = 0;
                curEntryBatchCode = 0;
                curBatchCode = 0;
                curItemCode = 0;
                lWarnings.Text = sNext + ": " + eEx.Message;
            }
            finally
            {
                sNext = "";
            }
        }
        /// <summary>
        /// Gets Entered item when item code is entered (Form "Clarity")
        /// </summary>
        public static void GetEnteredItem(ref string sNext,
                                            ref DataSet dsBatchSet,
                                            ref int curOrderCode,
                                            ref int curEntryBatchCode,
                                            ref int curBatchCode,
                                            ref int curItemCode,
                                            ref string curPartName,
                                            ref int curPartId,
                                            ref int accessCode,
                                            ref Label lPart,
                                            ref Label lCurrent,
                                            ref Label lHistory1,
                                            ref Label lHistory2,
                                            ref Label lHistory3,
                                            ref RadioButton rbNextItem,
                                            ref Label lBatchCode,
                                            ref Label lNewBatchCode,
                                            ref	Label lOldBatchCode,
                                            ref Label lItemCode,
                                            ref Label lNewItemCode,
                                            ref Label lOldItemCode,
                                            ref Label lWarnings,
                                            ref RadioButton rbGrade,
                                            ref TextBox tbItemsDone,
                                            ref TextBox tbItemsNotDone,
                                            int FormType,
                                            ref PictureBox pbShape,
                                            ref PictureBox pbItemPicture,
                                            ref TextBox tbComment,
                                            ref TextBox tbLaserInscription,
                                            int InscriptionCode,
                                            ref Label lMeasures,
                                            int iFormType,
                                            System.Boolean isNewItem,
                                            ref bool bFullAccess)
        {
            try
            {
                //GraderLib.ParseCode(dsBatchSet, tbHiddenNextItem, ref curOrderCode, ref curEntryBatchCode, ref curBatchCode, ref curItemCode);
                string sOldNumber = "";
				sNext = Service.GetItemNumberBy7digit(sNext);
                GraderLib.ParseCode(dsBatchSet, sNext, ref curOrderCode, ref curEntryBatchCode, ref curBatchCode, ref curItemCode, ref sOldNumber);
                if (dsBatchSet != null)
                    GraderLib.IsCurrentBatch(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref rbNextItem, accessCode, iFormType);

                if (dsBatchSet == null/* || GraderLib.IsBatchWorkedUp(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, false)*/)
                {
                    dsBatchSet = Service.GetClarityBatchInfo(curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, bFullAccess);
                    // Commented 4 lines below by Sasha 10/08/09
                    //bool bIsImport = false;
                    //bIsImport = GraderWork.CheckForData(dsBatchSet, GraderLib.Codes.Clarity, curOrderCode, curBatchCode, curItemCode, curPartId,false);
                    //if(bIsImport)
                    //dsBatchSet = Service.GetClarityBatchInfo(curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, bFullAccess);
                }
                GraderLib.ParseCode(dsBatchSet, sNext, ref curOrderCode, ref curEntryBatchCode, ref curBatchCode, ref curItemCode, ref sOldNumber);
                //if(!GraderWork.CheckForData(dsBatchSet, GraderLib.Codes.Clarity, curOrderCode, curBatchCode, curItemCode, curPartId))
                //	throw new Exception("There is no measure values in the db for entered item");
                //GraderWork.CheckForData(dsBatchSet, GraderLib.Codes.Clarity, curOrderCode, curBatchCode, curItemCode, curPartId);

                //GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, false);

                GraderLib.UpdateDoneNotDoneItemBoxes(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, ref tbItemsNotDone, ref tbItemsDone);

                GraderLib.IsBatchItem(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref rbNextItem, accessCode);
                GraderLib.IsItemBlocked(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref rbNextItem);

                //GraderLib.UpdateItemHistory(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode);
                GraderLib.UpdateItemValue(ref dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, true);

                GraderLib.NextPartName(dsBatchSet, curOrderCode, curEntryBatchCode, curBatchCode, curItemCode, ref curPartName, ref curPartId);
                GraderLib.UpdateCurrentPartInfo(dsBatchSet,
                                                curOrderCode,
                                                curEntryBatchCode,
                                                curBatchCode,
                                                curItemCode,
                                                curPartName,
                                                curPartId,
                                                InscriptionCode,
                                                "tblHistory1",
                                                "tblHistory2",
                                                "tblHistory3",
                                                ref lPart,
                                                ref lCurrent,
                                                ref tbComment,
                                                ref tbLaserInscription,
                                                ref lHistory1,
                                                ref lHistory2,
                                                ref lHistory3,
                                                ref pbShape,
                                                ref pbItemPicture,
                                                ref lMeasures,
                                                isNewItem);
                rbGrade.Checked = true;

                string sItemCode = GraderLib.GetCorrectFullCodeString(curOrderCode, curEntryBatchCode, curBatchCode, curItemCode);
                lNewItemCode.Text = sItemCode;
                lNewBatchCode.Text = lNewItemCode.Text.Substring(0, lNewItemCode.Text.Length - 3);

                lItemCode.Text = GraderLib.GetFullCodeStringWithDots(sNext);
                lBatchCode.Text = lItemCode.Text.Substring(0, lItemCode.Text.Length - 3);

                lOldItemCode.Text = GraderLib.GetFullCodeStringWithDots(sOldNumber);
                lOldBatchCode.Text = lOldItemCode.Text.Substring(0, lOldItemCode.Text.Length - 3);
                //lBatchCode.Text = curOrderCode+"."+curEntryBatchCode+"."+curBatchCode;
                //lItemCode.Text = curOrderCode+"."+curEntryBatchCode+"."+curBatchCode+"."+GraderLib.CorrectItemCode(dsBatchSet, curItemCode);
            }
            catch (Exception eEx)
            {
				lBatchCode.Text = "Order#.Batch#";
				lItemCode.Text = "Order#.Batch#.Item#";
				lNewBatchCode.Text = "";
                lNewItemCode.Text = "";
                lOldItemCode.Text = "";
                lOldBatchCode.Text = "";

                curOrderCode = 0;
                curEntryBatchCode = 0;
                curBatchCode = 0;
                curItemCode = 0;
                lWarnings.Text = sNext + ": " + eEx.Message;
                bFullAccess = false;
            }
            finally
            {
                //tbHiddenNextItem.Text = "";
                sNext = "";
            }
        }

        /// <summary>
        /// Updates batch information in the db
        /// </summary>
        public static void UpdateDbBatch(ref DataSet dsBatchSet,
                                            ref Label lPart,
                                            ref Label lCurrent,
                                            ref Label lHistory1,
                                            ref Label lHistory2,
                                            ref Label lHistory3,
                                            ref TextBox tbItemsDone,
                                            ref TextBox tbItemsNotDone,
                                            ref RadioButton rbNextItem,
                                            ref PictureBox pbShape,
                                            ref PictureBox pbItemPicture,
                                            int FormType,
                                            ref TextBox tbComment,
                                            ref TextBox tbLaserInscription)
        {
            int iOrderCode;
            int iBatchCode;
            int iItemCode;
            //int iPartId=0;
            string[] sTmp;  
			Regex rexItemCodes = new Regex(@"\d{5}.\d{5}.\d{3}\.\d{2}");
			Regex rexItemCodes1 = new Regex(@"\d{6}.\d{6}.\d{3}\.\d{2}");
			Regex rexItemCodes2 = new Regex(@"\d{7}.\d{7}.\d{3}\.\d{2}");

			if (rexItemCodes.IsMatch(tbItemsDone.Text))
            {
                MatchCollection mcItemCodes = rexItemCodes.Matches(tbItemsDone.Text);
                foreach (Match mItemCode in mcItemCodes)
                {
                    sTmp = mItemCode.Value.Split('.');
                    iOrderCode = Convert.ToInt32(sTmp[0]);
                    iBatchCode = Convert.ToInt32(sTmp[2]);
                    iItemCode = Convert.ToInt32(sTmp[3]);
                }
            }

            if (rexItemCodes1.IsMatch(tbItemsDone.Text))
            {
                MatchCollection mcItemCodes1 = rexItemCodes1.Matches(tbItemsDone.Text);
                foreach (Match mItemCode in mcItemCodes1)
                {
                    sTmp = mItemCode.Value.Split('.');
                    iOrderCode = Convert.ToInt32(sTmp[0]);
                    iBatchCode = Convert.ToInt32(sTmp[2]);
                    iItemCode = Convert.ToInt32(sTmp[3]);
                }
            }
			if (rexItemCodes2.IsMatch(tbItemsDone.Text))
			{
				MatchCollection mcItemCodes1 = rexItemCodes2.Matches(tbItemsDone.Text);
				foreach (Match mItemCode in mcItemCodes1)
				{
					sTmp = mItemCode.Value.Split('.');
					iOrderCode = Convert.ToInt32(sTmp[0]);
					iBatchCode = Convert.ToInt32(sTmp[2]);
					iItemCode = Convert.ToInt32(sTmp[3]);
				}
			}

			switch (FormType)
            {
                case GraderLib.Codes.Measure:
                    Service.UpdateMeasureBatchInfo(dsBatchSet);
                    break;

                case GraderLib.Codes.Color:
                    Service.UpdateColorBatchInfo(dsBatchSet);
                    break;

                case GraderLib.Codes.Clarity:
                    Service.UpdateClarityBatchInfo(dsBatchSet);
                    break;
            }

            tbComment.Text = "";
            tbLaserInscription.Text = "";
            tbItemsDone.Text = "";
            tbItemsNotDone.Text = "";
            lHistory1.Text = "";
            lHistory2.Text = "";
            lHistory3.Text = "";
            lPart.Text = "";
            lCurrent.Text = "";
            dsBatchSet = null;
            rbNextItem.Checked = true;
            throw new Exception("Batch was worked up. Enter next batch item code, please");
        }

        public static void UpdateBatch(ref DataSet dsBatchSet, int FormType, string ItemDoneText)//  int iOrderCode, int iBatchCode, int iItemCode, int iPartId)
        {
            return;
            int iOrderCode;
            int iBatchCode;
            int iItemCode;
            int iPartId = 0;
            if (FormType == GraderLib.Codes.Measure)
            {
                string[] sTmp;
                System.Text.RegularExpressions.Regex rexItemCodes = new System.Text.RegularExpressions.Regex("[0-9]{5}.[0-9]{5}.[0-9]{3}.[0-9]{2}");
                System.Text.RegularExpressions.Regex rexItemCodes1 = new System.Text.RegularExpressions.Regex("[0-9]{6}.[0-9]{6}.[0-9]{3}.[0-9]{2}");

                if (rexItemCodes.IsMatch(ItemDoneText))
                {
                    System.Text.RegularExpressions.MatchCollection mcItemCodes = rexItemCodes.Matches(ItemDoneText);
                    foreach (System.Text.RegularExpressions.Match mItemCode in mcItemCodes)
                    {
                        sTmp = mItemCode.Value.Split('.');
                        iOrderCode = Convert.ToInt32(sTmp[0]);
                        iBatchCode = Convert.ToInt32(sTmp[2]);
                        iItemCode = Convert.ToInt32(sTmp[3]);
                        DataRow[] drItems = dsBatchSet.Tables["tblItems"].Select("OrderCode = '" + iOrderCode + "' and BatchCode = '" + iBatchCode + "' and ItemCode = '" + iItemCode + "'");
                        foreach (DataRow drItem in drItems)
                        {
                            iItemCode = Convert.ToInt32(drItem["ItemCode"]);
                            CheckForData(dsBatchSet, FormType, iOrderCode, iBatchCode, iItemCode, iPartId, false);
                        }
                    }
                }
                if (rexItemCodes1.IsMatch(ItemDoneText))
                {
                    System.Text.RegularExpressions.MatchCollection mcItemCodes1 = rexItemCodes1.Matches(ItemDoneText);
                    foreach (System.Text.RegularExpressions.Match mItemCode in mcItemCodes1)
                    {
                        sTmp = mItemCode.Value.Split('.');
                        iOrderCode = Convert.ToInt32(sTmp[0]);
                        iBatchCode = Convert.ToInt32(sTmp[2]);
                        iItemCode = Convert.ToInt32(sTmp[3]);
                        DataRow[] drItems = dsBatchSet.Tables["tblItems"].Select("OrderCode = '" + iOrderCode + "' and BatchCode = '" + iBatchCode + "' and ItemCode = '" + iItemCode + "'");
                        foreach (DataRow drItem in drItems)
                        {
                            iItemCode = Convert.ToInt32(drItem["ItemCode"]);
                            CheckForData(dsBatchSet, FormType, iOrderCode, iBatchCode, iItemCode, iPartId, false);
                        }
                    }
                }
            }
        }
    }


}
