using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.Controls;

namespace WebUI.Models.Helpers
{
    public static class ControlExtensions
    {
        public static HtmlString CtrlButton(this HtmlHelper html,
            string viewName,
            string id,
            string label,
            string onClickFunction = "",
            string buttonType = "primary")
        {
            var ctrl = new CtrlButtonModel()
            {
                Id = id,
                Label = label,
                ViewName = viewName,
                Type = buttonType,
                FunctionName = onClickFunction,
            };

            return new HtmlString(ctrl.GetHtml());

        }

        public static HtmlString CtrlInput(this HtmlHelper html,
            string id, string type,
            string label, string placeHolder = "",
            string columnDataName = "")
        {
            var ctrl = new CtrlInputModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlTable(this HtmlHelper html, string viewName, string id, string title,
            string columnsTitle, string ColumnsDataName, string onSelectFunction)
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = onSelectFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }

    }
}