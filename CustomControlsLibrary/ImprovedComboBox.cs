using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CustomControlsLibrary
{
    public class ImprovedComboBox : ComboBox
    {
        private int _originalWidth = 0;
        protected override void OnCreateControl()
        {
            _originalWidth = DropDownWidth;
            base.OnCreateControl();
        }
        protected override void OnDropDown(EventArgs e)
        {
            int suggestedWidth = SuggestedDropDownWidth();
            if(suggestedWidth > _originalWidth) DropDownWidth = suggestedWidth;
            base.OnDropDown(e);
        }

        private int SuggestedDropDownWidth()
        {
            int widestStringInPixels = 0;
            foreach (object obj in Items)
            {
                string toCheck;
                PropertyInfo pinfo;
                Type objectType = obj.GetType();
                if (DisplayMember.CompareTo("") == 0)
                {
                    toCheck = obj.ToString();
                }
                else
                {
                    pinfo = objectType.GetProperty(DisplayMember);
                    toCheck = pinfo.GetValue(obj, null).ToString();
                }
                if (TextRenderer.MeasureText(toCheck, Font).Width > widestStringInPixels)
                    widestStringInPixels = TextRenderer.MeasureText(toCheck, Font).Width;
            }
            return widestStringInPixels + 15;
        }
    }
}
