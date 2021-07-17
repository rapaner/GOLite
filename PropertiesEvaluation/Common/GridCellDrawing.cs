using DevExpress.XtraGrid.Helpers;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Drawing;

namespace GOLite.Common
{
    /// <summary>
    /// Отрисовка границ ячеек
    /// </summary>
    public static class GridCellDrawing
    {
        public static void DrawCellBorder(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            Brush brush = Brushes.Black;
            //e.Cache.FillRectangle(brush, new Rectangle(e.Bounds.X - 1,      e.Bounds.Y - 1,         e.Bounds.Width + 2,     2));  // верх
            e.Cache.FillRectangle(brush, new Rectangle(e.Bounds.Right - 1,  e.Bounds.Y - 1,         2,                      e.Bounds.Height + 2));    //  правая
            //e.Cache.FillRectangle(brush, new Rectangle(e.Bounds.X - 1,      e.Bounds.Bottom - 1,    e.Bounds.Width + 2,     2));  // нижняя
            //e.Cache.FillRectangle(brush, new Rectangle(e.Bounds.X - 1,      e.Bounds.Y - 1,         2,                      e.Bounds.Height + 2));  // левая
        }

        public static void DoDefaultDrawCell(GridView view, RowCellCustomDrawEventArgs e)
        {
            e.Appearance.FillRectangle(e.Cache, e.Bounds);
            ((IViewController)view.GridControl).EditorHelper.DrawCellEdit(new GridViewDrawArgs(e.Cache, (view.GetViewInfo() as GridViewInfo), e.Bounds), (e.Cell as GridCellInfo).Editor, (e.Cell as GridCellInfo).ViewInfo, e.Appearance, (e.Cell as GridCellInfo).CellValueRect.Location);
        }
    }
}