using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DauThau.Class
{
    class FormHelper
    {
        /// <summary>
        /// Định nghĩa khởi tạo thuộc tính của lookUpEdit
        /// </summary>
        /// <param name="lue"></param>
        public static void LookUpEdit_Init(LookUpEdit lue)
        {
            //init Appearance
            lue.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            lue.Properties.Appearance.Options.UseFont = true;

            //init AppearanceDropDown
            lue.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F);
            lue.Properties.AppearanceDropDown.Options.UseFont = true;

            //init height
            lue.Properties.DropDownItemHeight = 25;
            lue.Properties.DropDownRows = 10;

            //auto popup columns
            lue.Properties.BestFit();
            int width = 0;
            foreach (LookUpColumnInfo column in lue.Properties.Columns)
                width += column.Width;
            lue.Properties.PopupWidth = width;
        }
    }
}
